using System;

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

    public class ChessBoard
    {
        private readonly ChessBoardColor[,] _chessBoardBackground = new ChessBoardColor[8,8];

        public ChessBoard()
        {
            for (int row = 0; row < 8; row++)
            {
                var startRowWithBlack = row % 2 == 0;
                var columnModifier = startRowWithBlack ? 0 : 1;
                for (int column = 0; column < 8; column++)
                {
                    var drawBlack = column % 2 == columnModifier;
                    _chessBoardBackground[row, column] = drawBlack 
                        ? ChessBoardColor.Black 
                        : ChessBoardColor.White;
                }
            }
        }

        public ChessBoardColor[,] ChessBoardBackground => _chessBoardBackground;
    }
}
