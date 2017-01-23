using Lemonade_Stand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Player
    {
        public Wallet wallet;
        public Inventory inventory;
        public Recipe recipe;
        public string name;
        
        public Player()
        {
            wallet = new Wallet();
            inventory = new Inventory();
            recipe = new Recipe();            
        }
        public string NewPlayer()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            this.name = name;
            return this.name;
        }
        public void BuyItems(Player player)
        {
            Console.WriteLine("\nYou currently have $" + wallet.cash + " in your wallet " + name);
            Console.WriteLine("Each pitcher of Lemonade will need to contain: lemons, cups of sugar, ice, each pitcher will make 10 cups ");
            Console.WriteLine("\nPrice of Ingredients:");
            Console.WriteLine("Lemons: $0.10 \nSugar: $0.10/cup \nIce: $0.01 \nCups: $0.02");
            inventory.ShowInventory();
            Console.WriteLine("\nwould you like to purchase supplies?");
            Console.WriteLine("yes or no");
            string decision = Console.ReadLine().ToLower();
            switch (decision)
            {
                case "yes":
                    LemonCount(player);
                    break;
                case "no":
                    Console.WriteLine("press any key to continue");
                    break;
                default:
                    Console.WriteLine("Not a valid selection");
                    BuyItems(player);
                    break;
            }
        }
        public void LemonCount(Player player)
        {
            Console.WriteLine("How many Lemons?");
            try
            {
                int lemonQuanity = Convert.ToInt32(Console.ReadLine());
                SugarCount(lemonQuanity, player);
            }
            catch (Exception)
            {
                LemonCount(player);
                throw;
            }
        }
        public void SugarCount(int lemonQuantity, Player player)
        {
            try
            {
                Console.WriteLine("How many cups of Sugar?");
                int sugarQuantity = Convert.ToInt32(Console.ReadLine());
                IceCount(lemonQuantity, sugarQuantity, player);
            }
            catch (Exception)
            {
                SugarCount(lemonQuantity, player);
                throw;
            }            
        }
        public void IceCount(int lemonQuantity, int sugarQuantity, Player player)
        {
            try
            {
                Console.WriteLine("How many pieces of Ice?");
                int iceQuantity = Convert.ToInt32(Console.ReadLine());
                CupCount(lemonQuantity, sugarQuantity, iceQuantity, player);
            }
            catch (Exception)
            {
                IceCount(lemonQuantity, sugarQuantity, player);
                throw;
            }           
        }
        public void CupCount(int lemonQuantity, int sugarQuantity, int iceQuantity, Player player)
        {
            try
            {
                Console.WriteLine("How many Cups");
                int cupQuantity = Convert.ToInt32(Console.ReadLine());
                CashChecker(lemonQuantity, sugarQuantity, iceQuantity, cupQuantity, wallet, player);
            }
            catch (Exception)
            {
                CupCount(lemonQuantity, sugarQuantity, iceQuantity, player);

                throw;
            }
            
        }
        public void CashChecker(int lemonQuantity, int sugarQuantity, int iceQuantity, int cupQuantity, Wallet wallet, Player player)
        {
            Lemons lemon = new Lemons();
            var lemonprice = lemonQuantity * lemon.lemon;
            Sugar sugar = new Sugar();
            var sugarprice = sugarQuantity * sugar.sugar;
            Ice ice = new Ice();
            var iceprice = iceQuantity * ice.ice;
            Cups cups = new Cups();
            var cupprice = cupQuantity * cups.cups;
            decimal totalcost = (lemonprice + sugarprice + iceprice + cupprice);
            Console.WriteLine("\nCurrent cash in wallet: " + wallet.cash);
            Console.WriteLine("Shopping cart total: " + totalcost);            
            if (wallet.cash > totalcost)
            {
                Console.WriteLine("\nWould you like run the transaction?");
                Console.WriteLine("yes or no?");
                string decision = Console.ReadLine();
                switch (decision)
                {
                    case "yes":
                        wallet.cash = (wallet.cash - totalcost);
                        Console.WriteLine("Thank You Come Again!");
                        Console.WriteLine("Current wallet total: " + wallet.cash);
                        int pushlemonQuantity = lemonQuantity;
                        int pushsugarQuantity = sugarQuantity;
                        int pushiceQuantity = iceQuantity;
                        int pushcupQuantity = cupQuantity;
                        AddItem(pushlemonQuantity, pushsugarQuantity, pushiceQuantity, pushcupQuantity, player);
                        return;
                                     
                    case "no":
                        BuyItems(player);
                        break;
                    default:
                        CashChecker(lemonQuantity, sugarQuantity, iceQuantity, cupQuantity, wallet, player);
                        break;
                }
            }
            else
            {
                Console.WriteLine("You are poor and do not have enough to purchase these items");
                Console.WriteLine("Be very sad about your wallet and press any key to continue...");
                Console.ReadLine();
                BuyItems(player);
            }
        }
        public void AddItem(int pushlemonQuantity,int pushsugarQuantity, int pushiceQuantity, int pushcupQuantity, Player player)
        {
            player.inventory.CreateLemons(pushlemonQuantity, player);
            player.inventory.CreateSugar(pushsugarQuantity, player);
            player.inventory.CreateIce(pushiceQuantity, player);
            player.inventory.CreateCup(pushcupQuantity, player);
        }
    }
}

