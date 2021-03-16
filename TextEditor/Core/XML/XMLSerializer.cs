using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TextEditor.Core.XML
{
    class XMLSerializer
    {

        public static string path;

        private static XMLSerializer instance;

        public static XMLSerializer Instance {
            get
            {
                if (instance == null)
                    instance = new XMLSerializer();
                return instance;
            }
        }

        private XMLSerializer()
        {
            path = Path.Combine(Application.StartupPath, "configs", "machineDefs.xml");
        }



        public static string PanelListToXML(List<ProgramPanel> panels)
        {
            string xml = "";

            XDocument doc = new XDocument();

            var mainElem = new XElement("panels");


            foreach (var elem in panels)
            {
                var name = elem.text;
                var tabElem = new XElement("panel");
                tabElem.SetAttributeValue("text", name);
                foreach (var tabItem in elem.Items)
                {
                    var xElem = new XElement("item");
                    xElem.SetAttributeValue("text", tabItem.text);
                    xElem.SetValue(tabItem.path);
                    tabElem.Add(xElem);
                }
                mainElem.Add(tabElem);

            }

            xml = mainElem.ToString(SaveOptions.None);

            return xml;
        }

        public static List<ProgramPanel> LoadTabsFromXml(string file)
        {
            var list = new List<ProgramPanel>();

            Logger.Log("Loading XML document...");
            var doc = XElement.Load(file);
            Logger.Log("Loaded XML Document!");

            var tabElems = doc.Elements("panel");

            foreach (var tab in tabElems)
            {
                var tabElem = new ProgramPanel();

                if (tab.Attribute("text") != null)
                    tabElem.text = tab.Attribute("text").Value;

                var items = tab.Elements("item");

                foreach (var item in items)
                {
                    var tabItem = new PanelElement();

                    if (item.Attribute("text") != null)
                        tabItem.text = item.Attribute("text").Value;


                    tabItem.path = item.Value;

                    tabElem.add(tabItem);

                }
                list.Add(tabElem);
            }

            return list;
        }

        public static List<Machine> LoadMachinesFromFile(string file)
        {

            var list = new List<Machine>();

            try
            {
                var doc = XElement.Load(file);

                if (!doc.IsEmpty)
                {
                    var elems = doc.Elements("Machine");

                    foreach (var elem in elems)
                    {
                        var machine = new Machine();
                        if (elem.Element("MachineName") != null)
                            machine.MachineName = elem.Element("MachineName").Value;

                        if (elem.Element("Path") != null)
                            machine.FolderPath = elem.Element("Path").Value;

                        if (elem.Element("ID") != null)
                            machine.SetID(elem.Element("ID").Value);

                        list.Add(machine);

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occured when parsing \"machines.xml\"\n" + e.Message);
            }


            return list;
        }

        public static string MachineListToXMLString(List<Machine> machines)
        {
            string xml = "";

            XDocument doc = new XDocument();

            var mainElem = new XElement("Machines");

            List<Machine> AddedMachines = new List<Machine>();

            foreach (var mElem in machines)
            {
                var name = mElem.MachineName;
                var path = mElem.FolderPath;
                var id = mElem.GetID();

                if (AddedMachines.SingleOrDefault(x => x.GetID() == id) == null)
                {
                    var elem = new XElement("Machine");

                    elem.SetElementValue("MachineName", name);
                    elem.SetElementValue("Path", path);
                    elem.SetElementValue("ID", id);

                    mainElem.Add(elem);
                    AddedMachines.Add(mElem);
                }
                else
                {
                    //We hit a duplicate. We dont want to add that.
                    console.log("Duplicate hit with id " + id);
                    continue;
                }

            }

            xml = mainElem.ToString(SaveOptions.None);

            return xml;
        }

        public static List<MachineDef> LoadMachineDefinitions(string file)
        {

            var list = new List<MachineDef>();

            try
            {
                var xDoc = XDocument.Load(file);

                if (xDoc.Element("Machines") != null)
                {
                    var machinesElem = xDoc.Element("Machines");
                    var machs = machinesElem.Elements("Machine");

                    foreach(var elem in machs)
                    {
                        var machDef = new MachineDef();

                        string name = "", oprRegex = "", tcRegex = "";

                        if (elem.Element("Name") != null)
                            name = elem.Element("Name").Value;

                        if (elem.Element("OperationRegex") != null)
                            oprRegex = elem.Element("OperationRegex").Value;

                        if (elem.Element("ToolCallRegex") != null)
                            tcRegex = elem.Element("ToolCallRegex").Value;

                        machDef.Name = name;
                        machDef.OperationRegex = oprRegex;
                        machDef.ToolCallRegex = tcRegex;

                        list.Add(machDef);

                    }
                }
            }
            catch (Exception)
            {

            }

            return list;
        }

        public static string ConvertMachineDefinitionsToString(List<MachineDef> machineDefs)
        {
            var str = "";



            var xDoc = new XDocument();
            var mainElem = new XElement("Machines");

            for (var i = 0; i < machineDefs.Count(); i++)
            {
                var machineElem = new XElement("Machine");

                if (machineDefs[i].Name == "Auto"
                    || machineDefs[i].Name == "ISO"
                    || machineDefs[i].Name == "Heidenhain"
                    || machineDefs[i].Name == "Siemens")
                {
                    continue;
                }

                var nameElem = new XElement("Name");
                nameElem.SetValue(machineDefs[i].Name);

                var oprRegexElem = new XElement("OperationRegex");
                oprRegexElem.SetValue(machineDefs[i].OperationRegex);

                var tcRegexElem = new XElement("ToolCallRegex");
                tcRegexElem.SetValue(machineDefs[i].ToolCallRegex);

                machineElem.Add(nameElem);
                machineElem.Add(oprRegexElem);
                machineElem.Add(tcRegexElem);

                mainElem.Add(machineElem);

            }

            xDoc.Add(mainElem);

            str = xDoc.ToString(SaveOptions.None);

            return str;
        }

    }
}
