namespace TextEditor.Core
{
    partial class ViewSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txWidth = new System.Windows.Forms.TextBox();
            this.lblWidth = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txHeight = new System.Windows.Forms.TextBox();
            this.cbOnTop = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbUseStartupSize = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbStartupHeight = new System.Windows.Forms.TextBox();
            this.tbStartupWidth = new System.Windows.Forms.TextBox();
            this.cbNewInstance = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbStartLocs = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txWidth
            // 
            this.txWidth.Location = new System.Drawing.Point(14, 30);
            this.txWidth.Name = "txWidth";
            this.txWidth.Size = new System.Drawing.Size(100, 20);
            this.txWidth.TabIndex = 0;
            this.txWidth.TextChanged += new System.EventHandler(this.txWidth_TextChanged);
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(11, 14);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(69, 13);
            this.lblWidth.TabIndex = 1;
            this.lblWidth.Text = "Current width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Current height";
            // 
            // txHeight
            // 
            this.txHeight.Location = new System.Drawing.Point(14, 69);
            this.txHeight.Name = "txHeight";
            this.txHeight.Size = new System.Drawing.Size(100, 20);
            this.txHeight.TabIndex = 2;
            this.txHeight.TextChanged += new System.EventHandler(this.txHeight_TextChanged);
            // 
            // cbOnTop
            // 
            this.cbOnTop.AutoSize = true;
            this.cbOnTop.Location = new System.Drawing.Point(33, 168);
            this.cbOnTop.Name = "cbOnTop";
            this.cbOnTop.Size = new System.Drawing.Size(109, 17);
            this.cbOnTop.TabIndex = 4;
            this.cbOnTop.Text = "Text editor on top";
            this.cbOnTop.UseVisualStyleBackColor = true;
            this.cbOnTop.CheckedChanged += new System.EventHandler(this.cbOnTop_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbUseStartupSize);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbStartupHeight);
            this.panel1.Controls.Add(this.tbStartupWidth);
            this.panel1.Controls.Add(this.lblWidth);
            this.panel1.Controls.Add(this.txWidth);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txHeight);
            this.panel1.Location = new System.Drawing.Point(19, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 122);
            this.panel1.TabIndex = 5;
            // 
            // cbUseStartupSize
            // 
            this.cbUseStartupSize.AutoSize = true;
            this.cbUseStartupSize.Location = new System.Drawing.Point(120, 95);
            this.cbUseStartupSize.Name = "cbUseStartupSize";
            this.cbUseStartupSize.Size = new System.Drawing.Size(109, 17);
            this.cbUseStartupSize.TabIndex = 6;
            this.cbUseStartupSize.Text = "Force startup size";
            this.cbUseStartupSize.UseVisualStyleBackColor = true;
            this.cbUseStartupSize.CheckedChanged += new System.EventHandler(this.CbUseStartupSize_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Startup height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Startup width";
            // 
            // tbStartupHeight
            // 
            this.tbStartupHeight.Location = new System.Drawing.Point(120, 69);
            this.tbStartupHeight.Name = "tbStartupHeight";
            this.tbStartupHeight.Size = new System.Drawing.Size(100, 20);
            this.tbStartupHeight.TabIndex = 7;
            // 
            // tbStartupWidth
            // 
            this.tbStartupWidth.Location = new System.Drawing.Point(120, 30);
            this.tbStartupWidth.Name = "tbStartupWidth";
            this.tbStartupWidth.Size = new System.Drawing.Size(100, 20);
            this.tbStartupWidth.TabIndex = 6;
            // 
            // cbNewInstance
            // 
            this.cbNewInstance.AutoSize = true;
            this.cbNewInstance.Location = new System.Drawing.Point(33, 191);
            this.cbNewInstance.Name = "cbNewInstance";
            this.cbNewInstance.Size = new System.Drawing.Size(149, 17);
            this.cbNewInstance.TabIndex = 5;
            this.cbNewInstance.Text = "New instance on file open";
            this.cbNewInstance.UseVisualStyleBackColor = true;
            this.cbNewInstance.CheckedChanged += new System.EventHandler(this.cbNewInstance_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Editor Visual Settings";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(19, 152);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 2);
            this.panel2.TabIndex = 6;
            // 
            // cbStartLocs
            // 
            this.cbStartLocs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStartLocs.FormattingEnabled = true;
            this.cbStartLocs.Location = new System.Drawing.Point(104, 214);
            this.cbStartLocs.Name = "cbStartLocs";
            this.cbStartLocs.Size = new System.Drawing.Size(121, 21);
            this.cbStartLocs.TabIndex = 7;
            this.cbStartLocs.SelectedIndexChanged += new System.EventHandler(this.cbStartLocs_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Start position";
            // 
            // ViewSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbStartLocs);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbNewInstance);
            this.Controls.Add(this.cbOnTop);
            this.Name = "ViewSettings";
            this.Size = new System.Drawing.Size(411, 472);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txWidth;
        public System.Windows.Forms.TextBox txHeight;
        public System.Windows.Forms.CheckBox cbOnTop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.CheckBox cbNewInstance;
        public System.Windows.Forms.TextBox tbStartupHeight;
        public System.Windows.Forms.TextBox tbStartupWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.CheckBox cbUseStartupSize;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbStartLocs;
        private System.Windows.Forms.Label label5;
    }
}
