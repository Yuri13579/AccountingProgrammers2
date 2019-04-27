using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingProgrammers.Interfaces;
using AccountingProgrammers.Models;

namespace AccountingProgrammers.Repository
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly ProjectContext _context;

        public DeveloperRepository(ProjectContext context)
        {
            _context = context;
        }

        public Developer Add(Developer item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _context.Developers.Add(item);
            _context.SaveChangesAsync();

            return item;

        }

        public bool Delete(int? id)
        {
            Developer developer = _context.Developers.FirstOrDefault(x => x.DeveloperId == id);

            if (developer != null)
            {
                _context.Developers.Remove(developer);
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public Developer Get(int? id)
        {
            return _context.Developers.FirstOrDefault(x => x.DeveloperId == id);

        }


        public IEnumerable<Developer> GetAll()
        {
            return _context.Developers.ToList();

        }

        public bool Update(Developer item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }


            int index = _context.Developers.FirstOrDefault(x => x.DeveloperId == item.DeveloperId).DeveloperId;
            if (index == -1)
            {
                return false;
            }

            _context.Developers.Remove(_context.Developers.FirstOrDefault(x => x.DeveloperId == item.DeveloperId));
            _context.Developers.Add(item);
            _context.SaveChangesAsync();

            return true;
        }
    }
}
