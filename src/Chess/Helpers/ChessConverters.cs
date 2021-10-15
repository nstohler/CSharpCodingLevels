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
        private static readonly ImmutableList<(string ChessPieceChar, string DisplayName, ChessPieceCategory Category)> AllMappings =
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

        public static readonly ImmutableDictionary<ChessPieceCategory, string> ChessPieceCategoryToCharMap;

        static ChessConverters()
        {
            ChessPieceCategoryToCharMap = AllMappings
                .Select(x => new { Key = x.Category, Value = x.ChessPieceChar })
                .ToImmutableDictionary(x => x.Key, x => x.Value);

        }
    }
}
