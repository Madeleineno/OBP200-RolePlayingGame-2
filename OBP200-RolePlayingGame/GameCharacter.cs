namespace OBP200_RolePlayingGame;

public abstract class GameCharacter
{
    public string Name { get; set; }
    public int HP { get; set; }
    public int MaxHP { get; set; }
    public int ATK { get; set; }
    public int DEF { get; set; }
    
    protected GameCharacter(string name, int hp, int atk, int def)
    {
        Name = name;
        MaxHP = hp;
        HP = hp;
        ATK = atk;
        DEF = def;
    }
}
    