using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Shared.Models
{
    public class ProjectMapping
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }
        public string Note { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
