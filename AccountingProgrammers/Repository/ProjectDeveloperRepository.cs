using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingProgrammers.Interfaces;
using AccountingProgrammers.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountingProgrammers.Repository
{
    public class ProjectDeveloperRepository: IProjectDeveloperRepository
    {
        private readonly ProjectContext _context;

        public ProjectDeveloperRepository(ProjectContext context)
        {
            _context = context;
        }

        public ProjectDeveloper Add(ProjectDeveloper item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _context.ProjectDevelopers.Add(item);
            _context.SaveChangesAsync();
            return item;
          }

        public bool Delete(int? ProjectId, int? DeveloperId)
        {
            ProjectDeveloper projectDeveloper = _context.ProjectDevelopers.FirstOrDefault((p => (p.ProjectId == ProjectId) && (p.DeveloperId == DeveloperId)));
                
            //        projectDeveloper.Project = await db.Projects.FirstOrDefaultAsync(p => p.ProjectId == ProjectId);
            //        projectDeveloper.Developer = await db.Developers.FirstOrDefaultAsync(p => p.DeveloperId == DeveloperId);

            if (projectDeveloper != null)
            {
                _context.ProjectDevelopers.Remove(projectDeveloper);
                _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public ProjectDeveloper Get(int? ProjectId, int? DeveloperId)
        {
            return _context.ProjectDevelopers.FirstOrDefault((p => (p.ProjectId == ProjectId) && (p.DeveloperId == DeveloperId)));

        }


        public IEnumerable<ProjectDeveloper> GetAll()
        {
            return _context.ProjectDevelopers.ToList();

        }

        public bool Update(ProjectDeveloper item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }


            int index = _context.ProjectDevelopers.FirstOrDefault(x => x.ProjectId == item.ProjectId).ProjectId;
            if (index == -1)
            {
                return false;
            }

            _context.Projects.Remove(_context.Projects.FirstOrDefault(x => x.ProjectId == item.ProjectId));
           // _context.Projects.Add();
            _context.SaveChangesAsync();

            return true;
        }
    }
}
