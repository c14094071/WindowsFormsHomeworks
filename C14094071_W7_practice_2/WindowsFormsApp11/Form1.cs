using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {
        public static int type = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                type = 1;
            }
            if (radioButton2.Checked == true)
            {
                type = 2;
            }
            if (radioButton3.Checked == true)
            {
                type = 3;
            }
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
