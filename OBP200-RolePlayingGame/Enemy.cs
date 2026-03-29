using System;

namespace OBP200_RolePlayingGame;

public class Enemy : GameCharacter
{
    public int GoldReward { get; set; }
    public int XPReward { get; set; }
    
    public Enemy(string name, int hp, int atk, int def, int goldReward, int xpReward) : base(name, hp, atk, def)
    {
        GoldReward = goldReward;
        XPReward = xpReward;
    }
    
    public static Enemy CreateRandomEnemy()
    {
        var random = new Random();
        int alternatives = random.Next(1, 5);
        switch (alternatives)
        {
            case 1:
                return new Enemy("Vildsvin", 18, 4, 1, 4, 6);
            case 2:
                return new Enemy("Skelett", 20, 5, 2, 5, 7);
            case 3:
                return new Enemy("Bandit", 16, 6, 1, 6, 8);
            default:
                return new Enemy("Geléslem", 14, 3, 0, 3, 5);
        }
    }
    
    public static Enemy CreateBoss()
    {
        return new Enemy("Urdraken", 55, 9, 4, 50, 30);
    }
}
