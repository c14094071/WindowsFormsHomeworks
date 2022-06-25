
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WindowsFormsApp5
{
    class Decryption
    {
        public static String decry_input = "";
        public static String decry_output = "";

        public Decryption()
        {

        }
        public void transfor()
        {
            Console.WriteLine(decry_input);
            foreach (char value in decry_input)
            {
                Console.WriteLine("1");
                int num1 = Substitution.subst_str.IndexOf(value);
                try
                {
                    decry_output = String.Concat(decry_output, Alphabet.alpha[num1]);
                }
                catch
                {
                    decry_output = String.Concat(decry_output, " ");
                }


            }
            
        }
    }
}