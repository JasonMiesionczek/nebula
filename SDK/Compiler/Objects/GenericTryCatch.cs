using System.Collections.Generic;

namespace Nebula.SDK.Compiler.Objects
{
    public class GenericTryCatch : RootObject
    {
        public List<string> Body { get; set; }

        public Dictionary<string, string> CatchExceptions { get; set; }

        public GenericTryCatch()
        {
            Body = new List<string>();
            CatchExceptions = new Dictionary<string, string>();
        }
    }
}