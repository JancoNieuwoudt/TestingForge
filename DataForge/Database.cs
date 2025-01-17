using DataForge;
using DataForge.Interfaces;
using Microsoft.Data.SqlClient;

namespace TestingForge
{
    public class Database : IPopulateDatabase
    {

        public void Populate(List<Team> teams)
        {
            PopulateDatabase(teams);
        }

        private SqlConnection SetupConnection()
        {
            string connectionString = "Server=HP_PROBOOK\\SQLEXPRESS; Initial Catalog=Forge; Integrated Security=SSPI; TrustServerCertificate=True";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                Console.WriteLine("Connection successful!");
                return sqlConnection;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw new Exception("Error: " + ex.Message);
            }
        }

        private void PopulateDatabase(List<Team> teams)
        {
            using (SqlConnection sqlConnection = SetupConnection())
            {
                foreach (Team team in teams)
                {
                    string query = @"INSERT INTO dbo.Teams (TeamName, CategoryID)
                                     VALUE (@teamName, 1)";

                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    cmd.Parameters.AddWithValue("@teamName", team.Name);
                    cmd.ExecuteNonQuery();

                    query = @"SELECT TeamID FROM dbo.Teams
                            WHERE TeamName == @teamName";
                    SqlCommand cmd2 = new SqlCommand(query, sqlConnection);
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

                    for (int i = 0; i <= team.Points.Count(); i++)
                    {
                        query = @"INSERT INTO dbo.Scores (GameID, TeamID, Points) 
                                     VALUES (@gameId, @teamId, @Points)";
                        SqlCommand cmd3 = new SqlCommand(query, sqlConnection);
                        cmd3.Parameters.AddWithValue("@gameId", i + 1);
                        cmd3.Parameters.AddWithValue("@teamId", teamId);
                        cmd3.Parameters.AddWithValue("@Points", team.Points[i]);
                        cmd3.ExecuteNonQuery();
                    }

                }
                sqlConnection.Close();
            }
        }

    }
}
