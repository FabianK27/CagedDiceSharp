using System;
using System.Collections.Generic;
using System.Text;

namespace CagedDice
{
    class Simulate
    {
        #region member variables
        private static Random m_rng = new Random();

        private int m_runs;
        private int m_totalWinnings;
        private int m_pick;
        private int[] m_rollResults;
        private int m_correctPicks;
        public int m_money { private set; get; }


        #endregion


        public Simulate(int n_runs)
        {
            m_pick = -1;
            m_runs = n_runs;
            m_totalWinnings = 0;
            m_correctPicks = -1;
            m_money = -1;
            m_rollResults = new int[Constants.numDices];
        }



        public double run()
        {
            m_totalWinnings = 0;
            for(int i = 0; i < m_runs; ++i)
            {
                // get a random pick and a random dice roll
                getRandomPick();
                getRandomRolls();
                // get the amount that was won this game
                checkResult();
                getPriceMoney();

                m_totalWinnings += m_money;

                //print every 100. result to check
                if(i % 100 == 0)
                {
                    Console.WriteLine($"Pick: {m_pick}, Rolls: {m_rollResults[0]}, {m_rollResults[1]}, {m_rollResults[2]}, Correct: {m_correctPicks}, Price Money: {m_money}");
                }
            }
            Console.WriteLine($"Total Runs: {m_runs}, total Winnings: {m_totalWinnings}");
            return (double)m_totalWinnings / m_runs;
        }

        public void getRandomPick()
        {
            m_pick = m_rng.Next(Constants.minNumOnDice, Constants.maxNumOnDice + 1);
            if (m_pick < 1 || m_pick > 6)
                throw new ArgumentOutOfRangeException("m_pick", $"Invalid value {m_pick}");
        }

        public void getRandomRolls()
        {
            for (int i = 0; i < m_rollResults.Length; i++)
            {
                m_rollResults[i] = m_rng.Next(Constants.minNumOnDice, Constants.maxNumOnDice + 1); //rng.Next(a, b) yields [a, b) !!
            }
        }

        public void getPriceMoney()
        {
            foreach (KeyValuePair<int, int> kvp in Constants.resultToWin)
            {
                if (kvp.Key == m_correctPicks)
                {
                    m_money = kvp.Value;
                    return;
                }
            }
            throw new Exception($"ERROR! m_correctPicks assumed bad value {m_correctPicks}\n");

        }

        public void checkResult()
        {
            m_correctPicks = 0;
            foreach (int result in m_rollResults)
            {
                if (result == m_pick)
                    m_correctPicks += 1;
            }
        }
    }
}
