using AccountingProgrammers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProgrammers.Interfaces
{
   public interface IProjectDeveloperRepository
    {
        IEnumerable<ProjectDeveloper> GetAll();
        ProjectDeveloper Get(int? ProjectId, int? DeveloperId);
        ProjectDeveloper Add(ProjectDeveloper item);
        bool Update(ProjectDeveloper item);
        bool Delete(int? ProjectId, int? DeveloperId);
    }
}
