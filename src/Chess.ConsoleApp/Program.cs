using System;
using System.Text;

namespace Chess.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            var chessDemo = new ChessDemo(new ChessBoardVisualizerService());
            chessDemo.Run();
        }
    }
}
