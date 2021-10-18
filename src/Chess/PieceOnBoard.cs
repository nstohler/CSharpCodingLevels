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
        // - try chessPiece movement matrix 
        //   - (0,0) is the player origin 
        //   - rest is in relative coordinates to (0,0), at most 8 in any direction
        // - OR: as enums/functions:
        //   - Horizontally, Vertically, DiagonallyUpLeft, DiagonallyUpRight, DiagonallyDownLeft, DiagonallyDownRight
        //   - KnightJump
        //   - PawnMove/PawnMoveIfNotMovedBefore/PawnAttack/PawnAttackEnPassant
        //   - KingMove
        // - calulate attack/movement possibilities starting from origin outwards, until something is blocking

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
