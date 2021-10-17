using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Xml.XPath;

namespace Chess
{
    // TODO:
    // - better data structures
    // - restricted access
    // - uniform access (row, column)
    // - drawing layers in own classes?
    // - logic to calculate endangered field via polymorphism/services?
    // - option to enable/disable single layers
    // - black/white player colors (font, symbol?)

    public class ChessBoard
    {
        private readonly ChessBoardColor[,] _chessBoardBackground = new ChessBoardColor[8, 8];

        private readonly ChessTileHighlightCategory[,] _highlightCategoryPositions = new ChessTileHighlightCategory[8, 8];

        private readonly bool[,] _endangeredPositions = new bool[8, 8];

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
                    _endangeredPositions[row, column] = false;
                }
            }
        }

        public int ChessBoardTileCount => _chessBoardBackground.Length;
        public ChessBoardColor ChessBoardColorAt(int row, int column) => _chessBoardBackground[row, column];

        public ChessTileHighlightCategory HighlightCategoryPositionAt(int row, int column) => _highlightCategoryPositions[row, column];

        public bool EndangeredPositionAt(int row, int column) => _endangeredPositions[row, column];

        public ImmutableDictionary<(int row, ChessBoardColumn column), ChessPiece> Pieces => _pieces.ToImmutableDictionary();

        public bool AddPiece(int row, ChessBoardColumn column, ChessPiece chessPiece)
        {
            // only add if the piece with the same id has not been added before
            if (_pieces.Values.Any(x => x.Id == chessPiece.Id))
            {
                throw new ArgumentException("Piece with same Id already on the board.", nameof(chessPiece));
            }

            var position = (row, column);
            var result = _pieces.TryAdd(position, chessPiece);

            _highlightCategoryPositions[row, (int)column] = ChessTileHighlightCategory.Piece;

            // mark attacked fields by this piece
            // - data strucure?
            //   - own layer owned by this piece or the board (so it can be removed again easily
            //   - or create combined attack layer after every addPiece/move piece action
            UpdateEndangeredPositions();

            return result;
        }

        private void UpdateEndangeredPositions()
        {
            ResetEndangeredPositions();
            foreach (var pieceEntry in _pieces)
            {
                var position = pieceEntry.Key;
                var piece = pieceEntry.Value;

                switch (piece.Category)
                {
                    case ChessPieceCategory.King:
                        break;
                    case ChessPieceCategory.Queen:
                        UpdateEndangeredPositionsByAQueen(position.row, position.column, piece);
                        break;
                    case ChessPieceCategory.Bishop:
                        break;
                    case ChessPieceCategory.Knight:
                        break;
                    case ChessPieceCategory.Rook:
                        break;
                    case ChessPieceCategory.Pawn:
                        break;
                }
            }
        }

        private void UpdateEndangeredPositionsByAQueen(int pieceRow, ChessBoardColumn pieceColumn, ChessPiece piece)
        {
            // same row to right
            for (int column = (int)pieceColumn + 1; column < 8; column++)
            {
                if (column != (int)pieceColumn)
                {
                    if (_pieces.Keys.Any(x => x.row == pieceRow && (int)x.column == column))
                    {
                        break;
                    }
                    _endangeredPositions[pieceRow, column] = true;
                }
            }

            // same row to right
            for (int column = (int)pieceColumn - 1; column > -1; column--)
            {
                if (column != (int)pieceColumn)
                {
                    if (_pieces.Keys.Any(x => x.row == pieceRow && (int)x.column == column))
                    {
                        break;
                    }
                    _endangeredPositions[pieceRow, column] = true;
                }
            }

            // same column down
            for (int row = 0; row < 8; row++)
            {
                if (row != (int)pieceRow)
                {
                    if (_pieces.Keys.Any(x => x.row == pieceRow && x.column == pieceColumn))
                    {
                        break;
                    }
                    _endangeredPositions[row, (int)pieceColumn] = true;
                }
            }

            // same column up
            for (int row = pieceRow - 1; row > -1; row--)
            {
                if (row != (int)pieceRow)
                {
                    if (_pieces.Keys.Any(x => x.row == pieceRow && x.column == pieceColumn))
                    {
                        break;
                    }
                    _endangeredPositions[row, (int)pieceColumn] = true;
                }
            }

            // diagonally in all 4 directions

            // down and left
            {
                var row = pieceRow - 1;
                var col = (int)pieceColumn - 1;
                for (; row > -1 && col > -1; row--, col--)
                {
                    // from piece left
                    if (_pieces.Keys.Any(x => x.row == row && (int)x.column == col))
                    {
                        break;
                    }
                    _endangeredPositions[row, col] = true;
                }
            }

            // down and right
            {
                var row = pieceRow - 1;
                var col = (int)pieceColumn + 1;
                for (; row > -1 && col < 8; row--, col++)
                {
                    // from piece right
                    if (_pieces.Keys.Any(x => x.row == row && (int)x.column == col))
                    {
                        break;
                    }
                    _endangeredPositions[row, col] = true;
                }
            }

            // up and left
            {
                var row = pieceRow + 1;
                var col = (int)pieceColumn - 1;
                for (; row < 8 && col > -1; row++, col--)
                {
                    // from piece left
                    if (_pieces.Keys.Any(x => x.row == row && (int)x.column == col))
                    {
                        break;
                    }
                    _endangeredPositions[row, col] = true;
                }
            }

            // up and right
            {
                var row = pieceRow + 1;
                var col = (int)pieceColumn + 1;
                for (; row < 8 && col < 8; row++, col++)
                {
                    // from piece right
                    if (_pieces.Keys.Any(x => x.row == row && (int)x.column == col))
                    {
                        break;
                    }
                    _endangeredPositions[row, col] = true;
                }
            }
        }

        private void ResetEndangeredPositions()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    //if (_highlightCategoryPositions[row, column] == ChessTileHighlightCategory.Attacked)
                    //{
                    //    _highlightCategoryPositions[row, column] = ChessTileHighlightCategory.None;
                    //    _endangeredPositions[row, column] = false;
                    //}
                    _endangeredPositions[row, column] = false;
                }
            }
        }
    }
}