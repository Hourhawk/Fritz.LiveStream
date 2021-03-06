﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FritzBasics
{
    class FritzApp
    {
        // This is called a constructor (or ctor for short).
        // Whenever you call "new FritzApp()" in your code, it will come here.
        // We need to leave this public so that we can create instances of this class
        public FritzApp()
        {
        }

        // We need to make this public so that we can call this from Program.cs
        public void Run()
        {
            string userInput = "";
            do
            {
                DisplayMenu();
                userInput = Console.ReadLine();
                ProcessMenu(userInput);

            } while (userInput.ToUpper() != "Q");
            Console.WriteLine("Happy coding! Press any key to quit!");
            Console.ReadKey();
        }

        private void ProcessMenu(string menuChoice)
        {
            // Since we are making a decision on a value, switch works.
            // This allows us to write "if (something=value1) {} else if (something = value2) {}"
            // into code a little cleaner to look at it.  This is used for readability more than anything.
            // If we had to check things like checking value ranges with greater than or less than, 
            // then switch would not be appropriate.
            switch (menuChoice)
            {
                case "1":
                    HelloYou("Sadukie");
                    break;
                case "2":
                    GetLunchIfElse();
                    break;
                case "3":
                    GetLunchSwitch();
                    break;
                case "4":
                    // We declare a variable here to hold the value that gets returned by FlipCoin()
                    string goesFirst = FlipCoin();
                    // We are using the value that we had gotten above.
                    Console.WriteLine($"{goesFirst} goes first!");
                    break;
                case "5":
                    GoHide();
                    break;
                case "6":
                    AllHid();
                    break;
                case "7":
                    LaunchRocket();
                    break;
                case "8":
                    GetSpaceCollections();
                    break;
                default:
                    if (menuChoice.ToUpper() != "Q")
                    {
                        Console.WriteLine("Not a valid menu option.\nPlease enter a valid choice.\n");
                    }
                    break;
            }
        }

        // Only FritzApp needs to know how to display the menu, so we make this private.
        // Run() can see this method because they are in the same class.
        // However, we cannot see this in Program.cs because the "access modifier"
        // is set to private.
        // ----
        // Think of it with this real-life example - in a restaurant, you can see the menu.  (public)
        // You may not necessarily see how the food is made. (private)
        // ----
        // Do other classes outside of here really need to access this? Do they need to call this process in pieces?
        // No - Run() is the only point that needs it.
        // So this is why we make it private.
        private void DisplayMenu()
        {
            Console.WriteLine("Fritz Basics");
            Console.WriteLine("*************");
            Console.WriteLine("1. Hello World");
            Console.WriteLine("2. What's For Lunch - If...Else");
            Console.WriteLine("3. What's For Lunch - Switch");
            Console.WriteLine("4. Football Flip - If...Else with Random");
            Console.WriteLine("5. Hide and Seek - Loops");
            Console.WriteLine("6. All Hid - Loops");
            Console.WriteLine("7. Rocket Launch - Loops");
            Console.WriteLine("8. Space Adventures - Collections");
            Console.WriteLine("Enter a number or Q to quit:");
        }

        private void HelloYou(string name)
        {
            // String concatenation
            Console.WriteLine("Hello, " + name + "!");
            // String interpolation
            Console.WriteLine($"Hello {name}!");
        }

        private void GetLunchIfElse()
        {
            string today = "Friday";
            if (today == "Tuesday")
            {
                Console.WriteLine("TACO TUESDAY!!!");
            }
            else if (today == "Friday")
            {
                Console.WriteLine("Pizza party!!!");
            }
            else
            {
                Console.WriteLine("BACON!!!!!");
            }
        }

        private void GetLunchSwitch()
        {
            string today = "Friday";
            switch (today)
            {
                case "Tuesday":
                    Console.WriteLine("TACO TUESDAY!!!");
                    break;
                case "Friday":
                    Console.WriteLine("Pizza party!!!");
                    break;
                default:
                    Console.WriteLine("BACON!!!!!");
                    break;
            }
        }

        // We are using the "string" keyword as our return type
        // This means that when we call the FlipCoin method,
        // it will return a string value.
        private string FlipCoin()
        {
            // Put the randomness here
            // Who will go first - Eagles (Jeff's team) or Browns (Sadukie's team)?
            Random random = new Random();
            // We want to choose either 0 or 1.  The Next() method includes the lower bounds but excludes the upper bounds.
            int coinFlip = random.Next(0, 2);
            // The question mark (?) is known as a "ternary operator"
            // This is a shortcut for saying "if this condition, then use this value; otherwise use this"
            // In our case, if the value is 0, set the team to Browns otherwise set the team to Eagles.
            string whoGoesFirst = (coinFlip == 0 ? "Browns" : "Eagles");
            // The "return" keyword returns a value from a method back to the method that called it.
            // In this case, it will go back to ProcessMenu().
            return whoGoesFirst;
        }

        private void GoHide()
        {
            // In Hide-And-Seek, the counter has to count to a number to give people time to hide
            // Create a for-loop to do the counting to 20
            Console.WriteLine("====================================");
            // Start the counter at 0
            // Do this while counter is less than 20
            // After the code in the loop is run, increase the counter by 5 each time
            for (int counter = 0; counter < 20; counter++) //shorthand for counter = counter + 1
            {
                // Display the current counter
                // We do the +1 because kids typically won't count "0, 1, 2, 3..." 
                // for hide-n-seek.
                Console.Write($"{counter+1}\t"); // Yes - we can do math in string interpolation expressions
            }
            Console.WriteLine("\n====================================");
        }

        private void AllHid()
        {
            // In Hide-And-Seek, there may be a song checking if they're all hid
            // "All hid, all hid, all hid... 5, 10, 15, 20 all hid"
            // Create a for-loop to show how to count up by 5s
            Console.WriteLine("====================================");
            // Start the counter at 0
            // Do this while counter is less than or equal to 20
            // After the code in the loop is run, increase the counter by 5 each time
            for (int counter = 0; counter <= 20; counter+=5) // shorthand for counter = counter + 5
            {
                Console.Write($"{counter}\t");
            }
            // We use \n to move our cursor to the next line.  
            // Keep in mind that Console.Write does not move to the next line. 
            // However, Console.WriteLine does include a new line character (\n) at the end of input automatically
            Console.WriteLine("\n====================================");
        }

        private void LaunchRocket()
        {
            // When rockets launch, there's a countdown
            // Create a for-loop to show how to count down from 10
            Console.WriteLine("====================================");
            // Start the countdown timer at 10
            // Run as long as the countdown timer is greater than 0
            // After the code in the loop is run, set the countdown timer to one less
            for (int countdownTimer = 10; countdownTimer > 0; countdownTimer--) //shorthand for countdownTimer = countdownTimer - 1
            {
                Console.WriteLine(countdownTimer);
            }
            Console.WriteLine("BLAST OFF!!!!");
            Console.WriteLine("====================================");

        }

        private void GetSpaceCollections()
        {
            // Let's talk about planet objects and values
            // Lots of statistics at https://nssdc.gsfc.nasa.gov/planetary/factsheet/

            // We are not using IEnumerable, as we want to add to our collection
            // IEnumerable only allows us to go forward through a collection
            // We need to create a collection of planets and add to it
            // We are using List, which does implement IEnumerable
            // However, List also allows us to add and remove items

            List<Planet> solarSystem = new List<Planet>();
            solarSystem.Add(new Planet("Mars", 0.642));
            solarSystem.Add(new Planet("Earth")); // What will default Mass be?
            solarSystem.Add(new Planet()); // What will this look like when we list them?
            solarSystem.Add(new Planet("Mercury",0.330));

            // We can use foreach to loop through our collection
            // \t is separating the properties with a tab
            PrintPlanets(solarSystem);
            
            // How do we remove the nameless planet?
            // We cannot use a foreach in this case, because foreach
            // does not allow us to change the collection size inside.
            // We can use something called LINQ to find the item in our collection
            // The part in the Find can be read as - 
            // "Find a planet where ethe planet name is equal to empty string"
            // This type of expression is known as a "lambda expression"
            Planet emptyPlanet = solarSystem.Find(planet => planet.Name == "");
            // Once we find the planet, let's remove it.
            solarSystem.Remove(emptyPlanet);
            PrintPlanets(solarSystem);

            // Wait - why didn't that work?
            // Set a breakpoint on the Remove statement
            // Start the debugger
            // Look carefully at the planets in solar system
            // What is that value?  Let's update our search for our empty planet
            emptyPlanet = solarSystem.Find(planet => planet.Name == null);
            // Once we find the planet, let's remove it.
            solarSystem.Remove(emptyPlanet);
            // And let's make sure it's really gone this time
            PrintPlanets(solarSystem);


            Console.WriteLine("=====================");

        }

        private void PrintPlanets(IEnumerable<Planet> planetList)
        {
            // Print headers
            Console.WriteLine($"Name\tMass");
            Console.WriteLine("=====================");
            // We are using the foreach here for simplicity's sake
            // We created this method so that we aren't repeating code
            // We are using IEnumerable so that we can pass in
            // any collection of planets that implements the functionality
            // of the IEnumerable interface.
            // The IEnumerable interface allows us to loop through using 
            // its enumerator.
            foreach (Planet planet in planetList)
            {
                Console.WriteLine($"{planet.Name}\t{planet.Mass}");
            }
        }

    }
}

