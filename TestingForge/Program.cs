using System;
using System.Text.RegularExpressions;
using DataForge;
using DataForge.Interfaces;
using LogicForge;
using LogicForge.Interfaces;
using Microsoft.Data.SqlClient;


namespace TestingForge
{
    public class TestForge
    {
        public static void Main(string[] args)
        {
            IDataCapture capture = new ConsoleDataCapture();
            IDisplay display = new Display();
            IDataOperations database = new SqlDataOperations();

            List<Team> teams = new();
            capture.GetTeams(teams);
            capture.GetScores(teams);
            display.DisplayLeaderboard(teams);
            database.Populate(teams);

            Console.ReadLine();
        }
    }
}
