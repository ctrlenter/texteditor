namespace TextEditor
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Copy settings");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("External Application");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("CNC");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.panelMain = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnSaveAndExit = new System.Windows.Forms.Button();
            this.btnCancelAndExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.Location = new System.Drawing.Point(195, 12);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(330, 473);
            this.panelMain.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Indent = 15;
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "nodeGeneral";
            treeNode1.Text = "General";
            treeNode2.Name = "nodeCopy";
            treeNode2.Text = "Copy settings";
            treeNode3.Name = "ExternalApplication";
            treeNode3.Text = "External Application";
            treeNode4.Name = "CNC";
            treeNode4.Text = "CNC";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.treeView1.Size = new System.Drawing.Size(177, 473);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // btnSaveAndExit
            // 
            this.btnSaveAndExit.Location = new System.Drawing.Point(283, 491);
            this.btnSaveAndExit.Name = "btnSaveAndExit";
            this.btnSaveAndExit.Size = new System.Drawing.Size(118, 23);
            this.btnSaveAndExit.TabIndex = 2;
            this.btnSaveAndExit.Text = "Save and exit";
            this.btnSaveAndExit.UseVisualStyleBackColor = true;
            this.btnSaveAndExit.Click += new System.EventHandler(this.btnSaveAndExit_Click);
            // 
            // btnCancelAndExit
            // 
            this.btnCancelAndExit.Location = new System.Drawing.Point(407, 491);
            this.btnCancelAndExit.Name = "btnCancelAndExit";
            this.btnCancelAndExit.Size = new System.Drawing.Size(118, 23);
            this.btnCancelAndExit.TabIndex = 3;
            this.btnCancelAndExit.Text = "Cancel and Exit";
            this.btnCancelAndExit.UseVisualStyleBackColor = true;
            this.btnCancelAndExit.Click += new System.EventHandler(this.btnCancelAndExit_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 526);
            this.Controls.Add(this.btnCancelAndExit);
            this.Controls.Add(this.btnSaveAndExit);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnSaveAndExit;
        private System.Windows.Forms.Button btnCancelAndExit;
    }
}