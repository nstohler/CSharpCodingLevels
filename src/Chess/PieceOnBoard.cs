using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class PieceOnBoard
    {
        private readonly ChessPiece _chessPiece;

        public PieceOnBoard(ChessPiece chessPiece)
        {
            _chessPiece = chessPiece;
        }

        // TODO: 
        // - needs info of other pieces to update attack highlights
        // - move piece?
    }
}
