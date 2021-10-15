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

        public (int top, int left) Draw(ChessBoard chessBoard)
        {
            // https://en.wikipedia.org/wiki/Box-drawing_character

            // https://docs.microsoft.com/en-us/dotnet/api/system.console.setcursorposition?view=net-5.0
            //Console.Clear();
            var origRow = Console.CursorTop;
            var origCol = Console.CursorLeft;

            // draw to console
            for (int row = 7; row > -1; row--)
            {
                for (int repeatLine = 0; repeatLine < RepeatLineCount; repeatLine++)
                {
                    for (int column = 0; column < 8; column++)
                    {
                        for (int reapeatChar = 0; reapeatChar < RepeatCharCount; reapeatChar++)
                        {
                            var color = chessBoard.ChessBoardBackground[row, column];
                            var drawChar = color == ChessBoardColor.White
                                ? "\u2588"
                                : "\u2591";

                            // TODO: add logic here to draw chess piece

                            Console.Write(drawChar);
                        }
                    }

                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            
            //var (endPosX, endPosY) = (Console.CursorTop, Console.CursorLeft);
            ////var origCol = Console.CursorLeft;

            //Console.SetCursorPosition(origCol+7, origRow+1);
            //Console.Write('X');

            //Console.SetCursorPosition(endPosY, endPosX);
            //// Console.Write("");

            return (origRow, origCol);
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
