using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);

        IEnumerable<Employee> GetAll();

        Employee Find(string searchString);

        Employee Remove(string ID);

        void Update(Employee employee);
    }
}
