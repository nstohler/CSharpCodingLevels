﻿using System;
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

            var chessBoard = new ChessBoard();

            var chessPiece = new ChessPiece();
            chessBoard.AddPiece(0, ChessBoardColumn.E, chessPiece);
            chessBoard.AddPiece(1, ChessBoardColumn.E, chessPiece);
            chessBoard.AddPiece(2, ChessBoardColumn.E, chessPiece);
            chessBoard.AddPiece(3, ChessBoardColumn.E, chessPiece);
            chessBoard.AddPiece(5, ChessBoardColumn.E, chessPiece);
            chessBoard.AddPiece(6, ChessBoardColumn.E, chessPiece);
            chessBoard.AddPiece(7, ChessBoardColumn.E, chessPiece);

            // draw an empty chessboard
            _chessBoardVisualizerService.DrawBackgroundTileLayer(consoleTop, consoleLeft, chessBoard);
            _chessBoardVisualizerService.DrawHighlightLayer(consoleTop, consoleLeft, chessBoard);

            foreach (var chessBoardPiece in chessBoard.Pieces)
            {
                var row = chessBoardPiece.Key.row;
                var column = chessBoardPiece.Key.column;
                _chessBoardVisualizerService.DrawPiece(consoleTop, consoleLeft, row, column, "P");
            }

            // temp: draw pieces as a test
            _chessBoardVisualizerService.DrawPiece(consoleTop, consoleLeft, 0, ChessBoardColumn.A, "X");
            _chessBoardVisualizerService.DrawPiece(consoleTop, consoleLeft, 1, ChessBoardColumn.B, "X");
            _chessBoardVisualizerService.DrawPiece(consoleTop, consoleLeft, 2, ChessBoardColumn.C, "X");
            _chessBoardVisualizerService.DrawPiece(consoleTop, consoleLeft, 3, ChessBoardColumn.D, "X");
            _chessBoardVisualizerService.DrawPiece(consoleTop, consoleLeft, 4, ChessBoardColumn.E, "X");
            _chessBoardVisualizerService.DrawPiece(consoleTop, consoleLeft, 5, ChessBoardColumn.F, "X");
            _chessBoardVisualizerService.DrawPiece(consoleTop, consoleLeft, 6, ChessBoardColumn.G, "X");
            _chessBoardVisualizerService.DrawPiece(consoleTop, consoleLeft, 7, ChessBoardColumn.H, "X");

            // put some pieces on the board and draw

            Console.SetCursorPosition(consoleLeft, consoleTop + 8 * ChessBoardVisualizerService.RepeatLineCount);
        }
    }
}
