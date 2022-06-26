using EmployeeManager.Blazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Blazor.Repositories
{
  public interface IEmployeeRepository
  {
    List<Employee> SelectAll();
    Employee SelectByID(int id);
    void Insert(Employee emp);
    void Update(Employee emp);
    void Delete(int id);
    List<string> SelectCountries();
  }
}
