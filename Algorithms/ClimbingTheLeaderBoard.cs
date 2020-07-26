using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    public class ClimbingTheLeaderBoard
    {
        //100 100 50 40 40 20 10

        //5 25 50 120
        public static int[] ClimbingLeaderboard(int[] scores, int[] alice)
        {
            int[] ranks = new int[alice.Length];
            Dictionary<int, int> rankScoreMap = new Dictionary<int, int>();
            for(int gameNo = 0; gameNo<alice.Length; gameNo++)
            {
                if (gameNo == 0)
                {
                    SetRankMap(scores, alice, ranks, rankScoreMap, gameNo);
                }
                else
                {
                    if (ranks[gameNo - 1] == 1)
                    {
                        ranks[gameNo] = 1;
                        continue;
                    }
                    int position = ranks[gameNo - 1] - 1;
                    position = SetRanks(alice, ranks, rankScoreMap, gameNo, position);
                }
            }
            return ranks;
        }

        private static int SetRanks(int[] alice, int[] ranks, Dictionary<int, int> rankScoreMap, int gameNo, int position)
        {
            while (position > 0)
            {
                if (rankScoreMap[position] == alice[gameNo])
                {
                    ranks[gameNo] = position;
                    break;
                }
                else if (rankScoreMap[position] > alice[gameNo])
                {
                    ranks[gameNo] = position + 1;
                    break;
                }
                else
                {
                    if (position == 1)
                    {
                        ranks[gameNo] = 1;
                        break;
                    }
                    position--;
                }
            }

            return position;
        }

        private static void SetRankMap(int[] scores, int[] alice, int[] ranks, Dictionary<int, int> rankScoreMap, int gameNo)
        {
            int denseRank = 0;
            int lastScore = 0;
            for (int scorePosition = 0; scorePosition < scores.Length; scorePosition++)
            {
                if (scores[scorePosition] != lastScore)
                {
                    lastScore = scores[scorePosition];
                    denseRank++;
                    rankScoreMap.Add(denseRank, scores[scorePosition]);
                }
                if (alice[gameNo] >= scores[scorePosition])
                {
                    ranks[gameNo] = denseRank;
                    break;
                }

            }
            if (ranks[gameNo] == 0)
            {
                ranks[gameNo] = denseRank + 1;
                rankScoreMap.Add(denseRank + 1, alice[gameNo]);
            }
        }
    }
}
