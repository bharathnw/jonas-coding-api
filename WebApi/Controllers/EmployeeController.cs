using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Custom_Handlers;
using WebApi.Models;

namespace WebApi.Controllers
{
    //Global Exception Handler
    [ExceptionHandler]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        // GET api/<controller>
        public async Task<IEnumerable<EmployeeDTO>> GetAll()
        {
            var items = await _employeeService.GetAllEmployeesAsync();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(items);
        }

        // GET api/<controller>/5
        public async Task<EmployeeDTO> Get(string employeeCode)
        {
            var item = await _employeeService.GetEmployeeByCodeAsync(employeeCode);
            return _mapper.Map<EmployeeDTO>(item);
        }

        // POST api/<controller>
        public async Task<bool> Post([FromBody]EmployeeDTO employee)
        {
            EmployeeInfo employeeInfo = _mapper.Map<EmployeeInfo>(employee);
            var response = await _employeeService.AddEmployeeAsync(employeeInfo);
            return response;
        }

        // PUT api/<controller>/5
        public async Task<bool> Put([FromBody]EmployeeDTO employee)
        {
            EmployeeInfo employeeInfo = _mapper.Map<EmployeeInfo>(employee);
            return await _employeeService.UpdateEmployeeAsync(employeeInfo);
        }

        // DELETE api/<controller>/5
        public async Task<bool> Delete(string employeeCode, string companyCode)
        {
            return await _employeeService.DeleteEmployeeAsync(employeeCode, companyCode);
        }
    }
}
