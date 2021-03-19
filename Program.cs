//This is a practice program for enumerations and random numbers.

using System;

namespace CrapsTutorial
{
    class Craps
    {
        //Creates object of class Random to use random number methods.
        private static Random randomNumbers = new Random();
        //Enumeration to represent game status
        private enum Status { Continue, Won, Lost }

        //Enum representing common dice rolls. Used in deciding points and win/lost.
        private enum DiceNames { SnakeEyes = 2, Trey = 3, Seven = 7, YoLeven = 11, BoxCars = 12 }

        static void Main(string[] args)
        {
            Status gameStatus = Status.Continue; //Status of game from enum

            int myPoint = 0; //Tracks points if not insta win/loss

            int sumOfDice = RollDice();

            switch ((DiceNames) sumOfDice) //Determines the game status and points based on first roll
            {
                case DiceNames.Seven: // win with 7 on first roll   
                case DiceNames.YoLeven: // win with 11 on first roll
                    gameStatus = Status.Won;
                    Console.WriteLine("You won!");
                    break;
                case DiceNames.SnakeEyes: // lose with 2 on first roll
                case DiceNames.Trey: // lose with 3 on first roll     
                case DiceNames.BoxCars: // lose with 12 on first roll 
                    gameStatus = Status.Lost;
                    Console.WriteLine("You lost!");
                    break;
                default: // did not win or lose, so remember point  
                    gameStatus = Status.Continue; // game is not over
                    myPoint = sumOfDice; // remember the point       
                    Console.WriteLine($"Point is {myPoint}");
                    break;
            }

            while (gameStatus == Status.Continue) //Game isn't insta over
            {
                sumOfDice = RollDice(); //rolls again

                if (sumOfDice == myPoint) //Player had to match their points in their first roll, if not lost, before they roll a seven.
                {
                    gameStatus = Status.Won;
                    Console.WriteLine("You won!");
                }
                else
                {
                    if (sumOfDice == (int)DiceNames.Seven)
                    {
                        gameStatus = Status.Lost;
                        Console.WriteLine("You lost!");
                    }
                }
            }
            static int RollDice()
            {
                int die1 = randomNumbers.Next(1, 7); //First roll
                int die2 = randomNumbers.Next(1, 7);//Second roll
                int sum = die1 + die2;
                Console.WriteLine($"Player rolled {die1} + {die2} = {sum}");
                return sum;

            }
        
        }
    }
}
