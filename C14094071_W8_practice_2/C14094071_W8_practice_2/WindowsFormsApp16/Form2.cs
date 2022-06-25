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
    public partial class Form2 : Form
    {
        public static Characters p1_characters, p2_characters;
        public static Chess[,] chesses;
        public static int round = 1;
        public static Button[,] button = new Button[4, 2];
        public static char p1_use_chess = 'A', p2_use_chess = 'A';
        public static Label label3 = new Label();
        public static Label label4 = new Label();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button1.Hide();
            new_chess_type();
            new_characters();
            new_chess();
            Form2.button[0, 0].Enabled = false;
            Form2.button[1, 0].Enabled = false;
            Form2.button[2, 0].Enabled = false;
            Form2.button[3, 0].Enabled = false;
            label1.Hide();
            label3.Size = label1.Size;
            label3.Location = label1.Location;
            label3.Text = Form1.label3.Text;
            label2.Hide();
            label4.Size = label2.Size;
            label4.Location = label2.Location;
            label4.Text = Form1.label4.Text;
            this.Controls.Add(label3);
            this.Controls.Add(label4);

        }
        public void new_characters()
        {
            if (Form1.p1_role == 1)
            {
                p1_characters = new Characters(1000, 0, 0, 5, Color.DeepSkyBlue);
                button[0, 1].Text = "普通棋子";
                button[1, 1].Text = "橫向棋子0顆";
                button[2, 1].Text = "綜向棋子0顆";
                button[3, 1].Text = "覆蓋棋子5顆";

            }
            if (Form1.p1_role == 2)
            {
                p1_characters = new Characters(1000, 1, 2, 2, Color.DarkBlue);
                button[0, 1].Text = "普通棋子";
                button[1, 1].Text = "橫向棋子1顆";
                button[2, 1].Text = "綜向棋子2顆";
                button[3, 1].Text = "覆蓋棋子2顆";
            }
            if (Form1.p1_role == 3)
            {
                p1_characters = new Characters(1000, 1, 1, 3, Color.BlueViolet);
                button[0, 1].Text = "普通棋子";
                button[1, 1].Text = "橫向棋子1顆";
                button[2, 1].Text = "綜向棋子1顆";
                button[3, 1].Text = "覆蓋棋子3顆";
            }
            if (Form1.p2_role == 1)
            {
                p2_characters = new Characters(1000, 0, 0, 6, Color.Orange);
                button[0, 0].Text = "普通棋子";
                button[1, 0].Text = "橫向棋子0顆";
                button[2, 0].Text = "綜向棋子0顆";
                button[3, 0].Text = "覆蓋棋子6顆";
            }
            if (Form1.p2_role == 2)
            {
                p2_characters = new Characters(1000, 1, 2, 3, Color.DarkOrange);
                button[0, 0].Text = "普通棋子";
                button[1, 0].Text = "橫向棋子1顆";
                button[2, 0].Text = "綜向棋子2顆";
                button[3, 0].Text = "覆蓋棋子3顆";
            }
            if (Form1.p2_role == 3)
            {
                p2_characters = new Characters(1000, 1, 1, 4, Color.OrangeRed);
                button[0, 0].Text = "普通棋子";
                button[1, 0].Text = "橫向棋子1顆";
                button[2, 0].Text = "綜向棋子1顆";
                button[3, 0].Text = "覆蓋棋子4顆";
            }
        }
        public void new_chess_type()
        {
            
            for(int k = 0; k <= 1; k++)
            {
                
                for (int i = 0; i <= 3; i++)
                {
                    button[i,k] = new Button();
                    button[i,k].Size = button1.Size;
                    button[i, k].Top = button1.Top + i*80;
                    button[i, k].Left = button1.Left + k * (500);
                    button[i, k].Click += button_Click;
                    this.Controls.Add(button[i, k]);

                }
                
            }

            
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            if(obj == button[0, 1])
            {
                p1_use_chess = 'A';
            }
            if (obj == button[1, 1])
            {
                p1_use_chess = 'B';
            }
            if (obj == button[2, 1])
            {
                p1_use_chess = 'C';
            }
            if (obj == button[3, 1])
            {
                p1_use_chess = 'D';
            }
            if (obj == button[0, 0])
            {
                p2_use_chess = 'A';
            }
            if (obj == button[1, 0])
            {
                p2_use_chess = 'B';
            }
            if (obj == button[2, 0])
            {
                p2_use_chess = 'C';
            }
            if (obj == button[3, 0])
            {
                p2_use_chess = 'D';
            }
        }

        public void new_chess()
        {
            chesses = new Chess[19,19];
            for(int i = 0; i <= 18; i++)
            {
                for(int k = 0; k <= 18; k++)
                {
                    chesses[i, k] = new Chess(k,i);
                    
                    chesses[i, k].Width = panel1.Width / 19;
                    chesses[i, k].Height = panel1.Height / 19;
                    
                    chesses[i, k].Left = k * (panel1.Width / 19);
                    chesses[i, k].Top = i * (panel1.Height / 19);
                    
                    chesses[i, k].BackColor = Color.LightGray;
                    
                    panel1.Controls.Add(chesses[i, k]);
                }
            }
        }
    }
    public class Characters
    {
        public int numA;
        public int numB;
        public int numC;
        public int numD;
        public Color chess_color;
        public Characters(int a,int b,int c,int d,Color color)
        {
            this.numA = a;
            this.numB = b;
            this.numC = c;
            this.numD = d;
            this.chess_color = color;
            

        }
    }
    public class Chess : Button
    {
        public int x, y, x_top,y_top,x_left,y_left,x_buttom,y_buttom,x_right,y_right;
        public Chess(int x1, int y1)
        {
            this.x = x1;
            this.y = y1;

            this.x_top = x;
            this.y_top = y - 1;

            this.x_left = x - 1;
            this.y_left = y;

            this.x_buttom = x;
            this.y_buttom = y + 1;

            this.x_right = x + 1;
            this.y_right = y;

            this.SystemColorsChanged += Chess_SystemColorsChanged;
            this.Click += Chess_Click;
        }

        private void Chess_Click(object sender, EventArgs e)
        {
            if (Form2.round % 2 == 1)
            {
                Ban_player1();
                Reveal_player2();
                if (Form2.p2_characters.numB == 0)
                {
                    Form2.button[1, 0].Enabled = false;
                }
                if (Form2.p2_characters.numC == 0)
                {
                    Form2.button[2, 0].Enabled = false;
                }
                if (Form2.p2_characters.numD == 0)
                {
                    Form2.button[3, 0].Enabled = false;
                }


                if (Form2.p1_use_chess == 'A')
                {
                    if (this.BackColor == Color.LightGray)
                    {
                        this.BackColor = Form2.p1_characters.chess_color;


                    }
                    Count_player1(this.y, this.x);
                }
                if (Form2.p1_use_chess == 'B')
                {
                    bool yes = false;
                    if (this.BackColor == Color.LightGray)
                    {
                        this.BackColor = Form2.p1_characters.chess_color;

                        yes = true;
                    }
                    if (this.y_right >= 0 && this.x_right >= 0 && this.y_right <= 18 && this.x_right <= 18)
                    {
                        if (Form2.chesses[this.y_right, this.x_right].BackColor == Color.LightGray)
                        {
                            Form2.chesses[this.y_right, this.x_right].BackColor = Form2.p1_characters.chess_color;

                            yes = true;
                        }
                    }
                    if (yes == true)
                    {
                        Form2.p1_characters.numB -= 1;
                    }
                    Form2.button[1, 1].Text = "橫向棋子" + Form2.p1_characters.numB.ToString() + "顆";
                    if (Form2.p1_characters.numB == 0)
                    {
                        Form2.button[1, 1].Enabled = false;
                    }

                    Count_player1(this.y, this.x);
                }
                if (Form2.p1_use_chess == 'C')
                {
                    bool yes = false;
                    if (this.BackColor == Color.LightGray)
                    {
                        this.BackColor = Form2.p1_characters.chess_color;
                        yes = true;
                    }
                    if (this.x_buttom >= 0 && this.x_buttom <= 18 && this.y_buttom >= 0 && this.y_buttom <= 18)
                    {
                        if (Form2.chesses[this.y_buttom, this.x_buttom].BackColor == Color.LightGray)
                        {
                            Form2.chesses[this.y_buttom, this.x_buttom].BackColor = Form2.p1_characters.chess_color;
                            yes = true;
                        }

                    }
                    if (yes == true)
                    {
                        Form2.p1_characters.numC -= 1;
                    }
                    Form2.button[2, 1].Text = "縱向棋子" + Form2.p1_characters.numC.ToString() + "顆";
                    if (Form2.p1_characters.numC == 0)
                    {
                        Form2.button[2, 1].Enabled = false;
                    }
                    Count_player1(this.y, this.x);
                }
                if (Form2.p1_use_chess == 'D')
                {
                    
                    this.BackColor = Form2.p1_characters.chess_color;
                    Form2.p1_characters.numD -= 1;
                    Form2.button[3, 1].Text = "覆蓋棋子" + Form2.p1_characters.numD.ToString() + "顆";
                    if (Form2.p1_characters.numD == 0)
                    {
                        Form2.button[3, 1].Enabled = false;
                    }

                    Count_player1(this.y, this.x);
                }
                Form2.p1_use_chess = 'A';
                Form2.round++;
                
            }
            else if (Form2.round % 2 == 0)
            {
                Ban_player2();
                Reveal_player1();
                if (Form2.p1_characters.numB == 0)
                {
                    Form2.button[1, 1].Enabled = false;
                }
                if (Form2.p1_characters.numC == 0)
                {
                    Form2.button[2, 1].Enabled = false;
                }
                if (Form2.p1_characters.numD == 0)
                {
                    Form2.button[3, 1].Enabled = false;
                }
                



                if (Form2.p2_use_chess == 'A')
                {
                    if (this.BackColor == Color.LightGray)
                    {
                        this.BackColor = Form2.p2_characters.chess_color;


                    }
                    Count_player2(this.y, this.x);

                }
                if (Form2.p2_use_chess == 'B')
                {
                    bool yes = false;
                    if (this.BackColor == Color.LightGray)
                    {
                        this.BackColor = Form2.p2_characters.chess_color;

                        yes = true;
                    }
                    if (this.y_right >= 0 && this.x_right >= 0 && this.y_right <= 18 && this.x_right <= 18)
                    {
                        if (Form2.chesses[this.y_right, this.x_right].BackColor == Color.LightGray)
                        {
                            Form2.chesses[this.y_right, this.x_right].BackColor = Form2.p2_characters.chess_color;

                            yes = true;
                        }
                    }
                    if (yes == true)
                    {
                        Form2.p2_characters.numB -= 1;
                    }
                    Form2.button[1, 0].Text = "橫向棋子" + Form2.p2_characters.numB.ToString() + "顆";
                    if (Form2.p2_characters.numB == 0)
                    {
                        Form2.button[1, 0].Enabled = false;
                    }

                    Count_player2(this.y, this.x);
                }
                if (Form2.p2_use_chess == 'C')
                {
                    bool yes = false;
                    if (this.BackColor == Color.LightGray)
                    {
                        this.BackColor = Form2.p2_characters.chess_color;
                        yes = true;
                    }
                    if (this.x_buttom >= 0 && this.x_buttom <= 18 && this.y_buttom >= 0 && this.y_buttom <= 18)
                    {
                        if (Form2.chesses[this.y_buttom, this.x_buttom].BackColor == Color.LightGray)
                        {
                            Form2.chesses[this.y_buttom, this.x_buttom].BackColor = Form2.p2_characters.chess_color;
                            yes = true;
                        }

                    }
                    if (yes == true)
                    {
                        Form2.p2_characters.numC -= 1;
                    }
                    Form2.button[2, 0].Text = "縱向棋子" + Form2.p2_characters.numC.ToString() + "顆";
                    if (Form2.p2_characters.numC == 0)
                    {
                        Form2.button[2, 0].Enabled = false;
                    }
                    Count_player2(this.y, this.x);
                }
                if (Form2.p2_use_chess == 'D')
                {
                    
                    this.BackColor = Form2.p2_characters.chess_color;
                    Form2.p2_characters.numD -= 1;
                    Form2.button[3, 0].Text = "覆蓋棋子" + Form2.p2_characters.numD.ToString() + "顆";
                    if (Form2.p2_characters.numD == 0)
                    {
                        Form2.button[3, 0].Enabled = false;
                    }
                    Count_player2(this.y, this.x);

                }
                Form2.p2_use_chess = 'A';
                Form2.round++;
                
            }
        }
        public void Ban_player1()
        {
            Form2.button[0, 1].Enabled = false;
            Form2.button[1, 1].Enabled = false;
            Form2.button[2, 1].Enabled = false;
            Form2.button[3, 1].Enabled = false;
        }
        public void Reveal_player1()
        {
            Form2.button[0, 1].Enabled = true;
            Form2.button[1, 1].Enabled = true;
            Form2.button[2, 1].Enabled = true;
            Form2.button[3, 1].Enabled = true;
        }
        public void Ban_player2()
        {
            Form2.button[0, 0].Enabled = false;
            Form2.button[1, 0].Enabled = false;
            Form2.button[2, 0].Enabled = false;
            Form2.button[3, 0].Enabled = false;
        }
        public void Reveal_player2()
        {
            Form2.button[0, 0].Enabled = true;
            Form2.button[1, 0].Enabled = true;
            Form2.button[2, 0].Enabled = true;
            Form2.button[3, 0].Enabled = true;
        }
        public void Count_player1(int h,int j)
        {
            for(int i = h - 4; i <= h + 4; i++)
            {
                for(int k = j - 4; k <= j + 4; k++)
                {
                    int count = 0;
                    if( k >= 0 && k < 19 && i >= 0 && i < 19)
                    {
                        try
                        {
                            if (Form2.chesses[i, k].BackColor == Form2.p1_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }
                    
                    if (k+1 < 19 &&k+1>=0 && i>=0 &&i<19)
                    {
                        
                        try
                        {
                            if (Form2.chesses[i, k + 1].BackColor == Form2.p1_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }
                    
                    if (k + 2 < 19 && k + 2 >= 0 && i >= 0 && i < 19)
                    {
                        try
                        {
                            if (Form2.chesses[i, k + 2].BackColor == Form2.p1_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }
                    if (k + 3 < 19 && k + 3 >= 0 && i >= 0 && i < 19)
                    {
                        try
                        {
                            if (Form2.chesses[i, k + 3].BackColor == Form2.p1_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }
                    if (k + 4 < 19 && k + 4 >= 0 && i >= 0 && i < 19)
                    {
                        try
                        {
                            if (Form2.chesses[i, k + 4].BackColor == Form2.p1_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }
                        
                    
                    
                    if (count == 5)
                    {
                        MessageBox.Show("player1獲勝");
                        Application.Exit();

                    }

                    count = 0;

                    if (k >= 0 && k < 19 && i >= 0 && i < 19)
                    {
                        try
                        {
                            if (Form2.chesses[i, k].BackColor == Form2.p1_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }
                    
                    if (i+1 < 19 && k+1<19 && k + 1 >= 0 && i+1>=0)
                    {
                        try
                        {
                            if (Form2.chesses[i + 1, k + 1].BackColor == Form2.p1_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }
                    if(i+2<19 && k + 2 < 19 && k + 2 >= 0 && i + 2 >= 0)
                    {
                        try
                        {
                            if (Form2.chesses[i + 2, k + 2].BackColor == Form2.p1_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }
                    if(i+3<19 && k + 3 < 19 && k + 3 >= 0 && i + 3 >= 0)
                    {
                        try
                        {
                            if (Form2.chesses[i + 3, k + 3].BackColor == Form2.p1_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }
                    if(i+4<19 && k + 4 < 19 && k + 4 >= 0 && i + 4 >= 0)
                    {
                        try
                        {
                            if (Form2.chesses[i + 4, k + 4].BackColor == Form2.p1_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }
                    
                    if (count == 5)
                    {
                        MessageBox.Show("player1獲勝");
                        Application.Exit();

                    }

                    count = 0;

                    if (k >= 0 && k < 19 && i >= 0 && i < 19)
                    {
                        try
                        {
                            if (Form2.chesses[i, k].BackColor == Form2.p1_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }
                    
                    if(i-1>=0 && k + 1 < 19 &&i-1<19 &&k+1>=0)
                    {
                        try
                        {
                            if (Form2.chesses[i - 1, k + 1].BackColor == Form2.p1_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }
                    
                    if (i - 2 >= 0 && k + 2 < 19 && i - 2 < 19 && k + 2 >= 0)
                    {
                        try
                        {
                            if (Form2.chesses[i - 2, k + 2].BackColor == Form2.p1_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }
                    
                    if (i - 3 >= 0 && k + 3 < 19 && i - 3 < 19 && k + 3 >= 0)
                    {
                        try
                        {
                            if (Form2.chesses[i - 3, k + 3].BackColor == Form2.p1_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }
                    
                    if (i - 4 >= 0 && k + 4 < 19 && i - 4 < 19 && k + 4 >= 0)
                    {
                        try
                        {
                            if (Form2.chesses[i - 4, k + 4].BackColor == Form2.p1_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }
                    
                    if (count == 5)
                    {
                        MessageBox.Show("player1獲勝");
                        Application.Exit();

                    }

                    count = 0;

                    if (k >= 0 && k < 19 && i >= 0 && i < 19)
                    {
                        try
                        {
                            if (Form2.chesses[i, k].BackColor == Form2.p1_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }
                    
                    if (i - 1 >= 0 &&i-1<19 && k >= 0 && k < 19)
                    {
                        try
                        {
                            if (Form2.chesses[i - 1, k].BackColor == Form2.p1_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }
                    
                    if (i - 2 >= 0 && i - 2 < 19 && k >= 0 && k < 19)
                    {
                        try
                        {
                            if (Form2.chesses[i - 2, k].BackColor == Form2.p1_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }
                    
                    if (i - 3 >= 0 && i - 3 < 19 && k >= 0 && k < 19)
                    {
                        try
                        {
                            if (Form2.chesses[i - 3, k].BackColor == Form2.p1_characters.chess_color)
                            {

                                count++;
                            }
                        }
                        catch { }
                    }
                    
                    if (i - 4 >= 0 && i - 4 < 19 && k >= 0 && k < 19)
                    {
                        try
                        {
                            if (Form2.chesses[i - 4, k].BackColor == Form2.p1_characters.chess_color)
                            {

                                count++;
                            }
                        }
                        catch { }
                    }
                    
                    if (count == 5)
                    {
                        MessageBox.Show("player1獲勝");
                        Application.Exit();

                    }

                    count = 0;
                }
            }
            
               
        }
        public void Count_player2(int h, int j)
        {
            for (int i = h - 4; i <= h + 4; i++)
            {
                for (int k = j - 4; k <= j + 4; k++)
                {
                    int count = 0;
                    if (k >= 0 && k < 19 && i >= 0 && i < 19)
                    {
                        try
                        {
                            if (Form2.chesses[i, k].BackColor == Form2.p2_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }

                    if (k + 1 < 19 && k + 1 >= 0 && i >= 0 && i < 19)
                    {

                        try
                        {
                            if (Form2.chesses[i, k + 1].BackColor == Form2.p2_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }

                    if (k + 2 < 19 && k + 2 >= 0 && i >= 0 && i < 19)
                    {
                        try
                        {
                            if (Form2.chesses[i, k + 2].BackColor == Form2.p2_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }
                    if (k + 3 < 19 && k + 3 >= 0 && i >= 0 && i < 19)
                    {
                        try
                        {
                            if (Form2.chesses[i, k + 3].BackColor == Form2.p2_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }
                    if (k + 4 < 19 && k + 4 >= 0 && i >= 0 && i < 19)
                    {
                        try
                        {
                            if (Form2.chesses[i, k + 4].BackColor == Form2.p2_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }



                    if (count == 5)
                    {
                        MessageBox.Show("player2獲勝");
                        Application.Exit();

                    }

                    count = 0;

                    if (k >= 0 && k < 19 && i >= 0 && i < 19)
                    {
                        try
                        {
                            if (Form2.chesses[i, k].BackColor == Form2.p2_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }

                    if (i + 1 < 19 && k + 1 < 19 && k + 1 >= 0 && i + 1 >= 0)
                    {
                        try
                        {
                            if (Form2.chesses[i + 1, k + 1].BackColor == Form2.p2_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }
                    if (i + 2 < 19 && k + 2 < 19 && k + 2 >= 0 && i + 2 >= 0)
                    {
                        try
                        {
                            if (Form2.chesses[i + 2, k + 2].BackColor == Form2.p2_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }
                    if (i + 3 < 19 && k + 3 < 19 && k + 3 >= 0 && i + 3 >= 0)
                    {
                        try
                        {
                            if (Form2.chesses[i + 3, k + 3].BackColor == Form2.p2_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }
                    if (i + 4 < 19 && k + 4 < 19 && k + 4 >= 0 && i + 4 >= 0)
                    {
                        try
                        {
                            if (Form2.chesses[i + 4, k + 4].BackColor == Form2.p2_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }

                    if (count == 5)
                    {
                        MessageBox.Show("player2獲勝");
                        Application.Exit();

                    }

                    count = 0;

                    if (k >= 0 && k < 19 && i >= 0 && i < 19)
                    {
                        try
                        {
                            if (Form2.chesses[i, k].BackColor == Form2.p2_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }

                    if (i - 1 >= 0 && k + 1 < 19 && i - 1 < 19 && k + 1 >= 0)
                    {
                        try
                        {
                            if (Form2.chesses[i - 1, k + 1].BackColor == Form2.p2_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }

                    if (i - 2 >= 0 && k + 2 < 19 && i - 2 < 19 && k + 2 >= 0)
                    {
                        try
                        {
                            if (Form2.chesses[i - 2, k + 2].BackColor == Form2.p2_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }

                    if (i - 3 >= 0 && k + 3 < 19 && i - 3 < 19 && k + 3 >= 0)
                    {
                        try
                        {
                            if (Form2.chesses[i - 3, k + 3].BackColor == Form2.p2_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }

                    if (i - 4 >= 0 && k + 4 < 19 && i - 4 < 19 && k + 4 >= 0)
                    {
                        try
                        {
                            if (Form2.chesses[i - 4, k + 4].BackColor == Form2.p2_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }

                    if (count == 5)
                    {
                        MessageBox.Show("player2獲勝");
                        Application.Exit();

                    }

                    count = 0;

                    if (k >= 0 && k < 19 && i >= 0 && i < 19)
                    {
                        try
                        {
                            if (Form2.chesses[i, k].BackColor == Form2.p2_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }

                    if (i - 1 >= 0 && i - 1 < 19 && k >= 0 && k < 19)
                    {
                        try
                        {
                            if (Form2.chesses[i - 1, k].BackColor == Form2.p2_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }

                    if (i - 2 >= 0 && i - 2 < 19 && k >= 0 && k < 19)
                    {
                        try
                        {
                            if (Form2.chesses[i - 2, k].BackColor == Form2.p2_characters.chess_color)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }

                    if (i - 3 >= 0 && i - 3 < 19 && k >= 0 && k < 19)
                    {
                        try
                        {
                            if (Form2.chesses[i - 3, k].BackColor == Form2.p2_characters.chess_color)
                            {

                                count++;
                            }
                        }
                        catch { }
                    }

                    if (i - 4 >= 0 && i - 4 < 19 && k >= 0 && k < 19)
                    {
                        try
                        {
                            if (Form2.chesses[i - 4, k].BackColor == Form2.p2_characters.chess_color)
                            {

                                count++;
                            }
                        }
                        catch { }
                    }

                    if (count == 5)
                    {
                        MessageBox.Show("player2獲勝");
                        Application.Exit();

                    }

                    count = 0;
                }
            }


        }
        private void Chess_SystemColorsChanged(object sender, EventArgs e)
        {
            
        }
    }
}
