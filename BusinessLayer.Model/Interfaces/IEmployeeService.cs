using BusinessLayer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeInfo>> GetAllEmployeesAsync();
        Task<EmployeeInfo> GetEmployeeByCodeAsync(string employeeCode);
        Task<bool> AddEmployeeAsync(EmployeeInfo employeeInfo);
        Task<bool> UpdateEmployeeAsync(EmployeeInfo employeeInfo);
        Task<bool> DeleteEmployeeAsync(string employeeCode, string companyCode);
    }
}
