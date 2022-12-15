using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Models
{
    public class Department
    {
        [Key]
        public int DId { get; set; }

        [Required]
        public string? DName { get; set; }

        public string? VcName { get; set; }
    }
}
