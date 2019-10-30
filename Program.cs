using System;

namespace first_project
{
    class Program
    {
        static void Main()
        {
            // Set up the project
            setup_app_program();
            initiate_game();

            // Generate random number
            int min_number = 1;
            int max_number = 10;
            int random_number = generate_random_number(min_number, max_number+1);

            // Guess the number with recursion
            guess_random_number(random_number, min_number, max_number);
        }

        static void setup_app_program()
        {
            /*
            Summary:
            This function will assign some info about this program
            and display it to the user
            */
            // Set app vars
            string app_name = "Number Guesser";
            string app_version = "1.0.0";
            string app_author = "Simon Van Den Hende";

            // set console text color
            Console.ForegroundColor = ConsoleColor.Green;

            // write out app info
            Console.WriteLine("{0}: version {1} by {2}", app_name, app_version, app_author);

            // reset console text color
            Console.ResetColor();
        }

        static void initiate_game()
        {
            /*
            Summary:
            This function will initiate the game
            It will ask for the user and welcome him/her
            */
            // ask user's name
            Console.Write("What is your name? >> ");

            // Get user input
            string user_name = Console.ReadLine();

            Console.WriteLine("Hello {0}, Let's play a game", user_name);
        }

        static int generate_random_number(int min, int max)
        {
            /*
            Summary:
            This function will return a random int between the given range

            Params:
            int min = minimum value the random int can be
            int max = max - 1 = maximum value the random int can be
            */
            Random rnd = new Random();
            return rnd.Next(min, max);
        }

        static void guess_random_number(int number, int min, int max)   // Recursive function
        {
            /*
            Summary:
            Function that will ask the user for a number between,
            as long as the guess does not match the randomly generated number,
            this function will keep getting called recursively.
            When the number does get guessed, the user is asked if he/she wants to play again.
            If so, a new number will be generated and the user will be able to guess again.

            Params: 
            int number = random number that has to be guessed
            int min = minimum value that the random number can be
            int max = maximum value that the random number can be
            */
            Console.Write("Guess the number (between {0} and {1}) >> ", min, max);
            string guess_input = Console.ReadLine();
            int guess = 0;

            if (Int32.TryParse(guess_input, out guess)) {
                // Compare input to generated number
                if (guess == number)    {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("you guessed it! The number was {0}", number);
                    Console.ResetColor();

                    // Ask to restart
                    Console.Write("Play again? (y/n) >> ");
                    if (Console.ReadLine() == "y")  {
                        int new_number = generate_random_number(min, max);
                        guess_random_number(new_number, min, max);
                    }   
                    else  {
                        Console.WriteLine("Thanks for playing ");
                    }
                }   
                else  {
                    Console.WriteLine("wrong number, try again");
                    guess_random_number(number, min, max);
                }
            }
            else  {
                Console.WriteLine("Input an integer number please.\n");
                guess_random_number(number, min, max);
            }
        }
    }
}
