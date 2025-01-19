using DataForge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataForge.Interfaces
{
    public interface IDataOperations
    {
        void SqlInsertQueries(List<Team> teams);           
    }
}
