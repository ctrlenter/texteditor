namespace TextEditor.Core
{
    partial class CNCView
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
            this.cbMachines = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddMachine = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.tbMachineName = new System.Windows.Forms.TextBox();
            this.tbOprRegex = new System.Windows.Forms.TextBox();
            this.tbTcRegex = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdateMachine = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbMachines
            // 
            this.cbMachines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMachines.FormattingEnabled = true;
            this.cbMachines.Location = new System.Drawing.Point(3, 59);
            this.cbMachines.Name = "cbMachines";
            this.cbMachines.Size = new System.Drawing.Size(121, 21);
            this.cbMachines.TabIndex = 0;
            this.cbMachines.SelectedIndexChanged += new System.EventHandler(this.CbMachines_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Valid machines";
            // 
            // btnAddMachine
            // 
            this.btnAddMachine.Location = new System.Drawing.Point(130, 57);
            this.btnAddMachine.Name = "btnAddMachine";
            this.btnAddMachine.Size = new System.Drawing.Size(82, 23);
            this.btnAddMachine.TabIndex = 2;
            this.btnAddMachine.Text = "Add machine";
            this.btnAddMachine.UseVisualStyleBackColor = true;
            this.btnAddMachine.Click += new System.EventHandler(this.BtnAddMachine_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(218, 57);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(82, 23);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Remove machine";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // tbMachineName
            // 
            this.tbMachineName.Location = new System.Drawing.Point(3, 35);
            this.tbMachineName.Name = "tbMachineName";
            this.tbMachineName.Size = new System.Drawing.Size(206, 20);
            this.tbMachineName.TabIndex = 5;
            // 
            // tbOprRegex
            // 
            this.tbOprRegex.Location = new System.Drawing.Point(3, 73);
            this.tbOprRegex.Name = "tbOprRegex";
            this.tbOprRegex.Size = new System.Drawing.Size(206, 20);
            this.tbOprRegex.TabIndex = 6;
            // 
            // tbTcRegex
            // 
            this.tbTcRegex.Location = new System.Drawing.Point(3, 114);
            this.tbTcRegex.Name = "tbTcRegex";
            this.tbTcRegex.Size = new System.Drawing.Size(206, 20);
            this.tbTcRegex.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Operation Regex";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tool Call Regex";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Name";
            // 
            // btnUpdateMachine
            // 
            this.btnUpdateMachine.Location = new System.Drawing.Point(3, 162);
            this.btnUpdateMachine.Name = "btnUpdateMachine";
            this.btnUpdateMachine.Size = new System.Drawing.Size(82, 23);
            this.btnUpdateMachine.TabIndex = 11;
            this.btnUpdateMachine.Text = "Update";
            this.btnUpdateMachine.UseVisualStyleBackColor = true;
            this.btnUpdateMachine.Click += new System.EventHandler(this.BtnUpdateMachine_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbMachineName);
            this.panel1.Controls.Add(this.btnUpdateMachine);
            this.panel1.Controls.Add(this.tbOprRegex);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbTcRegex);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(6, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 192);
            this.panel1.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Update machine";
            // 
            // CNCView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAddMachine);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbMachines);
            this.Name = "CNCView";
            this.Size = new System.Drawing.Size(552, 474);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbMachines;
        private System.Windows.Forms.Button btnAddMachine;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdateMachine;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox tbMachineName;
        public System.Windows.Forms.TextBox tbOprRegex;
        public System.Windows.Forms.TextBox tbTcRegex;
    }
}
