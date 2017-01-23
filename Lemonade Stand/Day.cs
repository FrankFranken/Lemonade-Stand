using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Day
    {
        public Weather weather;       
        Random random;
        string[] dayNames;

        public Day()
        {
            random = new Random();            
            weather = new Weather();
            dayNames = new string[7] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        }
        public void PrintDay(int index)
        {
            Console.WriteLine("\nDAILY WEATHER");
            Console.WriteLine(dayNames[index]);
        }
        public void PrintForcast(int index)
        {
            Console.WriteLine("\nDAILY FORCAST:");
            Console.WriteLine(dayNames[index]);
        }     
    }
}
        
    


