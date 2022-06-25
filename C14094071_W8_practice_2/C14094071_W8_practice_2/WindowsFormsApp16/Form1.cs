using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp16
{
    public partial class Form1 : Form
    {
        public static int p1_role = 1;
        public static int p2_role = 1;
        public static Label label3 = new Label();
        public static Label label4 = new Label();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p2_role = 1;
            label3.Text = "P2:戰士";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p2_role = 2;
            label3.Text = "P2:法師";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            p2_role = 3;
            label3.Text = "P2:弓箭手";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            p1_role = 1;
            label4.Text = "P1:戰士";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            p1_role = 2;
            label4.Text = "P1:法師";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            p1_role = 3;
            label4.Text = "P1:弓箭手";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Hide();
            label3.Size = label1.Size;
            label3.Location = label1.Location;
            label2.Hide();
            label4.Size = label2.Size;
            label4.Location = label2.Location;
            label3.Text = "P2:戰士";
            label4.Text = "P1:戰士";
            this.Controls.Add(label3);
            this.Controls.Add(label4);
        }
    }
   
}
