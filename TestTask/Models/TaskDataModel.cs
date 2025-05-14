using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Models
{
    public class TaskDataModel
    {
        public string TaskName { get; set; }
        public string ProjectName { get; set; }
        public string Status { get; set; }
        public string StartDate { get; set; }
        public string DueDate { get; set; }
    }
}