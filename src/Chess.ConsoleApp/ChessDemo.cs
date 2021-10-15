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
            var chessBoard = new ChessBoard();

            // draw an empty chessboard
            var (top, left) = _chessBoardVisualizerService.Draw(chessBoard);

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
