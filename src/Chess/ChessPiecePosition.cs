using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class ChessPiecePosition : IEquatable<ChessPiecePosition>
    {
        public ChessBoardRow    Row { get; }
        public ChessBoardColumn Column { get; }

        public ChessPiecePosition(ChessBoardRow row, ChessBoardColumn column)
        {
            Row = row;
            Column = column;
        }

        public bool Equals(ChessPiecePosition other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Row == other.Row && Column == other.Column;
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
            return HashCode.Combine((int)Row, (int)Column);
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
