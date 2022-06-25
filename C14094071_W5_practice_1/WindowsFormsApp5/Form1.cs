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
    public partial class Sub_Form : Form
    {
        Alphabet alp = new Alphabet();
        Substitution sub = new Substitution();
        public static int sho = 0;
        public static Encry_Form e_f = new Encry_Form();
        public static Decry_Form d_f = new Decry_Form();
        public static History_Form h_f = new History_Form();
        
        
        public Sub_Form()
        {
            this.Show();
            InitializeComponent();
            
            label3.Text = Alphabet.alpha_str;
            textBox1.Text = Substitution.subst_str;
            h_f.First_Sub_Record();

        }
        
        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("1");
            Substitution.subst_str = textBox1.Text;
            sub.sub_act_change();
            //Console.WriteLine(sub.subst_str);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            int x = 0;
            foreach(char value in Alphabet.alpha)
            {

                if (Substitution.subst_str.IndexOf(value)==-1){
                    label2.Text = "替換表不合法，請重新輸入";
                    x = 0;
                }
                else
                {
                    x = x + 1;
                }
                if (x == 52)
                {
                    h_f.Sub_Record();
                    label2.Text = "合法替換表";
                    
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Visible = false;
            h_f.Visible = true;
            Sub_Form.h_f.all_reocrd();
        }

        private void Sub_Form_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            e_f.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            d_f.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Alphabet();
            new Substitution();

            label3.Text = Alphabet.alpha_str;
            textBox1.Text = Substitution.subst_str;
        }
    }
}
