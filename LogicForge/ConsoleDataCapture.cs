using DataForge;
using LogicForge.Interfaces;
using Microsoft.Identity.Client;

namespace LogicForge
{
    public class ConsoleDataCapture : IDataCapture
    {
        int noOfTeams = 4;
        int noOfMatches = 3;

        public List<Team> GetTeams(List<Team> teams) 
        {
            GetTeamNames(teams);
            return teams;
        }

        public List<Team> GetScores(List<Team> teams)
        {
            GetTeamScores(teams);
            return teams;
        }

        #region
        /// <summary>
        /// Gets the Team names and their scores
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
        #endregion
    }
}
