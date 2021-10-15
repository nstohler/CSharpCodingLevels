using System;
using System.Text;

namespace Chess.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var chessDemo = new ChessDemo(new ChessBoardVisualizerService());
            chessDemo.Run();
        }
    }
}
