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

    public partial class Form2 : Form
    {

        Random rnd = new Random();
        public int total_sec = 60;
        public static int row0_top = 400, row1_top = 400, row2_top = 400, row3_top = 400;
        public static int player_left = 0, player_top = 260;
        public static int born0 = 0, born1 = 0, born2 = 0, born3 = 0;
        public static int bul_top, bul, left = 0;
        public static Button_Enemy btn_ene_col0;
        public static Button_Enemy btn_ene_col1;
        public static Button_Enemy btn_ene_col2;
        public static Button_Enemy btn_ene_col3;
        public static Bullet bul_col0;
        public static Bullet bul_col1;
        public static Bullet bul_col2;
        public static Bullet bul_col3;
        public Timer cd = new Timer();
        public int cd1 = 0;
        public static int score = 0;
        
        public Form2()
        {
            InitializeComponent();


        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = total_sec.ToString();
            total_sec = total_sec - 1;
            Console.WriteLine(button1.Top);
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            label5.Text = score.ToString();
            if (Form1.type == 1)
            {
                button1.BackColor = Color.Blue;
                label4.Text = "水";
            }
            if (Form1.type == 2)
            {
                button1.BackColor = Color.Red;
                label4.Text = "火";
            }
            if (Form1.type == 3)
            {
                button1.BackColor = Color.Green;
                label4.Text = "木";
            }
            if (Form1.type == 1&&Form2.score<0)
            {
                timer2.Stop();

                MessageBox.Show("你枯竭了!" + "你的分數:0");
                
                Application.Exit();
            }
            if (Form1.type == 2 && Form2.score < 0)
            {
                timer2.Stop();
                MessageBox.Show("你被熄滅了!" + "你的分數:0");
                timer2.Stop();
                Application.Exit();
            }
            if (Form1.type == 3 && Form2.score < 0)
            {
                timer2.Stop();
                MessageBox.Show("你燒起來了!" + "你的分數:0");
                timer2.Stop();
                Application.Exit();
            }
            if (total_sec == 0)
            {
                timer2.Stop();
                timer1.Stop();
                MessageBox.Show("遊戲結束!" + "你的分數:"+score.ToString());
                timer2.Stop();
                Application.Exit();
            }

            if (born0 == 1)
            {
                int num = rnd.Next(1, 99);
                btn_ene_col0 = new Button_Enemy(0,num);
                panel1.Controls.Add(btn_ene_col0);
                born0 = 0;
            }
            if (born1 == 1)
            {
                int num = rnd.Next(1, 99);
                btn_ene_col1 = new Button_Enemy(50,num);
                panel1.Controls.Add(btn_ene_col1);
                born1 = 0;
            }
            if (born2 == 1)
            {
                int num = rnd.Next(1, 99);
                btn_ene_col2 = new Button_Enemy(100,num);
                panel1.Controls.Add(btn_ene_col2);
                born2 = 0;
            }
            if (born3 == 1)
            {
                int num = rnd.Next(1, 99);
                btn_ene_col3 = new Button_Enemy(150,num);
                panel1.Controls.Add(btn_ene_col3);
                born3 = 0;
            }
        }



        private void Form2_Load(object sender, EventArgs e)
        {
            
            cd.Tick += cd_Tick;
            cd.Interval = 1000;

            panel1.Size = new Size(190, 400);

            button1.Left = 0;
            button1.Top = 260;
            button1.Size = new Size(40, 40);


            timer1.Interval = 1000;
            timer2.Interval = 1;
            timer1.Start();
            timer2.Start();
            born0 = born1 = born2 = born3 = 1;
            if (Form1.type == 1)
            {
                button1.BackColor = Color.Blue;
            }
            if (Form1.type == 2)
            {
                button1.BackColor = Color.Red;

            }
            if (Form1.type == 3)
            {
                button1.BackColor = Color.Green;
            }
            this.KeyPreview = true;
        }
        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            Console.WriteLine(button1.Left);
            switch (e.KeyChar)
            {
                case 'a':
                    if (button1.Left != 0)
                    {
                        button1.Left = button1.Left - 50;
                        player_left = player_left - 50;
                    }

                    break;
                case 'd':
                    if (button1.Left != 150)
                    {
                        button1.Left = button1.Left + 50;
                        player_left = player_left + 50;
                    }

                    break;
                case 'w':
                    if(cd1 == 0)
                    {
                        if (button1.Left == 0)
                        {
                            bul_col0 = new Bullet(button1, Form1.type);
                            panel1.Controls.Add(bul_col0);
                            cd1 = 1;
                            cd.Start();
                            
                        }
                        if (button1.Left == 50)
                        {
                            bul_col1 = new Bullet(button1, Form1.type);
                            panel1.Controls.Add(bul_col1);
                            cd1 = 1;
                            cd.Start();
                        }
                        if (button1.Left == 100)
                        {
                            bul_col2 = new Bullet(button1, Form1.type);
                            panel1.Controls.Add(bul_col2);
                            cd1 = 1;
                            cd.Start();
                        }
                        if (button1.Left == 150)
                        {
                            bul_col3 = new Bullet(button1, Form1.type);
                            panel1.Controls.Add(bul_col3);
                            cd1 = 1;
                            cd.Start();
                        }
                    }
                    
                    break;
            }

        }
        private void cd_Tick(object sender, EventArgs e)
        {
            cd1 = cd1 - 1;
            cd.Stop();

        }

    }

        
    public class Button_Enemy : Button
    {
        public Timer timer2 = new Timer();
        Random rnd1 = new Random();
        public int type = 0;
        
        
        public Button_Enemy(int x,int num)
        {
           
            
            Console.WriteLine("KKKKK");
            
            Console.WriteLine(num);
            if (num <= 33)
            {
                this.timer2 = new Timer(); ;
                this.Text = "水";
                this.type = 1;
                this.BackColor = Color.Blue;
            }
            else if (num <= 66)
            {
                this.Text = "火";
                this.type = 2;
                this.BackColor = Color.Red;
            }
            else
            {
                this.Text = "木";
                this.type = 3;
                this.BackColor = Color.Green;
            }

            this.Left = x;
            this.Top = 0;
            this.Width = 40;
            this.Height = 40;
   
            this.timer2.Tick += timer2_Tick;
            this.timer2.Interval = 100;
            this.timer2.Start();
        }
        //overload
        Timer timer2_bul = new Timer();
        public Button_Enemy(Button player)
        {
            this.BackColor = Color.Blue;
            this.Left = player.Left+20;
            this.Top = player.Top;
            this.Width = 20;
            this.Height = 20;

            timer2_bul.Tick += timer2_bul_Tick;
            timer2_bul.Interval = 100;
            timer2.Start();
        }
        public void Enemy1_Move()
        {
            this.Top = this.Top + 10;
        }
        public void Enemy2_Move()
        {
            this.Top = this.Top + 20;
        }
        public void Enemy3_Move()
        {
            this.Top = this.Top + 30;
        }
        public void Wt_Bullet_Move()
        {
            this.Top = this.Top -10;

        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.type == 1)
            {
                this.Enemy1_Move();
            }
            if (this.type == 2)
            {
                this.Enemy2_Move();
            }
            if (this.type == 3)
            {
                this.Enemy3_Move();
            }

            
            if ((this.Top+40 ) >= 400 )
            {

                timer2.Stop();
                if (this.Left == 0)
                {


                    this.Parent = null;
                    Form2.born0 = 1;

                }
                if (this.Left == 50)
                {


                    this.Parent = null;
                    Form2.born1 = 1;

                }
                if (this.Left == 100)
                {


                    this.Parent = null;
                    Form2.born2 = 1;

                }
                if (this.Left == 150)
                {


                    this.Parent = null;
                    Form2.born3 = 1;

                }

            }
            if ((this.Top) >= Form2.player_top&& this.Top <= Form2.player_top+40 && this.Left == Form2.player_left && this.type != Form1.type)
            {

                timer2.Stop();
                if (this.Left == 0)
                {
                    if (Form1.type == 1 && this.type == 2)
                    {
                        this.Parent = null;
                        Form2.score = Form2.score + 5;
                        Form2.born0 = 1;
                        Form1.type = 2;

                    }
                    if (Form1.type == 2 && this.type == 3)
                    {
                        this.Parent = null;
                        Form2.score = Form2.score + 5;
                        Form2.born0 = 1;
                        Form1.type = 3;

                    }
                    if (Form1.type == 3 && this.type == 1)
                    {
                        this.Parent = null;
                        Form2.score = Form2.score + 5;
                        Form2.born0 = 1;
                        Form1.type = 1;

                    }
                    if (Form1.type == 2 && this.type == 1)
                    {
                        this.Parent = null;
                        Form2.score = Form2.score - 5;
                        Form2.born0 = 1;

                    }
                    if (Form1.type == 3 && this.type == 2)
                    {
                        this.Parent = null;
                        Form2.score = Form2.score - 5;
                        Form2.born0 = 1;

                    }
                    if (Form1.type == 1 && this.type == 3)
                    {
                        this.Parent = null;
                        Form2.score = Form2.score - 5;
                        Form2.born0 = 1;

                    }






                }
                if (this.Left == 50)
                {


                    if (Form1.type == 1 && this.type == 2)
                    {
                        this.Parent = null;
                        Form2.score = Form2.score + 5;
                        Form2.born1 = 1;
                        Form1.type = 2;

                    }
                    if (Form1.type == 2 && this.type == 3)
                    {
                        this.Parent = null;
                        Form2.score = Form2.score + 5;
                        Form2.born1 = 1;
                        Form1.type = 3;

                    }
                    if (Form1.type == 3 && this.type == 1)
                    {
                        this.Parent = null;
                        Form2.score = Form2.score + 5;
                        Form2.born1 = 1;
                        Form1.type = 1;

                    }
                    if (Form1.type == 2 && this.type == 1)
                    {
                        this.Parent = null;
                        Form2.score = Form2.score - 5;
                        Form2.born1 = 1;

                    }
                    if (Form1.type == 3 && this.type == 2)
                    {
                        this.Parent = null;
                        Form2.score = Form2.score - 5;
                        Form2.born1 = 1;

                    }
                    if (Form1.type == 1 && this.type == 3)
                    {
                        this.Parent = null;
                        Form2.score = Form2.score - 5;
                        Form2.born1 = 1;

                    }

                }
                if (this.Left == 100)
                {


                    if (Form1.type == 1 && this.type == 2)
                    {
                        this.Parent = null;
                        Form2.score = Form2.score + 5;
                        Form2.born2 = 1;
                        Form1.type = 2;

                    }
                    if (Form1.type == 2 && this.type == 3)
                    {
                        this.Parent = null;
                        Form2.score = Form2.score + 5;
                        Form2.born2 = 1;
                        Form1.type = 3;
                    }
                    if (Form1.type == 3 && this.type == 1)
                    {
                        this.Parent = null;
                        Form2.score = Form2.score + 5;
                        Form2.born2 = 1;
                        Form1.type = 1;
                    }
                    if (Form1.type == 2 && this.type == 1)
                    {
                        this.Parent = null;
                        Form2.score = Form2.score - 5;
                        Form2.born2 = 1;

                    }
                    if (Form1.type == 3 && this.type == 2)
                    {
                        this.Parent = null;
                        Form2.score = Form2.score - 5;
                        Form2.born2 = 1;

                    }
                    if (Form1.type == 1 && this.type == 3)
                    {
                        this.Parent = null;
                        Form2.score = Form2.score - 5;
                        Form2.born2 = 1;

                    }

                }
                if (this.Left == 150)
                {


                    if (Form1.type == 1 && this.type == 2)
                    {
                        this.Parent = null;
                        Form2.score = Form2.score + 5;
                        Form2.born3 = 1;
                        Form1.type = 2;

                    }
                    if (Form1.type == 2 && this.type == 3)
                    {
                        this.Parent = null;
                        Form2.score = Form2.score + 5;
                        Form2.born3 = 1;
                        Form1.type = 3;
                    }
                    if (Form1.type == 3 && this.type == 1)
                    {
                        this.Parent = null;
                        Form2.score = Form2.score + 5;
                        Form2.born3 = 1;
                        Form1.type = 1;

                    }
                    if (Form1.type == 2 && this.type == 1)
                    {
                        this.Parent = null;
                        Form2.score = Form2.score - 5;
                        Form2.born3 = 1;

                    }
                    if (Form1.type == 3 && this.type == 2)
                    {
                        this.Parent = null;
                        Form2.score = Form2.score - 5;
                        Form2.born3 = 1;

                    }
                    if (Form1.type == 1 && this.type == 3)
                    {
                        this.Parent = null;
                        Form2.score = Form2.score - 5;
                        Form2.born3 = 1;

                    }

                }

            }

        }
        private void timer2_bul_Tick(object sender, EventArgs e)
        {
            this.Wt_Bullet_Move();

        }
    }

    

    
    public class Bullet:Button
    {
        Timer timer2_bul = new Timer();
        int type = 0;
        public Bullet(Button player,int type1)
        {
            this.type = type1;
            if (this.type==1)
            {
    
                this.BackColor = Color.Blue;
            }
            else if (this.type == 2)
            {
              
                this.BackColor = Color.Red;
            }
            else
            {
         
                this.BackColor = Color.Green;
            }
            this.Left = player.Left + 10;
            this.Top = player.Top;
            this.Width = 20;
            this.Height = 20;

            timer2_bul.Tick += timer2_bul_Tick;
            timer2_bul.Interval = 100;
            timer2_bul.Start();
        }
        public void Bullet1_Move()
        {
            this.Top = this.Top - 10;
        }
        public void Bullet2_Move()
        {
            this.Top = this.Top - 20;
        }
        public void Bullet3_Move()
        {
            this.Top = this.Top - 30;
        }
        private void timer2_bul_Tick(object sender, EventArgs e)
        {
            if (type == 1)
            {
                this.Bullet1_Move();
            }
            if (type == 2)
            {
                this.Bullet2_Move();
            }
            if (type == 3)
            {
                this.Bullet3_Move();
            }
            if (this.Top == 0)
            {
                this.Parent = null;
            }
            
            if (this.Top >= Form2.btn_ene_col0.Top && this.Top <= Form2.btn_ene_col0.Top + 40 && this.Left-10 ==0)
            {
                if(this.type==1 && Form2.btn_ene_col0.type == 2)
                {
                    Form2.score = Form2.score + 2;
                }
                if (this.type == 2 && Form2.btn_ene_col0.type == 3)
                {
                    Form2.score = Form2.score + 2;
                }
                if (this.type == 3 && Form2.btn_ene_col0.type == 1)
                {
                    Form2.score = Form2.score + 2;
                }
                if (this.type == 2 && Form2.btn_ene_col0.type == 2)
                {
                    Form2.score = Form2.score - 2;
                }
                if (this.type == 3 && Form2.btn_ene_col0.type == 2)
                {
                    Form2.score = Form2.score - 2;
                }
                if (this.type == 1 && Form2.btn_ene_col0.type == 3)
                {
                    Form2.score = Form2.score - 2;
                }
                timer2_bul.Stop();
                this.Parent = null;
                Form2.btn_ene_col0.Parent = null;
                Form2.btn_ene_col0.timer2.Stop();
                Form2.born0 = 1;
            }

            if (this.Top >= Form2.btn_ene_col1.Top && this.Top <= Form2.btn_ene_col1.Top + 40&& this.Left-10 == 50)
            {
                if (this.type == 1 && Form2.btn_ene_col1.type == 2)
                {
                    Form2.score = Form2.score + 2;
                }
                if (this.type == 2 && Form2.btn_ene_col1.type == 3)
                {
                    Form2.score = Form2.score + 2;
                }
                if (this.type == 3 && Form2.btn_ene_col1.type == 1)
                {
                    Form2.score = Form2.score + 2;
                }
                if (this.type == 2 && Form2.btn_ene_col1.type == 2)
                {
                    Form2.score = Form2.score - 2;
                }
                if (this.type == 3 && Form2.btn_ene_col1.type == 2)
                {
                    Form2.score = Form2.score - 2;
                }
                if (this.type == 1 && Form2.btn_ene_col1.type == 3)
                {
                    Form2.score = Form2.score - 2;
                }
                timer2_bul.Stop();
                this.Parent = null;
                Form2.btn_ene_col1.Parent = null;
                Form2.btn_ene_col1.timer2.Stop();
                Form2.born1 = 1;

            }


            if (this.Top >= Form2.btn_ene_col2.Top && this.Top <= Form2.btn_ene_col2.Top + 40 && this.Left-10 == 100)
            {

                if (this.type == 1 && Form2.btn_ene_col2.type == 2)
                {
                    Form2.score = Form2.score + 2;
                }
                if (this.type == 2 && Form2.btn_ene_col2.type == 3)
                {
                    Form2.score = Form2.score + 2;
                }
                if (this.type == 3 && Form2.btn_ene_col2.type == 1)
                {
                    Form2.score = Form2.score + 2;
                }
                if (this.type == 2 && Form2.btn_ene_col2.type == 2)
                {
                    Form2.score = Form2.score - 2;
                }
                if (this.type == 3 && Form2.btn_ene_col2.type == 2)
                {
                    Form2.score = Form2.score - 2;
                }
                if (this.type == 1 && Form2.btn_ene_col2.type == 3)
                {
                    Form2.score = Form2.score - 2;
                }
                timer2_bul.Stop();
                this.Parent = null;
                Form2.btn_ene_col2.Parent = null;
                Form2.btn_ene_col2.timer2.Stop();
                Form2.born2 = 1;
            }

            if (this.Top >= Form2.btn_ene_col3.Top && this.Top <= Form2.btn_ene_col3.Top + 40 && this.Left-10 == 150)
            {

                if (this.type == 1 && Form2.btn_ene_col3.type == 2)
                {
                    Form2.score = Form2.score + 2;
                }
                if (this.type == 2 && Form2.btn_ene_col3.type == 3)
                {
                    Form2.score = Form2.score + 2;
                }
                if (this.type == 3 && Form2.btn_ene_col3.type == 1)
                {
                    Form2.score = Form2.score + 2;
                }
                if (this.type == 2 && Form2.btn_ene_col3.type == 2)
                {
                    Form2.score = Form2.score - 2;
                }
                if (this.type == 3 && Form2.btn_ene_col3.type == 2)
                {
                    Form2.score = Form2.score - 2;
                }
                if (this.type == 1 && Form2.btn_ene_col3.type == 3)
                {
                    Form2.score = Form2.score - 2;
                }
                timer2_bul.Stop();
                this.Parent = null;
                Form2.btn_ene_col3.Parent = null;
                Form2.btn_ene_col3.timer2.Stop();
                Form2.born3 = 1;
            }
            
        }
    }
    public class Rowrow : Form2
    {

    }
}
