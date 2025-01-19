using DataForge.Interfaces;
using DataForge.Models;
using Microsoft.Data.SqlClient;

namespace TestingForge
{
    public class SqlDataOperations : IDataOperations
    {

        public void SqlInsertQueries(List<Team> teams)
        {
            try
            {
                foreach (Team team in teams)
                {
                    InsertIntoTeamTable(team);
                    int teamId = GetTeamId(team);
                    InsertIntoScoresTable(team, teamId);
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        #region Private Methods
        /// <summary>
        /// Sets up connection, inserts teams and their scores into the database
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

        private void InsertIntoTeamTable(Team team)
        {
            using (SqlConnection sqlConnection = SetupConnection())
            {
                string query = @"INSERT INTO dbo.Teams (TeamName, CategoryID)
                                     VALUES (@teamName, 1)";

                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("@teamName", team.Name);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Team insert Successfull");
            }
        }

        private int GetTeamId(Team team)
        {
            using (SqlConnection sqlConnection = SetupConnection())
            {
                string query = @"SELECT TeamID FROM dbo.Teams
                            WHERE TeamName = @teamName";
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

                sqlConnection.Close();
                Console.WriteLine("TeamId insert Successfull");
                return teamId;
            }
        }

        private void InsertIntoScoresTable(Team team, int teamId)
        {
            using (SqlConnection sqlConnection = SetupConnection())
            {
                    for (int i = 0; i <= team.Points.Count() - 1; i++)
                    {
                        string query = @"INSERT INTO dbo.Scores (GameID, TeamID, Points) 
                                     VALUES (@gameId, @teamId, @Points)";
                        SqlCommand cmd3 = new SqlCommand(query, sqlConnection);
                        cmd3.Parameters.AddWithValue("@gameId", i + 1);
                        cmd3.Parameters.AddWithValue("@teamId", teamId);
                        cmd3.Parameters.AddWithValue("@Points", team.Points[i]);
                        cmd3.ExecuteNonQuery();
                    }
                sqlConnection.Close();
                Console.WriteLine("Score insert Successfull");
            }         
        }
        #endregion
    }
}
