using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.Core
{
    public class Machine
    {
        public int ID;
        public string MachineName;
        public string FolderPath;

        public Machine()
        {

        }

        public Machine(int id, string name, string path)
        {
            ID = id;
            MachineName = name;
            FolderPath = path;
        }

        public int GetID()
        {
            return ID;
        }

        public void SetID(int val)
        {
            ID = val;
        }

        public void SetID(string val)
        {
            ID = int.Parse(val);
        }

        public override string ToString()
        {
            return $"[Name: {MachineName}, Path: {FolderPath}, ID: {ID}]";
        }

    }
}
