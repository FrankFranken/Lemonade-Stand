using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Inventory
    {
        public List<Lemons> lemons;
        public List<Ice> ices;
        public List<Sugar> sugars;
        public List<Cups> cups;

        public Inventory()
        {
            lemons = new List<Lemons>();
            ices = new List<Ice>();
            sugars = new List<Sugar>();
            cups = new List<Cups>();
        }
        public void CreateLemons(int pushlemonQuantity, Player player)
        {
            for (int i = 0; i < pushlemonQuantity; i++)
            {
                Lemons lemon = new Lemons();
                lemons.Add(lemon);               
            }
        }
        public void RemoveLemons(int pitchers)
        {
            for (int i = 0; i < pitchers; i++)
            {
                lemons.RemoveAt(0);
            }
        }
        public void CreateSugar(int pushsugarQuanity, Player player)
        {
            for (int i = 0; i < pushsugarQuanity; i++)
            {
                Sugar sugar = new Sugar();
                sugars.Add(sugar);
            }
        }
        public void RemoveSugar(int pitchers)
        {
            for (int i = 0; i < pitchers; i++)
            {             
            sugars.RemoveAt(0);
            }
        }
    public void CreateIce(int pushiceQuanity, Player player)
        {
            for (int i = 0; i < pushiceQuanity; i++)
            {
                Ice ice = new Ice();
                ices.Add(ice);
            }
        }
    public void RemoveIce(int pitcher)
    {
        for (int i = 0; i < pitcher; i++)
        {
            ices.RemoveAt(0);
        }
    }
    public void CreateCup(int pushcupQuantity, Player player)
        {
            for (int i = 0; i < pushcupQuantity; i++)
            {
                Cups cup = new Cups();
                cups.Add(cup);                
            }
        }
        public void RemoveCup(int pitcher)
        {
            for (int i = 0; i < pitcher; i++)
            {
                cups.RemoveAt(0);
            }
        }

        public void ShowInventory()
        {
            Console.WriteLine("\nWould you like to see your Inventory?");
            Console.WriteLine("yes or no");
            string decision = Console.ReadLine().ToLower();
            switch (decision)
            {
                case "yes":
                    ShowAllProductInventory();
                    break;
                case "no":
                    break;
                default:
                    ShowInventory();
                    break;
            }
        }
        public void ShowAllProductInventory()
        {
            Console.WriteLine("\nYou currently have:");
            Console.WriteLine("{0} lemons", lemons.Count);
            Console.WriteLine("{0} cups of sugar", sugars.Count);
            Console.WriteLine("{0} pieces of ice", ices.Count);
            Console.WriteLine("{0} cups\n", cups.Count);
        }
    }
}
