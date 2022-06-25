
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WindowsFormsApp6
{
    public class Pet
    {
        public static string name1 = "";
        

 
 
        private int health1;
        private int weight1;
        private int satisfaction1;
        private int emotion1;
        public static int egg = 0;

        public static int sick = 0;

        public static int death = 0;
        public static int sh = 0;

        Random rd = new Random();
        public Pet()
        {
            
        }
        public int health
        {
            get { return health1; }
            set {
                health1 = value;
                if (value >= 100)
                {
                    health1 = 100;
                }
                if (value <= 0)
                {
                    health1 = 0;
                }
                
            }
            
        }
        public int weight
        {
            get { return weight1; }
            set {
                weight1 = value;
                if (value >= 4000)
                {
                    weight1 = 4000;
                }
                if (value <= 0)
                {
                    weight1 = 0;
                }
                
            }

        }
        public int satisfaction
        {
            get { return satisfaction1; }
            set {
                satisfaction1 = value;
                if (value >= 100)
                {
                    satisfaction1 = 100;
                }
                if (value <= 0)
                {
                    satisfaction1 = 0;
                }
                
            }
            


        }
        public int emotion
        {
            get { return emotion1; }
            set {
                emotion1 = value;
                if (value >= 100)
                {
                    emotion1 = 100;
                }
                if (value <= 0)
                {
                    emotion1 = 0;
                }
                
            }

        }
    }
}