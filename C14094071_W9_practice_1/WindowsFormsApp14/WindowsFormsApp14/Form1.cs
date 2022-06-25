using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class Form1 : Form
    {
        public MusicPlayer mp = new MusicPlayer();
        public static GroupBox groupbox2;
        public static RadioButton[] rb;
        public static string[] files = new string[1] { "0" };
        public static string playsong_name="";
        public int count = 0;
        public Form1()
        {
            
            InitializeComponent();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            files = mp.SelectWavFiles();
            if (MusicPlayer.selectfiles == true)
            {
                groupbox2.Controls.Clear();


                Count();

                int i = 0;
                foreach (var itmes in files)
                {

                    rb[i] = new RadioButton();
                    rb[i].Size = new Size(500, 40);
                    rb[i].Text = itmes;
                    rb[i].Left = 20;
                    rb[i].Top = i * 40 + 20;
                    rb[0].Top = 20;
                    rb[i].CheckedChanged += rb_CheckedChanged;
                    rb[i].AutoSize = true;
                  
                    groupbox2.Controls.Add(rb[i]);
                    i++;

                }
            }
            MusicPlayer.selectfiles = false;

        }
        public void Count()
        {
            foreach (var itmes in files)
            {
                count++;
            }
            Console.WriteLine("@@{0}@@", count);
            rb = new RadioButton[count];
            count = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            set_groupbox2();
        }
        public void set_groupbox2()
        {
            groupBox1.Hide();
            groupbox2 = new GroupBox();
            groupbox2.Size = groupBox1.Size;
            groupbox2.Left = groupBox1.Left;
            groupbox2.Top = groupBox1.Top;
            groupbox2.Text = "Playlist";
            this.Controls.Add(groupbox2);
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn_touch = (RadioButton)sender;
            if(btn_touch.Checked == true)
            {
                //Console.WriteLine(btn_touch.Text);
                playsong_name = btn_touch.Text;
            }
            
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            mp.new_player();
            mp.play();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                MusicPlayer.repeat_bool = true;
            }
            else
            {
                MusicPlayer.repeat_bool = false;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mp.stop();
        }
    }
    public class MusicPlayer : SoundPlayer
    {
        public bool Loop = false;
        public string[] Playlist;
        public SoundPlayer player;
        public static bool player_bool = false, repeat_bool = false,play_finish=false;
        public Thread thread;
        public static bool selectfiles = false;
        public string[] SelectWavFiles()
        {
            OpenFileDialog openfiles = new OpenFileDialog();
            openfiles.Multiselect = true;

            openfiles.Filter = "Text files (*.wav)|*.wav";
            openfiles.FilterIndex = 4;
            string[] files1 = { };
            if (openfiles.ShowDialog() == DialogResult.OK)
            {
                int h = 0;
                foreach (var items in openfiles.FileNames.Take(4))
                {

                    Array.Resize(ref files1, files1.Length + 1);
                    files1[h] = items;
                    h++;
                }

                selectfiles = true;
            }

            return files1;
        }

        public void new_player()
        {
            if (Form1.playsong_name != "")
            {
                player = new SoundPlayer(Form1.playsong_name);
              
                player_bool = true;
            }
            
        }
        public void play()
        {
            
            if (Form1.playsong_name != "")
            {

                if(repeat_bool == true)
                {
                    player.PlayLooping();
                }
                else
                {
                    player.Play();
                    
                }
                
            }



        }

    

        public void stop()
        {
            
            try
            {
                player.Stop();
            }
            catch
            {
                Console.WriteLine("!!");
            }
            
        }

    }
}
