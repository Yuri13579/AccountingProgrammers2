using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingProgrammers.Models
{
    public class ProjectDeveloper
    {

        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }
    }
}
