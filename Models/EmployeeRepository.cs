using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeManagementSystemDbContext _employeelManagementSystemDbContext;

        public EmployeeRepository(EmployeeManagementSystemDbContext employeeManagementSystemDbContext)
        {

            _employeelManagementSystemDbContext = employeeManagementSystemDbContext;
        }
        public void AddEmployee(Employee employee)
        {
            Console.WriteLine("repository");
            _employeelManagementSystemDbContext.Employees.Add(employee);
            Console.WriteLine("repository next");

            _employeelManagementSystemDbContext.SaveChanges();
        }
        //retrieve ko lagi
        public IEnumerable<Employee> AllEmployee
        {
            get
            {
                return _employeelManagementSystemDbContext.Employees;
            }
        }
        //yeha samma

        //edit ko lagi
        public Employee? GetEmployeeById(int employeeId)
        {

            return _employeelManagementSystemDbContext.Employees.FirstOrDefault(p => p.EmployeeId == employeeId);
        }

        public void UpdateEmployee(Employee employee)
        {

            var employeePart = _employeelManagementSystemDbContext.Employees.FirstOrDefault(p => p.EmployeeId == employee.EmployeeId);
            if (employeePart == null)
            {
                throw new ArgumentException("employee not found");
            }


            employeePart.Name = employee.Name;
            employeePart.Email = employee.Email;
            employeePart.ImageUrl = employee.ImageUrl;
            employeePart.PhoneNumber = employee.PhoneNumber;
            employeePart.Address = employee.Address;

            _employeelManagementSystemDbContext.Entry(employeePart).State = EntityState.Modified;
            _employeelManagementSystemDbContext.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {

            var employee = _employeelManagementSystemDbContext.Employees.Find(id);

            if (employee == null)
            {
                throw new ArgumentException("Employee not found");
            }


            _employeelManagementSystemDbContext.Employees.Remove(employee);
            _employeelManagementSystemDbContext.SaveChanges();

        }
    }
}