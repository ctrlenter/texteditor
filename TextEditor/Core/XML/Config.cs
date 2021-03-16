using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextEditor.Core.XML
{
    public class Config
    {

        public const string FileName = "config.xml";
        public static string Path;
        public static string DirectoryPath;

        private Dictionary<string, string> Elements = new Dictionary<string, string>();

        public int ElementCount {
            get
            {
                return Elements.Keys.Count();
            }
        }

        public string this[string key] {
            get
            {

                key = key.ToLower();
                
                if (Elements.ContainsKey(key))
                {
                    return Elements[key];
                }
                return "";
            }

            set
            {
                key = key.ToLower();

                if (!Elements.ContainsKey(key))
                {
                    Elements.Add(key.ToLower(), value);
                }
                Elements[key] = value;
                Save();
            }

        }

        public Config()
        {
            Path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Cadsys\\TextEditor\\", FileName);
            DirectoryPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Cadsys\\TextEditor\\");
            console.log(Path);
        }

        public void Init()
        {
            var xml = "";

            if (Directory.Exists(DirectoryPath))
            {
                using (var reader = new StreamReader(Path))
                {
                    xml = reader.ReadToEnd();
                }

                var doc = XDocument.Parse(xml);

                var mainElem = doc.Element("Config");

                var configElems = mainElem.Elements("ConfigElem");

                foreach (var elem in configElems)
                {
                    Add(elem.Attribute("id").Value.ToLower(), elem.Value);
                }
            }
        }

        public void Save()
        {
            if (Directory.Exists(DirectoryPath))
            {
                BaseSave();
            }
            else
            {
                Directory.CreateDirectory(DirectoryPath);
                BaseSave();
            }
        }

        private void BaseSave()
        {
            //TODO: Find out why it outputs non xml at the end of the config
            var xDoc = new XDocument();

            var mainElem = new XElement("Config");

            foreach (var elem in Elements)
            {
                var configElem = new XElement("ConfigElem");
                configElem.SetAttributeValue("id", elem.Key.ToLower());
                configElem.SetValue(elem.Value);
                mainElem.Add(configElem);
            }

            xDoc.Add(mainElem);

            Utils.WriteText(Path, xDoc.ToString(SaveOptions.None));

        }

        public void Add(string key, string val)
        {
            if (!Elements.ContainsKey(key.ToLower()))
                Elements.Add(key.ToLower(), val);
        }

        public bool HasElements(params string[] args)
        {
            bool res = false;
            for(var i = 0; i < args.Length; i++)
            {
                if (Elements.ContainsKey(args[i].ToLower())) res = true;
                else return false;
            }
            return res;
        }

        public bool HasElement(string elem)
        {
            return Elements.ContainsKey(elem.ToLower());
        }

    }
}
