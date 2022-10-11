namespace Core_Dapper.Models
{
    public abstract class EntityBase { }

    public class Department:EntityBase
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }

    public class Employee : EntityBase
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public int Salary { get; set; }
        public int DeptNo { get; set; }
    }
}
