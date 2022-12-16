using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityApp.Models
{
    public class Employee
    {
        [Key]
        public string EID { get; set; }
        public string? EName { get; set; }
        public int Sal { get; set; }
        public string? Designation { get; set; }
        public DateTime JoiningDate { get; set; }
        public int Age { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
       
    }
}
