using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Shared.Models
{
    public class UserDetails
    {
        public int Id { get; set; } 
        public string Name { get; set; } = String.Empty;
        public string Designation { get; set; } = String.Empty;
        public DateTime DOB { get; set; }
        public string Gender { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }



    }
}
