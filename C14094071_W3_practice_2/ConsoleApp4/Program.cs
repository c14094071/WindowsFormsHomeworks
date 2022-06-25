using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static String[] coord;
        static void Main(string[] args)
        {
            int i = 0;
            Console.Write("地圖大小(1~10)：");
            String Size_str = Console.ReadLine();
            bool integ1 = int.TryParse(Size_str, out i);
            if (integ1 == false)
            {
                Console.WriteLine("請輸入範圍內的整數");
                Console.ReadKey();
                return;
            }
            else if (int.Parse(Size_str) <= 0 || int.Parse(Size_str) > 10)
            {
                Console.WriteLine("超出範圍");
                Console.ReadKey();
                return;
            }
            int Size = int.Parse(Size_str);


            Console.Write("地雷數量(1~10)：");
            String Quantity_str = Console.ReadLine();

            i = 0;
            bool integ2 = int.TryParse(Quantity_str, out i);
            if (integ2 == false)
            {
                Console.WriteLine("請輸入範圍內的整數");
                Console.ReadKey();
                return;
            }
            else if (int.Parse(Quantity_str) <=0 || int.Parse(Quantity_str) > 10)
            {
                Console.WriteLine("超出範圍");
                Console.ReadKey();
                return;
            }
            int Quantity = int.Parse(Quantity_str);

            Array co = new Array[Quantity];
            String[,] map = new string[Size + 2, Size + 2] ;
            for(int u=0; u<Size+2;u++)
            {
                for(int o=0; o < Size + 2; o++)
                {
                    map[u, o] = "0";
                }
                
            }

            
            String coordline;
            
            int a=0, b=0;
            for(int h=0; h<Quantity;h++)
            {
                Console.Write("第 {0} 個地雷的位置(以空白區隔)：", h);
                coordline = Console.ReadLine();
                try
                {
                    coord = coordline.Split(' ');
                    a = int.Parse(coord[0]);
                    b = int.Parse(coord[1]);
                }
                catch
                {
                    Console.WriteLine("請輸入兩個以空白區隔的整數");
                    Console.ReadKey();
                    return;
                }
                
                if(a>=Size || b>=Size || a<=-1 || b<=-1)
                {
                    Console.WriteLine("地雷位置超出範圍");
                    Console.ReadKey();
                    return;
                }

                
                
               
                map[b+1,a+1] = ("X");

            }
            Console.WriteLine("---");
            ///////寫入數字//////
            int count = 0;
            for (int u = 1; u < Size + 1; u++)
            {
                for (int o = 1; o < Size + 1; o++)
                {
                    if (map[u, o] == "X")
                    {

                    }
                    else
                    {
                        if (map[u - 1, o - 1] == "X")
                        {
                            count = count +1;
                        }
                        if (map[u - 1, o] == "X")
                        {
                            count = count + 1;
                        }
                        if (map[u - 1, o + 1] == "X")
                        {
                            count = count + 1;
                        }
                        if (map[u, o - 1] == "X")
                        {
                            count = count + 1;
                        }
                        if (map[u, o + 1] == "X")
                        {
                            count = count + 1;
                        }
                        if (map[u + 1, o - 1] == "X")
                        {
                            count = count + 1;
                        }
                        if (map[u + 1, o] == "X")
                        {
                            count = count + 1;
                        }
                        if (map[u + 1, o + 1] == "X")
                        {
                            count = count + 1;
                        }
                        map[u, o] = count.ToString();
                        
                    }
                    count = 0;
                    
                    
                }
                

            }

            /////////////////////////////
            for (int u = 1; u < Size + 1; u++)
            {
                for (int o = 1; o < Size + 1; o++)
                {
                    Console.Write(map[u, o]);
                }
                Console.WriteLine("\n");

            }
            ////////////////////////////
       
            Console.ReadKey();
        }
    }
}
