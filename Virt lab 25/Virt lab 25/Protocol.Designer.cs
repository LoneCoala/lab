using System.ComponentModel;

namespace Virt_lab_25
{
    partial class Protocol
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.exportProtocol = new System.Windows.Forms.Button();
            this.importProtocol = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // exportProtocol
            // 
            this.exportProtocol.Location = new System.Drawing.Point(40, 375);
            this.exportProtocol.Name = "exportProtocol";
            this.exportProtocol.Size = new System.Drawing.Size(350, 63);
            this.exportProtocol.TabIndex = 0;
            this.exportProtocol.Text = "Экспортировать протокол";
            this.exportProtocol.UseVisualStyleBackColor = true;
            this.exportProtocol.Click += new System.EventHandler(this.exportProtocol_Click);
            // 
            // importProtocol
            // 
            this.importProtocol.Location = new System.Drawing.Point(422, 375);
            this.importProtocol.Name = "importProtocol";
            this.importProtocol.Size = new System.Drawing.Size(350, 63);
            this.importProtocol.TabIndex = 1;
            this.importProtocol.Text = "Импортировать протокол";
            this.importProtocol.UseVisualStyleBackColor = true;
            this.importProtocol.Click += new System.EventHandler(this.importProtocol_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(34, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(369, 98);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Protocol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.importProtocol);
            this.Controls.Add(this.exportProtocol);
            this.Name = "Protocol";
            this.Text = "Protocol";
            this.Load += new System.EventHandler(this.Protocol_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.OpenFileDialog openFileDialog1;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Button exportProtocol;
        private System.Windows.Forms.Button importProtocol;

        #endregion
    }
}