using System;

namespace StoryAdventure.Models
{
  public class Game
  {
    public string PlayerName { set; get; }
    public int Room { set; get; }
    public bool Note { set; get; }
    public bool Food { set; get; }

    public Game(string playerName, int room)
    {
      PlayerName = playerName;
      Room = room;
      Note = false;
      Food = false;
    }
    public void RunGame()
    {
      LoadRoom();
      Console.WriteLine(PlayerName);
    }
    public void LoadRoom()
    {
      if (Room == 0)
      {
        LoadRoomDoorstep();
      }
    }
    public void LoadRoomDoorstep()
    {
      Console.BackgroundColor = ConsoleColor.Blue;
      Console.ForegroundColor = ConsoleColor.DarkGray;
      Console.WriteLine(@"
      You stand on the doorstep of a run-down house. What would you like to do?
        K: Knock on the door
        O: Open the door
        W: Walk around to the backyard");
      string input = Console.ReadLine();
      string lowerInput = input.ToLower();
      if (input == "k")
      {
        Console.WriteLine(@"You hear a voice from the other side of the door. 
' _    _ _   _  ___ _____   _____ _____   _____ _   _ _____  ______  ___  _____ _____ _    _ _________________ ___  
| |  | | | | |/ _ |_   _| |_   _/  ___| |_   _| | | |  ___| | ___ \/ _ \/  ___/  ___| |  | |  _  | ___ |  _  |__ \ 
| |  | | |_| / /_\ \| |     | | \ `--.    | | | |_| | |__   | |_/ / /_\ \ `--.\ `--.| |  | | | | | |_/ | | | |  ) |
| |/\| |  _  |  _  || |     | |  `--. \   | | |  _  |  __|  |  __/|  _  |`--. \`--. | |/\| | | | |    /| | | | / / 
\  /\  | | | | | | || |    _| |_/\__/ /   | | | | | | |___  | |   | | | /\__/ /\__/ \  /\  \ \_/ | |\ \| |/ / |_|  
 \/  \/\_| |_\_| |_/\_/    \___/\____/    \_/ \_| |_\____/  \_|   \_| |_\____/\____/ \/  \/ \___/\_| \_|___/  (_)'");
        string password = Console.ReadLine();
        string passwordLower = password.ToLower();
        if (passwordLower == "password")
        {
          Console.WriteLine("The door opens a crack. 'Prove it', the voice says.");
          Console.WriteLine("H: Hand them something");
          string entry = Console.ReadLine();
          string entryLower = entry.ToLower();
          if (entryLower == "h" && Note == true)
          {
            Console.WriteLine("The door opens with a creak and you step inside.");
            Note = false;
            LoadRoomFoyer();
          }
          else
          {
            Console.WriteLine("You have nothing to give them.");
            LoadRoomDoorstep();
          }
        }
        else
        {
          Console.WriteLine("That's incorrect! Go away!");
          LoadRoomDoorstep();
        }
      }
      else if (input == "o")
      {
        Console.WriteLine("You rattle the handle, but the door will not budge.");
        LoadRoomDoorstep();
      }
      else if (input == "w")
      {
        LoadRoomBackyard();
      }
      else
      {
        LoadRoomDoorstep();
      }
    }
    public void LoadRoomBackyard()
    {
      Console.WriteLine(@"
      You enter the backyard and look around. In one corner is a small apple tree. In the other, a sleeping dog.
        T: Inspect the apple tree
        D: Approach the sleeping dog
        S: Sneak in using the backdoor
        F: Go back to the front door
      ");
      string input = Console.ReadLine();
      string lowerInput = input.ToLower();
      if (input == "t")
      {
        LoadRoomTree();
      }
      else if (lowerInput == "d")
      {
        Console.WriteLine("The dog wakes as you approach! Barking angrily, it chases you out of the yard. Game Over.");
        GameOver();
      }
      else if (lowerInput == "s")
      {
        LoadRoomKitchen();
      }
      else if (lowerInput == "f")
      {
        LoadRoomDoorstep();
      }
    }

    public void LoadRoomTree()
    {
    if (Note == true)
    {
      Console.WriteLine("You already have the note from the tree.");
      LoadRoomBackyard();
    }
    else
    {
      Console.WriteLine(@"You inspect the tree and find a note saying:
                          'Password to enter the house is: This note!' ..it says 'Password'
                          
                          What will you do?
                          T: Take the note
                          S: Sneak in using the backdoor
                          F: Go back to the front door");
      string yardInput = Console.ReadLine();
      string yardInputLower = yardInput.ToLower();
      if (yardInputLower == "s")
      {
        LoadRoomKitchen();
      }
      else if (yardInputLower == "f")
      {
        LoadRoomDoorstep();
      }
      else if (yardInputLower == "t")
        Console.WriteLine("You pull the note from the tree. This will help!");
        Note = true;
        LoadRoomBackyard();
      }
    }
    public void LoadRoomFoyer()
    {
      Console.WriteLine(@"
      ");
    }
    public void GameOver()
    {

    }
    public void LoadRoomKitchen()
    {
      Console.WriteLine(@"You come inside and realize you are in the kitchen. You see leftover food on the table and a door to the rest of the house. You will:
        T: take the food
        Y: go back to the yard
        D: open the door to the rest of the house");
      string kitchenInput = Console.ReadLine();
      string kitchenInputLower = kitchenInput.ToLower();
      if(kitchenInputLower == "t")
      {
        if (Food == false)
        {
        Food = true;
        Console.WriteLine("You take a half-eaten piece of steak.");
        LoadRoomKitchen();
        }
        else
        {
          Console.WriteLine("You have already taken the only food worth taking from the plate.");
          LoadRoomKitchen();
        }
      }
      else if (kitchenInputLower == "y")
      {
        LoadRoomBackyard();
      }
      else if (kitchenInputLower == "d")
      {
        if(Food == true)
        {
          Console.WriteLine("A very angry hungry ogre jumps out yelling and kills you. You are dead.");
          GameOver();
        }
        else if(Food == false)
        {
          Console.WriteLine("The door seems blocked. Voice on the other side says: 'I'm starving! You got any food??'");
          LoadRoomKitchen();
        }
      }
    }
  }
}