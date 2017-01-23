using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Pitcher
    {
        public int lemons;
        public int sugar;
        public int ice;
        public int cups = 10;
        
        public void SetIngredients()
        {
            Console.WriteLine("Each pitcher of Lemonade will need to contain: lemons, cups of sugar, ice, and will make 10 cups");
            Console.WriteLine("Unused ingredients will spoil");
            SetLemons();
            SetSugar();
            SetIce();                   
        }
        public int SetLemons()
        {
            Console.WriteLine("\nHow many lemons in a pitcher?");
            try
            {
                int lemons = Convert.ToInt16(Console.ReadLine());
                this.lemons = lemons;
                return this.lemons;
            }
            catch (Exception)
            {
                Console.WriteLine("please enter a valid number");
                SetLemons();
                throw;
            }
            
        }
        public int SetSugar()
        {
            Console.WriteLine("How much sugar in a pitcher?");
            try
            {
                int sugar = Convert.ToInt16(Console.ReadLine());
                this.sugar = sugar;
                return this.sugar;
            }
            catch (Exception)
            {
                Console.WriteLine("please enter a valid number");
                SetSugar();
                throw;
            }
        }
        public int SetIce()
        {
            Console.WriteLine("How much ice in a pitcher?");
            try
            {
                int ice = Convert.ToInt16(Console.ReadLine());
                this.ice = ice;
                return this.ice;
            }
            catch (Exception)
            {
                Console.WriteLine("please enter a valid number");
                SetIce();
                throw;
            }
        }       
    }
}
