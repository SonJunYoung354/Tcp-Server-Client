namespace TCP_Client
{
    partial class Login
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.AgeBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtPW = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(667, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(667, 345);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(200, 289);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(198, 21);
            this.NameBox.TabIndex = 2;
            // 
            // AgeBox
            // 
            this.AgeBox.Location = new System.Drawing.Point(202, 363);
            this.AgeBox.Name = "AgeBox";
            this.AgeBox.Size = new System.Drawing.Size(196, 21);
            this.AgeBox.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(529, 103);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 47);
            this.button3.TabIndex = 4;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(191, 83);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(225, 21);
            this.txtID.TabIndex = 5;
            // 
            // txtPW
            // 
            this.txtPW.Location = new System.Drawing.Point(191, 143);
            this.txtPW.Name = "txtPW";
            this.txtPW.Size = new System.Drawing.Size(225, 21);
            this.txtPW.TabIndex = 5;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(667, 289);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtPW);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.AgeBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox AgeBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtPW;
        private System.Windows.Forms.Button button4;
    }
}