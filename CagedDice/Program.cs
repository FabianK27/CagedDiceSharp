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
            while (true)
            {
                Game gGame = new Game();
                try
                {
                    gGame.run();
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
                if (repeat?.FirstOrDefault() == 'N' || repeat?.FirstOrDefault() == 'n')
                    continue;
            }
        }
    }
}
