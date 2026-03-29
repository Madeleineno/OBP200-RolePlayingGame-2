using System;

namespace OBP200_RolePlayingGame;

public class RestRoom : Room
{
    public RestRoom(string name, string description) : base(name, description) {}
    

    public override void Interact(Player player)
    {
        Console.WriteLine("Du slår läger och vilar.");
        player.HP = player.MaxHP;
        Console.WriteLine("HP återställt till max.");
    }
}