using System;
using System.Collections.Generic;

namespace CagedDice
{
    class Constants
    {
        public const int numDices = 3;
        public const int minNumOnDice = 1;
        public const int maxNumOnDice = 6;

        public static IDictionary<int, int> resultToWin = new Dictionary<int, int>()
        {
            {0, 0},
            {1, 2},
            {2, 3},
            {3, 4}
        };

        public const string rules = "";


        public const int startBankroll = 10;

        public const string gameOver = "";
        
        
    }
}