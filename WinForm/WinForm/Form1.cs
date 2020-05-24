using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Form1
{
    #region Windows Form Designer generated code
    public partial class Form1
    {
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            // 
            // button1
            // 
            this.button1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Location = new System.Drawing.Point(32, 40);
            this.button1.Name = "button1";
            this.button1.TabIndex = 0;
            this.button1.Click += new EventHandler(Button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = null;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.Text = "pictureBox1";
            this.pictureBox1.Location = new System.Drawing.Point(8, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(928, 592);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox1.DropDownWidth = 121;
            this.comboBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBox1.ItemHeight = 15;
            this.comboBox1.Text = "comboBox1";
            this.comboBox1.Location = new System.Drawing.Point(128, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(951, 693);
            this.Text = "Form1";
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
        }
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
    #endregion
    public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
        private void Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button Clicked!");
        }
    }
}
