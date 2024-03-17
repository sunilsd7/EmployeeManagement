using EmployeeManagement.Models;

namespace EmployeeManagement.ViewModel
{
    public class EmployeeListViewModel
    {
        public IEnumerable<Employee> Employees { get; }

        public EmployeeListViewModel(IEnumerable<Employee> employees)
        {

            Employees = employees;
        }
    }
}
