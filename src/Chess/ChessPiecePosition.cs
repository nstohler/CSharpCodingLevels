using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class ChessPiecePosition : IEquatable<ChessPiecePosition>
    {
        public ChessBoardColumn Column { get; }
        public ChessBoardRow    Row { get; }

        public ChessPiecePosition(ChessBoardColumn column, ChessBoardRow row)
        {
            Column = column;
            Row = row;
        }

        public bool Equals(ChessPiecePosition other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Column == other.Column && Row == other.Row;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ChessPiecePosition)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((int)Column, (int)Row);
        }

        public static bool operator ==(ChessPiecePosition left, ChessPiecePosition right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ChessPiecePosition left, ChessPiecePosition right)
        {
            return !Equals(left, right);
        }
    }
}
