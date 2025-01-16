using DataForge;
using Microsoft.Identity.Client;

namespace LogicForge
{
    public class DataCapture
    {
        Team teamClass = new Team();
        Teams teamsClass = new Teams();


        int noOfTeams = 4;
        int noOfMatches = 3;


        public void GetTeamNames()
        { 
            Console.WriteLine("Enter team names:");
            for (int i = 0; i < noOfTeams; i++)
            {
                Console.Write($"Team {i + 1}: ");
                string teamName = Console.ReadLine();
                teamsClass.teams.Add(new Team(teamName));
            }
        }

        public void GetScores()
        {
            
            Console.WriteLine("Enter the scores for the matches: ");
            for (int i = 0; i < noOfMatches; i++)
            {
                Console.WriteLine($"Match {i + 1}");
                foreach (Team team in teamsClass.teams)
                {
                    Console.WriteLine($"Score for Team {team.Name}: ");
                    Console.Write("Points: ");
                    double points = Convert.ToDouble(Console.ReadLine());
                    team.Points[i] = points;
                }
            }
        }
    }
}
