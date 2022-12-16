using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model.Models
{
    public class ErrorLogInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime LoggedDate { get; set; }
    }
}
