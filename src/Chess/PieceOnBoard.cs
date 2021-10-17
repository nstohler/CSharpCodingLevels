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
        private readonly PlayerColor _playerColor;

        public PieceOnBoard(ChessPiece chessPiece, PlayerColor playerColor)
        {
            _chessPiece = chessPiece;
            _playerColor = playerColor;
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
