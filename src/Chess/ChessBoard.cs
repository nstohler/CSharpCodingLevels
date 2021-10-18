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

        private readonly Dictionary<(ChessBoardColumn column, ChessBoardRow row), ChessPiece> _pieces =
            new Dictionary<(ChessBoardColumn column, ChessBoardRow row), ChessPiece>();

        public ChessBoard()
        {
            var x = ChessAttackCalculationService.QueenAttackPaths;

            for (int row = 0; row < 8; row++)
            {
                var startRowWithBlack = row % 2 == 0;
                var columnModifier = startRowWithBlack ? 0 : 1;
                for (int column = 0; column < 8; column++)
                {
                    var drawBlack = column % 2 == columnModifier;
                    _chessBoardBackground[column, row] = drawBlack
                        ? ChessBoardColor.Black
                        : ChessBoardColor.White;

                    _highlightCategoryPositions[column, row] = ChessTileHighlightCategory.None;
                    _endangeredPositions[column, row] = false;
                }
            }
        }

        public int ChessBoardTileCount => _chessBoardBackground.Length;
        public ChessBoardColor ChessBoardColorAt(int column, int row) => _chessBoardBackground[column, row];

        public ChessTileHighlightCategory HighlightCategoryPositionAt(int column, int row) => _highlightCategoryPositions[column, row];

        public bool EndangeredPositionAt(int column, int row) => _endangeredPositions[column, row];

        public ImmutableDictionary<(ChessBoardColumn column, ChessBoardRow row), ChessPiece> Pieces => _pieces.ToImmutableDictionary();

        public bool AddPiece(ChessBoardColumn column, ChessBoardRow row, ChessPiece chessPiece)
        {
            // only add if the piece with the same id has not been added before
            if (_pieces.Values.Any(x => x.Id == chessPiece.Id))
            {
                throw new ArgumentException("Piece with same Id already on the board.", nameof(chessPiece));
            }

            var position = (column, row);
            var result = _pieces.TryAdd(position, chessPiece);

            _highlightCategoryPositions[(int)column, (int)row] = ChessTileHighlightCategory.Piece;

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
                        UpdateEndangeredPositionsByAQueen(position.column, position.row, piece);
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

        private void UpdateEndangeredPositionsByAQueen(ChessBoardColumn pieceColumn, ChessBoardRow pieceRow, ChessPiece piece)
        {
            // same row to right
            for (int column = (int)pieceColumn + 1; column < 8; column++)
            {
                if (column != (int)pieceColumn)
                {
                    _endangeredPositions[column, (int)pieceRow] = true;
                    if (_pieces.Keys.Any(x => (int)x.column == column && x.row == pieceRow))
                    {
                        break;
                    }
                }
            }

            // same row to right
            for (int column = (int)pieceColumn - 1; column > -1; column--)
            {
                if (column != (int)pieceColumn)
                {
                    _endangeredPositions[column, (int)pieceRow] = true;
                    if (_pieces.Keys.Any(x => (int)x.column == column && x.row == pieceRow))
                    {
                        break;
                    }
                }
            }

            // same column down
            for (int row = (int)pieceRow + 1; row < 8; row++)
            {
                _endangeredPositions[(int)pieceColumn, row] = true;
                if (_pieces.Keys.Any(x => x.column == pieceColumn && (int)x.row == row))
                {
                    break;
                }
            }

            // same column up
            for (int row = (int)pieceRow - 1; row > -1; row--)
            {
                _endangeredPositions[(int)pieceColumn, row] = true;
                if (_pieces.Keys.Any(x => x.column == pieceColumn && (int)x.row == row))
                {
                    break;
                }
            }

            // diagonally in all 4 directions

            // down and left
            {
                var row = (int)pieceRow - 1;
                var col = (int)pieceColumn - 1;
                for (; row > -1 && col > -1; row--, col--)
                {
                    // from piece left
                    _endangeredPositions[col, row] = true;
                    if (_pieces.Keys.Any(x => (int)x.column == col && (int)x.row == row))
                    {
                        break;
                    }
                }
            }

            // down and right
            {
                var row = pieceRow - 1;
                var col = (int)pieceColumn + 1;
                for (; (int)row > -1 && col < 8; row--, col++)
                {
                    // from piece right
                    _endangeredPositions[col, (int)row] = true;
                    if (_pieces.Keys.Any(x => (int)x.column == col && x.row == row))
                    {
                        break;
                    }
                }
            }

            // up and left
            {
                var row = pieceRow + 1;
                var col = (int)pieceColumn - 1;
                for (; (int)row < 8 && col > -1; row++, col--)
                {
                    // from piece left
                    _endangeredPositions[col, (int)row] = true;
                    if (_pieces.Keys.Any(x => (int)x.column == col && x.row == row))
                    {
                        break;
                    }
                }
            }

            // up and right
            {
                var row = pieceRow + 1;
                var col = (int)pieceColumn + 1;
                for (; (int)row < 8 && col < 8; row++, col++)
                {
                    // from piece right
                    _endangeredPositions[col, (int)row] = true;
                    if (_pieces.Keys.Any(x => (int)x.column == col && x.row == row))
                    {
                        break;
                    }
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
                    _endangeredPositions[column, row] = false;
                }
            }
        }
    }
}