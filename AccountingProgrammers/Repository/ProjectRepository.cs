using AccountingProgrammers.Interfaces;
using AccountingProgrammers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProgrammers.Repository
{
    public class ProjectRepository : IProjectRepository
    {
      private readonly ProjectContext _context;
        
        public ProjectRepository(ProjectContext context)
        {
            _context = context;
        }

        public Project Add(Project item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _context.Projects.Add(item);
            _context.SaveChangesAsync();
       
            return item;

        }

        public bool Delete(int? id)
        {
            Project project = _context.Projects.FirstOrDefault(x => x.ProjectId == id);
                
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
               
                return true;
            }
            
            return false;
        }

        public Project Get(int? id)
        {
            return _context.Projects.FirstOrDefault(x => x.ProjectId == id);
           
        }


        public IEnumerable<Project> GetAll()
        {
            return _context.Projects.ToList();
            
        }

        public bool Update(Project item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }


            int index = _context.Projects.FirstOrDefault(x => x.ProjectId == item.ProjectId).ProjectId ;
            if (index == -1)
            {
                return false;
            }
            
            _context.Projects.Remove(_context.Projects.FirstOrDefault(x => x.ProjectId == item.ProjectId));
            _context.Projects.Add(item);
            _context.SaveChangesAsync();
           
            return true;
        }
    }
}
