
namespace Virt_lab_25
{
    partial class Register
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
            this.enterRegister = new System.Windows.Forms.Button();
            this.closeRegister = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxGroup = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.Label();
            this.group = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // enterRegister
            // 
            this.enterRegister.Location = new System.Drawing.Point(40, 154);
            this.enterRegister.Name = "enterRegister";
            this.enterRegister.Size = new System.Drawing.Size(75, 23);
            this.enterRegister.TabIndex = 0;
            this.enterRegister.Text = "Ввод";
            this.enterRegister.UseVisualStyleBackColor = true;
            this.enterRegister.Click += new System.EventHandler(this.enterRegister_Click);
            // 
            // closeRegister
            // 
            this.closeRegister.Location = new System.Drawing.Point(157, 154);
            this.closeRegister.Name = "closeRegister";
            this.closeRegister.Size = new System.Drawing.Size(75, 23);
            this.closeRegister.TabIndex = 1;
            this.closeRegister.Text = "Выход";
            this.closeRegister.UseVisualStyleBackColor = true;
            this.closeRegister.Click += new System.EventHandler(this.closeRegister_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(106, 27);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 2;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // textBoxGroup
            // 
            this.textBoxGroup.Location = new System.Drawing.Point(106, 53);
            this.textBoxGroup.Name = "textBoxGroup";
            this.textBoxGroup.Size = new System.Drawing.Size(100, 20);
            this.textBoxGroup.TabIndex = 3;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(13, 34);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(87, 13);
            this.name.TabIndex = 4;
            this.name.Text = "Имя и фамилия";
            // 
            // group
            // 
            this.group.AutoSize = true;
            this.group.Location = new System.Drawing.Point(58, 56);
            this.group.Name = "group";
            this.group.Size = new System.Drawing.Size(42, 13);
            this.group.TabIndex = 5;
            this.group.Text = "Группа";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(46, 98);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(69, 17);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "30-40 см";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(137, 98);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(69, 17);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.Text = "40-50 см";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // Register
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(265, 191);
            this.ControlBox = false;
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.group);
            this.Controls.Add(this.name);
            this.Controls.Add(this.textBoxGroup);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.closeRegister);
            this.Controls.Add(this.enterRegister);
            this.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.MinimumSize = new System.Drawing.Size(263, 223);
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Определение ускорения свободного падения";
            this.Load += new System.EventHandler(this.Register_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enterRegister;
        private System.Windows.Forms.Button closeRegister;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxGroup;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label group;
        public System.Windows.Forms.RadioButton radioButton1;
        public System.Windows.Forms.RadioButton radioButton2;
    }
}