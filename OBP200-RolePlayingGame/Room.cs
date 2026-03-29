namespace OBP200_RolePlayingGame;

/*
 Abstrakt basklass för alla rum i spelet.
 Samlar alla gemensamma egenskaper för att undvika kodupprepning.
 Klassen är abstrakt så att ett rum inte ska kunna skapas utan specifika underklasser.
 */
public abstract class Room : IInteractable
{
   public string Name {get; set;} 
   public string Description {get; set;}

   protected Room(string name, string description)
   {
      Name = name;
      Description = description;
   }
   public abstract void Interact(Player player);
}