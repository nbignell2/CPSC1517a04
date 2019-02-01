using System;
using System.Collections.Generic; // Don't have to write System.Console.Writeline because it is referenced already.
using System.Linq;
using System.Text;
using System.Threading.Tasks; // Namespaces. Tasks in threading. Threading in system.

namespace OOPsReview
{
    class Program
    {
        static void Main(string[] args)
        {

            //new: cause an instance (occurance) of the specified
            //   class to be created and placed in the
            //   receiving variable
            //the variable is a pointer address to the actual
            //   physical memory location of the instance -- ADDRESSOF


            //declaring an instance (occurance) of the specified
            //   class will not create a physical instance, just a 
            //   a pointer which can hold a physical instance -- ADDRESSOF
            Turn theTurn;


            //new: cause the constructor of a class to execute
            //   and a phyiscal instance to be created
            Die Player1 = new Die();    //default
            Die Player2 = new Die(6, "Green"); //Greedy

            //Track game plays
            List<Turn> rounds = new List<Turn>(); // Coded outside loop so it's reused.


            string menuChoice = "";
            do
            {
                //Console is a static class -- Class/Method/Value
                Console.WriteLine("\nMake a choice\n");
                Console.WriteLine("A) Roll");
                Console.WriteLine("B) Set number of dice sides");
                Console.WriteLine("C) Display Current Game Stats");
                Console.WriteLine("X) Exit\n");
                Console.Write("Enter your choice:\t");
                menuChoice = Console.ReadLine();

                //user friendly error handling
                try
                {
                    switch (menuChoice.ToUpper())
                    {
                        case "A":
                            {
                                //Turn is a non-static class
                                theTurn = new Turn();

                                //generate a new FaceValue
                                Player1.Roll();
                                //generate a new FaceValue
                                Player2.Roll();
                                // save the roll

                                // .Player 1 and .Facevalue are properties
                                //  set                     get
                                theTurn.Player1Roll = Player1.FaceValue;
                                theTurn.Player2Roll = Player2.FaceValue;

                                //display the round results
                                Console.WriteLine("Player 1 rolled {0}", theTurn.Player1Roll);
                                Console.WriteLine("Player 2 rolled {0}", Player2.FaceValue);
                                if (Player1.FaceValue > Player2.FaceValue)
                                {
                                    Console.WriteLine("Player 1 wins");
                                }
                                else if (Player2.FaceValue > Player1.FaceValue)
                                {
                                    Console.WriteLine("Player 2 wins");
                                }
                                else
                                {
                                    Console.WriteLine("Round is a draw");
                                }


                                //track the round
                                rounds.Add(theTurn);

                                break;
                            }
                        case "B":
                            {
                                string inputSides = "";
                                int sides = 0;

                                Console.Write("Enter your number of desired sides (greater than 1):\t");
                                inputSides = Console.ReadLine();

                                //using the conversion try version of parsing
                                // TryParse has two parameters
                                // one: in string to convert
                                // two: the output conversion value if the string can be
                                //      converted
                                // successful conversion returns a true bool
                                // failed conversion returns a false bool
                                if (int.TryParse(inputSides, out sides))
                                {
                                    //validation of the incoming value
                                    if (sides > 1)
                                    {
                                        //set the die instance Sides
                                        Player1.Sides = sides;
                                        Player2.Sides = sides;
                                    }
                                    else
                                    {
                                        throw new Exception("You did not enter a numeric value greater than 1.");
                                    }
                                }
                                else
                                {
                                    throw new Exception("You did not enter a numeric value.");
                                }
                                break;
                            }
                        case "C":
                            {
                                //Display the current players' stats
                                DisplayCurrentPlayerStats(rounds);
                                break;
                            }
                        case "X":
                            {
                                //Display the final players' stats
                                DisplayCurrentPlayerStats(rounds);
                                Console.WriteLine("\nThank you for playing.");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Your choice was invalid. Try again.");
                                break;
                            }
                    }//eos
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: " + ex.Message);
                    Console.ResetColor();
                }
            } while (menuChoice.ToUpper() != "X");
        }//eomain

        public static void DisplayCurrentPlayerStats(List<Turn> rounds  )
        {

            int wins1 = 0;
            int wins2 = 0;
            int draws = 0;

            //travser the List<Turn> to calculate wins for each player, and draws
            foreach(Turn item in rounds)
            {
                if(item.Player1Roll > item.Player2Roll)
                {
                    wins1 = wins1 + 1;
                }
                else if (item.Player2Roll > item.Player1Roll)
                {
                    wins2 += 1;
                }
                else
                {
                    draws++;
                }
            }


            //display the results
            Console.WriteLine("\n Total Rounds: " + (wins1 + wins2 + draws).ToString());
            Console.WriteLine("\nPlayer1: Wins: {0}  Player2: Wins: {1}  Total Draws: {2}",
                wins1, wins2, draws);

        }
    }
}
