using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor.Testing
{
    public partial class TestingForm : Form
    {

        
        public TestingForm(string text = "")
        {
            InitializeComponent();

            string content = "";
            using (var reader = new StreamReader("bee movie.txt"))
            {
                content = reader.ReadToEnd();
            }

            fctb.Text = "";
            fctb.Text = content;

        }

        private void fastColoredTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Shift && e.KeyCode == Keys.F3)
            {

            }
        }
    }
}
