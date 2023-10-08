namespace CRUD_Application.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StudentId { get; set; }
        public int Age { get; set; }
        public string Number { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
