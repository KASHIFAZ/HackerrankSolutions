using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {

            foreach(int i in ClimbingTheLeaderBoard.ClimbingLeaderboard(new int[] { 100, 100, 50, 40, 40, 20, 10 }, new int[] { 5, 25, 50, 120 }))
            {
                Console.WriteLine(i);
            }
        }
    }
}
