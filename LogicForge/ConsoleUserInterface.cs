using DataForge.Models;
using Microsoft.Identity.Client;

namespace LogicForge
{
    public class ConsoleUserInterface
    {
        int noOfTeams = 4;
        int noOfMatches = 3;

        public ConsoleUserInterface(List<Team> teams)
        {
            GetTeamNames(teams);
            GetTeamScores(teams);
            DisplayLeaderboard(teams);
        }

        #region
        /// <summary>
        /// Gets the Team names and their scores and display leaderboard
        /// </summary>
        /// <param name="teams"></param>
        /// <returns></returns>

        private List<Team> GetTeamNames(List<Team> teams)
        { 
            Console.WriteLine("Enter team names:");
            for (int i = 0; i < noOfTeams; i++)
            {
                Console.Write($"Team {i + 1}: ");
                string teamName = Console.ReadLine();
                teams.Add(new Team { Name = teamName});
            }
            return teams;
        }

        private void GetTeamScores(List<Team> teams)
        {
            
            Console.WriteLine("Enter the scores for the matches: ");
            for (int i = 0; i < noOfMatches; i++)
            {
                Console.WriteLine($"Match {i + 1}");
                foreach (Team team in teams)
                {
                    Console.WriteLine($"Score for Team {team.Name}: ");
                    Console.Write("Points: ");
                    double points = Convert.ToDouble(Console.ReadLine());
                    team.Points[i] = points;
                }
            }
        }
        private void DisplayLeaderboard(List<Team> teams)
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
