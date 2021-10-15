﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.ConsoleApp
{
    public class ChessBoardVisualizerService
    {
        public const int RepeatLineCount = 3;
        public const int RepeatCharCount = 5;

        private const ConsoleColor WhiteTileColor = ConsoleColor.White;
        private const ConsoleColor BlackTileColor = ConsoleColor.DarkGray;

        private const ConsoleColor HighlightPieceColor = ConsoleColor.Cyan;
        private const ConsoleColor HighlightAttackedColor = ConsoleColor.Red;

        public void DrawBackgroundTileLayer(int consoleTop, int consoleLeft, ChessBoard chessBoard)
        {
            // https://en.wikipedia.org/wiki/Box-drawing_character

            // https://docs.microsoft.com/en-us/dotnet/api/system.console.setcursorposition?view=net-5.0
            
            for (int row = 7; row > -1; row--)
            {
                for (int column = 0; column < 8; column++)
                {
                    var consoleColor = chessBoard.ChessBoardColorAt(row, column) == ChessBoardColor.White
                        ? WhiteTileColor
                        : BlackTileColor;
                    DrawBoxAt(consoleTop, consoleLeft, row, column, consoleColor, chessBoard);
                }
            }
            
            // reset position
            // Console.SetCursorPosition(consoleLeft, consoleTop + 8 * RepeatLineCount);
        }

        public void DrawHighlightLayer(int consoleTop, int consoleLeft, ChessBoard chessBoard)
        {
            for (int row = 7; row > -1; row--)
            {
                for (int column = 0; column < 8; column++)
                {
                    var highlightColor = chessBoard.HighlightCategoryPositionAt(row, column);
                    if (highlightColor != ChessTileHighlightCategory.None)
                    {
                        var consoleColor = ConsoleColor.Black;
                        switch (chessBoard.HighlightCategoryPositionAt(row, column))
                        {
                            case ChessTileHighlightCategory.Piece:
                                consoleColor = HighlightPieceColor;
                                break;
                            case ChessTileHighlightCategory.Attacked:
                                consoleColor = HighlightAttackedColor;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException("unsupported highlight category");
                                break;
                        }
                        DrawBoxAt(consoleTop, consoleLeft, row, column, consoleColor, chessBoard);
                    }
                }
            }
        }

        private void DrawBoxAt(int consoleTop, int consoleLeft, int row, int column, ConsoleColor consoleColor, ChessBoard chessBoard)
        {
            var consoleRow = 8 - row - 1;
            var posLeft = consoleLeft + RepeatCharCount * column; 
            var posTop = consoleTop + RepeatLineCount * consoleRow;

            Console.ForegroundColor = consoleColor;

            var color = chessBoard.ChessBoardColorAt(row, column);
            var drawChar = color == ChessBoardColor.White
                ? "\u2588"
                : "\u2588";

            for (int repeatLine = 0; repeatLine < RepeatLineCount; repeatLine++)
            {
                Console.SetCursorPosition(posLeft, posTop + repeatLine);
                for (int reapeatChar = 0; reapeatChar < RepeatCharCount; reapeatChar++)
                {
                    Console.Write(drawChar);
                }
            }

            Console.ResetColor();
            Console.SetCursorPosition(consoleLeft, consoleTop);
        }

        public void DrawPiece(int top, int left, int row, ChessBoardColumn chessBoardColumn, string s)
        {
            var origRow = Console.CursorTop;
            var origCol = Console.CursorLeft;

            var posX = left + RepeatCharCount * (int)chessBoardColumn + (RepeatCharCount / 2);
            var posY = top + RepeatLineCount * row + (RepeatLineCount / 2);

            Console.SetCursorPosition(posX, posY);
            Console.Write(s);

            Console.SetCursorPosition(origCol, origRow);
            //(RepeatLineCount * row) 
        }
    }
}
