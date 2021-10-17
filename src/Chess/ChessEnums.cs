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

    public enum ChessBoardRow
    {
        Row1, Row2, Row3, Row4, Row5, Row6, Row7, Row8
    }

    public enum ChessBoardColumn
    {
        ColA, ColB, ColC, ColD, ColE, ColF, ColG, ColH
    }

    public enum ChessTileHighlightCategory
    {
        None,
        Piece,
        // Attacked
    }

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
