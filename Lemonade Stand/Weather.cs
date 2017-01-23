using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Weather
    {
        Random random;
        List<string> newcond;
        List<int> newtemp;
        public string cond;
        public int temp;
        public Customer customer;
        public Weather()
        {
            random = new Random();
            customer = new Customer();
            newcond = new List<string> { "Sunny", "Overcast", "Raining", "HighWind" };
            newtemp = new List<int> { 50, 60, 70, 80, 90, 95, 100 };
        }
        public void DailyCondition()
        {
            foreach (var item in newcond)
            {
                string cond = newcond[random.Next(0, 4)];
                Console.WriteLine("Weather:" + cond);
                this.cond = cond;
                break;             
            }
            DailyTemp();
        }
        public void DailyTemp()
        {
            foreach (var item in newcond)
            {
                int temp = newtemp[random.Next(0, 7)];
                Console.WriteLine("Temp:" + temp);
                this.temp = temp;
                break;           
            }
        }
        public void DailyForcast()
        {
            foreach (var item in newcond)
            {
                string cond = newcond[random.Next(0, 4)];
                Console.WriteLine("Weather:" + cond);
                break;
            }
            foreach (var item in newcond)
            {
                int temp = newtemp[random.Next(0, 7)];
                Console.WriteLine("Temp:" + temp);
                break;
            }
        }
    }
}
