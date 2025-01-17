using System.Data.SqlClient;
using static System.Formats.Asn1.AsnWriter;

namespace DataForge
{
    public class Team
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public double[] Points { get; set; } = new double[3];

        //public Team()
        //{
        //}

        //public Team(string name)
        //{
        //    Name = name;
        //    CategoryId = 1;
        //    Points = new double[3];
        //}
    }
}
