using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    // Horizontally, Vertically, DiagonallyUpLeft, DiagonallyUpRight, DiagonallyDownLeft, DiagonallyDownRight
    public enum AttackVector
    {
        Left, 
        Right, 
        Up, 
        Down, 
        LeftUp, 
        LeftDown, 
        RightUp, 
        RightDown
    }

    public class ChessAttackCalculationService
    {
        // (row, col)
        public static readonly IImmutableList<(int Column, int Row)> QueenAttackPaths = Initialize();
        
        public static readonly IImmutableDictionary<AttackVector, List<(int Column, int Row)>> QueenAttackVector = InitializeVectors();

        private static IImmutableDictionary<AttackVector, List<(int Column, int Row)>> InitializeVectors()
        {
            var vectorLeft = new List<(int, int)>();
            var vectorRight = new List<(int, int)>();
            var vectorDown = new List<(int, int)>();
            var vectorUp = new List<(int, int)>();
            var vectorLeftUp = new List<(int, int)>();
            var vectorLeftDown = new List<(int, int)>();
            var vectorRightUp = new List<(int, int)>();
            var vectorRightDown = new List<(int, int)>();

            for (int i = 1; i < 8; i++)
            {
                vectorLeft.Add((-i, 0));
                vectorRight.Add((i, 0));

                vectorUp.Add((0, i));
                vectorDown.Add((0, -i));

                vectorLeftUp.Add((-i, i));
                vectorLeftDown.Add((-i, -i));

                vectorRightUp.Add((i, i));
                vectorRightDown.Add((i, -i));
            }

            var map = new Dictionary<AttackVector, List<(int Column, int Row)>>();
            map.Add(AttackVector.Left, vectorLeft);
            map.Add(AttackVector.Right, vectorRight);
            map.Add(AttackVector.Down, vectorDown);
            map.Add(AttackVector.Up, vectorUp);
            map.Add(AttackVector.LeftUp, vectorLeftUp);
            map.Add(AttackVector.LeftDown, vectorLeftDown);
            map.Add(AttackVector.RightUp, vectorRightUp);
            map.Add(AttackVector.RightDown, vectorRightDown);

            return map.ToImmutableDictionary();
        }

        //static ChessAttackCalculationService()
        //{
        //    //var queenAttackMatrix[,] = new 

        //    var queenAttackMatrix = new List<(int, int)>();
        //    for (int i = -7; i < 8; i++)
        //    {
        //        queenAttackMatrix.Add((0, i));  // horizontally
        //        queenAttackMatrix.Add((i, 0));  // vertically
        //        queenAttackMatrix.Add((-i, i)); // diagonally up-left / down-right
        //        queenAttackMatrix.Add((i, i));  // diagonally down-left / up-right
        //    }

        //    QueenAttackPaths = queenAttackMatrix.ToImmutableList();
        //}


        private static IImmutableList<(int, int)> Initialize()
        {
            var queenAttackMatrix = new List<(int, int)>();
            for (int i = -7; i < 8; i++)
            {
                queenAttackMatrix.Add((i, 0));  // horizontally
                queenAttackMatrix.Add((0, i));  // vertically
                queenAttackMatrix.Add((i, -i)); // diagonally up-left / down-right
                queenAttackMatrix.Add((i, i));  // diagonally down-left / up-right
            }

            // TODO: save single "vectors" from (0,0) outwards

            // makes sense to sort inward out? 

            return queenAttackMatrix.ToImmutableList();
        }

        //static (bool isReachable, int distance) IsVerticallyReachable(ChessPiecePosition position1, ChessPiecePosition position2)
        //{
        //    //if(position1)
        //}
    }
}
