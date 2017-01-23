using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Recipe
    {
        public Pitcher pitcher;
        public List<Pitcher> dailypitchers;
       
        public Recipe()
        {
            pitcher = new Pitcher();
            dailypitchers = new List<Pitcher>();
        }
        public void CreatePitchers(Player player)
        {
            
            Console.WriteLine("How many pitchers would you like to make?");
            try
            {
                int pitchers = Convert.ToInt32(Console.ReadLine());
                CreatePitchers(pitchers, player);
            }
            catch (Exception)
            {
                CreatePitchers(player);
                throw;
            }
        }
        public void CreatePitchers(int pitchers, Player player)
        {
            if (!(pitchers * player.recipe.pitcher.lemons <=  player.inventory.lemons.Count))
            {
                Console.WriteLine("You dont have enough lemons");
                Console.WriteLine("Would you like to try to create more pitchers? yes or no?");
                string decision = Console.ReadLine().ToLower();
                switch (decision)
                {
                    case "yes":
                        CreatePitchers(player);
                        break;
                    case "no":
                        return;
                }
            }
            else if (!(pitchers * pitcher.sugar <= player.inventory.sugars.Count))
            {
                Console.WriteLine("You don't have enough sugar");
                Console.WriteLine("Would you like to try to create more pitchers? yes or no?");
                string decision = Console.ReadLine().ToLower();
                switch (decision)
                {
                    case "yes":
                        CreatePitchers(player);
                        break;
                    case "no":
                        return;
                }
            }
            else if (!(pitchers * pitcher.ice <= player.inventory.ices.Count))
            {
                Console.WriteLine("You don't have enough ice");
                Console.WriteLine("Would you like to try to create more pitchers? yes or no?");
                string decision = Console.ReadLine().ToLower();
                switch (decision)
                {
                    case "yes":
                        CreatePitchers(player);
                        break;
                    case "no":
                        return;
                }
            }
            else if (!(pitchers * pitcher.cups <= player.inventory.cups.Count))
            {
                Console.WriteLine("you don't have enough cups");
                Console.WriteLine("Would you like to try to create more pitchers? yes or no?");
                string decision = Console.ReadLine().ToLower();
                switch (decision)
                {
                    case "yes":
                        CreatePitchers(player);
                        break;
                    case "no":
                        return;
                }
            }
            else
            {
                player.inventory.RemoveLemons(pitchers * pitcher.lemons);
                player.inventory.RemoveSugar(pitchers * pitcher.sugar);
                player.inventory.RemoveIce(pitchers * pitcher.ice);
                player.inventory.RemoveCup(pitchers * pitcher.cups);
                for (int i = 0; i < pitchers; i++)
                {
                    pitcher = new Pitcher();
                    dailypitchers.Add(pitcher);                           
                }
                Console.WriteLine("You have created: " + dailypitchers.Count + " Pitchers\n");
            }
        }
    }
}
