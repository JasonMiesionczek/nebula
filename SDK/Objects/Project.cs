using System.Collections.Generic;
using Nebula.SDK.Util;
using Newtonsoft.Json;

namespace Nebula.SDK.Objects
{
    public class Project
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Company { get; set; }
        public string Version { get; set; }
        public string Manifest { get; set; }
        public Dictionary<string, string> Templates { get; set; }
        [JsonIgnore]
        public string SourceDirectory { get; set; }
        [JsonIgnore]
        public string TemplateDirectory { get; set; }
        [JsonIgnore]
        public string ProjectDirectory { get; set; }
        [JsonIgnore]
        public string OutputDirectory { get; set; }
        [JsonIgnore]
        public string ManifestDirectory { get; set; }

        public Project()
        {
            Templates = new Dictionary<string, string>();
        }

        public string GetProperName()
        {
            return Name.Replace("-", " ").Replace("_", " ").ToProperCase().ToPascalCase();
        }

    }
}