using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WindowsFormsApp5
{
    class Alphabet
    {
        public static String alpha_str;
        public static char[] alpha;
        public Alphabet()
        {
  
            alpha_str = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            
            alpha = alpha_str.ToCharArray();
            
        }
    }
}