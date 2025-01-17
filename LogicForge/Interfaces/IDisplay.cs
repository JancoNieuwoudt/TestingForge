using DataForge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicForge.Interfaces
{
    public interface IDisplay
    {
        List<Team> DisplayLeaderboard(List<Team> teams);
    }
}
