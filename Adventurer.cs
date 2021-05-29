using System.Collections.Generic;

namespace Quest
{
    // An instance of the Adventurer class is an object that will undergo some challenges
    public class Adventurer
    {
        // The is an "immutable" property. It only has a "get".
        // The only place the Name can be set is in the Adventurer constructor below.
        public string Name { get; }
        public Robe ColorfulRobe { get; }
        public Hat ShinyHat { get; set; }

        // This is a mutable property it has a "get" and a "set" so it can be read and changed by any code in the application
        public int Awesomeness { get; set; }

        // A constructor to make a new Adventurer object with the name and robe and hat details from the player.
        public Adventurer(string name, Robe playerRobe, Hat playerHat)
        {
            Name = name;
            ColorfulRobe = playerRobe;
            ShinyHat = playerHat;
            Awesomeness = 50;
        }

        // This method returns a string that describes the Adventurer's status
        // Note one way to describe what this method does is: it transforms the Awesomeness integer into a status string.
        public string GetAdventurerStatus()
        {
            string status = "okay";
            if (Awesomeness >= 75)
            {
                status = "great";
            }
            else if (Awesomeness < 25 && Awesomeness >= 10)
            {
                status = "not so good";
            }
            else if (Awesomeness < 10 && Awesomeness > 0)
            {
                status = "barely hanging on";
            }
            else if (Awesomeness <= 0)
            {
                status = "not gonna make it";
            }

            return $"Adventurer, {Name}, is {status}";
        }

        public string GetDescription()
        {
            return $"Adventurer, {Name} is wearing a {ColorfulRobe.Colors}robe that is {ColorfulRobe.Length} inches long and a very {ShinyHat.ShininessDescription} hat. Good luck on your quest!";
        }
    }
}