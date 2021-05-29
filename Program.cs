using System;
using System.Collections.Generic;
using System.Linq;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Who are you?");
            string name = Console.ReadLine();

            Console.WriteLine("What color(s) is your robe?");
            string robeColor = Console.ReadLine();

            Console.WriteLine("How long is your robe? (Just the number will do.)");
            string length = Console.ReadLine();
            int robeLength = Int32.Parse(length);

            Robe playerRobe = new Robe();
            playerRobe.Colors = robeColor;
            playerRobe.Length = robeLength;

            Console.WriteLine("Now tell me about your hat. How shiny is it on a scale of 1-10? ");
            string level = Console.ReadLine();
            int shinyLevel = Int32.Parse(level);

            Hat playerHat = new Hat();
            playerHat.ShininessLevel = shinyLevel;


            // Make a new "Adventurer" object using the "Adventurer" class
            Adventurer theAdventurer = new Adventurer(name, playerRobe, playerHat);

            Console.WriteLine(theAdventurer.GetDescription());

           // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments - the text of the challenge, a correct answer, a number of awesome points to gain or lose depending on the success of the challenge
                
                Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);

                // --------------------------------------------------------------------------------------
                
                Challenge theAnswer = new Challenge(
                    "What's the answer to life, the universe and everything?", 42, 25);

                // --------------------------------------------------------------------------------------

                Challenge whatSecond = new Challenge(
                    "What is the current second?", DateTime.Now.Second, 25);

                // --------------------------------------------------------------------------------------

                int randomNumber = new Random().Next() % 10;
                Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 35);

                // --------------------------------------------------------------------------------------

                Challenge favoriteBeatle = new Challenge(
                    @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                    4, 20
                );

                // --------------------------------------------------------------------------------------

                Challenge favoriteNumber = new Challenge("What's my favorite number?", 7, 25);

               // --------------------------------------------------------------------------------------

                Challenge aroundTheWorld = new Challenge("How many days does it take to travel around the world?", 81, 25); 
                // --------------------------------------------------------------------------------------

                Challenge numberOfSeasons = new Challenge("How many seasons are there?", 4, 10); 
           
           
               // A list of challenges for the Adventurer to complete
                List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                favoriteNumber,
                aroundTheWorld,
                numberOfSeasons
            };

            // "Awesomeness" is like our Adventurer's current "score". A higher Awesomeness is better
            // Here we set some reasonable min and max values.
                int minAwesomeness = 0;
                int maxAwesomeness = 100;

            bool playing = true;
           
            while (playing)
            {    
                // create list of 5 random challenges
                 List <Challenge> listOfChallenges = challenges.OrderBy(x => Guid.NewGuid()).Take(5).ToList(); 

                 foreach(Challenge challenge in listOfChallenges)
                 {
                     challenge.RunChallenge(theAdventurer);
                 }  
                 
                // This also works but leads to repeat challenges in the same set
                // for (int i = 0; i < 5; i++)
                // {
                //     int challengeNumber = new Random().Next(0, challenges.Count);
                //     challenges[challengeNumber].RunChallenge(theAdventurer);
                // }

                // This code examines how Awesome the Adventurer is after completing the challenges and praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did pretty well!");
                }

                Prize prize = new Prize("Teddy Bear");

                Console.WriteLine("Ready for your prize? Press any key to continue...");
                Console.ReadLine();
                Console.Clear();

                prize.ShowPrize(theAdventurer);

                Console.WriteLine("Well that was fun. Would you like to do it again? (Y/N)");
                string answer = Console.ReadLine().ToLower();

                while (answer != "y" && answer != "n")
                {
                    Console.Write("Would you like to do it again? (Y/N): ");
                    answer = Console.ReadLine().ToLower();
                }

                if (answer == "y")
                {
                    theAdventurer.Awesomeness = theAdventurer.SuccessfullChallenges * 10;
                    theAdventurer.SuccessfullChallenges = 0;
                    Console.Clear();
                }
                else
                {
                    playing = false;
                }
            }
        }
    }
}
