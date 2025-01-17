using System;
using System.Text.RegularExpressions;
using DataForge;
using LogicForge;
using LogicForge.Interfaces;
using Microsoft.Data.SqlClient;
using TestingForge.Interfaces;


namespace TestingForge
{
    public class TestForge
    {
        public static void Main(string[] args)
        {
            IDataCapture capture = new DataCapture();
            IDisplay display = new Display();
            IPopulateDatabase database = new Database();

            List<Team> teams = new();
            capture.GetTeams(teams);
            capture.GetScores(teams);
            display.DisplayLeaderboard(teams);
            database.Populate(teams);

            Console.ReadLine();
        }
    }
}
