using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProgrammers.Models
{
    public class Developer
    {
        [Key]
        public int DeveloperId { get; set; }
        public string DeveloperName { get; set; }
        public virtual ICollection<ProjectDeveloper> ProjectDevelopers { get; } = new List<ProjectDeveloper>();
    }
}
