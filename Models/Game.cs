using System;

namespace StoryAdventure.Models
{
  public class Game
  {
    public string PlayerName { set; get; }
    public int Room { set; get; }
    public bool Note { set; get; }

    public Game(string playerName, int room)
    {
      PlayerName = playerName;
      Room = room;
      Note = false;
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
      Console.WriteLine(@"
      You stand on the doorstep of a run-down house. What would you like to do?
        K: Knock on the door
        O: Open the door
        W: Walk around to the backyard");
      string input = Console.ReadLine();
      string lowerInput = input.ToLower();
      if (input == "k")
      {
        Console.WriteLine("You hear a voice from the other side of the door. 'What is the password?'");
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
        LoadRoomBack();
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
        LoadRoomBack();
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
    public void LoadRoomBack()
    {

    }
  }
}