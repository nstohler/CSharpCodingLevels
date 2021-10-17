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
        // - color endangered pieces in different color
        // - white/black player distinguishing

        // REQ?
        // - Helper service
        //   - To check if one position is horizontally/vertically/diagonally reachable/attackable from another position
    }
}
