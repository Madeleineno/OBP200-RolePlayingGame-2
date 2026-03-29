using System;
using System.Collections.Generic;
namespace OBP200_RolePlayingGame;

public class Map
{
    public static List<Room> GenerateMap()
    {
        List<Room> map = new List<Room>();
        
        map.Add(new CombatRoom("Skogsstig", "", Enemy.CreateRandomEnemy()));
        map.Add(new TreasureRoom("Gammal kista", ""));
        map.Add(new ShopRoom("Vandrande köpman", ""));
        map.Add(new CombatRoom("Grottans mynning", "", Enemy.CreateRandomEnemy()));
        map.Add(new RestRoom("Lägereld", ""));
        map.Add(new CombatRoom("Grottans djup", "", Enemy.CreateRandomEnemy()));
        map.Add(new CombatRoom("Urdraken", "", Enemy.CreateBoss()));
        return map;
    }
}