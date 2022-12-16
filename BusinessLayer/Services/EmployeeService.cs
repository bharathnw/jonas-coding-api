﻿using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
      
        public async Task<IEnumerable<EmployeeInfo>> GetAllEmployeesAsync()
        {
            var res = await _employeeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeInfo>>(res);
        }

        public async Task<EmployeeInfo> GetEmployeeByCodeAsync(string employeeCode)
        {
            var result = await _employeeRepository.GetByCodeAsync(employeeCode);
            return _mapper.Map<EmployeeInfo>(result);
        }
     
        public async Task<bool> AddEmployeeAsync(EmployeeInfo employeeInfo)
        {
            Employee employeeData = _mapper.Map<Employee>(employeeInfo);
            return await _employeeRepository.SaveEmployeeAsync(employeeData);
        }

        public async Task<bool> UpdateEmployeeAsync(EmployeeInfo employeeInfo)
        {
            Employee employeeData = _mapper.Map<Employee>(employeeInfo);
            return await _employeeRepository.SaveEmployeeAsync(employeeData);
        }
      
        public async Task<bool> DeleteEmployeeAsync(string employeeCode, string companyCode)
        {
            return await _employeeRepository.DeleteEmployeeAsync(employeeCode, companyCode);
        }
    }
}
