using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static int Width = 0;
        static int Height = 0;
        static int count = 0;

        static int start_x_1 = 0;
        static int start_y_1 = 0;
        static char[][,] all_maps = new char[1000][,];

        static char[,] map_copy;
        static void Main(string[] args)
        {
            Console.Write("請輸入迷宮大小(底,高)： ");
            String Size_str = Console.ReadLine();
            String[] Size = Size_str.Split(',');
            Width = int.Parse(Size[0]);
            
            Height = int.Parse(Size[1]);
            char[,] map = new char [Height, Width];
            map_copy = new char[Height, Width];

            int start_x=0, start_y=0, end_x=0, end_y=0;

            Console.WriteLine("輸入迷宮地圖:");
            for (int i = 0; i <Height; i++)
            {
                String Line = Console.ReadLine();
                char[] Line1 = Line.ToCharArray();
                
                for(int h =0; h < Width; h++)
                {
                    map[i,h] = Line1[h];

                }
            }


            for (int i = 0; i < Height; i++)
            {
                
                for (int h = 0; h < Width; h++)
                {
                    if (map[i, h] == '0')
                    {
                        start_x = h;
                        start_y = i;
                        start_x_1 = h;
                        start_y_1 = i;
                    }
                    if (map[i, h] == 'X')
                    {
                        end_x = h;
                        end_y = i;
                    }

                }
                
            }
            
          
            walk(ref map, start_x, start_y, end_x, end_y);
            map_copy = all_maps[8];
            Console.WriteLine();
            Console.WriteLine("Output:");
            for(int g = 0; g< 1000; g++)
            {
                
                
                if (all_maps[g] != null)
                {
                 
                    map_copy = all_maps[g];
                    for (int i = 0; i < Height; i++)
                    {


                        for (int h = 0; h < Width; h++)
                        {
                            Console.Write(map_copy[i, h]);
                            

                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine(g);
                    break;
                }
                if (g == 999)
                {
                    map[start_y_1, start_x_1] = '0';
                    for (int i = 0; i < Height; i++)
                    {


                        for (int h = 0; h < Width; h++)
                        {
                            Console.Write(map[i, h]);


                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("沒有路徑");

                }
               
            }
            

            Console.ReadKey();


        }
        static void walk(ref char[,] map,int start_x, int start_y, int end_x, int end_y)
        {
      
            map[start_y, start_x] = '*';
            if(start_x==end_x && start_y == end_y)
            {
                map_copy = new char[Height, Width];
                map[start_y_1, start_x_1] = '0';
                map[end_y, end_x] = 'X';
                for (int i = 0; i < Height; i++)
                {


                    for (int h = 0; h < Width; h++)
                    {

                        if (map[i, h] == '*')
                        {
                            count = count + 1;
                            
                        }
                        map_copy[i, h] = map[i, h];
                    }

                }
                all_maps[count] = map_copy; 

                count = 0;

                return;
            }
            

            if ((start_y-1>=0) && (map[start_y-1,start_x]==' ' || map[start_y - 1, start_x] == 'X'))
            {
                walk(ref map, start_x, start_y - 1, end_x, end_y);
            }
            if ((start_y + 1 < Height) && (map[start_y + 1, start_x] == ' ' || map[start_y + 1, start_x] == 'X'))
            {
                walk(ref map, start_x, start_y + 1, end_x, end_y);
            }
            if ((start_x - 1 >= 0) && (map[start_y, start_x-1] == ' ' || map[start_y, start_x - 1] == 'X'))
            {
                walk(ref map, start_x-1, start_y, end_x, end_y);
            }
            if ((start_x + 1 < Width) && (map[start_y, start_x + 1] == ' ' || map[start_y, start_x + 1] == 'X'))
            {
                walk(ref map, start_x +1, start_y, end_x, end_y);
            }
            map[start_y, start_x] = ' ';
        }
        
    }
}
