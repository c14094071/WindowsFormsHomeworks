using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class Form2 : Form
    {
        public Button[,] btn;
        public int recent_num = 0;
        Random rd = new Random();
        public int score = 0;
        public double sec = 3;
        public bool cal = true;
        public int[,] arr =
        {
            {0,0,0,0 },
            {0,0,0,0 },
            {0,0,0,0 },
            {0,0,0,0 },
            {0,0,0,0 },
            {0,0,0,0 }
        };
        public Form2()
        {
            InitializeComponent();
            this.Show();
            
        }

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {

            
            switch (e.KeyChar)
            {
                case 'q':
                    sec = 3;
                    for (int i = 5; i >=0; i--)
                    {
                        if (arr[i, 0] == 0)
                        {
                            arr[i, 0] = recent_num;
                            break;
                        }
                    }
                    Calculation();
                    Show_map();
                    Rand();
                    Check_map(arr);
                    break;
                case 'w':
                    sec = 3;
                    for (int i = 5; i >= 0; i--)
                    {
                        if (arr[i, 1] == 0)
                        {
                            arr[i, 1] = recent_num;
                            break;
                        }
                    }
                    Calculation();
                    Show_map();
                    Rand();
                    Check_map(arr);
                    break;
                case 'e':
                    sec = 3;
                    for (int i = 5; i >= 0; i--)
                    {
                        if (arr[i, 2] == 0)
                        {
                            arr[i, 2] = recent_num;
                            break;
                        }
                    }
                    Calculation();
                    Show_map();
                    Rand();
                    Check_map(arr);
                    break;
                case 'r':
                    sec = 3;
                    for (int i = 5; i >= 0; i--)
                    {
                        if (arr[i, 3] == 0)
                        {
                            arr[i, 3] = recent_num;
                            break;
                        }
                    }
                    Calculation();
                    Show_map();
                    Rand();
                    Check_map(arr);
                    break;
                case 'a':
                    if (Form1.normal == false)
                    {
                        recent_num = 2;
                        label4.Text = recent_num.ToString();
                    }
                    break;
                case 's':
                    if (Form1.normal == false)
                    {
                        recent_num = 4;
                        label4.Text = recent_num.ToString();
                    }
                    break;
                case 'd':
                    if (Form1.normal == false)
                    {
                        recent_num = 8;
                        label4.Text = recent_num.ToString();
                    }
                    break;



            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            if (Form1.normal == false)
            {
                label5.Hide();
                label6.Hide();

            }
            else
            {
                timer1.Interval = 1000;
                timer1.Start();
                
            }
            
            Rand();
            btn = new Button[6, 4];
            
            for(int i = 0; i < 6; i++)
            {
                for(int k=0;k<4; k++)
                {
                    btn[i,k] = new Button();
                    btn[i, k].Hide();
                    panel1.Controls.Add(btn[i, k]);
                    btn[i, k].Left = (panel1.Width / 4) * k;
                    btn[i, k].Top = (panel1.Height / 6) * i;
                    btn[i, k].Width = panel1.Width / 4;
                    btn[i, k].Height = panel1.Height / 6;
                    btn[i, k].Text = i.ToString() + "," + k.ToString();
                }
            }
            
            
        }
        public void Rand()
        {
            int rd_num = rd.Next(1, 99);
            if (rd_num <= 33)
            {
                recent_num = 2;
            }
            else if(rd_num>33 && rd_num<=66)
            {
                recent_num = 4;
            }
            else
            {
                recent_num = 8;
            }
            label4.Text = recent_num.ToString();
        }
        public void Show_map()
        {
            for(int i = 0; i < 6; i++)
            {
                for(int k = 0; k < 4; k++)
                {
                    btn[i, k].Text = arr[i, k].ToString();
                    if (btn[i, k].Text != "0")
                    {
                        btn[i, k].Show();
                    }
                    else
                    {
                        btn[i, k].Hide();
                    }
                }
            }
        }
        public void Calculation()
        {
            int[,] arr_copy =
            {
                {0,0,0,0 },
                {0,0,0,0 },
                {0,0,0,0 },
                {0,0,0,0 },
                {0,0,0,0 },
                {0,0,0,0 }
            };
            Copy(arr, arr_copy);
            cal = true;
            while (cal)
            {
                int y = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (arr_copy[i, 0].Equals(arr_copy[i + 1, 0]) && arr_copy[i, 0] != 0)
                    {
                        arr_copy[i + 1, 0] = arr_copy[i, 0] * 2;
                        arr_copy[i, 0] = 0;
                        y = 1;
                    }
                    if (arr_copy[i, 1].Equals(arr_copy[i + 1, 1]) && arr_copy[i, 1] != 0)
                    {
                        arr_copy[i + 1, 1] = arr_copy[i, 1] * 2;
                        arr_copy[i, 1] = 0;
                        y = 1;
                    }
                    if (arr_copy[i, 2].Equals(arr_copy[i + 1, 2]) && arr_copy[i, 2] != 0)
                    {
                        arr_copy[i + 1, 2] = arr_copy[i, 2] * 2;
                        arr_copy[i, 2] = 0;
                        y = 1;
                    }
                    if (arr_copy[i, 3].Equals(arr_copy[i + 1, 3]) && arr_copy[i, 3] != 0)
                    {
                        arr_copy[i + 1, 3] = arr_copy[i, 3] * 2;
                        arr_copy[i, 3] = 0;
                        y = 1;
                    }

                }
                for (int i = 5; i >= 0; i--)
                {
                    if (arr_copy[i, 0].Equals(arr_copy[i, 1]) && arr_copy[i, 0].Equals(arr_copy[i, 2]) && arr_copy[i, 0].Equals(arr_copy[i, 3]) && arr_copy[i, 0] != 0)
                    {
                        score = score + arr_copy[i, 0] * arr_copy[i, 0];
                        for (int k = i; k > 0; k--)
                        {
                            arr_copy[k, 0] = arr_copy[k - 1, 0];
                            arr_copy[k, 1] = arr_copy[k - 1, 1];
                            arr_copy[k, 2] = arr_copy[k - 1, 2];
                            arr_copy[k, 3] = arr_copy[k - 1, 3];
                        }
                        label3.Text = score.ToString();
                        y = 1;
                    }
                }
                if (y == 0)
                {
                    cal = false;
                }
            }
            
            
            
            Copy(arr_copy, arr);
        }
        public void Copy(int[,] ar,int[,] ar_copy)
        {
            for(int i = 0; i < 6; i++)
            {
                for(int k = 0; k < 4; k++)
                {
                    ar_copy[i, k] = ar[i, k];
                }
            }
        }
        public void Check_map(int[,]ar)
        {
            if(ar[0,0]!=0 || ar[0, 1] != 0 || ar[0, 2] != 0 || ar[0, 3] != 0)
            {
                if (Form1.normal == true)
                {
                    timer1.Stop();
                }
                MessageBox.Show("遊戲結束"+"\n"+"你的分數:"+score.ToString());
                
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = sec.ToString();
            sec = sec - 1;
            if (sec == 0)
            {
                for (int i = 5; i >= 0; i--)
                {
                    if (arr[i, 1] == 0)
                    {
                        arr[i, 1] = recent_num;
                        break;
                    }
                }
                Calculation();
                Show_map();
                Rand();
                Check_map(arr);
                sec = 3;
            }
        }
    }
}
