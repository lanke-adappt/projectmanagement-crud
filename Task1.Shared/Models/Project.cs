using System.ComponentModel.DataAnnotations;

namespace Task1.Shared.Models
{
    public class Project
    {

        public int Id { get; set; }
        [Required]
        public string ProjectName { get; set; } = null!;
        [Required]

        public string Description { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public string ModifiedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Technologies { get; set; } = null!;



    }
}

//Project Name

//Description

//CreatedBy

//ModifiedBy

//CreatedDate

//ModifiedDate

//TechNologies - Enum (Angular, C#, Drupal, NodeJs,Blazor,Dotnet)