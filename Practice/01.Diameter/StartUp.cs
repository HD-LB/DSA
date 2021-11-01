using System;
using System.Linq;
using System.Collections.Generic;

namespace BoxOfBalls
{
    class BoxOfBallsMain
    {
        ////Recursion
        //static void Main()
        //{
        //    var moves = Console.ReadLine()
        //        .Split(' ')
        //        .Select(int.Parse)
        //        .ToArray();

        //    var ab = Console.ReadLine()
        //         .Split(' ')
        //         .Select(int.Parse)
        //         .ToArray();

        //    int a = ab[0];
        //    int b = ab[1];

        //    int total = 0;
        //    for (int i = a; i <= b; ++i)
        //    {
        //        if (IsWins(i, moves))
        //        {
        //            ++total;
        //        }
        //    }

        //    Console.WriteLine(total);
        //}

        //static bool IsWins(int balls, int[] moves)
        //{   
        //    if(balls == 0)
        //    {
        //        return false;
        //    }

        //    foreach (var move in moves)
        //    {
        //        if (move > balls)
        //        {
        //            continue;
        //        }
        //        if(!IsWins(balls - move, moves))
        //        {
        //            return true;
        //        }                
        //    }
        //    return false;
        //}


        //Dynamic Solution
        static void Main()
        {
            var moves = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Array.Sort(moves);

            var ab = Console.ReadLine()
                 .Split(' ')
                 .Select(int.Parse)
                 .ToArray();

            int a = ab[0];
            int b = ab[1];

            var isWins = new bool[b + 1];
            isWins[0] = false; //whoevere has 0 balls, looses
            for (int i = 1; i <= b; ++i)
            {
                foreach (var m in moves)
                {
                    if (m > i)
                    {
                        break;
                    }
                    if (!isWins[i - m])
                    {
                        isWins[i] = true;
                    }
                }
            }
            int total = 0;
            for (int i = a; i <= b; ++i)
            {
                if (isWins[i])
                {
                    ++total;
                }
            }

            Console.WriteLine(total);
        }
    }
}
