using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.ConsoleApp
{
    public class ChessBoardVisualizerService
    {
        private const int RepeatLineCount = 3;
        private const int RepeatCharCount = 5;

        public (int top, int left) Draw(int consoleTop, int consoleLeft, ChessBoard chessBoard)
        {
            // https://en.wikipedia.org/wiki/Box-drawing_character

            // https://docs.microsoft.com/en-us/dotnet/api/system.console.setcursorposition?view=net-5.0
            //Console.Clear();
            

            for (int row = 7; row > -1; row--)
            {
                for (int column = 0; column < 8; column++)
                {
                    var consoleColor = chessBoard.ChessBoardBackground[row, column] == ChessBoardColor.White
                        ? ConsoleColor.White
                        : ConsoleColor.Cyan;
                    DrawBoxAt(consoleTop, consoleLeft, row, column, consoleColor, chessBoard);
                }
            }

            //// draw to console
            //for (int row = 7; row > -1; row--)
            //{
            //    for (int repeatLine = 0; repeatLine < RepeatLineCount; repeatLine++)
            //    {
            //        for (int column = 0; column < 8; column++)
            //        {
            //            for (int reapeatChar = 0; reapeatChar < RepeatCharCount; reapeatChar++)
            //            {
            //                var color = chessBoard.ChessBoardBackground[row, column];
            //                var drawChar = color == ChessBoardColor.White
            //                    ? "\u2588"
            //                    : "\u2591";

            //                // TODO: add logic here to draw chess piece

            //                Console.Write(drawChar);
            //            }
            //        }

            //        Console.WriteLine();
            //    }
            //}
            //Console.WriteLine();
            
            //var (endPosX, endPosY) = (Console.CursorTop, Console.CursorLeft);
            ////var origCol = Console.CursorLeft;

            //Console.SetCursorPosition(origCol+7, origRow+1);
            //Console.Write('X');

            //Console.SetCursorPosition(endPosY, endPosX);
            //// Console.Write("");
            ///
            
            Console.SetCursorPosition(consoleLeft, consoleTop + 8 * RepeatLineCount);

            return (consoleTop, consoleLeft);
        }

        private void DrawBoxAt(int consoleTop, int consoleLeft, int row, int column, ConsoleColor consoleColor, ChessBoard chessBoard)
        {
            var consoleRow = 8 - row - 1;
            var posLeft = consoleLeft + RepeatCharCount * column; 
            var posTop = consoleTop + RepeatLineCount * consoleRow;

            Console.ForegroundColor = consoleColor;

            var color = chessBoard.ChessBoardBackground[row, column];
            var drawChar = color == ChessBoardColor.White
                ? "\u2588"
                : "\u2591";

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
