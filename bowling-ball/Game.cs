using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class Game
    {
        private int rollCount = 0;
        private int[] rolls = new int[21];
    
        public static void Main(string[] args)
        {

        }
        
        public  void Add(int pins)
        {
            rolls[rollCount++] = pins;
         }

        public  int GetScore()
        {
           int score = 0;
           int rollIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
               if (Strike(rollIndex))
               {
                 score = score+ 10 + Bonus(rollIndex);
                 rollIndex = rollIndex+ 1;

                }
                else if (Spare(rollIndex))
                {
                    score = score + 10 + rolls[rollIndex + 2];
                  rollIndex = rollIndex+ 2;
                }
                else
                {
                    score = score + SumOfPins(rollIndex);
                    rollIndex = rollIndex + 2;
                 }
                }
               return score;
            }

           private bool Strike(int rollIndex)
           {
               return rolls[rollIndex] == 10;
           }

           private int SumOfPins(int rollIndex)
           {
               return rolls[rollIndex] + rolls[rollIndex + 1];
           }

           private int Bonus(int rollIndex)
           {
               return rolls[rollIndex + 1] + rolls[rollIndex + 2];
           }

           private bool Spare(int rollIndex)
           {
               return rolls[rollIndex] + rolls[rollIndex + 1] == 10;
           }
           
        }
    
}
