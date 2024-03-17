namespace EmployeeManagement.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> AllEmployee { get; }
        void AddEmployee(Employee employee);

        Employee? GetEmployeeById(int employeeId);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int employee);
    }
}