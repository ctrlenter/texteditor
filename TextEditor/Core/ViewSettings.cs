using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextEditor.Properties;

namespace TextEditor.Core
{
    public partial class ViewSettings : UserControl
    {

        //@TODO: Implement my own config file. Settings.Default doesnt work. will do this over the weekend.

        public SettingsForm settings;

        public const string POS_CENTER = "Centered";
        public const string POS_LAST = "Sidste position";

        public ViewSettings(SettingsForm settingsForm)
        {
            InitializeComponent();
            this.settings = settingsForm;
            this.Load += this.ViewSettings_Load;
        }

        private void ViewSettings_Load(object sender, EventArgs e)
        {
            cbStartLocs.Items.Add(POS_CENTER);
            cbStartLocs.Items.Add(POS_LAST);
        }

        private void txWidth_TextChanged(object sender, EventArgs e)
        {
            settings.HasSaved = false;
        }

        private void txHeight_TextChanged(object sender, EventArgs e)
        {
            settings.HasSaved = false;
        }

        private void cbOnTop_CheckedChanged(object sender, EventArgs e)
        {
            settings.HasSaved = false;
        }

        private void cbNewInstance_CheckedChanged ( object sender, EventArgs e )
        {
            settings.HasSaved = false;
            
        }

        private void CbUseStartupSize_CheckedChanged(object sender, EventArgs e)
        {
            if(cbUseStartupSize.Checked == true)
            {
                tbStartupHeight.Enabled = true;
                tbStartupWidth.Enabled = true;
            }
            else
            {
                tbStartupHeight.Enabled = false;
                tbStartupWidth.Enabled = false;
            }
        }

        private void cbStartLocs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStartLocs.Items.Count == 0) return;

            Form1.Config["start_pos"] = $"{cbStartLocs.Items[cbStartLocs.SelectedIndex]}";
            Form1.Config["X"] = settings.mainForm.Location.X.ToString();
            Form1.Config["Y"] = settings.mainForm.Location.Y.ToString();
        }
    }
}
