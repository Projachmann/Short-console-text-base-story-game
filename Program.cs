using System;

namespace Text_based_console_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            Random random = new Random();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Dreamscape");
            Console.WriteLine("");
            Console.WriteLine("Are you you ready?");
            Console.ReadLine();
            Console.Clear();
            WakeUp();

            void WakeUp()
            {
                bool wakeUp = false;
                string choice;

                Console.WriteLine("Wake up! Wake up! This is not the real World! Wake up!");
                Console.WriteLine("Try to wake up?");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "yes":
                    case "Yes":
                    case "YES":
                        wakeUp = true;
                    break;
                    case "no":
                    case "No":
                    case "NO":
                        wakeUp = false;
                    break;
                    default:
                        Console.Clear ();
                        WakeUp();
                    break;
                }
                if (wakeUp)
                {
                    Console.WriteLine("You try to wake up but nothing happens.");
                    Console.WriteLine();
                    Console.WriteLine("You need to try harder!");
                    Console.WriteLine();
                    Console.WriteLine("You try it again and you slowly wake up. You cannot remember anything but you know you don't belong here.");
                    Console.WriteLine();
                    Console.Clear();
                    Explore();
                }
                else
                {
                    Console.WriteLine("You decide to stay asleep. As you drift off, you hear a faint whisper: 'It's your choice.'");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Game Over.");
                    Console.ReadLine();
                }
            }

            void Explore()
            {
                Console.WriteLine("You find yourself in a dimly lit room. The air is cold and you feel a strange sense of unease.");
                Console.WriteLine("There are three doors in front of you: one red, one blue, and one green.");
                Console.WriteLine("Which door will you choose?");
                string doorChoice = Console.ReadLine().ToLower();

                switch (doorChoice)
                {
                    case "red":
                    case "Red":
                        Console.WriteLine();
                        RedDoor();
                        break;
                    case "blue":
                    case "Blue":
                        Console.WriteLine();
                        break;
                    case "green":
                    case "Green":
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("You hesitate and the doors disappear. You are left in darkness.");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Game Over.");
                        Console.ReadLine();
                        break;
                }
            }

            void RedDoor()
            {
                Console.WriteLine("You open the red door and step into a fiery chamber. The heat is intense and you see a figure in the distance.");
                Console.WriteLine("The figure turns around and reveals itself as a fierce dragon.");
                Console.WriteLine("Do you fight the dragon or attempt to escape?");
                string action = Console.ReadLine().ToLower();

                switch (action)
                {
                    case "fight":
                        Console.Clear();
                        DragonFight();
                        break;
                    case "escape":
                        Console.WriteLine("You manage to evade the dragon and find another door leading to a safe room.");
                        Console.WriteLine("You are now in a peaceful garden with a serene fountain.");
                        Console.WriteLine("Do you investigate the fountain or explore the garden?");
                        string nextAction = Console.ReadLine().ToLower();

                        if (nextAction == "investigate" || nextAction == "Investigate")
                        {
                            Console.WriteLine("You discover a hidden key in the fountain. This key may be useful later.");
                            Console.WriteLine("The garden has another door leading out.");
                            Console.WriteLine("You continue to the next door.");
                            Continue();
                        }
                        else
                        {
                            Console.WriteLine("You enjoy the peaceful garden but find no further clues.");
                            Console.WriteLine("The garden eventually fades away and you are left in darkness.");
                            Console.WriteLine("Game Over.");
                            Console.ReadLine();
                        }
                        break;
                    default:
                        Console.WriteLine("You stand paralyzed with fear and the dragon catches you.");
                        Console.WriteLine("Game Over.");
                        Console.ReadLine();
                        break;
                }
            }

            void DragonFight()
            {
                int playerHP = 100;
                int dragonHP = 150;
                int playerAttack;
                int dragonAttack;
                int succesfullAttack;
                string action;

                Console.WriteLine("The battle begins!");

                while (playerHP > 0 && dragonHP > 0)
                {
                    Console.WriteLine($"Player HP: {playerHP} | Dragon HP: {dragonHP}");
                    Console.WriteLine("Choose your attack: bow, sword, take cover");
                    action = Console.ReadLine().ToLower();

                    switch (action)
                    {
                        case "bow":
                            succesfullAttack = random.Next(1, 4);
                            if (succesfullAttack == 1 || succesfullAttack == 2)
                            {
                                playerAttack = random.Next(10, 20);
                                dragonHP -= playerAttack;
                                Console.WriteLine($"You shoot at the dragon and it hits! The dragon takes {playerAttack} damage.");
                            }
                            break;
                        case "sword":
                            playerAttack = random.Next(15, 30);
                            dragonHP -= playerAttack;
                            Console.WriteLine($"You deal {playerAttack} damage to the dragon!");
                            break;
                        case "take cover":
                        case "cover":
                            Console.WriteLine("You take cover from the dragon's next attack.");
                            break;
                        default:
                            Console.WriteLine("Invalid action. You lose your turn.");
                            break;
                    }

                    if (dragonHP > 0)
                    {
                        int succsesfullDragonAttack = random.Next(1, 3);
                        dragonAttack = random.Next(15, 25);

                        if (action == "cover" || action == "take cover")
                        {
                            dragonAttack = 0;
                        }
                        else if(action == "bow" && succsesfullDragonAttack == 1)
                        {
                            dragonAttack = 0;
                            Console.WriteLine("The dragon mist you.");
                        }

                        playerHP -= dragonAttack;
                        Console.WriteLine($"The dragon attacks and deals {dragonAttack} damage!");
                    }
                }

                if (playerHP > 0)
                {
                    Console.Clear();
                    Console.WriteLine("Congratulations! You have defeated the dragon.");
                    Console.WriteLine("You find a hidden door leading to a peaceful garden.");
                    Continue();
                }
                else
                {
                    Console.WriteLine("You have been defeated by the dragon.");
                    Console.WriteLine("Game Over.");
                    Console.ReadLine();
                }
            }

            void BlueDoor()
            {
                Console.WriteLine("You open the blue door and enter a room filled with ancient books and artifacts.");
                Console.WriteLine("A wise old man sits at a desk, reading a large tome.");
                Console.WriteLine("He looks up and says, 'Welcome, seeker of knowledge. To proceed, you must answer a riddle.'");
                Console.WriteLine("Do you wish to attempt the riddle or search the room for clues?");
                string choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "riddle":
                        Console.WriteLine("The old man presents the riddle: 'I speak without a mouth and hear without ears. I have no body, but I come alive with the wind. What am I?'");
                        string riddleAnswer = Console.ReadLine().ToLower();

                        if (riddleAnswer == "echo")
                        {
                            Console.WriteLine("Correct! The old man opens a hidden passage behind the bookshelves.");
                            Console.WriteLine("You proceed through the passage and find yourself in a luxurious treasure room.");
                            Console.WriteLine("You have the option to take some treasure or continue exploring.");
                            string decision = Console.ReadLine().ToLower();

                            if (decision == "take")
                            {
                                Console.WriteLine("You take some treasure and find a way out of the labyrinth.");
                                Console.WriteLine("Congratulations! You have won the game.");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("You choose to leave the treasure and continue exploring.");
                                Console.WriteLine("You find yourself in a labyrinth with no way out.");
                                Console.WriteLine("Game Over.");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Incorrect. The old man vanishes and the room collapses.");
                            Console.WriteLine("Game Over.");
                            Console.ReadLine();
                        }
                        break;
                    case "search":
                        Console.WriteLine("You search the room and find a secret compartment with an old map.");
                        Console.WriteLine("The map reveals a hidden door in another part of the labyrinth.");
                        Console.WriteLine("You follow the map and find the way out.");
                        Console.WriteLine("Congratulations! You have won the game.");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("You stand confused and the room begins to fade away.");
                        Console.WriteLine("Game Over.");
                        Console.ReadLine();
                        break;
                }
            }

            void GreenDoor()
            {
                Console.WriteLine("You open the green door and step into a lush, mystical forest.");
                Console.WriteLine("The forest is enchanting but also seems to have a strange sense of foreboding.");
                Console.WriteLine("You see a path leading deeper into the forest and another path leading to a mysterious old cabin.");
                Console.WriteLine("Do you follow the path or investigate the cabin?");
                string choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "path":
                        Console.WriteLine("You follow the path and discover a magical glade with a powerful artifact.");
                        Console.WriteLine("The artifact allows you to control time.");
                        Console.WriteLine("Do you use the artifact to alter your past decisions or continue forward?");
                        string artifactDecision = Console.ReadLine().ToLower();

                        if (artifactDecision == "alter")
                        {
                            Console.WriteLine("You use the artifact to revisit previous choices.");
                            Console.WriteLine("You make better decisions and ultimately escape the labyrinth.");
                            Console.WriteLine("Congratulations! You have won the game.");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("You choose to move forward. The forest transforms into a beautiful landscape.");
                            Console.WriteLine("You find a path leading out of the labyrinth.");
                            Console.WriteLine("Congratulations! You have won the game.");
                            Console.ReadLine();
                        }
                        break;
                    case "cabin":
                        Console.WriteLine("You approach the cabin and find an old woman who offers to tell you your fortune.");
                        Console.WriteLine("Do you accept her offer or refuse?");
                        string fortuneDecision = Console.ReadLine().ToLower();

                        if (fortuneDecision == "accept")
                        {
                            Console.WriteLine("The old woman tells you that you are destined to escape the labyrinth.");
                            Console.WriteLine("She gives you a key to unlock the final door.");
                            Console.WriteLine("You use the key and escape the labyrinth.");
                            Console.WriteLine("Congratulations! You have won the game.");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("You refuse the offer and the cabin vanishes, leaving you lost in the forest.");
                            Console.WriteLine("Game Over.");
                            Console.ReadLine();
                        }
                        break;
                    default:
                        Console.WriteLine("You stand indecisive and the forest fades into darkness.");
                        Console.WriteLine("Game Over.");
                        Console.ReadLine();
                        break;
                }
            }

            void Continue()
            {
                Console.WriteLine("You find yourself in a tranquil clearing with a serene pond.");
                Console.WriteLine("As you approach the pond, you notice something shimmering at the bottom.");
                Console.WriteLine("Do you dive into the pond to retrieve the object or explore the surrounding area?");
                string choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "dive":
                        Console.WriteLine("You dive into the pond and retrieve a mysterious crystal.");
                        Console.WriteLine("The crystal grants you visions of different pathways to escape.");
                        Console.WriteLine("You follow the visions and find your way out of the labyrinth.");
                        Console.WriteLine("Congratulations! You have won the game.");
                        Console.ReadLine();
                        break;
                    case "explore":
                        Console.WriteLine("You explore the surrounding area and find a hidden cave.");
                        Console.WriteLine("Inside the cave, you discover ancient writings that reveal a secret exit.");
                        Console.WriteLine("You follow the instructions and successfully escape the labyrinth.");
                        Console.WriteLine("Congratulations! You have won the game.");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("You hesitate and the clearing begins to fade away.");
                        Console.WriteLine("Game Over.");
                        Console.ReadLine();
                        break;
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
