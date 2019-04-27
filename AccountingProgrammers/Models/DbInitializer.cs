using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountingProgrammers.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Project = AccountingProgrammers.Models.Project;

namespace AccountingProgrammers.Controllers
{
    public static class DbInitializer 
    {
        public static void Initialize(ProjectContext context)
        {
            
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Projects.Any())
            {
                return;   // DB has been seeded
            }


            Project p1 = new Project {ProjectName = "HTML-1"};
            Project p2 = new Project{ProjectName = "HTML-2"};
            Project p3 = new Project{ProjectName = "CSS-1"};
            Project p4 = new Project{ProjectName = "CSS-3"};

            context.Projects.Add(p1);
            context.Projects.Add(p2);
            context.Projects.Add(p3);
            context.Projects.Add(p4);
            
            Developer d1 = new Developer {DeveloperName = "Ivan"};
            Developer d2 = new Developer { DeveloperName = "Petro" };
            Developer d3 = new Developer { DeveloperName = "Vasyl" };

            //context.Developers.Add(d1);
            //context.Developers.Add(d2);
            //context.Developers.Add(d3);

            //ProjectDeveloper pd1 = new ProjectDeveloper( p1, d1);
            //ProjectDeveloper pd2 = new ProjectDeveloper(p2, d2);
            //ProjectDeveloper pd3 = new ProjectDeveloper(p2, d3);

            
            context.SaveChanges();
            


        }
    }
}
