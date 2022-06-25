using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public static int col1;
        public static int row1;
        public static int col11;
        public static int row11;
        public Button[,] btn,btn2;
        public static string text_str;
        public static char[] text;
        public static Boolean number1=true;
        public static Boolean number2=true;



        public Form1()
        {
            InitializeComponent();
            textBox3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                row11 = int.Parse(textBox1.Text);
                col11 = int.Parse(textBox2.Text);
                if((row11 >= 7 && row11 <= 15) && (col11 >= 5 && col11 <= 10))
                {
                    
                    if (row11 % 2 == 1)
                    {
                        row1 = row11;
                        col1 = col11;
                        New_buttons();
                        New_Buttons_2();
                        textBox3.Enabled = true;
                        if (textBox3.Text != null && number1 !=false)
                        {
                            Show_nums();
                            
                        }
                        if (textBox3.Text != null && number2 != false)
                        {
                            Show_num_2();

                        }

                    }
                    else if (row11 % 2 == 0)
                    {
                        MessageBox.Show("高不能為偶數");
                    }
                }
                else
                {
                    MessageBox.Show("請輸入範圍內的數字");
                }

            }
            catch {
                MessageBox.Show("請輸入數字");
            }
            

            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            text_str = textBox3.Text;
            try
            {
                
                int text_int = int.Parse(text_str);
                
                if(text_int>=-9 && text_int <= 99)
                {
                    number1 = true;
                    number2 = true;
                    
                    
                    text = text_str.ToCharArray();
             



                }
                else
                {
                    Console.WriteLine("AAAA");
                    Array.Clear(text, 0, text.Length);
                    number1 = false;
                    number2 = false;

                    New_buttons();
                    New_Buttons_2();
                }
                
                
                
            }
            catch
            {
                number1 = false;
                number2 = false;
                New_buttons();
                New_Buttons_2();
            }
      

            try
            {
                
                if (number2==false)
                {
                    
                }
                else
                {
                    Show_num_2();
                    
                    
                }
            }
            catch { }

            try
            {
                if (number1==false)
                {
                    
                }
                else
                {
                    Show_nums();
                }
            }
            catch { }
            


        }
        public void New_buttons()
        {
            btn = new Button[row1, col1];
            
            while (panel1.Controls.Count > 0)
            {
                foreach (Control item in panel1.Controls.OfType<Button>())
                {

                    panel1.Controls.Remove(item);
                }
            }
            
            


            for (int i = 0; i < row1; i++)
            {
                for (int k = 0; k < col1; k++)
                {

                    btn[i, k] = new Button();


                    panel1.Controls.Add(btn[i, k]);
                    btn[i, k].Left = (panel1.Width / col1) * k;
                    btn[i, k].Top = (panel1.Height / row1) * i;
                    btn[i, k].Width = panel1.Width / col1;
                    btn[i, k].Height = panel1.Height / row1;
                   
                }
            }
            
        }
        public void Show_nums()
        {
            try
            {
                text = textBox3.Text.ToCharArray();

            }
            catch
            {

            }

            try
            {
                New_buttons();
                if (text[0].Equals('1'))
                {
                   
                   
                    
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[i, col1 - 1].BackColor = Color.Red; //右上豎
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[row1/2+i, col1 - 1].BackColor = Color.Red; //右下豎
                    }

                }
                if (text[0].Equals('2'))
                {
              
        
                    for (int i = 1; i < col1-1; i++)
                    {
                        btn[0, i].BackColor = Color.Red;   //上橫
                    }

                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[i,col1-1].BackColor = Color.Red; //右上豎
                    }
                    for (int i = 1; i < col1-1; i++)
                    {
                        btn[row1 / 2, i].BackColor = Color.Red; //中橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[row1 / 2 + i, 0].BackColor = Color.Red; //左下豎
                    }
                    for (int i = 1; i < col1-1; i++)
                    {
                        btn[row1 - 1, i].BackColor = Color.Red;  //下橫
                    }
                }
                if (text[0].Equals('3'))
                {
                  
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn[0, i].BackColor = Color.Red;   //上橫
                    }

                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[i, col1 - 1].BackColor = Color.Red; //右上豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn[row1 / 2, i].BackColor = Color.Red; //中橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[row1 / 2 + i, col1 - 1].BackColor = Color.Red; //右下豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn[row1 - 1, i].BackColor = Color.Red;  //下橫
                    }
                }
                if (text[0].Equals('4'))
                {
                
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[i, 0].BackColor = Color.Red; //左上豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn[row1 / 2, i].BackColor = Color.Red; //中橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[i, col1 - 1].BackColor = Color.Red; //右上豎
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[row1 / 2 + i, col1 - 1].BackColor = Color.Red; //右下豎
                    }
                }
                if (text[0].Equals('5'))
                {
             
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn[0, i].BackColor = Color.Red;   //上橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[i, 0].BackColor = Color.Red; //左上豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn[row1 / 2, i].BackColor = Color.Red; //中橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[row1 / 2 + i, col1 - 1].BackColor = Color.Red; //右下豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn[row1 - 1, i].BackColor = Color.Red;  //下橫
                    }
                }
                if (text[0].Equals('6'))
                {
                  
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn[0, i].BackColor = Color.Red;   //上橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[i, 0].BackColor = Color.Red; //左上豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn[row1 / 2, i].BackColor = Color.Red; //中橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[row1 / 2 + i, 0].BackColor = Color.Red; //左下豎
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[row1 / 2 + i, col1 - 1].BackColor = Color.Red; //右下豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn[row1 - 1, i].BackColor = Color.Red;  //下橫
                    }
                }
                if (text[0].Equals('7'))
                {
         
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn[0, i].BackColor = Color.Red;   //上橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[i, col1 - 1].BackColor = Color.Red; //右上豎
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[row1 / 2 + i, col1 - 1].BackColor = Color.Red; //右下豎
                    }
                }
                if (text[0].Equals('8'))
                {

                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn[0, i].BackColor = Color.Red;   //上橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[i, 0].BackColor = Color.Red; //左上豎
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[i, col1 - 1].BackColor = Color.Red; //右上豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn[row1 / 2, i].BackColor = Color.Red; //中橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[row1 / 2 + i, col1 - 1].BackColor = Color.Red; //右下豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn[row1 - 1, i].BackColor = Color.Red;  //下橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[row1 / 2 + i, 0].BackColor = Color.Red; //左下豎
                    }
                    
                }
                if (text[0].Equals('9'))
                {
           
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn[0, i].BackColor = Color.Red;   //上橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[i, 0].BackColor = Color.Red; //左上豎
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[i, col1 - 1].BackColor = Color.Red; //右上豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn[row1 / 2, i].BackColor = Color.Red; //中橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[row1 / 2 + i, col1 - 1].BackColor = Color.Red; //右下豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn[row1 - 1, i].BackColor = Color.Red;  //下橫
                    }
                }
                if (text[0].Equals('-'))
                {
            
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn[row1 / 2, i].BackColor = Color.Red; //中橫
                    }
                }
                if (text[0].Equals('0'))
                {
                
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn[0, i].BackColor = Color.Red;   //上橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[i, 0].BackColor = Color.Red; //左上豎
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[i, col1 - 1].BackColor = Color.Red; //右上豎
                    }
                    
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[row1 / 2 + i, col1 - 1].BackColor = Color.Red; //右下豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn[row1 - 1, i].BackColor = Color.Red;  //下橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn[row1 / 2 + i, 0].BackColor = Color.Red; //左下豎
                    }
                }
                

            }
            catch
            {

            }

            
        }
        public void New_Buttons_2()
        {
            btn2 = new Button[row1, col1];
            while (panel2.Controls.Count > 0)
            {
                foreach (Control item in panel2.Controls.OfType<Button>())
                {

                    panel2.Controls.Remove(item);
                }
            }
            for (int i = 0; i < row1; i++)
            {
                for (int k = 0; k < col1; k++)
                {

                    btn2[i, k] = new Button();


                    panel2.Controls.Add(btn2[i, k]);
                    btn2[i, k].Left = (panel2.Width / col1) * k;
                    btn2[i, k].Top = (panel2.Height / row1) * i;
                    btn2[i, k].Width = panel2.Width / col1;
                    btn2[i, k].Height = panel2.Height / row1;
                    
                }
            }

        }
        public void Show_num_2()
        {
            try
            {
                text = textBox3.Text.ToCharArray();

            }
            catch
            {

            }
            try
            {
                New_Buttons_2();
                if (text[1].Equals('1'))
                {
           
                    
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[i, col1 - 1].BackColor = Color.Red; //右上豎
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[row1 / 2 + i, col1 - 1].BackColor = Color.Red; //右下豎
                    }

                }
                if (text[1].Equals('2'))
                {
                  
                    
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn2[0, i].BackColor = Color.Red;   //上橫
                    }

                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[i, col1 - 1].BackColor = Color.Red; //右上豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn2[row1 / 2, i].BackColor = Color.Red; //中橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[row1 / 2 + i, 0].BackColor = Color.Red; //左下豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn2[row1 - 1, i].BackColor = Color.Red;  //下橫
                    }
                }
                if (text[1].Equals('3'))
                {
          
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn2[0, i].BackColor = Color.Red;   //上橫
                    }

                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[i, col1 - 1].BackColor = Color.Red; //右上豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn2[row1 / 2, i].BackColor = Color.Red; //中橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[row1 / 2 + i, col1 - 1].BackColor = Color.Red; //右下豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn2[row1 - 1, i].BackColor = Color.Red;  //下橫
                    }
                }
                if (text[1].Equals('4'))
                {
                  
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[i, 0].BackColor = Color.Red; //左上豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn2[row1 / 2, i].BackColor = Color.Red; //中橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[i, col1 - 1].BackColor = Color.Red; //右上豎
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[row1 / 2 + i, col1 - 1].BackColor = Color.Red; //右下豎
                    }
                }
                if (text[1].Equals('5'))
                {
              
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn2[0, i].BackColor = Color.Red;   //上橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[i, 0].BackColor = Color.Red; //左上豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn2[row1 / 2, i].BackColor = Color.Red; //中橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[row1 / 2 + i, col1 - 1].BackColor = Color.Red; //右下豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn2[row1 - 1, i].BackColor = Color.Red;  //下橫
                    }
                }
                if (text[1].Equals('6'))
                {
                   
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn2[0, i].BackColor = Color.Red;   //上橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[i, 0].BackColor = Color.Red; //左上豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn2[row1 / 2, i].BackColor = Color.Red; //中橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[row1 / 2 + i, 0].BackColor = Color.Red; //左下豎
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[row1 / 2 + i, col1 - 1].BackColor = Color.Red; //右下豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn2[row1 - 1, i].BackColor = Color.Red;  //下橫
                    }
                }
                if (text[1].Equals('7'))
                {
      
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn2[0, i].BackColor = Color.Red;   //上橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[i, col1 - 1].BackColor = Color.Red; //右上豎
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[row1 / 2 + i, col1 - 1].BackColor = Color.Red; //右下豎
                    }
                }
                if (text[1].Equals('8'))
                {
      
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn2[0, i].BackColor = Color.Red;   //上橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[i, 0].BackColor = Color.Red; //左上豎
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[i, col1 - 1].BackColor = Color.Red; //右上豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn2[row1 / 2, i].BackColor = Color.Red; //中橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[row1 / 2 + i, col1 - 1].BackColor = Color.Red; //右下豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn2[row1 - 1, i].BackColor = Color.Red;  //下橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[row1 / 2 + i, 0].BackColor = Color.Red; //左下豎
                    }

                }
                if (text[1].Equals('9'))
                {
           
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn2[0, i].BackColor = Color.Red;   //上橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[i, 0].BackColor = Color.Red; //左上豎
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[i, col1 - 1].BackColor = Color.Red; //右上豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn2[row1 / 2, i].BackColor = Color.Red; //中橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[row1 / 2 + i, col1 - 1].BackColor = Color.Red; //右下豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn2[row1 - 1, i].BackColor = Color.Red;  //下橫
                    }
                }
                if (text[1].Equals('-'))
                {
           
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn2[row1 / 2, i].BackColor = Color.Red; //中橫
                    }
                }
                if (text[1].Equals('0'))
                {
    
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn2[0, i].BackColor = Color.Red;   //上橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[i, 0].BackColor = Color.Red; //左上豎
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[i, col1 - 1].BackColor = Color.Red; //右上豎
                    }

                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[row1 / 2 + i, col1 - 1].BackColor = Color.Red; //右下豎
                    }
                    for (int i = 1; i < col1 - 1; i++)
                    {
                        btn2[row1 - 1, i].BackColor = Color.Red;  //下橫
                    }
                    for (int i = 1; i < row1 / 2; i++)
                    {
                        btn2[row1 / 2 + i, 0].BackColor = Color.Red; //左下豎
                    }
                }
            }
            catch
            {

            }
            
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
