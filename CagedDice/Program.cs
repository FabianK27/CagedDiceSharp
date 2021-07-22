using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace CagedDice
{

    class Program
    {
        static void Main(string[] args)
        {
            /*
            Game gGame = new Game();
            Player player = new Player();
            while (true)
            {
                if(player.m_bankroll == 0)
                {
                    Console.WriteLine(Constants.gameOver);
                    break;
                }
                try
                {
                    Console.WriteLine($"Current bankroll: {player.m_bankroll}");
                    Console.WriteLine("The wager is 1 Euro");
                    player.changeBankroll(-1);
                    gGame.run();
                    player.changeBankroll(gGame.m_money);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }

                Console.Write("Again? [y or n]: ");
                string repeat = Console.ReadLine();

                if (repeat?.FirstOrDefault() == 'N' || repeat?.FirstOrDefault() == 'n')
                    break;
                if (repeat?.FirstOrDefault() == 'Y' || repeat?.FirstOrDefault() == 'y')
                    continue;
            }
            */


            //simulate
            int runs = 100000;
            Simulate sim = new Simulate(runs);
            double avgWin = sim.run();
            Console.WriteLine($"Average win after simulating {runs} games: {avgWin}");
        }
    }
}
