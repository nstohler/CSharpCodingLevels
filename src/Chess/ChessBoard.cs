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
            if(_pieces.Values.Any(x => x.Id == chessPiece.Id))
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
            // same row
            for (int column = 0; column < 8; column++)
            {
                if(column != (int)pieceColumn)
                {
                    _endangeredPositions[pieceRow, column] = true;
                }
            }

            // same column
            for (int row = 0; row < 8; row++)
            {
                if (row != (int)pieceRow)
                {
                    _endangeredPositions[row, (int)pieceColumn] = true;
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