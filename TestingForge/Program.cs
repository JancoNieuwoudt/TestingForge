using System;
using System.Text.RegularExpressions;
using DataForge;
using LogicForge;
using Microsoft.Data.SqlClient;


namespace TestingForge
{
    public class TestForge
    {
        public static void Main(string[] args)
        {
            string connectionString = "Server=HP_PROBOOK\\SQLEXPRESS; Initial Catalog=Forge; Integrated Security=SSPI; TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connection successful!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            Teams teams = new Teams();
            DataCapture capture = new DataCapture();
            Display display = new Display();
            Database database = new Database();

            capture.GetTeamNames();
            capture.GetScores();
            display.DisplayLeaderboard();

            //database.PopulateDatabase();
            Console.ReadLine();
        }
    }
}
