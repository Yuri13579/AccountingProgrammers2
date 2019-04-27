using AccountingProgrammers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProgrammers.Interfaces
{
    public interface IDeveloperRepository
    {
        IEnumerable<Developer> GetAll();
        Developer Get(int? id);
        Developer Add(Developer item);
        bool Update(Developer item);
        bool Delete(int? id);
    }
}
