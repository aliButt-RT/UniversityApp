namespace UniversityApp.ViewModels
{
    public class EmployeeViewModel
    {
        //not included the password/email/sal in response
        public string EID { get; set; }
        public string? EName { get; set; }
        public string? Designation { get; set; }
        public DateTime JoiningDate { get; set; }
        public int Age { get; set; }
    }
}
