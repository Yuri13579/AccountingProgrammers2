using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountingProgrammers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using AccountingProgrammers.Repository;
using AccountingProgrammers.Interfaces;

namespace AccountingProgrammers.Controllers
{
    public class HomeController : Controller
    {
    //    private ProjectContext db;
        readonly IProjectRepository projectRepository;
        readonly IDeveloperRepository developerRepository;
        readonly IProjectDeveloperRepository projectDeveloperRepository;

        public HomeController(IProjectRepository repositoryProject, IDeveloperRepository repositoryDeveloper, IProjectDeveloperRepository repositoryProjectDeveloper)
        {
            this.projectRepository = repositoryProject;
            this.developerRepository = repositoryDeveloper;
            this.projectDeveloperRepository = repositoryProjectDeveloper;
            //   db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View( projectRepository.GetAll());
          }

        public async Task<IActionResult> About()
        {
            return View();
        }

        public async Task<IActionResult> Contact()
        {
            return View();
        }

        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(Project project)
        {
            projectRepository.Add(project);
           return RedirectToAction("ProjectList");
        }

        public IActionResult CreateDeveloper()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDeveloper(Developer developer)
        {
            developerRepository.Add(developer);
          return RedirectToAction("DeveloperList");
        }
        public IActionResult CreateProjectDeveloper()
        {
            var developers = developerRepository.GetAll();  
            ViewBag.Developers = new SelectList(developers, "DeveloperId", "DeveloperName");
            var projects = projectRepository.GetAll();
            ViewBag.Projects = new SelectList(projects, "ProjectId", "ProjectName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProjectDeveloper(ProjectDeveloper projectDeveloper)
        {
            projectDeveloperRepository.Add(projectDeveloper);
            return RedirectToAction("ProjectDeveloperList");
        }


        public async Task<IActionResult> DetailsProject(int? id)
        {
            if (id != null)
            {
                Project project = projectRepository.Get(id);
               // Project project = await db.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
                if (project != null)
                    return View(project);
            }
            return NotFound();
        }

        public async Task<IActionResult> DetailsDeveloper(int? id)
        {
            if (id != null)
            {
                Developer developer = developerRepository.Get(id);
                if (developer != null)
                    return View(developer);
            }
            return NotFound();
        }
        public async Task<IActionResult> DetailsProjectDeveloper(int? ProjectId, int? DeveloperId)
        {
            if ((ProjectId != null) && (DeveloperId != null))
            {
                ProjectDeveloper projectDeveloper = projectDeveloperRepository.Get(ProjectId, DeveloperId);
                projectDeveloper.Project = projectRepository.Get(ProjectId);
                projectDeveloper.Developer = developerRepository.Get(DeveloperId);

                if (projectDeveloper != null)
                    return View(projectDeveloper);
            }
            return NotFound();
        }

        public async Task<IActionResult> ProjectList()
        {
            return View( projectRepository.GetAll());
           
        }

        public async Task<IActionResult> ProjectSearch()
        {
            return PartialView(projectRepository.GetAll());
        }

        [HttpPost]
        public ActionResult ProjectDelete(int id)
        {
          projectRepository.Delete(id);
           return PartialView("_ProjectList", projectRepository.GetAll());
        }


        [HttpPost]
        public ActionResult DeveloperDelete(int id)
        {
            developerRepository.Delete(id);
            return PartialView("_DeveloperList", developerRepository.GetAll());
        }

        public ActionResult Partial()
        {
            ViewBag.Message = "Это частичное представление.";
            return PartialView();
        }




        public async Task<IActionResult> DeveloperList()
        {
            return View(developerRepository.GetAll());
        }
        public async Task<IActionResult> ProjectDeveloperList()
        {
            var developers = developerRepository.GetAll();
            ViewBag.Developers = new SelectList(developers, "DeveloperId", "DeveloperName");
            var projects = projectRepository.GetAll();
            ViewBag.Projects = new SelectList(projects, "ProjectId", "ProjectName");
            return View( projectDeveloperRepository.GetAll() );
        }

        public async Task<IActionResult> EditProject(int? id)
        {
            if (id != null)
            {
                Project project = projectRepository.Get(id);
                //Project project = await db.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);

                if (project != null)
                    return View(project);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditProject(Project project)
        {
            projectRepository.Update(project);
          return RedirectToAction("ProjectList");
        }

        public async Task<IActionResult> EditDeveloper(int? id)
        {
            if (id != null)
            {
                Developer developer = developerRepository.Get(id);
                if (developer != null)
                    return View(developer);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditDeveloper(Developer developer)
        {
            developerRepository.Update(developer);
            return RedirectToAction("DeveloperList");
        }
        ///// <summary>
        ///// //////////////////////////////////////////////////////////////////////////////////////////!!!!

        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public async Task<IActionResult> EditProjectDeveloper(int? ProjectId, int? DeveloperId)///////////////////////
        //{
        //    if ( (ProjectId != null) && (DeveloperId != null))
        //    {
        //       ProjectDeveloper projectDeveloper = await db.ProjectDevelopers.FirstOrDefaultAsync(p => (p.ProjectId == ProjectId) && (p.DeveloperId == DeveloperId));
        //      // projectDeveloper.Project = db.Projects.ToList();

        //        projectDeveloper.Project = await db.Projects.FirstOrDefaultAsync(p => p.ProjectId == ProjectId);
        //       projectDeveloper.Developer = await db.Developers.FirstOrDefaultAsync(p => p.DeveloperId == DeveloperId);

        //        //var developers = db.Developers.ToList();
        //        //ViewBag.Developers =  new SelectList(developers, "DeveloperId", "DeveloperName");
        //        //var projects = db.Projects.ToList();
        //        //ViewBag.Projects = new SelectList(projects, "ProjectId", "ProjectName");
        //        //ViewBag.projectDeveloper= await db.ProjectDevelopers.FirstOrDefaultAsync(p => (p.ProjectId == ProjectId) && (p.DeveloperId == DeveloperId));

        //        if (projectDeveloper != null)
        //            return View(projectDeveloper);
        //    }
        //    return NotFound();
        //}
        //[HttpPost]
        //public async Task<IActionResult> EditProjectDeveloper(ProjectDeveloper projectDeveloper)
        //{
        //    db.ProjectDevelopers.Update(projectDeveloper);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("ProjectDeveloperList");
        //}
        ////delete


        [HttpGet]
        [ActionName("DeleteProject")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
              Project project = projectRepository.Get(id);
                if (project != null)
                    return View(project);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProject(int? id)
        {
            if (id != null)
            {
               Project project = projectRepository.Get(id);
                if (project != null)
                {
                    projectRepository.Delete(id);
                return RedirectToAction("ProjectList");
                }
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("DeleteDeveloper")]
        public async Task<IActionResult> ConfirmDeleteDeveloper(int? id)
        {
            if (id != null)
            {
                Developer developer = developerRepository.Get(id);
                if (developer != null)
                    return View(developer);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDeveloper(int? id)
        {
            if (id != null)
            {
                Developer developer = developerRepository.Get(id);
                if (developer != null)
                {
                    developerRepository.Delete(id);
                    return RedirectToAction("DeveloperList");
                }
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("DeleteProjectDeveloper")]
        public async Task<IActionResult> ConfirmDeleteProjectDeveloper(int? ProjectId, int? DeveloperId)
        {
            if ((ProjectId != null) && (DeveloperId != null))
            {
                ProjectDeveloper projectDeveloper = projectDeveloperRepository.Get(ProjectId, DeveloperId);
                if (projectDeveloper != null)
                    return View(projectDeveloper);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProjectDeveloper(int? ProjectId, int? DeveloperId)
        {
            if ((ProjectId != null) && (DeveloperId != null))
            {
                projectDeveloperRepository.Delete(ProjectId, DeveloperId);
                 return RedirectToAction("ProjectDeveloperList");
                
            }
            return NotFound();
        }






    }
}
