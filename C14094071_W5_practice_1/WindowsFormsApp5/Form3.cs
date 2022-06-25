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
    public partial class Encry_Form : Form
    {
        Encryption enc = new Encryption();

        public Encry_Form()
        {
            InitializeComponent();
            this.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Encryption.encry_input = textBox2.Text;
            Console.WriteLine(Encryption.encry_input);
            enc.transfor();
            textBox1.Text = Encryption.encry_output;

            Sub_Form.h_f.Enc_Record();
 
            Encryption.encry_output = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            this.Visible = false;
            Sub_Form.d_f.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Sub_Form.h_f.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form5.s_f.Visible = true;
        }
    }
}
