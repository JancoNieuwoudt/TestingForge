using System.Data.SqlClient;
using static System.Formats.Asn1.AsnWriter;

namespace DataForge
{
    public class Team
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public double[] Points { get; set; } = new double[3];
    }
}
