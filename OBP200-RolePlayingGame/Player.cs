using System;

namespace OBP200_RolePlayingGame;

public class Player : GameCharacter
{
    public string ClassName { get; private set; }
    public int Gold { get; set; }
    public int XP { get; private set; }
    public int Level { get; private set; }
    public int Potions { get; set; }
    public List <Item> Inventory { get; set; }

    public Player(string name, string className, int hp, int atk, int def, int gold, int potions) : base(name, hp, atk, def)
    {
        ClassName = className;
        Gold = gold;
        Potions = potions;
        XP = 0;
        Level = 1;
        Inventory = new List<Item>
        {
            new Item("Wooden Sword"),
            new Item("Cloth Armor")
        };
    }
  
    public static Player CreatePlayer(string name, string classChoice)
    {
        if (classChoice == "2")
        {
            return new Player(name, "Mage", 28, 10, 2, 15, 2);
        }
        else if (classChoice == "3")
        {
            return new Player(name, "Rogue", 32, 8, 3, 20, 3);
        }
        else
        {
            return new Player(name, "Warrior", 40, 7, 5, 15, 2);
        }  
    }
    
    
    public void GainXP(int amount)
    {
        XP += amount;
        int nextLevel = Level == 1 ? 10 : (Level == 2 ? 25 : (Level == 3 ? 45 : Level * 20));
        if (XP >= nextLevel)
        {
            LevelUp();
        }
    }
    
    private void LevelUp()
    {
        Level++;
        if (ClassName == "Warrior")
        {
            MaxHP += 6; 
            ATK += 2; 
            DEF += 2;
        }
        
        else if (ClassName == "Mage") 
        { MaxHP += 4; 
            ATK += 4; 
            DEF += 1; 
        }
        
        else if (ClassName == "Rogue")
        {
            MaxHP += 5;
            ATK += 3;
            DEF += 1;
        }
        else
        {
            MaxHP += 4; ATK += 3; DEF += 1;
        }
        HP = MaxHP;
        Console.WriteLine($"Du når nivå {Level}! Värden ökade och HP återställd.");
    }
    
    
    public void UsePotion()
    {
        if (Potions > 0)
        {
            int maxHealAmount = 12;
            int healthRestored = Math.Min(maxHealAmount, MaxHP - HP);
            HP += healthRestored;
            Potions--;
            Console.WriteLine($"Du dricker en dryck och återfår {healthRestored} HP.");
        }
        else
        {
            Console.WriteLine("Du har inga drycker kvar!");
        }
    }

    
    public bool TryFlee()
    {
        var random = new Random();
        double chance = 0.25;

        if (ClassName == "Rogue") chance = 0.50;
        else if (ClassName == "Mage") chance = 0.35;
        return random.NextDouble() < chance;
    }
    
    public int UseSpecialAttack(Enemy target)
    {
        var random = new Random();
        int specialDmg = 0;
        if (ClassName == "Warrior")
        {
            Console.WriteLine("Warrior använder Heavy Strike!");
            specialDmg = Math.Max(2, ATK + 3 - target.DEF);
            HP -= 2;
            Console.WriteLine("Du tar 2 skada av ansträngningen!");
        }
        else if (ClassName == "Mage")
        {
            if (Gold >= 3)
            {
                Console.WriteLine("Mage kastar Fireball!");
                Gold -= 3;
                specialDmg = Math.Max(3, ATK + 5 - (target.DEF/2));
            }
            else
            {
                Console.WriteLine("Inte tillräckligt med guld för att kasta Fireball (kostar 3).");
                return 0;
            }
        }
        else if (ClassName == "Rogue")
        {
            if (random.NextDouble() < 0.5)
            {
                Console.WriteLine("Rogue utför en lyckad Backstab!");
                specialDmg = Math.Max(4, ATK + 6);
            }
            else
            {
                Console.WriteLine("Backstab misslyckades!");
                specialDmg = 1;
            }
        }
        if (target.Name == "Urdraken")
        {
            specialDmg = (int)Math.Round(specialDmg * 0.8);
        }
        return specialDmg;
    }

    public int CalculateBasicAttackDamage(Enemy target)
    {
        var random = new Random();
        int baseDmg = Math.Max(1, ATK - (target.DEF / 2));
        int roll = random.Next(0, 3);

        if (ClassName == "Warrior")
        {
            baseDmg += 1;
        }
        else if (ClassName == "Mage")
        {
            baseDmg += 2;
        }
        else if (ClassName == "Rogue")
        {
            if (random.NextDouble() < 0.2)
            {
                baseDmg += 4;
                Console.WriteLine("Kritisk träff!");
            }
        }

        return Math.Max(1, baseDmg + roll);
    }
}