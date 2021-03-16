using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.Core
{
    public class MachineDef
    {

        /// <summary>
        /// Name of the machine type
        /// </summary>
        public string Name;


        public string OperationRegex; // Can be custom
        public string ToolCallRegex; // Can be custom

        public const string traceRegex = "(@rotate_to_plane)|(@change_tool)|(@turn_change_tool)|(@start_of_job)|(@end_program)";

        public MachineDef()
        {

        }

        public MachineDef(string name)
        {
            Name = name;
        }

        public MachineDef(string name, string opRegex, string tcRegex)
        {
            this.Name = name;
            this.OperationRegex = opRegex;
            this.ToolCallRegex = tcRegex;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
