using System.Collections.Generic;
using Nebula.SDK.Compiler.Objects;

namespace Nebula.SDK.Compiler.Abstracts
{
    /// <summary>
    /// This object represents a class constructor for a given language
    /// </summary>
    public class AbstractConstructor : RootObject
    {
        public List<AbstractVariableDefinition> Arguments { get; set; }

        public List<string> Body { get; set; }

        protected AbstractConstructor()
        {
            Arguments = new List<AbstractVariableDefinition>();
            Body = new List<string>();
        }
    }
}