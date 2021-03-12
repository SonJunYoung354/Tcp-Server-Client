namespace TCP_Client
{
    partial class Form3
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
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.NameBox = new MetroFramework.Controls.MetroTextBox();
            this.AgeBox = new MetroFramework.Controls.MetroTextBox();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(647, 44);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(105, 49);
            this.metroButton1.TabIndex = 0;
            this.metroButton1.Text = "metroButton1";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // NameBox
            // 
            // 
            // 
            // 
            this.NameBox.CustomButton.Image = null;
            this.NameBox.CustomButton.Location = new System.Drawing.Point(164, 1);
            this.NameBox.CustomButton.Name = "";
            this.NameBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.NameBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.NameBox.CustomButton.TabIndex = 1;
            this.NameBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.NameBox.CustomButton.UseSelectable = true;
            this.NameBox.CustomButton.Visible = false;
            this.NameBox.Lines = new string[] {
        "metroTextBox1"};
            this.NameBox.Location = new System.Drawing.Point(202, 273);
            this.NameBox.MaxLength = 32767;
            this.NameBox.Name = "NameBox";
            this.NameBox.PasswordChar = '\0';
            this.NameBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.NameBox.SelectedText = "";
            this.NameBox.SelectionLength = 0;
            this.NameBox.SelectionStart = 0;
            this.NameBox.ShortcutsEnabled = true;
            this.NameBox.Size = new System.Drawing.Size(186, 23);
            this.NameBox.TabIndex = 1;
            this.NameBox.Text = "metroTextBox1";
            this.NameBox.UseSelectable = true;
            this.NameBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.NameBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // AgeBox
            // 
            // 
            // 
            // 
            this.AgeBox.CustomButton.Image = null;
            this.AgeBox.CustomButton.Location = new System.Drawing.Point(164, 1);
            this.AgeBox.CustomButton.Name = "";
            this.AgeBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.AgeBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.AgeBox.CustomButton.TabIndex = 1;
            this.AgeBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.AgeBox.CustomButton.UseSelectable = true;
            this.AgeBox.CustomButton.Visible = false;
            this.AgeBox.Lines = new string[] {
        "metroTextBox1"};
            this.AgeBox.Location = new System.Drawing.Point(202, 349);
            this.AgeBox.MaxLength = 32767;
            this.AgeBox.Name = "AgeBox";
            this.AgeBox.PasswordChar = '\0';
            this.AgeBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.AgeBox.SelectedText = "";
            this.AgeBox.SelectionLength = 0;
            this.AgeBox.SelectionStart = 0;
            this.AgeBox.ShortcutsEnabled = true;
            this.AgeBox.Size = new System.Drawing.Size(186, 23);
            this.AgeBox.TabIndex = 1;
            this.AgeBox.Text = "metroTextBox1";
            this.AgeBox.UseSelectable = true;
            this.AgeBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.AgeBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(452, 254);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(169, 85);
            this.metroButton2.TabIndex = 2;
            this.metroButton2.Text = "metroButton2";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.AgeBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.metroButton1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroTextBox NameBox;
        private MetroFramework.Controls.MetroTextBox AgeBox;
        private MetroFramework.Controls.MetroButton metroButton2;
    }
}