using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Helpers
{
    public static class ChessConverters
    {
        private static readonly ImmutableList<(string ChessPieceChar, string DisplayName, ChessPieceCategory Category)> PieceMappings =
            new List<(string, string, ChessPieceCategory)>()
            {
                //( "\u2655", "Queen", ChessPieceCategory.Queen ),
                ( "Q", "Queen", ChessPieceCategory.Queen ),
                ( "K", "King", ChessPieceCategory.King ),
                ( "B", "Bishop", ChessPieceCategory.Bishop ),
                ( "R", "Rook", ChessPieceCategory.Rook ),
                ( "N", "Knight", ChessPieceCategory.Knight ),
                ( "P", "Pawn", ChessPieceCategory.Pawn ),
            }
            .ToImmutableList();

        private static readonly ImmutableList<(string ColumnChar, ChessBoardColumn Column)> ColumnMappings =
            new List<(string, ChessBoardColumn)>()
            {
                ( "A", ChessBoardColumn.ColA ),
                ( "B", ChessBoardColumn.ColB ), 
                ( "C", ChessBoardColumn.ColC ),
                ( "D", ChessBoardColumn.ColD ),
                ( "E", ChessBoardColumn.ColE ),
                ( "F", ChessBoardColumn.ColF ), 
                ( "G", ChessBoardColumn.ColG ),
                ( "H", ChessBoardColumn.ColH ),
            }
            .ToImmutableList();

        private static readonly ImmutableList<(string RowChar, ChessBoardRow Row)> RowMappings =
            new List<(string, ChessBoardRow)>()
            {
                ( "1", ChessBoardRow.Row1 ),
                ( "2", ChessBoardRow.Row2 ),
                ( "3", ChessBoardRow.Row3 ),
                ( "4", ChessBoardRow.Row4 ),
                ( "5", ChessBoardRow.Row5 ),
                ( "6", ChessBoardRow.Row6 ),
                ( "7", ChessBoardRow.Row7 ),
                ( "8", ChessBoardRow.Row8 ),
            }
            .ToImmutableList();

        public static readonly ImmutableDictionary<ChessPieceCategory, string> ChessPieceCategoryToCharMap;
        public static readonly ImmutableDictionary<ChessBoardColumn, string> ChessBoardColumnToCharMap;
        public static readonly ImmutableDictionary<ChessBoardRow, string> ChessBoardRowToCharMap;

        static ChessConverters()
        {
            ChessPieceCategoryToCharMap = PieceMappings
                .Select(x => new { Key = x.Category, Value = x.ChessPieceChar })
                .ToImmutableDictionary(x => x.Key, x => x.Value);

            ChessBoardColumnToCharMap = ColumnMappings
                .Select(x => new { Key = x.Column, Value = x.ColumnChar })
                .ToImmutableDictionary(x => x.Key, x => x.Value);

            ChessBoardRowToCharMap = RowMappings
                .Select(x => new { Key = x.Row, Value = x.RowChar })
                .ToImmutableDictionary(x => x.Key, x => x.Value);

        }
    }
}
