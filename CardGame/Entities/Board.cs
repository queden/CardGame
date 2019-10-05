using System;
using System.Collections.Generic;
using System.Text;

class Board
{
    /// <summary>
    /// Initializes a memory value with random values, each having its own duplicate
    /// </summary>
    public Board()
    {
        Card[] boardList = new Card[16];
        Random rnd = new Random();
        for (int i = 0; i < boardList.Length; i++)
        {
            if (boardList[i] is null)
            {
                int num = rnd.Next(1, 9);
                boardList[i] = new Card();
                Card duplicate = new Card();
                switch (num)
                {
                    case 1:
                        boardList[i].type = CardTypes.A;
                        duplicate.type = CardTypes.A;
                        break;
                    case 2:
                        boardList[i].type = CardTypes.B;
                        duplicate.type = CardTypes.B;
                        break;
                    case 3:
                        boardList[i].type = CardTypes.C;
                        duplicate.type = CardTypes.C;
                        break;
                    case 4:
                        boardList[i].type = CardTypes.D;
                        duplicate.type = CardTypes.D;
                        break;
                    case 5:
                        boardList[i].type = CardTypes.E;
                        duplicate.type = CardTypes.E;
                        break;
                    case 6:
                        boardList[i].type = CardTypes.F;
                        duplicate.type = CardTypes.F;
                        break;
                    case 7:
                        boardList[i].type = CardTypes.G;
                        duplicate.type = CardTypes.G;
                        break;
                    case 8:
                        boardList[i].type = CardTypes.H;
                        duplicate.type = CardTypes.H;
                        break;
                }
                bool duplicatePlaced = false;
                while (!duplicatePlaced)
                {
                    int rndIndex = rnd.Next(0, 16);
                    if (boardList[rndIndex] is null)
                    {
                        boardList[rndIndex] = duplicate;
                        duplicatePlaced = true;
                    }
                }
            }

        }
        board = boardList;
    }
    /// <summary>
    /// The list of the boards cards
    /// </summary>
    public Card[] board { get; set; }
    /// <summary>
    /// Prints the board as a String representation
    /// </summary>
    /// <returns>A string that represents the current state of the board</returns>
    public string PrintBoard()
    {
        Card[] board = this.board;
        string boardString = "  1 2 3 4\n1 ";
        for (int i = 0; i < board.Length; i++)
        {
            if (i != 0 && i % 4 == 0)
            {
                boardString += "\n";
                if (i / 4 == 1)
                {
                    boardString += "2 ";
                }
                else if (i / 4 == 2)
                {
                    boardString += "3 ";
                }
                else boardString += "4 ";
            }
            boardString += board[i].PrintCard() + " ";
        }
        return boardString;
    }
    /// <summary>
    /// Flips the card and returns true if the card was not already flipped, false if it was
    /// </summary>
    /// <param name="row">The row of the card</param>
    /// <param name="col">The col of the card</param>
    /// <returns>Boolean describing if the card was already flipped</returns>
    public bool ShowCard(Card card)
    {
        bool flipped = false;
        if (!card.enabled)
        {
            card.enabled = true;
            flipped = true;
        }
        else
        {
            Console.WriteLine("Card already reavealed");
        }
        Console.WriteLine(this.PrintBoard());
        return flipped;
    }
    /// <summary>
    /// Takes in a row and column and finds the card in the array
    /// </summary>
    /// <param name="row">Row of the card on the board</param>
    /// <param name="col">Column of the card on the board</param>
    /// <returns></returns>
    public Card CalculateCard(int row, int col)
    {

        Card card;
        if ((row > 4 || row < 1)  || (col > 4 || col < 1))
        {
            Console.WriteLine("Please input valid row and column (1-4)");
            card = null;
        }
        else if (row == 1)
        {
            card = this.board[col - 1];
        }
        else if (row == 2)
        {
            card = this.board[3 + col];
        }
        else if (row == 3)
        {
            card = this.board[7 + col];
        }
        else
        {
            card = this.board[11 + col];
        }
        return card;
    }
    /// <summary>
    /// Takes in a users input to find the users card and their guess for the duplicate
    /// Keeps the cards enabled if they are duplicates, otherwise hides them 
    /// Ensures the user puts in the input of a card that has not been flipped
    /// </summary>
    public void FindDuplicate()
    {
        Console.Write("Enter row of card to flip: ");
        int row = ReadInt();
        Console.Write("Enter column of card to flip: ");
        int col = ReadInt();
        Card card = CalculateCard(row, col);
        while (card is null || !ShowCard(card))
        {
            Console.Write("Enter row of card to flip: ");
            row = ReadInt();
            Console.Write("Enter column of card tp flip: ");
            col = ReadInt();
            card = CalculateCard(row, col);
        }
        Console.Write("Enter row of duplicate guess: ");
        int rowDup = ReadInt();
        Console.Write("Enter column of duplicate guess: ");
        int colDup = ReadInt();
        Card duplicate = CalculateCard(rowDup, colDup);
        while (duplicate is null || !ShowCard(duplicate))
        {
            Console.Write("Enter row of duplicate guess: ");
            rowDup = ReadInt();
            Console.Write("Enter column of duplicate guess: ");
            colDup = ReadInt();
            duplicate = CalculateCard(rowDup, colDup);
        }
        if (duplicate.type == card.type)
        {
            Console.WriteLine("Found duplicate");
        }
        else
        {
            duplicate.enabled = false;
            card.enabled = false;
        }
    }
    /// <summary>
    /// Checks to see if all cards have been enabled, returns true if so, false if not
    /// </summary>
    /// <returns>True if game is over, false if not</returns>
    public bool EndGame()
    {
        bool allFlipped = true;
        foreach (Card card in board)
        {
            if (!card.enabled)
            {
                allFlipped = false;
            }
        }
        return allFlipped;
    }
    /// <summary>
    /// Reads in the users input and insures it is a valid integer
    /// </summary>
    /// <returns></returns>
    public int ReadInt()
    {
        bool parsed = false;
        int num = 0;
        while (!parsed)
        {
            try
            {
                num = int.Parse(Console.ReadLine());
                parsed = true;
            }
            catch(Exception e)
            {
                Console.Write("Please input an integer for this value: ");
            }
        }
        return num;
    }
}

