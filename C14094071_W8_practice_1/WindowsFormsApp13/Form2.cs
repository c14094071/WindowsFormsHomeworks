using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp13
{
    public partial class Form2 : Form
    {
        public static int pan_width, pan_height;
        public static int player1_grades = 0, player2_grades = 0;
        
        public static int turn=1,round =1;
        public static int[,] cards_nums;
        public static Label label1 = new Label();
        public static Label label5 = new Label();
        public static Label label6 = new Label();
        public static Label label7 = new Label();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(@"..\..\card.map");
            string cards1 = sr.ReadToEnd();
            cards1 = cards1.Replace("\r", string.Empty); //注意:檔案換行會在\n後面多此字元!!,\r是指換行並移到最前方
            String[] cards = cards1.Split(' ','\n');

            label4.Hide();
            set_label1();
            this.Controls.Add(label1);
            set_label5();
            this.Controls.Add(label5);
            set_label6();
            this.Controls.Add(label6);
            set_label7();
            this.Controls.Add(label7);

            Card.row = int.Parse(cards[0]);
            Card.col = int.Parse(cards[1]);
            cards_nums = new int[Card.row, Card.col];
            int h = 2;
            for (int i = 0; i < Card.row; i++)
            {
                for (int k = 0; k < Card.col; k++)
                {
                    cards_nums[i, k] = int.Parse(cards[h]);
                     
                    h++;
                }
                
            }


            pan_width = panel1.Width;
            pan_height = panel1.Height;
            
      
            
            Card cd = new Card();
            for(int i = 0; i < Card.row; i++)
            {
                for (int k = 0; k < Card.col; k++)
                {
                    panel1.Controls.Add(cd.btn[i,k]);
                    cd.btn[i, k].Text = cards_nums[i, k].ToString();
                }
            }
            
            
        }

        public void set_label1()
        {
            label1.Size = new Size(60, 18);
         
            label1.Location = new Point((int)label4.Location.X -50,(int)label4.Location.Y);

            label1.Text = "第1回合";
            
        }
        public void set_label5()
        {
            label5.Size = new Size(70, 18);

            label5.Location = new Point((int)label2.Location.X +30, (int)label2.Location.Y);
        
            label5.Text = "0分";

        }
        public void set_label6()
        {
            label6.Size = new Size(70, 18);

            label6.Location = new Point((int)label3.Location.X + 30, (int)label3.Location.Y);

            label6.Text = "0分";

        }
        public void set_label7()
        {
            label7.Size = new Size(70, 18);

            label7.Location = new Point((int)label4.Location.X+10, (int)label4.Location.Y);

            label7.Text = "輪到P1";

        }
        /*
        public System.Windows.Forms.Label Label1 //可在其他class透過Form2 f2 =new Form2();來引用
        {
            get {
                    return label1;
                }
            set
            {
                label1 = value;
            }
        }
        */

    }
    public class Card : Button
    {
        public static int row, col;
        public Button[,] btn; //不能用[][]，要用[,]
        public Timer timer_3s = new Timer();
        public Timer timer_2s = new Timer();
        public int sec_3 = 3, sec_2 = 2;
        public static int p1_card_x, p1_card_y,p2_card_x,p2_card_y;
        public int finish = 0;
        

        public Card()
        {
            btn = new Button[row, col];
            
            for (int i = 0; i < row;i++)
            {
                
                for (int k = 0; k < col; k++)
                {
                    
                    btn[i,k] = new Button();
                    btn[i,k].Left = k * (Form2.pan_width / col);
                    btn[i,k].Top = i * (Form2.pan_height / row);
                    btn[i, k].Width = Form2.pan_width / col;
                    btn[i, k].Height = Form2.pan_height / row;
                    btn[i, k].BackColor = Color.AliceBlue;
                    btn[i, k].Click += btn_click;
                    btn[i, k].Enabled = false;
                    
                }
                
            }
            timer_3s.Tick +=timer_3s_Tick; //要加.Tick
            timer_3s.Interval = 1000;
            timer_3s.Start();
            timer_2s.Tick += timer_2s_Tick;
        }
        private void timer_3s_Tick(object sender, EventArgs e)
        {
            sec_3 = sec_3 - 1;
            if (sec_3 == 0)
            {
                timer_3s.Stop();
                for (int i = 0; i < row; i++)
                {
                    for (int k = 0; k < col; k++)
                    {
                        btn[i, k].Enabled = true;
                        btn[i, k].BackColor = Color.Gray;
                        btn[i, k].Text = "";
                    }
                }
            }
        }
        private void timer_2s_Tick(object sender, EventArgs e)
        {
            sec_2 = sec_2 - 1;
            if (sec_2 == 0)
            {
                timer_2s.Stop();
                
                Tell_cards();
                for (int i = 0; i < row; i++)
                {

                    for (int k = 0; k < col; k++)
                    {

                        if(Form2.cards_nums[i,k] != -1)
                        {
                            btn[i, k].BackColor = Color.Gray;
                            btn[i, k].Enabled = true;
                        }
                        
                        

                    }

                }
                
             
            }
            
        }
        private void btn_click(object sender, EventArgs e)
        {
            Button cd_now = (Button)sender;  //將當下點選的按鈕轉成物件
            cd_now.BackColor = Color.AliceBlue;
            int k = cd_now.Left / (Form2.pan_width / col);
            int i = cd_now.Top / (Form2.pan_height / row);
            cd_now.Text = Form2.cards_nums[i, k].ToString();
            //Console.WriteLine("{0},{1}", k, i);
            if (Form2.round%2==1)
            {
                if (Form2.turn == 1)
                {
                    p1_card_x = k;
                    p1_card_y = i;
                    
                    Form2.label7.Text = "輪到P2";
                    Form2.turn++;
                    finish++;
                }
                else
                {
                    p2_card_x = k;
                    p2_card_y = i;

                    Form2.label7.Text = "輪到P2";
                    Form2.turn = 1;
                    finish++;
                }
                
            }
            else if (Form2.round%2==0)
            {
                if (Form2.turn == 1)
                {
                    p2_card_x = k;
                    p2_card_y = i;
                    Console.WriteLine("!!{0} {1}", p2_card_y, p2_card_x);
                    Form2.label7.Text = "輪到P1";
                    
                    Form2.turn++;
                    finish++;
                }
                else
                {
                    p1_card_x = k;
                    p1_card_y = i;

                    Form2.label7.Text = "輪到P1";
                    Form2.turn = 1;
                    finish++;
                }
                
                
            }
            
            if (finish == 2)
            {
        
                Form2.turn = Form2.turn % 2;
                
                Other_card_false();
                finish = 0;
                
                
            }
            
        }
        public void Other_card_false()
        {
            sec_2 = 2;
            
            timer_2s.Interval = 1000;
            
            for (int i = 0; i < row; i++)
            {
                for (int k = 0; k < col; k++)
                {
                    if ((i == p1_card_y && k == p1_card_x) || (i == p2_card_y && k == p2_card_x))
                    {
                        //Console.WriteLine("{0},{1}", p1_card_x, p1_card_y);
                        //Console.WriteLine("{0},{1}", p2_card_x, p2_card_y);
                        
                        continue;
                    }
                    btn[i, k].Enabled = false;
                    btn[i, k].BackColor = Color.Gray;
                    btn[i, k].Text = "";
                }
            }
            timer_2s.Start();
            
            
            

        }
        public void Tell_cards()
        {
            //p1是先手
            Console.WriteLine(Form2.round);
            Console.WriteLine("{0},{1}", p1_card_x, p1_card_y);
            Console.WriteLine("{0},{1}", p2_card_x, p2_card_y);
            if (Form2.round%2==1 && Form2.cards_nums[p1_card_y, p1_card_x] > Form2.cards_nums[p2_card_y, p2_card_x])
            {
                btn[p1_card_y, p1_card_x].Enabled = false;
                btn[p1_card_y, p1_card_x].BackColor = Color.Gray;
                btn[p1_card_y, p1_card_x].Text = "";
                btn[p2_card_y, p2_card_x].Enabled = false;
                btn[p2_card_y, p2_card_x].BackColor = Color.Gray;
                btn[p2_card_y, p2_card_x].Text = "";
                
            }
            else if (Form2.round%2==1&& Form2.cards_nums[p1_card_y, p1_card_x] < Form2.cards_nums[p2_card_y, p2_card_x])
            {
                Console.WriteLine("!!!!");
                Form2.player2_grades += Form2.cards_nums[p2_card_y, p2_card_x] - Form2.cards_nums[p1_card_y, p1_card_x];
                btn[p1_card_y, p1_card_x].Parent = null;
                Form2.cards_nums[p1_card_y, p1_card_x] = -1;
                btn[p2_card_y, p2_card_x].Parent = null;
                Form2.cards_nums[p2_card_y, p2_card_x] = -1;
                

            }//p2是先手
            else if (Form2.round%2==0 && Form2.cards_nums[p1_card_y, p1_card_x] < Form2.cards_nums[p2_card_y, p2_card_x])
            {
                Console.WriteLine("@@@");
                btn[p1_card_y, p1_card_x].Enabled = false;
                btn[p1_card_y, p1_card_x].BackColor = Color.Gray;
                btn[p1_card_y, p1_card_x].Text = "";
                btn[p2_card_y, p2_card_x].Enabled = false;
                btn[p2_card_y, p2_card_x].BackColor = Color.Gray;
                btn[p2_card_y, p2_card_x].Text = "";
               
            }
            else if (Form2.round%2==0 && Form2.cards_nums[p1_card_y, p1_card_x] > Form2.cards_nums[p2_card_y, p2_card_x])
            {
                Console.WriteLine(Form2.cards_nums[p1_card_y, p1_card_x]);
                Console.WriteLine(Form2.cards_nums[p2_card_y, p2_card_x]);
                Form2.player1_grades += Form2.cards_nums[p1_card_y, p1_card_x] - Form2.cards_nums[p2_card_y, p2_card_x];
                btn[p1_card_y, p1_card_x].Parent = null;
                Form2.cards_nums[p1_card_y, p1_card_x] = -1;
                btn[p2_card_y, p2_card_x].Parent = null;
                Form2.cards_nums[p2_card_y, p2_card_x] = -1;
                
            }
            int count = 0;
            for (int i = 0; i < row; i++)
            {
                for (int k = 0; k < col; k++)
                {
                    if (Form2.cards_nums[i, k] == -1)
                    {
                        count++;
                    }
                }
            }
            
            Form2.label5.Text = Form2.player2_grades.ToString()+"分";
            Form2.label6.Text = Form2.player1_grades.ToString()+"分";
            if (count > (row * col-1) / 2)
            {
                if (Form2.player1_grades > Form2.player2_grades)
                {
                    MessageBox.Show("P1勝利");
                }
                else if (Form2.player1_grades < Form2.player2_grades)
                {
                    MessageBox.Show("P2勝利");
                }
                else
                {
                    MessageBox.Show("平手");
                }
                Application.Exit();
            }
            Form2.round++;
            Form2.label1.Text = "第" + Form2.round.ToString() + "回合";
        }
        public void Show_Nums()
        {

        }
    }
}
