using System;
using System.Linq;

namespace OBP200_RolePlayingGame;


public class CombatRoom : Room
{
    public Enemy RoomEnemy { get; set; }

    public CombatRoom(string name, string description, Enemy enemy) : base(name, description)
    {
        RoomEnemy = enemy;
    }
    
    public override void Interact(Player player)
    {
        StartCombat(player);
    }

    
    private void StartCombat(Player player)
    {
        Console.WriteLine($"En {RoomEnemy.Name} dyker upp! (HP {RoomEnemy.MaxHP}, ATK {RoomEnemy.ATK}, DEF {RoomEnemy.DEF})");
        while (player.HP > 0 && RoomEnemy.HP > 0)
        {
            Console.WriteLine();
            Console.WriteLine($"[{player.Name} | {player.ClassName}] HP {player.HP}/{player.MaxHP} ATK {player.ATK} DEF {player.DEF} LVL {player.Level} XP {player.XP} Guld {player.Gold} Drycker {player.Potions}");
            var itemNames = player.Inventory.Select(item => item.Name).ToList();
            Console.WriteLine($"Väska: {string.Join(", ", itemNames)}");
            Console.WriteLine($"Fiende: {RoomEnemy.Name} HP={RoomEnemy.HP}");
            
            Console.WriteLine("[A] Attack  [X] Special  [P] Dryck  [R] Fly");
            if (RoomEnemy.Name == "Urdraken")
            {
                Console.WriteLine("(Du kan inte fly från en boss!)");
            }
            Console.Write("Val: ");
            
            string choice = Console.ReadLine()?.ToUpper();

            switch (choice)
            {
                case "A":
                    int damageToEnemy = player.CalculateBasicAttackDamage(RoomEnemy);
                    RoomEnemy.HP -= damageToEnemy;
                    Console.WriteLine($"Du slog {RoomEnemy.Name} för {damageToEnemy} skada.");
                    break;
                case "X":
                    int specialDamage = player.UseSpecialAttack(RoomEnemy);
                    if (specialDamage > 0)
                    {
                        RoomEnemy.HP -= specialDamage;
                        Console.WriteLine($"Special! {RoomEnemy.Name} tar {specialDamage} skada.");
                    }
                    break;
                case "P":
                    player.UsePotion();
                    break;
                case "R":
                    if (RoomEnemy.Name == "Urdraken")
                    {
                        Console.WriteLine("(Du kan inte fly från en boss!)");
                        continue;
                    }

                    if (player.TryFlee())
                    {
                        Console.WriteLine("Du flydde!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Misslyckad flykt!");
                    }
                    break;
                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    continue;
            }

            if (RoomEnemy.HP > 0)
            {
                Random rng = new Random();
                int roll = rng.Next(0, 3);
                int damageFromEnemy = Math.Max(1, RoomEnemy.ATK - (player.DEF/2)) + roll;
                if (rng.NextDouble() < 0.1)
                {
                    damageFromEnemy = Math.Max(1, damageFromEnemy - 2);
                }
                player.HP -= damageFromEnemy;
                Console.WriteLine($"{RoomEnemy.Name} anfaller och gör {damageFromEnemy} skada!");
            }
        }

        if (player.HP > 0)
        {
            Console.WriteLine($"Seger! +{RoomEnemy.XPReward} XP, +{RoomEnemy.GoldReward} guld.");
            player.Gold += RoomEnemy.GoldReward;
            player.GainXP(RoomEnemy.XPReward);

            if (new Random().NextDouble() < 0.35)
            {
                string drop = RoomEnemy.Name == "Urdraken" ? "Dragon Scale" : "Minor Gem";
                player.Inventory.Add(new Item(drop));
                Console.WriteLine($"Föremål hittat: {drop} (lagt i din väska)");
            }
        }
        else
        {
            Console.WriteLine($"Spelet över. {player.Name} har fallit i strid...");
        }
    }
}