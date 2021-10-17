using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;

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
            board.ChessBoardTileCount.Should().Be(64);
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
            board.ChessBoardTileCount.Should().Be(64);

            for (int row = 0; row < 8; row++)
            {
                var rowColors = new List<ChessBoardColor>();
                for (int column = 0; column < 8; column++)
                {
                    rowColors.Add(board.ChessBoardColorAt(row, column));
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
            board.ChessBoardTileCount.Should().Be(64);

            var corner_1a = board.ChessBoardColorAt(0, (int)ChessBoardColumn.ColA);
            var corner_1h = board.ChessBoardColorAt(0, (int)ChessBoardColumn.ColH);
            var corner_8a = board.ChessBoardColorAt(7, (int)ChessBoardColumn.ColA);
            var corner_8h = board.ChessBoardColorAt(7, (int)ChessBoardColumn.ColH);

            corner_1a.Should().Be(ChessBoardColor.Black);
            corner_1h.Should().Be(ChessBoardColor.White);
            corner_8a.Should().Be(ChessBoardColor.White);
            corner_8h.Should().Be(ChessBoardColor.Black);
        }

        [TestMethod]
        public void AddPiece_should_fail_when_adding_the_same_piece_multiple_times()
        {
            // Arrange
            var board = new ChessBoard();
            var queen = ChessPiece.Queen;

            // Act
            board.AddPiece(ChessBoardRow.Row1, ChessBoardColumn.ColA, queen);
            Action act = () => board.AddPiece(ChessBoardRow.Row2, ChessBoardColumn.ColB, queen);

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("Piece with same Id already on the board.*")
                .WithParameterName("chessPiece");

            // board.Pieces.Add((0, ChessBoardColumn.A), queen); // TODO: better readonly access, do not allow to call add etc...

            board.Pieces.Count.Should().Be(1);
        }
    }
}
