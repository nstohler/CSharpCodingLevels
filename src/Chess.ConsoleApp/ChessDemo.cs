using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.ConsoleApp
{
    public class ChessDemo
    {
        private readonly ChessBoardVisualizerService _chessBoardVisualizerService;

        public ChessDemo(ChessBoardVisualizerService chessBoardVisualizerService)
        {
            _chessBoardVisualizerService = chessBoardVisualizerService;
        }

        public void Run()
        {
            var consoleTop = Console.CursorTop;
            var consoleLeft = Console.CursorLeft;

            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.ResetColor();

            var chessBoard = new ChessBoard();

            // draw an empty chessboard
            var (top, left) = _chessBoardVisualizerService.Draw(consoleTop, consoleLeft, chessBoard);

            var chessPiece = new ChessPiece();
            chessBoard.AddPiece(0, ChessBoardColumn.E, chessPiece);
            chessBoard.AddPiece(1, ChessBoardColumn.E, chessPiece);
            chessBoard.AddPiece(2, ChessBoardColumn.E, chessPiece);
            chessBoard.AddPiece(3, ChessBoardColumn.E, chessPiece);
            chessBoard.AddPiece(5, ChessBoardColumn.E, chessPiece);
            chessBoard.AddPiece(6, ChessBoardColumn.E, chessPiece);
            chessBoard.AddPiece(7, ChessBoardColumn.E, chessPiece);
            
            foreach (var chessBoardPiece in chessBoard.Pieces)
            {
                var row = chessBoardPiece.Key.row;
                var column = chessBoardPiece.Key.column;
                _chessBoardVisualizerService.DrawPiece(top, left, row, column, "P");
            }

            // temp: draw pieces as a test
            _chessBoardVisualizerService.DrawPiece(top, left, 0, ChessBoardColumn.A, "X");
            _chessBoardVisualizerService.DrawPiece(top, left, 1, ChessBoardColumn.B, "X");
            _chessBoardVisualizerService.DrawPiece(top, left, 2, ChessBoardColumn.C, "X");
            _chessBoardVisualizerService.DrawPiece(top, left, 3, ChessBoardColumn.D, "X");
            _chessBoardVisualizerService.DrawPiece(top, left, 4, ChessBoardColumn.E, "X");
            _chessBoardVisualizerService.DrawPiece(top, left, 5, ChessBoardColumn.F, "X");
            _chessBoardVisualizerService.DrawPiece(top, left, 6, ChessBoardColumn.G, "X");
            _chessBoardVisualizerService.DrawPiece(top, left, 7, ChessBoardColumn.H, "X");

            // put some pieces on the board and draw

        }
    }
}
