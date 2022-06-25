using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace ConsoleApp1
{
    class Program
    {
        public static int space = 0;
        
        static void Main(string[] args)
        {

            Console.Write("1月1號星期幾(1~7):");
            String WeekDay1_str = Console.ReadLine();
            Regex rgx = new Regex(@"[1-9]");
            int i = 0;
            int[] array_month = new int[] { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
            bool result1 = int.TryParse(WeekDay1_str, out i);
            
            
            if (result1 == false) 
            {
                Console.WriteLine("請輸入範圍內的整數");
                Console.ReadKey();
                return;
            }
            else if(int.Parse(WeekDay1_str) > 7 || int.Parse(WeekDay1_str) < 1)
            {
                Console.WriteLine("超出範圍");
                Console.ReadKey();
                return;
            }
            int WeekDay1 = int.Parse(WeekDay1_str);


            Console.Write("從幾月開始(1~12):");
            String Month1_str = Console.ReadLine();
            i=0;
            bool result2 = int.TryParse(Month1_str, out i);
            if (result2 == false)
            {
                Console.WriteLine("請輸入範圍內的整數");
                Console.ReadKey();
                return;
            }
            else if (int.Parse(Month1_str) > 12 || int.Parse(Month1_str) < 1)
            {
                Console.WriteLine("超出範圍");
                Console.ReadKey();
                return;
            }
            int Month1 = int.Parse(Month1_str);
            
            space = space + WeekDay1 - 1;
            for (int h =1; h < Month1; h++)
            {
                space = space + array_month[h];
            }
            for(int k = Month1; k<=12; k++)
            {
                
               
                if (k == 1)
                {
                    space = space + 31;
                    Console.WriteLine(" January");
                    
                    Console.WriteLine(" Mon Tue Wed Thu Fri Sat Sun");
                    int month_day = 31;
                    
                    for(int a1 = 1; a1 < WeekDay1; a1++)
                    {
                        Console.Write("    ");
                    }
                   

                    for (int a = 1; a <= month_day; a++)
                    {

                        //////////////////
                        if (a < 10)
                        {
                            Console.Write("   ");
                        }
                        else
                        {
                            Console.Write("  ");
                        }
                        ///////////////
                        if ((a + WeekDay1-1)%7==0 && a !=1)
                        {
                            Console.WriteLine("{0}",a); 
                        }
                        else
                        { 
                            Console.Write("{0}", a);     
                        }

                    }
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
                
                if (k == 2)
                {
                    Console.WriteLine(" February");
                    Month2to12(28);
                }
                if (k == 3)
                {
                    Console.WriteLine(" March");
                    Month2to12(31);
                }
                if (k == 4)
                {
                    Console.WriteLine(" April");
                    Month2to12(30);
                }
                if (k == 5)
                {
                    Console.WriteLine(" May");
                    Month2to12(31);
                }
                if (k == 6)
                {
                    Console.WriteLine(" June");
                    Month2to12(30);
                }
                if (k == 7)
                {
                    Console.WriteLine(" July");
                    Month2to12(31);
                }
                if (k == 8)
                {
                    Console.WriteLine(" August");
                    Month2to12(31);
                }
                if (k == 9)
                {
                    Console.WriteLine(" September");
                    Month2to12(30);
                }
                if (k == 10)
                {
                    Console.WriteLine(" October");
                    Month2to12(31);
                }
                if (k == 11)
                {
                    Console.WriteLine(" November");
                    Month2to12(30);
                }
                if (k == 12)
                {
                    Console.WriteLine(" December");
                    Month2to12(31);
                }



            }
            Console.ReadKey();
        }
        static void Month2to12(int monthday)
        {
            int x = 0;
            
            x = space % 7;

            Console.WriteLine(" Mon Tue Wed Thu Fri Sat Sun");
            int month_day = monthday;

            for (int a1 = 1; a1 <= x; a1++)
            {
                Console.Write("    ");
            }


            for (int a = 1; a <= month_day; a++)
            {

                //////////////////
                if (a < 10)
                {
                    Console.Write("   ");
                }
                else
                {
                    Console.Write("  ");
                }
                ///////////////
                if ((a + x) % 7 == 0)
                {
                    Console.WriteLine("{0}", a);
                  
                }
                else
                {

                    Console.Write("{0}", a);
                 

                }


            }

            Console.WriteLine("");
            Console.WriteLine("");
            space = space + monthday;
        }
        
    }
}
