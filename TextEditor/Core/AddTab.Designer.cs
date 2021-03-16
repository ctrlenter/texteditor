namespace TextEditor.Core
{
    partial class AddTab
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbItems = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOkay = new System.Windows.Forms.Button();
            this.btnAddPanel = new System.Windows.Forms.Button();
            this.btnRemPanel = new System.Windows.Forms.Button();
            this.tbItemName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(12, 25);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(136, 20);
            this.tbName.TabIndex = 1;
            // 
            // lbItems
            // 
            this.lbItems.FormattingEnabled = true;
            this.lbItems.Location = new System.Drawing.Point(12, 146);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(136, 95);
            this.lbItems.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(89, 289);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOkay
            // 
            this.btnOkay.Location = new System.Drawing.Point(12, 289);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(62, 23);
            this.btnOkay.TabIndex = 4;
            this.btnOkay.Text = "Okay";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // btnAddPanel
            // 
            this.btnAddPanel.Location = new System.Drawing.Point(12, 247);
            this.btnAddPanel.Name = "btnAddPanel";
            this.btnAddPanel.Size = new System.Drawing.Size(62, 38);
            this.btnAddPanel.TabIndex = 5;
            this.btnAddPanel.Text = "Add panel";
            this.btnAddPanel.UseVisualStyleBackColor = true;
            this.btnAddPanel.Click += new System.EventHandler(this.btnAddPanel_Click);
            // 
            // btnRemPanel
            // 
            this.btnRemPanel.Location = new System.Drawing.Point(89, 247);
            this.btnRemPanel.Name = "btnRemPanel";
            this.btnRemPanel.Size = new System.Drawing.Size(62, 38);
            this.btnRemPanel.TabIndex = 6;
            this.btnRemPanel.Text = "Remove Panel";
            this.btnRemPanel.UseVisualStyleBackColor = true;
            this.btnRemPanel.Click += new System.EventHandler(this.btnRemPanel_Click);
            // 
            // tbItemName
            // 
            this.tbItemName.Location = new System.Drawing.Point(33, 71);
            this.tbItemName.Name = "tbItemName";
            this.tbItemName.Size = new System.Drawing.Size(100, 20);
            this.tbItemName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Panel item name";
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(30, 99);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(80, 13);
            this.lblPath.TabIndex = 9;
            this.lblPath.Text = "Panel item path";
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(33, 115);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(77, 23);
            this.btnSelectPath.TabIndex = 10;
            this.btnSelectPath.Text = "Select path";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // AddTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 317);
            this.Controls.Add(this.btnSelectPath);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbItemName);
            this.Controls.Add(this.btnRemPanel);
            this.Controls.Add(this.btnAddPanel);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lbItems);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.Name = "AddTab";
            this.Text = "AddTab";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.ListBox lbItems;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.Button btnAddPanel;
        private System.Windows.Forms.Button btnRemPanel;
        private System.Windows.Forms.TextBox tbItemName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button btnSelectPath;
    }
}