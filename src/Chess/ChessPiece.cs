using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class ChessPiece
    {
        public static ChessPiece Queen => new ChessPiece(ChessPieceCategory.Queen);

        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public readonly ChessPieceCategory Category;

        public ChessPiece(ChessPieceCategory category)
        {
            Category = category;
        }
    }
}
