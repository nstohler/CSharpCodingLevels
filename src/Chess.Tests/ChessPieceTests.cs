using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Chess.Tests
{
    [TestClass]
    public class ChessPieceTests
    {
        [TestMethod]
        public void Static_getters_create_unique_pieces()
        {
            // Arrange


            // Act
            var queen1 = ChessPiece.Queen;
            var queen2 = ChessPiece.Queen;

            // Assert
            queen1.Should().NotBeSameAs(queen2);
            queen1.Id.Should().NotBe(queen2.Id);
        }
    }
}
