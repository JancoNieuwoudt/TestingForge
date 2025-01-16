using DataForge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicForge
{
    public class Display
    {
        Teams teams = new Teams();

        //public double GetTotalScore()
        //{
        //    return Points.Sum();
        //}

        public void DisplayLeaderboard()
        {
            Console.WriteLine("Final Scores:");
            Console.WriteLine("Team Name".PadRight(20) + "Total Score");
            Console.WriteLine("-".PadRight(35, '-'));

            foreach (Team team in teams.teams)
            {
                Console.WriteLine($"{team.Name.PadRight(20)}{team.GetTotalScore()}");
            }
        }
    }
}
