using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace WindowsFormsApp8
{
    public class TextFont1
    {
        public FontFamily fm1 = new FontFamily("標楷體");
        public FontFamily fm2 = new FontFamily("新細明體");
        public FontFamily fm3 = new FontFamily("微軟正黑體");
        public FontStyle fs1 = FontStyle.Bold;
        public FontStyle fs2 = FontStyle.Italic;
        public FontStyle fs3 = FontStyle.Regular;

        public int fontsize;
        public TextFont1()
        {
            fontsize = 12;



        }
        public void Tell_it_bd_1(bool H)
        {
            if (H == true)
            {
                Form1.fs_1 = fs1;
            }
            else
            {
                Form1.fs_1 = fs3;
            }
        }
        public void Tell_it_bd_2(bool H)
        {
            if (H == true)
            {
                Form1.fs_2 = fs2;
            }
            else
            {
                Form1.fs_2 = fs3;
            }
        }
        


            
    }
}