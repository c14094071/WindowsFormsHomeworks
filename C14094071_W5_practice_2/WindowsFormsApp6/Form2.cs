using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    //static Pet pt;
    public partial class Form2 : Form
    {
        public static Pet pt = new Pet();
        public static int money = 0;
        public static int act = 0;
        public static int Day = 1;
        public static int ee = 0;
        Random random = new Random();
       
        public Form2()
        {
            this.Show();
            InitializeComponent();
            
            ban_act();
            ban_finshday();
            label4.Text = String.Concat(money.ToString(),"元");
            label13.Text = "請幫寵物取名";
            label9.Text = String.Concat(pt.health.ToString(), "%");
            label10.Text = String.Concat(pt.weight.ToString(), "g");
            label11.Text = String.Concat(pt.satisfaction.ToString(), "%");
            label12.Text = String.Concat(pt.emotion.ToString(), "%");
        }
        public void ban_input_name()
        {
            button1.Enabled = false;
        }
        public void ban_act()
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
        }
        public void ban_finshday()
        {
            button6.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                Pet.name1 = "電子雞";

            }
            else
            {
                Pet.name1 = textBox1.Text;
            }
            richTextBox1.AppendText(String.Concat("你開始養了",Pet.name1));
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            ban_input_name();
            money = 100;
            pt.health = 70;
            pt.weight = 700;
            pt.satisfaction = 70;
            pt.emotion = 50;
            show_nums();
            label13.Text = String.Concat(Pet.name1, "出生了");
            richTextBox1.AppendText(String.Concat("\n", "第一天"));

        }

        
        public void show_nums()
        {
            label4.Text = String.Concat(money.ToString(), "元");
            label9.Text = String.Concat(pt.health.ToString(), "%");
            label10.Text = String.Concat(pt.weight.ToString(), "g");
            label11.Text = String.Concat(pt.satisfaction.ToString(), "%");
            label12.Text = String.Concat(pt.emotion.ToString(), "%");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            
            pt.satisfaction = pt.satisfaction - 20;
            if (pt.satisfaction == 0)
            {
                pt.weight = pt.weight - 200;
            }
            if (Day >= 11)
            {
                pt.health = pt.health - 10;
            }


            if (Pet.sick == 1)
            {
                pt.weight = pt.weight - 150;
                pt.emotion = pt.emotion - 20;

            }
            if(Pet.sh == 1)
            {
                pt.health = pt.health - 30;
            }
            Day++;
            richTextBox1.AppendText(String.Concat("\n\n", "第",Day.ToString(),"天"));
            Event();
            if (Pet.death == 1)
            {

            }
            else
            {
                if (act == 0)
                {
                    richTextBox1.AppendText(String.Concat("\n", "一天平安的過去了"));
                    label13.Text = "小雞今天很乖";
                }
                else if (ee == 1)
                {
                    label13.Text = "小雞今天很乖";
                    ee = 0;
                }
            }
            
            act = 0;
            show_nums();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (money >= 10) {
                richTextBox1.AppendText(String.Concat("\n","餵食了", Pet.name1));
                
                money = money - 10;
                pt.satisfaction = pt.satisfaction + random.Next(0, 20);
                pt.weight = pt.weight + random.Next(50, 100);
                show_nums();
                if (Pet.sh == 1)
                {
                    pt.health = pt.health - 10;
                }
                
            }
            else
            {
                richTextBox1.AppendText(String.Concat("\n","金錢不足無法餵食"));
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (money >= 5)
            {
                richTextBox1.AppendText(String.Concat("\n","與", Pet.name1, "玩耍了"));
     
                money = money - 5;
                pt.health = pt.health + random.Next(0, 20);
                pt.emotion = pt.emotion + random.Next(0, 20);
                pt.satisfaction = pt.satisfaction - random.Next(0, 20);
                show_nums();
            }
            else
            {
                richTextBox1.AppendText(String.Concat("\n","金錢不足無法玩耍"));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (money >= 5)
            {
                money = money - 5;
                richTextBox1.AppendText(String.Concat("\n","清理了", Pet.name1));
                Pet.sh = 0;
                show_nums();
            }
            else
            {
                richTextBox1.AppendText(String.Concat("\n","金錢不足無法打掃"));
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (money >= 20)
            {
                money = money - 20;
                richTextBox1.AppendText(String.Concat("\n","帶", Pet.name1, "去看醫生"));
                Pet.sick = 0;
                show_nums();
            }
            else
            {
                richTextBox1.AppendText(String.Concat("\n","金錢不足無法看醫生"));
            }
        }
       
        public void Event()
        {
            String tb = "";
            String event_str = "";
            if (pt.weight > 1000 && pt.health >= 60)
            {

                int x = random.Next(1, 100);
                if (x <= pt.emotion)
                {
                    int y = random.Next(15, 25);
                    tb = String.Concat("\n", Pet.name1, "下蛋了", "賣掉蛋後獲得", y.ToString(), "塊錢");
                    money = money + y;
                    act = 1;
                    pt.health = pt.health - 5;
                    ee = 1;
                }


            }
            if (pt.satisfaction >= 50)
            {
                Pet.sh = 1;
                tb = String.Concat(tb,"\n","牠大便了");
                event_str = String.Concat(Pet.name1, "大便了");
                act = 1;
                ee = 0;
            }else if (Pet.sh == 1)
            {
                tb = String.Concat(tb,"\n", "牠大便了");
                event_str = String.Concat(Pet.name1, "大便了");
                act = 1;
                ee = 0;
            }
            
            if(pt.health<=50 && pt.emotion <= 50)
            {
                int x = random.Next(1, 100);
                if (x <= (100 - pt.health))
                {
                    Pet.sick = 1;
                    tb = String.Concat(tb,"\n",Pet.name1, "生病了");
                    event_str = String.Concat(event_str, " ", Pet.name1, "生病了");
                    act = 1;
                    ee = 0;
                }
                else if (Pet.sick == 1)
                {
                    tb = String.Concat(tb,"\n", Pet.name1, "生病了");
                    event_str = String.Concat(event_str, " ", Pet.name1, "生病了");
                    act = 1;
                    ee = 0;
                }
            }
            
            
            if (pt.health < 10 && pt.weight < 1000)
            {
                int x = random.Next(1, 100);
                if (x <= (100 - pt.emotion))
                {
                    Pet.death = 1;
                    
                    event_str = String.Concat(Pet.name1, "死掉了");

                }


            }
            if (Pet.death == 1)
            {
                richTextBox1.AppendText("\n死掉了，遊戲結束");
            }
            else
            {
                richTextBox1.AppendText(String.Concat(tb));
            }
            
            label13.Text = event_str;
            if (Pet.death == 1)
            {
                ban_act();
                ban_finshday();
                ban_input_name();
            }
        }
    }

}
