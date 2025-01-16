using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataForge;
using Microsoft.Data.SqlClient;

namespace TestingForge
{
    public class Database
    {
        Teams teams = new Teams();

        public void PopulateDatabase()
        {
            string connectionString = "Server=HP_PROBOOK\\SQLEXPRESS; Initial Catalog=Forge; Integrated Security=SSPI; TrustServerCertificate=True";

            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();
                Console.WriteLine("Connection successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }


            foreach (Team team in teams)
            {
                string query = @"INSERT INTO dbo.Teams (TeamName, CategoryID)
                                 VALUE (@teamName, 1)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@teamName", team.Name);
                cmd.ExecuteNonQuery();

                query = @"SELECT TeamID FROM dbo.Teams
                        WHERE TeamName == @teamName";
                SqlCommand cmd2 = new SqlCommand(query, con);
                cmd2.Parameters.AddWithValue("@teamName", team.Name);

                SqlDataReader reader = cmd2.ExecuteReader();
                int teamId = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        teamId = reader.GetInt32(0);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                reader.Close();

                for (int i = 0; i < 3; i++)
                {
                    query = @"INSERT INTO dbo.Scores (GameID, TeamID, Points) 
                                 VALUES (@gameId, @teamId, @Points)";
                    SqlCommand cmd3 = new SqlCommand(query, con);
                    cmd3.Parameters.AddWithValue("@gameId", i + 1);
                    cmd3.Parameters.AddWithValue("@teamId", teamId);
                    cmd3.Parameters.AddWithValue("@Points", Points[i]);
                    cmd3.ExecuteNonQuery();
                }
            }
            con.Close();
        }
        
    }
}
