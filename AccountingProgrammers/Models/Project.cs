using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProgrammers.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public virtual ICollection<ProjectDeveloper> ProjectDevelopers { get;  } = new List<ProjectDeveloper>();
        
    }
}
