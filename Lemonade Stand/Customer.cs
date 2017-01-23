using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Customer
    {    
        public double tempcustomers;
        public double condcustomers;
        public double pricecustomers;       
        public decimal price;
        public double allcustomers;
        public List<Customer> customer;
        public decimal dailyProfit;
        public Player player;
        private int pitchers;

        public Customer()
        {
            customer = new List<Customer>();
            player = new Player();
        }
        public void CustomerConditions(Weather weather)
        {        
            TempCustomers(weather);
            CondCustomers(weather);
            SetPrice();
            PriceCustomers();
            AddConditions();
            IsThirsty();    
            CreateCustomers();      
        }    
        public void TempCustomers(Weather weather)
        {
            if (weather.temp >= 80)
            {
                tempcustomers = 100 / 1.25;
            }
            else if(weather.temp == 70)
            {
                tempcustomers = 100 / 1.75;
            }
            else if(weather.temp <= 60)
            {
                tempcustomers = 100 / 2.75;
            }
        }
        public void CondCustomers(Weather weather)
        {
            if (weather.cond == "Sunny")
            {
                condcustomers = 100 / 1.75;
            }
            else if(weather.cond == "Overcast")
            {
                condcustomers = 100 / 2.5;
            }
            else if(weather.cond == "Raining")
            {
                condcustomers = 100 / 8.5;
            }
            else if(weather.cond == "HighWind")
            {
                condcustomers = 100 / 10;
            }
        }
        public decimal SetPrice()
        {
            Console.WriteLine("\nHow much do you want to charge per cup (X.XX)?");            
            try
            {
                decimal price = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("charging $" + price + " per cup");
                this.price = price;
                Console.WriteLine("\nPress any key to run day");
                Console.ReadLine();
                int milliseconds = 2000;
                Thread.Sleep(milliseconds);
            }
            catch (Exception)
            {
                Console.WriteLine("please enter a dollar amount. EXAMPLE: 0.25");
                SetPrice();         
            }
            return this.price;
        }
        public void PriceCustomers()
        {
            if (price <= 0.05m)
            {
                pricecustomers = 100 / 1.25;
            }
            else if (price > 0.05m || price < 0.10m)
            {
                pricecustomers = 100 / 1.5;
            }
            else if (price > 0.10m || price < 0.20m)
            {
                pricecustomers = 100 / 2;
            }
            else if (price > 0.20m || price < 0.40m)
            {
                pricecustomers = 100 / 4;
            }
            else if (price > 0.40m || price < 0.90m)
            {
                pricecustomers = 100 / 10;
            }
            else if (price > 0.90m)
            {
                pricecustomers = 100 / 50;
            }        
        }
        public void AddConditions()
        {
            double allcustomers = (condcustomers + tempcustomers + pricecustomers);
            this.allcustomers = allcustomers;
        }
        public void IsThirsty()
        {
            Random random = new Random();
            this.allcustomers = random.Next(1,100);
            if (allcustomers % 2 == 0)
            {
                allcustomers++;
            }
            else if(allcustomers % 2 != 0)
            {
                return;
            }
        }
        public void CreateCustomers()
        {
            for (int i = 0; i < allcustomers; i++)
            {
                Customer newcustomer = new Customer();
                this.customer.Add(newcustomer);
            }
        }
        public void BuyLemonade(Inventory inventory, Pitcher pitcher, Recipe recipe, Wallet wallet)
        {                      //10 cups in a pitcher
            int readyToBuy = customer.Count / 10;                       
            for (int i = 0; i < readyToBuy; i++)
            {
                if (recipe.dailypitchers.Count > 0)
                {
                    recipe.dailypitchers.RemoveAt(0);
                    this.pitchers++;

                }
                else if (recipe.dailypitchers.Count == 0)
                {
                    Console.WriteLine("You are out of supplies");
                    break;
                }              
            }
            Console.WriteLine("you have sold " + pitchers * 10 + " cups of Lemonade");
            this.dailyProfit = pitchers * 10 * price;
            Console.WriteLine("You have made " + this.dailyProfit + " profit today");
            wallet.cash = (wallet.cash + dailyProfit);
            Console.WriteLine("Your new wallet total is " + wallet.cash);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
    }
}
