using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;
using TextEditor.Core.XML;

namespace TextEditor.Core
{


    public partial class CopyToSettingView : UserControl
    {

        public const string FileName = "";

        public List<Machine> machines = new List<Machine>();

        public SettingsForm SettingsForm;


        public CopyToSettingView(SettingsForm settings)
        {
            SettingsForm = settings;
            InitializeComponent();
            Load += CopyToSettingView_Load;

        }

        private void CopyToSettingView_Load(object sender, EventArgs e)
        {
            //TODO: implement loading of the different machines. possibly create my own class for storing this data since it just says "Item1","Item2" and "Item3" in the tuple
            machines = Utils.LoadMachines();
            DataTable table = ConvertListToDataTable(machines);
            dataGridView1.DataSource = table;
            foreach (DataGridViewColumn elem in dataGridView1.Columns)
            {
                elem.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        public void RefreshPresetList()
        {
            //Beep boop boop
            SettingsForm.mainForm.rcbPresets.DropDownItems.Clear();
            for(var i = 0; i < machines.Count; i++)
            {
                SettingsForm.mainForm.rcbPresets.DropDownItems.Add(new RibbonButton(machines[i].MachineName));
            }
        }

        private DataTable ConvertListToDataTable(List<Machine> machines)
        {
            DataTable table = new DataTable();

            var machineName = table.Columns.Add("Preset Name");
            var path = table.Columns.Add("Path");

            for (int i = 0; i < machines.Count; i++)
            {
                var row = table.NewRow();
                row["Preset Name"] = machines[i].MachineName;
                row["Path"] = machines[i].FolderPath;
                table.Rows.Add(row);
            }

            return table;
        }

        public void SaveMachines()
        {

            var xml = XMLSerializer.MachineListToXMLString(machines);
            Utils.WriteText(Utils.machinesFile, xml);
            SelfUpdate();
        }

        private void SelfUpdate()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ConvertListToDataTable(machines);
        }

        public bool AddItem(Machine item)
        {
            if(!machines.Exists(i => i.MachineName == item.MachineName ) )
            {
                item.ID = machines.Count + 1;
                machines.Add(item);
                return true;
            }
            else
            {
                console.error ( "An error occured when adding machine item" );
                return false;
            }
        }
        

        private void btnNew_Click(object sender, EventArgs e)
        {
            new AddCopyPreset(this).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewCell item in this.dataGridView1.SelectedCells)
            {
                if (item.RowIndex < 0) continue;
                console.log(item.RowIndex);
                machines.RemoveAt(item.RowIndex);
                this.dataGridView1.Rows.RemoveAt(item.RowIndex);
                SaveMachines();
                RefreshPresetList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
