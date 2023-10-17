using Stockfish.NET;
using Stockfish.NET.Models;
using System;

namespace ChessStockfishConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stockfish.NET.Stockfish stockfish = new Stockfish.NET.Stockfish(@"C:\TUe\Homework\Personal Projects\ChessStockfishConsole\ChessStockfishConsole\bin\Debug\net6.0\stockfish_20090216_x64.exe");
            //stockfish.SetPosition("e2e4", "e7e6");
            /*Console.WriteLine(stockfish.GetBoardVisual());
            

            var move = stockfish.GetBestMove();
            stockfish.SetPosition("e2e4", "e7e6", move);

            Console.WriteLine(stockfish.GetBoardVisual());

            //stockfish.SetPosition("e2", "e4");
            //Console.WriteLine(stockfish.GetBoardVisual());*/


            //Evaluation evaluation = new Evaluation();
            int n = 0;
            string[] moves = new string[401];
            //moves[0] = "e2e4";
            //moves[1] = "c7c6";
            while (n < 200)
            {
                string previousMove = stockfish.GetBestMoveTime(1000);
                moves[n] = previousMove;
                stockfish.SetPosition(moves);

                var currentMove = stockfish.GetBestMoveTime(1000);
                moves[n + 1] = currentMove;
                stockfish.SetPosition(moves);
                Console.WriteLine(stockfish.GetBoardVisual());
                //Console.WriteLine(stockfish.GetEvaluation());
                n += 2;

                //evaluation = stockfish.GetEvaluation();
                //Console.WriteLine(evaluation.Type + " " + evaluation.Value);
                /*if(evaluation.Value >= 3200 || evaluation.Value >= -3200)
                {
                    break;
                }*/
            }
            var pos = stockfish.GetFenPosition();
            Console.WriteLine(pos);

            foreach (var move in moves)
            {
                Console.Write(move + " ");
            }
        }
    }
}
