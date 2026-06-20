public class Board 
{
    public Piece[,] Grid { get; set; } = new Piece[8, 8];

    public void Intialize()
    {
        //Black pieces (top)
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                if ((row + col) % 2 == 1)
                    Grid[row, col] = new Piece(PieceColor.Black);
            }
        }
        //Red pieces (bottom)
        for (int row = 5; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                if ((row + col) % 2 == 1)
                    Grid[row, col] = new Piece(PieceColor.Red);
            }
        }
    }
}
