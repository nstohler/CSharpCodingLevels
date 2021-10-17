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

        public void DrawBackgroundTileLayer(int consoleTop, int consoleLeft, ChessBoard chessBoard)
        {
            // https://en.wikipedia.org/wiki/Box-drawing_character

            // https://docs.microsoft.com/en-us/dotnet/api/system.console.setcursorposition?view=net-5.0
            
            for (int row = 7; row > -1; row--)
            {
                for (int column = 0; column < 8; column++)
                {
                    var backgroundColor = GetBackgroundConsoleColorAt(row, column, chessBoard);
                    DrawBoxAt(consoleTop, consoleLeft, row, column, backgroundColor, chessBoard);
                }
            }

            // reset position
            Console.SetCursorPosition(consoleTop, consoleLeft);
        }

        public void DrawColumnAndRowLabels(int consoleTop, int consoleLeft, int indent)
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

            Console.SetCursorPosition(consoleTop, consoleLeft);
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

        public void DrawPiece(int top, int left, ChessBoardRow row, ChessBoardColumn chessBoardColumn, ChessBoard chessBoard, string s)
        {
            var consoleRow = 8 - row - 1;
            var origRow = Console.CursorTop;
            var origCol = Console.CursorLeft;

            var posTop = top + RepeatLineCount * (int)consoleRow + (RepeatLineCount / 2);
            var posLeft = left + RepeatCharCount * (int)chessBoardColumn + (RepeatCharCount / 2);

            Console.SetCursorPosition(posLeft, posTop);

            var backgroundColor = GetBackgroundConsoleColorAt((int)row, (int)chessBoardColumn, chessBoard);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = backgroundColor;

            Console.Write(s);

            Console.ResetColor();

            Console.SetCursorPosition(origCol, origRow);
            //(RepeatLineCount * row) 
        }

        private ConsoleColor GetBackgroundConsoleColorAt(int row, int column, ChessBoard chessBoard)
        {
            // TODO: refactor into ChessBoard?
            // get either background or (if set) the highlight color at the position

            var chessBoardColor = chessBoard.ChessBoardColorAt(row, column);
            var backgroundColor = chessBoardColor == ChessBoardColor.White
                ? WhiteTileColor
                : BlackTileColor;

            var highlightColor = chessBoard.HighlightCategoryPositionAt(row, column);
            if (highlightColor != ChessTileHighlightCategory.None)
            {
                switch (chessBoard.HighlightCategoryPositionAt(row, column))
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

            if(chessBoard.EndangeredPositionAt(row, column))
            {
                backgroundColor = chessBoardColor == ChessBoardColor.White
                            ? HighlightEndangeredLightColor
                            : HighlightEndangeredDarkColor;
            }

            return backgroundColor;
        }
    }
}
