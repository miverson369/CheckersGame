using System.Security.Cryptography.X509Certificates;

public class Game
{
    public Board Board { get; set; } = new Board();

    public PieceColor CurrentTurn { get; private set; } = PieceColor.Red;

    public Game()
    {
        Board.Initialize();
    }

    public void Start()
    {
        Console.WriteLine("Welcome to Checkers");

        while (true)
        {
            PrintBoard();

            Console.WriteLine("Enter move (fromRow fromCol toRow toCol) or type 'quit':");
            string input = Console.ReadLine();

            if (input.Equals("quit", StringComparison.CurrentCultureIgnoreCase))
                break;

            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 4)
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            int fromRow = int.Parse(parts[0]);
            int fromCol = int.Parse(parts[1]);
            int toRow = int.Parse(parts[2]);
            int toCol = int.Parse(parts[3]);

            if (Move(fromRow, fromCol, toRow, toCol))
            {
                // Switch turns
                CurrentTurn = CurrentTurn == PieceColor.Red 
                    ? PieceColor.Black 
                    : PieceColor.Red;
            }
            else
            {
                Console.WriteLine("Invalid move.");
            }
        }
    }
    // Movement logic lives here
    public bool Move(int fromRow, int fromCol, int toRow, int toCol)
    {
        var piece = Board.Grid[fromRow, fromCol];

        if (piece == null)
            return false;

        if (Board.Grid[toRow, toCol] != null)
            return false;

        if (piece.Color != CurrentTurn)
            return false;


        int rowDiff = toRow - fromRow;
        int colDiff = Math.Abs(toCol - fromCol);


        // Red pieces move up the board
        if (piece.Color == PieceColor.Red)
        {
            if (rowDiff != -1 && rowDiff != -2)
                return false;
        }

        // Black pieces move down the board
        if (piece.Color == PieceColor.Black)
        {
            if (rowDiff != 1 && rowDiff != 2)
                return false;
        }

        Console.WriteLine($"Row difference: {rowDiff}");
        Console.WriteLine($"Column difference: {colDiff}");


             // Basic Move (diagonal 1)
             if (Math.Abs(rowDiff) == 1 && colDiff == 1)
             {

                if (Board.Grid[toRow, toCol] == null)
                {
                    Board.Grid[toRow, toCol] = piece;
                    Board.Grid[fromRow, fromCol] = null;
                    return true;
                }
            }

            // Capture move (jump 2)
            if (Math.Abs(rowDiff) == 2 && colDiff == 2)
            {
                int midRow = (fromRow + toRow) / 2;
                int midCol = (fromCol + toCol) / 2;

                var middlePiece = Board.Grid[midRow, midCol];

                if (middlePiece != null && middlePiece.Color != piece.Color)
                {
                    Board.Grid[toRow, toCol] = piece;
                    Board.Grid[fromRow, fromCol] = null;
                    Board.Grid[midRow, midCol] = null;
                    return true;
                }
            }
            return false;
        }

    public void PrintBoard()
    {
        Console.WriteLine("  0 1 2 3 4 5 6 7");

        for (int row = 0; row < 8; row++)
        {
            Console.Write(row + " ");

            for (int col = 0; col < 8; col++)
            {
                if (Board.Grid[row, col] == null)
                    Console.Write(". ");
                else if (Board.Grid[row, col].Color == PieceColor.Red)
                    Console.Write("R ");
                else
                    Console.Write("B ");
            }

            Console.WriteLine();
        }
    
    }
 
}