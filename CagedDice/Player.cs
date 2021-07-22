using System;
using System.Collections.Generic;
using System.Text;

namespace CagedDice
{
    class Player
    {
        #region member vars

        public int m_bankroll { private set; get; }    

        #endregion

        #region methods
        public Player(int startBankroll = Constants.startBankroll)
        {
            m_bankroll = startBankroll;
        }

        public bool changeBankroll(int x)
        {
            m_bankroll += x;
            if (m_bankroll <= 0)
            {
                m_bankroll = 0;
                return false;
            }
            return true;
        }

        #endregion
    }
}
