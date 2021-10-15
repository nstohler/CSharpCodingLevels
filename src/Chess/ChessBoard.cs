using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Xml.XPath;

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

        private readonly Dictionary<(int row, ChessBoardColumn column), ChessPiece> _pieces =
            new Dictionary<(int row, ChessBoardColumn column), ChessPiece>();

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

        public ImmutableDictionary<(int row, ChessBoardColumn column), ChessPiece> Pieces => _pieces.ToImmutableDictionary();

        public bool AddPiece(int row, ChessBoardColumn column, ChessPiece chessPiece)
        {
            var position = (row, column);
            var result = _pieces.TryAdd(position, chessPiece);
            return result;

            //if (!_pieces.ContainsKey(position))
            //{
            //    var result = _pieces.TryAdd(position, chessPiece);
            //}
        }
    }
}
