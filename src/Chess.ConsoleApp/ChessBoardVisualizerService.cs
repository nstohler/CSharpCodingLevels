using Chess.Helpers;
using System;
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

        private const ConsoleColor HighlightPieceLightColor = ConsoleColor.Cyan;
        private const ConsoleColor HighlightPieceDarkColor = ConsoleColor.DarkCyan;

        private const ConsoleColor HighlightEndangeredLightColor = ConsoleColor.Red;
        private const ConsoleColor HighlightEndangeredDarkColor = ConsoleColor.DarkRed;

        public void DrawBackgroundTileLayer(int consoleLeft, int consoleTop, ChessBoard chessBoard)
        {
            // https://en.wikipedia.org/wiki/Box-drawing_character

            // https://docs.microsoft.com/en-us/dotnet/api/system.console.setcursorposition?view=net-5.0
            
            for (int row = 7; row > -1; row--)
            {
                for (int column = 0; column < 8; column++)
                {
                    var backgroundColor = GetBackgroundConsoleColorAt(column, row, chessBoard);
                    DrawBoxAt(consoleLeft, consoleTop, column, row, backgroundColor, chessBoard);
                }
            }

            // reset position
            Console.SetCursorPosition(consoleLeft, consoleTop);
        }

        public void DrawColumnAndRowLabels(int consoleLeft, int consoleTop, int indent)
        {
            for (int row = 7; row > -1; row--)
            {
                var consoleRow = 8 - row - 1;
                var posTop = consoleTop + RepeatLineCount * consoleRow + (RepeatLineCount / 2);

                Console.SetCursorPosition(consoleLeft - indent + 1, posTop);
                Console.Write(row + 1);
            }

            var labelRowPosTop = consoleTop + RepeatLineCount * 8 + 1;
            for (int col = 0; col < 8; col++)
            {
                var posLeft = consoleLeft + RepeatCharCount * col + (RepeatCharCount / 2);

                Console.SetCursorPosition(posLeft, labelRowPosTop);
                Console.Write(ChessConverters.ChessBoardColumnToCharMap[(ChessBoardColumn)col]);
            }

            Console.SetCursorPosition(consoleLeft, consoleTop);
        }

        private void DrawBoxAt(int consoleLeft, int consoleTop, int column, int row, ConsoleColor consoleColor, ChessBoard chessBoard)
        {
            var consoleRow = 8 - row - 1;
            var posLeft = consoleLeft + RepeatCharCount * column; 
            var posTop = consoleTop + RepeatLineCount * consoleRow;

            Console.ForegroundColor = consoleColor;

            var color = chessBoard.ChessBoardColorAt(column, row);
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

        public void DrawPiece(int left, int top, ChessBoardColumn chessBoardColumn, ChessBoardRow row, ChessBoard chessBoard, string s)
        {
            var consoleRow = 8 - row - 1;
            var origRow = Console.CursorTop;
            var origCol = Console.CursorLeft;

            var posTop = top + RepeatLineCount * (int)consoleRow + (RepeatLineCount / 2);
            var posLeft = left + RepeatCharCount * (int)chessBoardColumn + (RepeatCharCount / 2);

            Console.SetCursorPosition(posLeft, posTop);

            var backgroundColor = GetBackgroundConsoleColorAt((int)chessBoardColumn, (int)row, chessBoard);

            var isBlackPlayer = true;
            var boxColor = isBlackPlayer
                ? ConsoleColor.Black
                : ConsoleColor.White;

            // draw box
            //var boxBackgroundColor = 
            Console.ForegroundColor = boxColor;
            Console.BackgroundColor = backgroundColor;

            // above
            Console.SetCursorPosition(posLeft - 1, posTop - 1);
            Console.Write("\u2584\u2584\u2584");

            // below
            Console.SetCursorPosition(posLeft - 1, posTop + 1);
            Console.Write("\u2580\u2580\u2580");

            // same line as piece char
            Console.BackgroundColor = boxColor;
            Console.SetCursorPosition(posLeft - 1, posTop);
            Console.Write("\u2588\u2588\u2588");

            // draw piece char now 
            Console.ResetColor();
            Console.SetCursorPosition(posLeft, posTop);
            if (isBlackPlayer)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }
            Console.Write(s);

            Console.ResetColor();

            Console.SetCursorPosition(origCol, origRow);
        }

        private ConsoleColor GetBackgroundConsoleColorAt(int column, int row, ChessBoard chessBoard)
        {
            // TODO: refactor into ChessBoard?
            // get either background or (if set) the highlight color at the position

            var chessBoardColor = chessBoard.ChessBoardColorAt(column, row);
            var backgroundColor = chessBoardColor == ChessBoardColor.White
                ? WhiteTileColor
                : BlackTileColor;

            var highlightColor = chessBoard.HighlightCategoryPositionAt(column, row);
            if (highlightColor != ChessTileHighlightCategory.None)
            {
                switch (chessBoard.HighlightCategoryPositionAt(column, row))
                {
                    case ChessTileHighlightCategory.Piece:
                        backgroundColor = chessBoardColor == ChessBoardColor.White
                            ? HighlightPieceLightColor
                            : HighlightPieceDarkColor;
                        break;
                    //case ChessTileHighlightCategory.Attacked:
                    //    backgroundColor = chessBoardColor == ChessBoardColor.White
                    //        ? HighlightAttackedLightColor
                    //        : HighlightAttackedDarkColor;
                    //    break;
                    default:
                        break;
                }
            }

            if(chessBoard.EndangeredPositionAt(column, row))
            {
                backgroundColor = chessBoardColor == ChessBoardColor.White
                            ? HighlightEndangeredLightColor
                            : HighlightEndangeredDarkColor;
            }

            return backgroundColor;
        }
    }
}
