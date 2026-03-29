using System;

namespace OBP200_RolePlayingGame;


public class TreasureRoom : Room
{
    public TreasureRoom(string name, string description) : base(name, description) {}
    
    public override void Interact(Player player)
    {
        Console.WriteLine("Du hittar en gammal kista...");
        var random = new Random();
        if (random.NextDouble() < 0.5)
        {
            int gold = random.Next(8, 15);
            player.Gold += gold;
            Console.WriteLine($"Kistan innehåller {gold} guld!");
        }
        else
        {
            string[] items = { "Iron Dagger", "Oak Staff", "Leather Vest", "Healing Herb" };
            string foundItem = items[random.Next(items.Length)];

            player.Inventory.Add(new Item(foundItem));
            Console.WriteLine($"Du plockar upp: {foundItem}");
        }
    }
}