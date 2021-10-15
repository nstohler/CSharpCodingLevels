using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public enum ChessBoardColor
    {
        Black,
        White
    };

    public enum ChessBoardColumn
    {
        A, B, C, D, E, F, G, H
    }

    public enum ChessTileHighlightCategory
    {
        None,
        Piece,
        Attacked
    };

    public enum ChessPieceCategory
    {
        King,
        Queen, 
        Bishop, 
        Knight, 
        Rook, 
        Pawn
    }
}
