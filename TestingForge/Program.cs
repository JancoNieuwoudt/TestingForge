using System;
using System.Text.RegularExpressions;
using DataForge.Interfaces;
using DataForge.Models;
using LogicForge;
using Microsoft.Data.SqlClient;


namespace TestingForge
{
    public class TestForge
    {
        public static void Main(string[] args)
        {
            List<Team> teams = new();

            ConsoleUserInterface capture = new ConsoleUserInterface(teams);
            IDataOperations database = new SqlDataOperations();

            database.SqlInsertQueries(teams);

            Console.ReadKey();
        }
    }
}
