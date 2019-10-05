using System;

namespace Memory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi! Welcome to M E M O R Y with Caden Felton!");
            Console.WriteLine("Rules: Flip over cards by inputting the row and columns until you find duplicates.");
            Console.WriteLine("Try to flip over every card! Once a duplicate is found, those cards will stay revealed.");
            Console.WriteLine("And please do not cheat... I'm testing your memory, not your ability to scroll in a console!!");
            Board board = new Board();
            Console.WriteLine(board.PrintBoard());
            while (!board.EndGame())
            {
                board.FindDuplicate();
            }
            Console.WriteLine("All cards are flipped! Good job, and I hope you enjoyed.");
        }
    }
}
