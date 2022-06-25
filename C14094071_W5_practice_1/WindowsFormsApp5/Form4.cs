using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Decry_Form : Form
    {
        Decryption dec = new Decryption();

        public Decry_Form()
        {
            InitializeComponent();
        }
      

        private void button6_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("1");
            Decryption.decry_input = textBox2.Text;
            dec.transfor();
            textBox1.Text = Decryption.decry_output;
            Sub_Form.h_f.Dec_Record();
            Decryption.decry_output = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Sub_Form.h_f.Visible = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form5.s_f.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Sub_Form.e_f.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
