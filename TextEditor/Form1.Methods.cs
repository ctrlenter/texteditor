using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextEditor.Core;
using TextEditor.Core.XML;

namespace TextEditor
{
    partial class Form1
    {

        public bool FirstTimeNewTab = false;

        private List<string> lDrivers = new List<string>();
        private List<string> lFolders = new List<string>();
        int prevTab = 0;

        public static Config Config { get; set; } = new Config();

        private SettingsForm settingsForm;

        public void Init()
        {
            //AddDrivesToDropDownList(rcbDrives);
            tFindDrives.Start();
            settingsForm = new SettingsForm(this);
            showAllForm = new ShowAllForm(this);
            AllowDrop = true;
            foreach (var str in settingsForm.Machines)
            {
                rcbCNC.DropDownItems.Add(new RibbonButton(str.Name));
            }
            rcbCNC.SelectedItem = rcbCNC.DropDownItems.First();
        }

        public void AddTab()
        {
            tabs.TabPages.Add(Utils.CreateTabPage(textContextMenu, this.fctb_MouseDown, Event_KeyDown, DragEnterEvent, DragDropEvent, 0));
            if (tabs.TabCount >= 1)
            {
                var tab = tabs.TabPages[0];
                if (tab != null)
                {
                    lblPath.Text = $"Path: {tab.Tag}";
                }
                else
                {
                    lblPath.Text = $"Path: ";
                }

            }
        }

        public void AddTab(string file)
        {
            tabs.TabPages.Add(Utils.CreateTabPageAndLoadFile(textContextMenu, fctb_MouseDown, Event_KeyDown, DragDropEvent, DragEnterEvent, file));
            if (tabs.TabCount >= 1)
                lblPath.Text = $"Path: {file}";
        }

        public static List<string> LoadDrives()
        {
            List<string> listToReturn = new List<string>();
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo i in drives)
            {
                if (i.DriveType != DriveType.CDRom)
                {
                    listToReturn.Add(i.Name);
                }
            }

            return listToReturn;
        }

        private List<string> LoadFolders(string path)
        {
            string[] folders = Directory.GetDirectories(path);
            List<string> foldersToAdd = new List<string>();
            foreach (string s in folders)
            {
                foldersToAdd.Add(s);
            }
            return foldersToAdd;
        }

        private string[] GetListOfFolders(string drive)
        {
            return Directory.GetDirectories(drive);
        }

    }
}
