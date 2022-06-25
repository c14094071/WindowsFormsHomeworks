using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class Form2 : Form
    {
        public Label[,] label = new Label[10, 4];
       
        public static Timer timer1 = new Timer();
        public static Random rnd = new Random();
        
        public Form2()
        {
            InitializeComponent();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
            label1.Hide();
            
            new_labels();
            timer1.Interval = 500;
            timer1.Tick += Timer1_Tick;
            timer1.Start();
            
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine(trackBar1.Value);
            int n1 = rnd.Next(0,trackBar1.Value+2);
            Console.WriteLine("@@@{0}@@@", n1);
            shine(n1, 0);
            int n2 = rnd.Next(0,trackBar1.Value+2);
            shine(n2, 1);

            int n3 = rnd.Next(0,trackBar1.Value+2);
            shine(n3, 2);
            int n4 = rnd.Next(0,trackBar1.Value+2);
            shine(n4, 3);
            
        }
        public void shine(int n,int x)
        {
            
            for (int k = 1; k <= n; k++)
            {
                
                label[k-1, x].BackColor = Color.Blue;
            }
            for (int i = 9; i >=n; i--)
            {
                label[i, x].BackColor = Color.Transparent;
            }
        }

        
        public void new_labels()
        {
            
            
            for (int i = 0; i<10; i++)
            {
                for(int k = 0; k < 4; k++)
                {
                    label[i, k] = new Label();
                    panel1.Controls.Add(label[i, k]);
                    
                    label[i, k].Size = label1.Size;
                    label[i, k].Left = k * (label[0,0].Width+20);
                    label[i, k].Top = (9-i) * (label[0,0].Height+10);
                    
                    label[i, k].Text = i.ToString() + "," + k.ToString();
                    

                }
            }
        }
    

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
