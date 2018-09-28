using Nebula.Compiler.Abstracts;
using Nebula.Models;
using Nebula.Parser;
using System.Collections.Generic;
using System.Linq;

namespace Nebula.Compiler.Objects.Csharp
{
    public class CsharpCompiler : AbstractCompiler
    {
        /// <summary>
        /// The output of the compiler is a collection of OutputFile objects that contain the
        /// structure to be rendered
        /// </summary>
        /// <param name="rootNode"></param>
        public CsharpCompiler(Project project, ProjectNode rootNode, TemplateMeta templateData)
            : base(project, rootNode, templateData)
        {
            var entityNamespace = new AbstractNamespace { 
                Name = project.Name + "." + templateData.EntityLocation,
                Imports = new List<string> {
                    "System",
                    "System.Collections.Generic"
                }
            };
            var clientNamespace = new AbstractNamespace {
                Name = project.Name + "." + templateData.ClientLocation,
                Imports = new List<string> {
                    "System",
                    "System.Collections.Generic",
                    "RestSharp",
                    "RestSharp.Authenticators",
                    $"{project.Name}.{templateData.EntityLocation}"
                }
            };
            
            var entityClasses = GetClassesByType<EntityNode, CsharpEntityClass>(entityNamespace, this);
            var clientClasses = GetClassesByType<ApiNode, CsharpClientClass>(clientNamespace, this);

            OutputFiles.AddRange(entityClasses.Select(c => new CsharpOutputFile(c, templateData)));
            OutputFiles.AddRange(clientClasses.Select(c => new CsharpOutputFile(c, templateData)));
        }
    }
}