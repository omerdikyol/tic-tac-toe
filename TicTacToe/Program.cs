using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static int move_count = 0;
        static void printDeck(string [,] deck)
        {
            Console.WriteLine("     Tic Tac Toe Game By Omer Dikyol");
            Console.WriteLine("\n         Deck:");

            Console.WriteLine(@"
               |       |  
            {0}  |   {1}   |  {2}
               |       |  
         --------------------
               |       |  
            {3}  |   {4}   |  {5}
               |       |  
         --------------------
               |       |  
            {6}  |   {7}   |  {8}
               |       |   " + "\n", deck[0, 0], deck[0, 1], deck[0, 2], deck[1, 0], deck[1, 1], deck[1, 2], deck[2, 0], deck[2, 1], deck[2, 2]);           
        }

        static bool isValid(string choice)
        {
            if (choice == "X" || choice == "O")
                    return false;
            return true;
        }

        static int isWinner(string[,] deck) // 1 for winner, 0 for continue, -1 for tie 
        {
            for(int i = 0; i < 2; i++)
            {
                if ((deck[0, i] == deck[1, i]) && (deck[1, i] == deck[2, i]))
                    return 1;
                else if ((deck[i, 0] == deck[i, 1]) && (deck[i, 1] == deck[i, 2]))
                    return 1;
            }
            if ((deck[0, 0] == deck[1, 1]) && (deck[1, 1] == deck[2, 2]))
                return 1;
            else if ((deck[2, 0] == deck[1, 1]) && (deck[1, 1] == deck[0, 2]))
                return 1;

            if (move_count == 9)
                return -1;

            return 0;
        }

        static void Game(string[,] deck) 
        {
            for (int i = 1; i < 3; i++)
            {
                PlayerMove(deck, i);
                printDeck(deck);
                if (isWinner(deck) == 1)
                {
                    Console.WriteLine("Winner is Player {0}!", i);
                    return;
                }
                else if(isWinner(deck) == -1)
                {
                    Console.WriteLine("The game is Tie!");
                    return;
                }
            }
        }

        static void PlayerMove(string[,] deck, int playerNum)
        {
            string symbol;
            if (playerNum == 1)
                symbol = "X";
            else
                symbol = "O";

            if (isWinner(deck) == 0)
            {
                Console.Write("Player {0}: ", playerNum);
                int player = int.Parse(Console.ReadLine());

                switch (player)
                {
                    case 1:
                        if (isValid(deck[0, 0]))
                            deck[0, 0] = symbol;
                        else
                            PlayerMove(deck,playerNum);
                        break;
                    case 2:
                        if (isValid(deck[0, 1]))
                            deck[0, 1] = symbol;
                        else
                            PlayerMove(deck, playerNum);
                        break;
                    case 3:
                        if (isValid(deck[0, 2]))
                            deck[0, 2] = symbol;
                        else
                            PlayerMove(deck, playerNum);
                        break;
                    case 4:
                        if (isValid(deck[1, 0]))
                            deck[1, 0] = symbol;
                        else
                            PlayerMove(deck, playerNum);
                        break;
                    case 5:
                        if (isValid(deck[1, 1]))
                            deck[1, 1] = symbol;
                        else
                            PlayerMove(deck, playerNum);
                        break;
                    case 6:
                        if (isValid(deck[1, 2]))
                            deck[1, 2] = symbol;
                        else
                            PlayerMove(deck, playerNum);
                        break;
                    case 7:
                        if (isValid(deck[2, 0]))
                            deck[2, 0] = symbol;
                        else
                            PlayerMove(deck, playerNum);
                        break;
                    case 8:
                        if (isValid(deck[2, 1]))
                            deck[2, 1] = symbol;
                        else
                            PlayerMove(deck, playerNum);
                        break;
                    case 9:
                        if (isValid(deck[2, 2]))
                            deck[2, 2] = symbol;
                        else
                            PlayerMove(deck, playerNum);
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1-9.");
                        PlayerMove(deck, playerNum);
                        break;
                }
                move_count++;
                Console.Clear();
            }
        }

        static void Main(string[] args)
        {
            string[,] deck =
            {
                {"1", "2", "3" },
                {"4", "5", "6" },
                {"7", "8", "9" }
            };

            printDeck(deck);
            while (isWinner(deck) == 0){
                Game(deck);
            }
                             
            Console.WriteLine("\nGithub: https://github.com/omerdikyol");
            Console.WriteLine("Thanks for playing!");
            Console.ReadKey();
        }
    }
}
