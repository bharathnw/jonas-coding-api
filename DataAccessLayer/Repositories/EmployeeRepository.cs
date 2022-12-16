using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly IDbWrapper<Employee> _employeeDbWrapper;

        public EmployeeRepository(IDbWrapper<Employee> employeeDbWrapper)
        {
            _employeeDbWrapper = employeeDbWrapper;
        }

  
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employeeDbWrapper.FindAllAsync();
        }

     
        public async Task<Employee> GetByCodeAsync(string employeeCode)
        {
            var employees = await _employeeDbWrapper.FindAsync(t => t.EmployeeCode.Equals(employeeCode));
            return employees?.FirstOrDefault();
        }

       
        public async Task<bool> SaveEmployeeAsync(Employee employee)
        {
            var employees = await _employeeDbWrapper.FindAsync(t =>
                t.CompanyCode.Equals(employee.CompanyCode) && t.EmployeeCode.Equals(employee.EmployeeCode));
            var itemRepo = employees?.FirstOrDefault();
            if (itemRepo != null)
            {
                itemRepo.EmailAddress = employee.EmailAddress;
                itemRepo.EmployeeName    = employee.EmployeeName;
                itemRepo.EmployeeStatus = employee.EmployeeStatus;
                itemRepo.Phone = employee.Phone;
                itemRepo.Occupation = employee.Occupation;
                itemRepo.LastModified = employee.LastModified;
                return await _employeeDbWrapper.UpdateAsync(itemRepo);
            }
            return await _employeeDbWrapper.InsertAsync(employee);
        }

    
        public async Task<bool> DeleteEmployeeAsync(string employeeCode, string companyCode)
        {
            Expression<Func<Employee, bool>> expression = n => n.EmployeeCode == employeeCode && n.CompanyCode == companyCode;
            return await _employeeDbWrapper.DeleteAsync(expression);
        }
    }
}
