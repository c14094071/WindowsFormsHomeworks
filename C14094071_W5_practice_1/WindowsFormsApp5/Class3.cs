using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WindowsFormsApp5
{
    class Encryption
    {
        public static String encry_input = "";
        public static String encry_output = "";
     
        public Encryption()
        {
            
        }
        public void transfor()
        {

            foreach(char value in encry_input)
            {
                Console.WriteLine("1");
                int num = Alphabet.alpha_str.IndexOf(value);
                try
                {
                    encry_output = String.Concat(encry_output, Substitution.subst[num]);
                }
                catch
                {
                    encry_output = String.Concat(encry_output, " ");
                }
                
                
            }
            Console.WriteLine(encry_output);
        }
    }
}