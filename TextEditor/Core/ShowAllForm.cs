using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor.Core
{
    public partial class ShowAllForm : Form
    {

        public Form1 Parent;
        public List<LineDef> LineDefs = new List<LineDef>();
        public class LineDef
        {
            public int iLine;
            public string strContent;
            public string Token;

            public LineDef(int line, string content, string regexExecuted)
            {
                iLine = line;
                strContent = content;
                Token = Regex.Match(strContent, regexExecuted).Value;
            }

            public override string ToString()
            {
                return $"Line {iLine + 1} ::: {strContent}";
            }
        }

        public ShowAllForm(Form1 parent)
        {
            InitializeComponent();
            Parent = parent;
            lbItems.MouseDoubleClick += this.LbItems_MouseDoubleClick;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void LbItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lbItems.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                var item = lbItems.Items[index] as LineDef;
                if (item != null)
                {
                    Parent.CurrentTextbox.Selection = new FastColoredTextBoxNS.Range(Parent.CurrentTextbox, item.iLine);
                    Parent.CurrentTextbox.DoSelectionVisible();
                }
            }
        }



        public void ShowForm(List<LineDef> Lines)
        {
            LineDefs = Lines;
            lbItems.DataSource = LineDefs;
            this.Show();
        }

        private void ShowAllForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        char[] ignoredChars = { ';', '(' };
        bool mode = true;

        private void ToggleCommentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = !mode;
            if (mode == false)
            {

                var AddList = new List<LineDef>();
                var RemoveList = new List<LineDef>();
                bool shouldAdd = true;
                for (var i = 0; i < LineDefs.Count; i++)
                {
                    var line = LineDefs[i];
                    var lineCopy = line.strContent;
                    var index = lineCopy.IndexOf(line.Token);
                    while (index >= 0)
                    {
                        char charAt = lineCopy.ElementAt(index);
                        if (charAt == '(' || charAt == ';' || charAt == '*')
                        {
                            console.log("Should have comment infront");
                            console.log("Line " + line.iLine);
                            shouldAdd = false;
                            break;
                        }
                        else
                        {
                            shouldAdd = true;
                        }
                        index--;
                    }
                    if (shouldAdd)
                    {
                        AddList.Add(line);
                    }
                }


                //AddList = AddList.GroupBy(r => r.iLine).Select(g => g.First()).ToList();

                //for (var i = 0; i < AddList.Count; i++)
                //{
                //    for (var j = 0; j < RemoveList.Count; j++)
                //    {
                //        if (AddList.Contains(RemoveList[j]))
                //        {
                //            AddList.Remove(RemoveList[j]);
                //        }
                //    }
                //}


                lbItems.DataSource = null;
                lbItems.DataSource = AddList;
                lbItems.Refresh();
            }
            else if (mode == true)
            {
                lbItems.DataSource = null;
                lbItems.DataSource = LineDefs;
                lbItems.Refresh();
            }


        }
    }
}
