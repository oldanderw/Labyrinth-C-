using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PracticalReviewLab
{
    class Program
    {
        //current room
        public static int currroom = 0;
        //current switch
        public static int button = 1;


        static void Main(string[] args)
        {
            //introduction to the labyrinth with instructions
            Console.WriteLine("Welcome to the Labyrinth! \nEach room has several options of where to go.\nThe goal is to press the 4 switches in the proper order.\nThe final switch is in the center of the labyrinth./nUse the map on Github to find all the buttons.");
            //read in the rooms from rooms.txt
            List<string> roomsStrings = new List<string>();
            using (StreamReader reader = new StreamReader(@"../../rooms.txt"))
            {
                while (reader.Peek() > -1)
                {
                    roomsStrings.Add(reader.ReadLine());
                }
            }
			// removing these [ ]
            roomsStrings.RemoveAt(0);
            roomsStrings.RemoveAt(roomsStrings.Count - 1);
            
            //store the rooms in a List of objects
            List<Room> allRooms = new List<Room>();
            foreach (string s in roomsStrings)
            {
                allRooms.Add(StringRoom(s));
            }

            //repeat these steps until the user completes the labyrinth
           
            while (true)
            {
                bool buttonCkeck = false;
                    Console.WriteLine("where would you like to go?");
                if (allRooms[currroom].Left != -1)
                {
                    Console.WriteLine("left");
                }
                if (allRooms[currroom].Back != -1)
                {
                    Console.WriteLine("back");
                }
                if (allRooms[currroom].Right != -1)
                {
                    Console.WriteLine("right");
                }
                if (allRooms[currroom].Forward != -1)
                {
                    Console.WriteLine("forward");
                }
                if (allRooms[currroom].TheSwitch.Button > 0)
                {
                    Console.WriteLine("switch");
                }
				string userInput = Console.ReadLine();
                if (userInput == "left" && allRooms[currroom].Left != -1)
                {
                    currroom = allRooms[currroom].Left;
                }
                if (userInput == "back" && allRooms[currroom].Back == 0)
                {
                    Console.WriteLine("The door shut behind you, you are unable to move back");
                    currroom = allRooms[currroom].Forward;
                }
                if (userInput == "back" && allRooms[currroom].Back != -1)
                {
                    currroom = allRooms[currroom].Back;
                }
                if (userInput == "right" && allRooms[currroom].Right != -1)
                {
                    currroom = allRooms[currroom].Right;
                }
                if (userInput == "forward" && allRooms[currroom].Forward != -1)
                {
                    currroom = allRooms[currroom].Forward;
                }
                if (userInput == "switch" && allRooms[currroom].TheSwitch.Button >= 1)
                {
                    if (button == allRooms[currroom].TheSwitch.Button)
                    {
                        buttonCkeck = true;
                        button += 1;
                        Console.WriteLine("The switch was activated");
                    }
                    else
                    {
                        buttonCkeck = true;
                        Console.WriteLine("nothing happened");
                    }
                }
                
                if (button == 5)
                {
                    break;
                }

                //starting in room zero ask the user where they want to move to

                //Handle the user selection by making the current room the one they selected to move to
                Console.Clear();
                if (userInput != "back" && userInput != "forward" && userInput != "right" && userInput != "left" || userInput == "switch")
                {
                    if (buttonCkeck == false)
                    {
                        Console.WriteLine("Invalid input, try again.");
                    }
                }
            }
            Console.WriteLine("You have solved the labyrinth");
            Console.ReadLine();
            //Once the final switch has been pressed in the correct order then the labyrinth is complete, inform the user they have finished

        }
        static Room StringRoom(string allRoom)
        {
            Room relVal = new Room();
            allRoom = allRoom.Replace("{", "");
            allRoom = allRoom.Replace("}", "");
            allRoom = allRoom.Trim();
            string[] splitOnComma = allRoom.Split(',');

            relVal.Left = Int32.Parse(splitOnComma[0]);
            relVal.Back = Int32.Parse(splitOnComma[1]);
            relVal.Right = Int32.Parse(splitOnComma[2]);
            relVal.Forward = Int32.Parse(splitOnComma[3]);
            if (splitOnComma.Length > 4)
            {
                if (splitOnComma[4] != "")
                {
                    relVal.TheSwitch.Button = Int32.Parse(splitOnComma[4]);
                }
            }

            return relVal;
        }
    }
}
