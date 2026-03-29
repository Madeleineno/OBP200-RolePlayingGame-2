using System;
using System.Collections.Generic;

namespace OBP200_RolePlayingGame;

class Program
{
 
 static void Main(string[] args)
 {
  while (true)
  {
   Console.WriteLine("=== Text-RPG ===");
   Console.WriteLine("1. Nytt spel");
   Console.WriteLine("2. Avsluta");
   Console.Write("Välj: ");

   string choice = Console.ReadLine();
   if (choice == "1")
   {
    StartGame();
   }
   else if (choice == "2")
   {
    Console.WriteLine("Avslutar spelet...");
    break;
   }
   else
   {
    Console.WriteLine("Ogiltigt val.");
   }
  }
 }
 
 static void StartGame()
 {
  Console.WriteLine("Ange namn: ");
  string namn = Console.ReadLine();
  Console.WriteLine("Välj klass: 1) Warrior 2) Mage 3) Rogue");
  Console.WriteLine("Val: ");
  string classChoice = Console.ReadLine();
  Player player = Player.CreatePlayer(namn, classChoice);
  Console.WriteLine($"Välkommen, {player.Name} the {player.ClassName}!");

  List<Room> map = Map.GenerateMap();
  PlayAdventure(player, map);
 }

 
 static void PlayAdventure(Player player, List<Room> map)
 {
  for (int i = 0; i < map.Count; i++)
  {
   Console.WriteLine($"--- Rum {i + 1}/{map.Count}: {map[i].Name} ---");
   map[i].Interact(player);

   if (player.HP <= 0)
   {
    Console.WriteLine("Du har stupat... Spelet över.");
    return;
   }

   if (i == map.Count - 1)
   {
    Console.WriteLine("GRATTIS! Du har klarat spelet!");
    return;
   }

   Console.WriteLine("[C] Fortsätt  [Q] Avsluta till huvudmeny");
   string playOrQuit = Console.ReadLine()?.ToUpper();
   if (playOrQuit == "Q") return;
  }
 }
}
