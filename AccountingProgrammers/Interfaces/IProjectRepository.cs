using AccountingProgrammers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProgrammers.Interfaces
{
   public interface IProjectRepository
    {
        IEnumerable<Project> GetAll();
        Project Get(int? id);
        Project Add(Project item);
        bool Update(Project item);
        bool Delete(int? id);

    }
}
