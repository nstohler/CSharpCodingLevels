using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Chess.Tests
{
    [TestClass]
    public class ChessGameTests
    {
        [TestMethod]
        public void Constructor_creates_empty_chessboard()
        {
            // Arrange/Act
            var board = new ChessBoard();

            // Assert
            board.ChessBoardBackground.Length.Should().Be(64);
        }

        [TestMethod]
        public void Constructor_creates_empty_chessboard_with_correct_background_pattern()
        {
            // Arrange/Act
            var board = new ChessBoard();
            var expectedEvenRowColorPattern = new List<ChessBoardColor>()
            {
                ChessBoardColor.Black, ChessBoardColor.White, ChessBoardColor.Black, ChessBoardColor.White,
                ChessBoardColor.Black, ChessBoardColor.White, ChessBoardColor.Black, ChessBoardColor.White,
            };
            var expectedOddRowColorPattern = new List<ChessBoardColor>()
            {
                ChessBoardColor.White, ChessBoardColor.Black, ChessBoardColor.White, ChessBoardColor.Black, 
                ChessBoardColor.White, ChessBoardColor.Black, ChessBoardColor.White, ChessBoardColor.Black, 
            };

            // Assert
            board.ChessBoardBackground.Length.Should().Be(64);

            for (int row = 0; row < 8; row++)
            {
                var rowColors = new List<ChessBoardColor>();
                for (int column = 0; column < 8; column++)
                {
                    rowColors.Add(board.ChessBoardBackground[row, column]);
                }

                if (row % 2 == 0)
                {
                    rowColors.Should().Equal(expectedEvenRowColorPattern);
                }
                else
                {
                    rowColors.Should().Equal(expectedOddRowColorPattern);
                }
            }
        }
    }
}
