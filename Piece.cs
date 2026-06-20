public enum PieceColor
{
    Red,
    Black
}
public class Piece
{
    public PieceColor Color { get; set; }
    public bool IsKing { get; set; }

    public Piece(PieceColor color)
    {
        Color = color;
        IsKing = false;
    }
}