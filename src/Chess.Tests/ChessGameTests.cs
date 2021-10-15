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

        [TestMethod]
        public void Constructor_creates_empty_chessboard_with_correct_corner_colors()
        {
            // Arrange/Act
            var board = new ChessBoard();
            
            // Assert
            board.ChessBoardBackground.Length.Should().Be(64);

            var corner_1a = board.ChessBoardBackground[0, (int)ChessBoardColumn.A];
            var corner_1h = board.ChessBoardBackground[0, (int)ChessBoardColumn.H];
            var corner_8a = board.ChessBoardBackground[7, (int)ChessBoardColumn.A];
            var corner_8h = board.ChessBoardBackground[7, (int)ChessBoardColumn.H];

            corner_1a.Should().Be(ChessBoardColor.Black);
            corner_1h.Should().Be(ChessBoardColor.White);
            corner_8a.Should().Be(ChessBoardColor.White);
            corner_8h.Should().Be(ChessBoardColor.Black);
        }
    }
}
