using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WindowsFormsApp5
{
    class Substitution
    {
        public static String subst_str;
        public static char[] subst;
        Random random = new Random();
        public Substitution()
        {
            subst_str = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            
            subst = subst_str.ToCharArray();
            subst = subst.OrderBy(x => random.Next()).ToArray();
            subst_str = new string(subst);
            
        }
        public void sub_act_change()
        {
            subst = subst_str.ToCharArray();

            subst_str = new string(subst);
        }
    }
}