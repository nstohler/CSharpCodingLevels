using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Xml.XPath;

namespace Chess
{
    

    public class ChessBoard
    {
        private readonly ChessBoardColor[,] _chessBoardBackground = new ChessBoardColor[8,8];

        private readonly ChessTileHighlightCategory[,] _highlightCategoryPositions = new ChessTileHighlightCategory[8, 8];

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

                    _highlightCategoryPositions[row, column] = ChessTileHighlightCategory.None;
                }
            }
        }

        public int ChessBoardTileCount => _chessBoardBackground.Length;
        public ChessBoardColor ChessBoardColorAt(int row, int column) => _chessBoardBackground[row, column];

        public ChessTileHighlightCategory HighlightCategoryPositionAt(int row, int column) => _highlightCategoryPositions[row, column];

        public ImmutableDictionary<(int row, ChessBoardColumn column), ChessPiece> Pieces => _pieces.ToImmutableDictionary();

        public bool AddPiece(int row, ChessBoardColumn column, ChessPiece chessPiece)
        {
            // only add if the piece with the same id has not been added before
            if(_pieces.Values.Any(x => x.Id == chessPiece.Id))
            {
                throw new ArgumentException("Piece with same Id already on the board.", nameof(chessPiece));
            }

            var position = (row, column);
            var result = _pieces.TryAdd(position, chessPiece);

            // _highlightCategoryPositions[row, (int)column] = ChessTileHighlightCategory.None;

            return result;
        }
    }
}
