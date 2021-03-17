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
            this.NameBox = new MetroFramework.Controls.MetroTextBox();
            this.PwBox = new MetroFramework.Controls.MetroTextBox();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.IDBox = new MetroFramework.Controls.MetroTextBox();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.SuspendLayout();
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
        "ID"};
            this.NameBox.Location = new System.Drawing.Point(209, 129);
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
            this.NameBox.Text = "ID";
            this.NameBox.UseSelectable = true;
            this.NameBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.NameBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // PwBox
            // 
            // 
            // 
            // 
            this.PwBox.CustomButton.Image = null;
            this.PwBox.CustomButton.Location = new System.Drawing.Point(164, 1);
            this.PwBox.CustomButton.Name = "";
            this.PwBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.PwBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.PwBox.CustomButton.TabIndex = 1;
            this.PwBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.PwBox.CustomButton.UseSelectable = true;
            this.PwBox.CustomButton.Visible = false;
            this.PwBox.Lines = new string[] {
        "Pw"};
            this.PwBox.Location = new System.Drawing.Point(209, 200);
            this.PwBox.MaxLength = 32767;
            this.PwBox.Name = "PwBox";
            this.PwBox.PasswordChar = '\0';
            this.PwBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PwBox.SelectedText = "";
            this.PwBox.SelectionLength = 0;
            this.PwBox.SelectionStart = 0;
            this.PwBox.ShortcutsEnabled = true;
            this.PwBox.Size = new System.Drawing.Size(186, 23);
            this.PwBox.TabIndex = 1;
            this.PwBox.Text = "Pw";
            this.PwBox.UseSelectable = true;
            this.PwBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.PwBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(441, 170);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(169, 85);
            this.metroButton2.TabIndex = 2;
            this.metroButton2.Text = "가입";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // IDBox
            // 
            // 
            // 
            // 
            this.IDBox.CustomButton.Image = null;
            this.IDBox.CustomButton.Location = new System.Drawing.Point(164, 1);
            this.IDBox.CustomButton.Name = "";
            this.IDBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.IDBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.IDBox.CustomButton.TabIndex = 1;
            this.IDBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.IDBox.CustomButton.UseSelectable = true;
            this.IDBox.CustomButton.Visible = false;
            this.IDBox.Lines = new string[] {
        "Name"};
            this.IDBox.Location = new System.Drawing.Point(209, 256);
            this.IDBox.MaxLength = 32767;
            this.IDBox.Name = "IDBox";
            this.IDBox.PasswordChar = '\0';
            this.IDBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.IDBox.SelectedText = "";
            this.IDBox.SelectionLength = 0;
            this.IDBox.SelectionStart = 0;
            this.IDBox.ShortcutsEnabled = true;
            this.IDBox.Size = new System.Drawing.Size(186, 23);
            this.IDBox.TabIndex = 1;
            this.IDBox.Text = "Name";
            this.IDBox.UseSelectable = true;
            this.IDBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.IDBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.Location = new System.Drawing.Point(209, 158);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(71, 15);
            this.metroCheckBox1.TabIndex = 4;
            this.metroCheckBox1.Text = "중복검사";
            this.metroCheckBox1.UseSelectable = true;
            this.metroCheckBox1.CheckedChanged += new System.EventHandler(this.metroCheckBox1_CheckedChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroCheckBox1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.IDBox);
            this.Controls.Add(this.PwBox);
            this.Controls.Add(this.NameBox);
            this.Name = "Form3";
            this.Text = "Form3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTextBox NameBox;
        private MetroFramework.Controls.MetroTextBox PwBox;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroTextBox IDBox;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
    }
}