using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TCP_Client
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public delegate void TextEventHandler(string text);

        public event TextEventHandler WriteTextEvent;

        public void received2(string str)

        {

            this.textBox2.Text = str;

            textBox2.Invalidate();

        }




    }
}
