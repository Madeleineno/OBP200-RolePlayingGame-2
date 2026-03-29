using System;
using System.Linq;

namespace OBP200_RolePlayingGame;

class ShopRoom : Room
{
   public ShopRoom(string name, string description) : base(name, description)
   {
   }
   public override void Interact(Player player)
   {
      Console.WriteLine("En vandrande köpman erbjuder sina varor:");
      bool shopping = true;
      while (shopping)
      {
         Console.WriteLine($"Guld: {player.Gold} | Drycker: {player.Potions}");
         Console.WriteLine("1) Köp dryck (10 guld)");
         Console.WriteLine("2) Köp vapen (+2 ATK) (25 guld)");
         Console.WriteLine("3) Köp rustning (+2 DEF) (25 guld)");
         Console.WriteLine("4) Sälj alla 'Minor Gem' (+5 guld/st)");
         Console.WriteLine("5) Lämna butiken");
         Console.Write("Val:  ");

         string choice = Console.ReadLine();
         if (choice == "1" && player.Gold >= 10)
         {
            player.Gold -= 10;
            player.Potions++;
            Console.WriteLine("Du köpte en dryck.");
         }
         else if (choice == "2" && player.Gold >= 25)
         {
            player.Gold -= 25;
            player.ATK += 2;
            Console.WriteLine("Du köpte bättre vapen!");
         }
         else if (choice == "3" && player.Gold >= 25)
         {
            player.Gold -= 25;
            player.DEF += 2;
            Console.WriteLine("Du köpte bättre rustning!");
         }
         else if (choice == "4")
         {
            int gemCount = player.Inventory.Count(item => item.Name == "Minor Gem");
            if (gemCount > 0)
            {
               int payout = gemCount * 5;
               player.Gold += payout;
               player.Inventory.RemoveAll(item => item.Name == "Minor Gem");
               Console.WriteLine($"Du sålde {gemCount}st Minor Gem för {payout} guld!");
            }
            else
            {
               Console.WriteLine("Inga 'Minor Gem' i väskan.");
            }
         }
         else if (choice == "5")
         {
               Console.WriteLine("Du säger adjö till köpmannen.");
               shopping = false;
         }
         else
         {
            Console.WriteLine("Köpmannen förstår inte ditt val.");
         }
      }
   }
}

