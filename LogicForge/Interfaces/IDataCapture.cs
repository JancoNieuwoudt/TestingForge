using DataForge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicForge.Interfaces
{
    public interface IDataCapture
    {
        List<Team> GetTeams(List<Team> teams);
        List<Team> GetScores(List<Team> teams);
    }
}
