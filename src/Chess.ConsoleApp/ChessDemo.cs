﻿using Chess.Helpers;
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
            var boardIndent = 3; // to leave some space for the row labels on the left side of the board

            var consoleTop = Console.CursorTop;
            var consoleLeft = Console.CursorLeft;

            Console.SetCursorPosition(consoleLeft + 3, consoleTop);
            consoleLeft += boardIndent;

            var chessBoard = new ChessBoard();

            //chessBoard.AddPiece(0, ChessBoardColumn.E, ChessPiece.Queen);
            //chessBoard.AddPiece(1, ChessBoardColumn.E, ChessPiece.Queen);
            //chessBoard.AddPiece(2, ChessBoardColumn.E, ChessPiece.Queen);
            //chessBoard.AddPiece(3, ChessBoardColumn.E, ChessPiece.Queen);
            chessBoard.AddPiece(ChessBoardRow.Row5, ChessBoardColumn.ColE, ChessPiece.Queen);

            // diagonal checks
            chessBoard.AddPiece(ChessBoardRow.Row2, ChessBoardColumn.ColB, ChessPiece.Pawn);
            chessBoard.AddPiece(ChessBoardRow.Row3, ChessBoardColumn.ColG, ChessPiece.Pawn);
            chessBoard.AddPiece(ChessBoardRow.Row7, ChessBoardColumn.ColG, ChessPiece.Pawn);
            chessBoard.AddPiece(ChessBoardRow.Row7, ChessBoardColumn.ColC, ChessPiece.Pawn);

            // hor/vert checks
            chessBoard.AddPiece(ChessBoardRow.Row5, ChessBoardColumn.ColG, ChessPiece.Pawn);
            chessBoard.AddPiece(ChessBoardRow.Row5, ChessBoardColumn.ColB, ChessPiece.Pawn);
            chessBoard.AddPiece(ChessBoardRow.Row3, ChessBoardColumn.ColE, ChessPiece.Pawn);
            chessBoard.AddPiece(ChessBoardRow.Row7, ChessBoardColumn.ColE, ChessPiece.Pawn);

            //chessBoard.AddPiece(5, ChessBoardColumn.E, ChessPiece.Queen);
            //chessBoard.AddPiece(6, ChessBoardColumn.E, ChessPiece.Queen);
            //chessBoard.AddPiece(7, ChessBoardColumn.E, ChessPiece.Queen);

            // draw an empty chessboard
            _chessBoardVisualizerService.DrawBackgroundTileLayer(consoleTop, consoleLeft, chessBoard);
            _chessBoardVisualizerService.DrawColumnAndRowLabels(consoleTop, consoleLeft, boardIndent);
            // _chessBoardVisualizerService.DrawHighlightLayer(consoleTop, consoleLeft, chessBoard);

            foreach (var chessBoardPiece in chessBoard.Pieces)
            {
                var chessPiece = chessBoardPiece.Value;
                var row = chessBoardPiece.Key.row;
                var column = chessBoardPiece.Key.column;
                _chessBoardVisualizerService.DrawPiece(consoleTop, consoleLeft, 
                    row, column, chessBoard, 
                    ChessConverters.ChessPieceCategoryToCharMap[chessPiece.Category]);
            }

            //// temp: draw pieces as a test
            //_chessBoardVisualizerService.DrawPiece(consoleTop, consoleLeft, 0, ChessBoardColumn.A, "X");
            //_chessBoardVisualizerService.DrawPiece(consoleTop, consoleLeft, 1, ChessBoardColumn.B, "X");
            //_chessBoardVisualizerService.DrawPiece(consoleTop, consoleLeft, 2, ChessBoardColumn.C, "X");
            //_chessBoardVisualizerService.DrawPiece(consoleTop, consoleLeft, 3, ChessBoardColumn.D, "X");
            //_chessBoardVisualizerService.DrawPiece(consoleTop, consoleLeft, 4, ChessBoardColumn.E, "X");
            //_chessBoardVisualizerService.DrawPiece(consoleTop, consoleLeft, 5, ChessBoardColumn.F, "X");
            //_chessBoardVisualizerService.DrawPiece(consoleTop, consoleLeft, 6, ChessBoardColumn.G, "X");
            //_chessBoardVisualizerService.DrawPiece(consoleTop, consoleLeft, 7, ChessBoardColumn.H, "X");

            // put some pieces on the board and draw

            Console.SetCursorPosition(consoleLeft, consoleTop + 8 * ChessBoardVisualizerService.RepeatLineCount + 2);
        }
    }
}
