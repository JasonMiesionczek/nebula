using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Nebula.Core.Parser;
using Nebula.SDK.Objects;
using Nebula.SDK.Util;
using Newtonsoft.Json;
using SharpPad;

namespace Nebula.Core.Generators
{
    public class EntityGenerator
    {
        private List<Entity> _newEntities;
        private IFileUtil _fileUtil;

        public EntityGenerator(IFileUtil fileUtil)
        {
            _newEntities = new List<Entity>();
            _fileUtil = fileUtil;
        }

        public void GenerateEntityFromJSON(Project p, string input)
        {
            if (_fileUtil.FileExists(input))
            {
                var stream = new InputStream(new FileInfo(input));
                var tokens = new Tokenizer(stream);
                var parser = new JsonParser(tokens);
                var root = parser.Parse();
                
                FindAndPrompt(root, null);
                WriteEntities(p);
            }
        }

        private void WriteEntities(Project project)
        {
            var outputFolder = Path.Combine(project.SourceDirectory, "models");
            foreach (var entity in _newEntities)
            {
                var outputFile = Path.Combine(outputFolder, entity.Name + ".neb");
                var output = RenderEntity(entity);
                _fileUtil.FileWriteAllLines(outputFile, output);
            }
        }

        private List<string> RenderEntity(Entity entity)
        {
            var output = new List<string>();
            output.Add($"entity {entity.Name} {{");
            var fields = new List<string>();
            foreach (var field in entity.Fields)
            {
                var name = field.Name.Replace("_", " ").Replace("-", " ").ToProperCase().ToCamelCase();
                fields.Add($"    {name}: {field.Type}");
            }
            output.Add(string.Join("," + Environment.NewLine, fields));
            output.Add("}");
            return output;
        }

        private string Prompt(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        private void FindAndPrompt(SDK.Objects.JsonObject obj, Entity parentEntity)
        {
            if (obj.IsObject)
            {
                var newEntity = new Entity();
                _newEntities.Add(newEntity);
                
                if (parentEntity == null)
                {
                    newEntity.Name = Prompt("Enter name for root entity: ");
                }
                else
                {
                    var name = Prompt($"Enter name of sub-object of {parentEntity.Name} and property {obj.Name}: ");
                    newEntity.Name = name;
                    parentEntity.Fields.Add(new EntityField() { Name = name, Type = name });
                }

                foreach (var child in obj.Children)
                {
                    FindAndPrompt(child, newEntity);
                }
            }

            if (obj.IsValue && parentEntity != null)
            {
                
                parentEntity.Fields.Add(new EntityField() { Name = obj.Name, Type = DetermineType(obj.Value)});
            }
        }

        private string DetermineType(dynamic value)
        {
            var t = value.GetType().ToString();
            t = t.Replace("System.", "").Replace("Int32", "integer");
            return t.ToLower();
        }
    }
}