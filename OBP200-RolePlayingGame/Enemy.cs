using System;

namespace OBP200_RolePlayingGame;

public class Enemy : GameCharacter
{
    public int GoldReward { get; private set; }
    public int XPReward { get; private set; }
    
    public Enemy(string name, int hp, int atk, int def, int goldReward, int xpReward) : base(name, hp, atk, def)
    {
        GoldReward = goldReward;
        XPReward = xpReward;
    }
    
    public static Enemy CreateRandomEnemy()
    {
        var random = new Random();
        int hpMod = random.Next(-1, 3);
        int atkMod = random.Next(0, 2);
        int defMod = random.Next(0, 2);
        int xpMod = random.Next(0, 3);
        int goldMod = random.Next(0, 3);

        int type = random.Next(1, 5);
        switch (type)
        {
            case 1:
                return new Enemy("Vildsvin", 18 + hpMod, 4 + atkMod, 1 + defMod, 4 + goldMod, 6 + xpMod);
            case 2:
                return new Enemy("Skelett", 20 + hpMod, 5 + atkMod, 2 + defMod, 5 + goldMod, 7 + xpMod);
            case 3:
                return new Enemy("Bandit", 16 + hpMod, 6 + atkMod, 1 + defMod, 6 + goldMod, 8 + xpMod);
            default:
                return new Enemy("Geléslem", 14 + hpMod, 3 + atkMod, 0 + defMod, 3 + goldMod, 5 + xpMod);
        }
    }
    
    public static Enemy CreateBoss()
    {
        return new Enemy("Urdraken", 55, 9, 4, 50, 30);
    }
}
