using System;
using System.Collections.Generic;
using System.Text;

namespace CagedDice
{
    class Game
    {
        #region member variables
        private static Random m_rng = new Random();

        private int m_playerPick;
        private int[] m_rollResults;
        private int m_correctPicks;
        public int m_money { private set; get; }


        #endregion

        #region const/destrc
        public Game()
        {
            initVariables();
            displayWelcomeText();
        }
        #endregion

        #region methods
        void displayWelcomeText()
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Casino!\nYou are playing the Caged Dice Game!\nTo start playing press 1, to see the rules press 2!");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("Let's go!");
                    break;
                }
                else if (choice == "2")
                {
                    Console.WriteLine(Constants.rules);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                    continue;
                }
            }
        }

        public void run()
        {
            getPlayerPick();
            getRandomRolls();
            checkResult();
            getPriceMoney();
        }


        public void getPlayerPick()
        {
            while(true)
            {
                Console.Write($"Please pick a dice number to bet on [{Constants.minNumOnDice}-{Constants.maxNumOnDice}]: ");
                string inp = Console.ReadLine();
                if ((int.TryParse(inp, out m_playerPick)) && m_playerPick >= Constants.minNumOnDice && m_playerPick <= Constants.maxNumOnDice)
                {
                    Console.WriteLine($"You are betting on the number {m_playerPick}");
                    break;
                }
                else
                    continue;
            }
        }

        public void getRandomRolls()
        {
            for(int i = 0; i < m_rollResults.Length; i++)
            {
                m_rollResults[i] = m_rng.Next(Constants.minNumOnDice, Constants.maxNumOnDice + 1); //rng.Next(a, b) yields [a, b) !!
            }
            
            printDiceRolls();
        }

        public void getPriceMoney()
        {
            foreach(KeyValuePair<int, int> kvp in Constants.resultToWin)
            {
                if(kvp.Key == m_correctPicks)
                {
                    m_money = kvp.Value;
                    Console.WriteLine($"You won {m_money} Euros.");
                    return;
                }
            }
            throw new Exception($"ERROR! m_correctPicks assumed bad value {m_correctPicks}\n");

        }

        public void checkResult()
        {
            m_correctPicks = 0;
            foreach(int result in m_rollResults)
            {
                if (result == m_playerPick)
                    m_correctPicks += 1;
            }
            Console.WriteLine($"You achieved {m_correctPicks} matches!");
        }

        private void initVariables()
        {
            m_playerPick = -1;
            m_correctPicks = -1;
            m_money = -1;
            m_rollResults = new int[Constants.numDices];
        }

        #endregion

        #region utility
        private void printDiceRolls()
        {
            Console.Write("The dice are rolling...\n..And the outcome is: ");
            for (int i = 0; i < m_rollResults.Length - 1; ++i)
                Console.Write(m_rollResults[i] + ", ");
            Console.WriteLine(m_rollResults[m_rollResults.Length - 1]);
        }
        #endregion
    }
}
