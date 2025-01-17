using DataForge;
using LogicForge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicForge
{
    public class Display : IDisplay
    {
        public List<Team> DisplayLeaderboard(List<Team> teams) 
        { 
            Leaderboard(teams);
            return teams;
        }

        #region Private Methods
        /// <summary>
        /// DIsplay the teams with their totals
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>

        private void Leaderboard(List<Team> teams)
        {
            Console.WriteLine("Final Scores:");
            Console.WriteLine("Team Name".PadRight(20) + "Total Score");
            Console.WriteLine("-".PadRight(35, '-'));

            foreach (Team team in teams)
            {
                Console.WriteLine($"{team.Name.PadRight(20)}{GetTotalScore(team.Points)}");
            }
        }

        private double GetTotalScore(double[] points)
        {
            return points.Sum();
        }        
        #endregion
    }
}
