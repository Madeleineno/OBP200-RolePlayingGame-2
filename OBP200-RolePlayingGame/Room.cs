namespace OBP200_RolePlayingGame;

public abstract class Room : IInteractable
{
   public string Name { get; private set; } 
   public string Description { get; protected set; }

   protected Room(string name, string description)
   {
      Name = name;
      Description = description;
   }
   public abstract void Interact(Player player);
}