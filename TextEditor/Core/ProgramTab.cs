using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.Core
{
    public class ProgramPanel
    {
        public List<PanelElement> Items;
        public string text;
        public string panelName;

        public ProgramPanel()
        {
            Items = new List<PanelElement>();
        }

        public void Add(string path, string text)
        {
            PanelElement elem = new PanelElement();
            elem.path = path;
            elem.text = text;
            Items.Add(elem);
        }

        public void add(PanelElement elem)
        {
            if (elem == null)
                throw new ArgumentNullException("program element");
            Items.Add(elem);
        }
    }
    
    public class PanelElement
    {
        public string path;
        public string text;

        public PanelElement(string path,string text)
        {
            this.path = path;
            this.text = text;
        }

        public PanelElement()
        {
            //Empty stuff xd
            path = "";
            text = "";
        }

        public override string ToString()
        {
            return $"Path: {path}\nText: {text}";
        }

    }
}
