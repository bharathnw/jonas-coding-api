using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using WebApi.Models;
using BusinessLayer.Model.Models;
using System.Threading.Tasks;
using WebApi.Custom_Handlers;

namespace WebApi.Controllers
{
    [ExceptionHandler]
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        // GET api/<controller>
        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            var items = await _companyService.GetAllCompaniesAsync();
            return _mapper.Map<IEnumerable<CompanyDto>>(items);
        }

        // GET api/<controller>/5
        public async Task<CompanyDto> Get(string companyCode)
        {
            var item = await _companyService.GetCompanyByCodeAsync(companyCode);
            return _mapper.Map<CompanyDto>(item);
        }

        // POST api/<controller>
        public async Task<bool> Post([FromBody]CompanyDto companyData)
        {
            CompanyInfo compInfo = _mapper.Map<CompanyInfo>(companyData);
            var response = await _companyService.AddCompanyAsync(compInfo);
            return response;
        }

        // PUT api/<controller>/5
        public async Task<bool> Put([FromBody]CompanyDto companyData)
        {
            CompanyInfo compInfo = _mapper.Map<CompanyInfo>(companyData);
            return await _companyService.UpdateCompanyAsync(compInfo);
        }

        // DELETE api/<controller>/5
        public async Task<bool> Delete(string siteId, string companyCode)
        {
            return await _companyService.DeleteCompanyAsync(siteId, companyCode);
        }
    }
}