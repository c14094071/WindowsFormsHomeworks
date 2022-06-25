using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        int current;
       
        Font f;
        
        public TextFont1 tf = new TextFont1();
        public static FontStyle fs_1, fs_2;
        public Form1()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            current = 1;
            Show_pic();
            radioButton1.Checked = true;
            radioButton4.Checked = true;
        }
        public void Show_pic()
        {
            Image img = Image.FromFile(@"..\..\Practice2_picture\pic" + "_0"+current + ".png");
            
            pictureBox1.Image = img;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (current == 1)
            {
                current = 5;
            }
            else
            {
                current--;
            }
            Show_pic();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (current == 5)
            {
                current = 1;
            }
            else
            {
                current++;
            }
            Show_pic();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            f = new Font(tf.fm1, label5.Font.Size, label5.Font.Style);
            label5.Font = f;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

            label5.Text = richTextBox1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
            f = new Font(tf.fm2, label5.Font.Size, label5.Font.Style);
            label5.Font = f;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            
            f = new Font(tf.fm3, label5.Font.Size, label5.Font.Style);
            label5.Font = f;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
    
            label5.TextAlign = ContentAlignment.TopLeft;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
  
            label5.TextAlign = ContentAlignment.TopCenter;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
      
            label5.TextAlign = ContentAlignment.TopRight;
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
        
            label5.TextAlign = ContentAlignment.BottomLeft;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
          
            label5.TextAlign = ContentAlignment.BottomCenter;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
          
            label5.TextAlign = ContentAlignment.BottomRight;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tf.fontsize = int.Parse(textBox1.Text);
                if(tf.fontsize>32 || tf.fontsize < 1)
                {
                    tf.fontsize = 12;
                    
                }
   
                f = new Font(label5.Font.FontFamily, tf.fontsize, label5.Font.Style);
                label5.Font = f;
            }
            catch
            {
                tf.fontsize = 12;
                f = new Font(label5.Font.FontFamily, tf.fontsize, label5.Font.Style);
                label5.Font = f;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tf.Tell_it_bd_1(checkBox1.Checked);
            f = new Font(label5.Font.FontFamily, label5.Font.Size, fs_1 | fs_2);
            label5.Font = f;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
            tf.Tell_it_bd_2(checkBox2.Checked);
            f = new Font(label5.Font.FontFamily, label5.Font.Size, fs_1 | fs_2);
            label5.Font = f;
        }
    }
}
