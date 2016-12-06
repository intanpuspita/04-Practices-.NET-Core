using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace WebAPI.Models
{
    // Without connected into database
    public class EmployeeRepository : IEmployeeRepository
    {
        private static ConcurrentDictionary<string, Employee> _employee = new ConcurrentDictionary<string, Employee>();

        public EmployeeRepository()
        {
            Add(new Employee { FullName = "Intan", Address = "Cimahi" });
        }

        public void Add(Employee employee)
        {
            employee.ID = Guid.NewGuid().ToString();
            _employee[employee.ID] = employee;
        }

        public Employee Find(string searchString)
        {
            Employee employee;
            _employee.TryGetValue(searchString, out employee);

            return employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employee.Values;
        }

        public Employee Remove(string ID)
        {
            Employee employee;
            _employee.TryRemove(ID, out employee);

            return employee;
        }

        public void Update(Employee employee)
        {
            _employee[employee.ID] = employee;
        }
    }
}
