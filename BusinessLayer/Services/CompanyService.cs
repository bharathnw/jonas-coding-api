using BusinessLayer.Model.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public IEnumerable<CompanyInfo> GetAllCompanies()
        {
            var res = _companyRepository.GetAll();
            return _mapper.Map<IEnumerable<CompanyInfo>>(res);
        }

        public async Task<IEnumerable<CompanyInfo>> GetAllCompaniesAsync()
        {
            var res = await _companyRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CompanyInfo>>(res);
        }

        public CompanyInfo GetCompanyByCode(string companyCode)
        {
            var result = _companyRepository.GetByCode(companyCode);
            return _mapper.Map<CompanyInfo>(result);
        }

        public async Task<CompanyInfo> GetCompanyByCodeAsync(string companyCode)
        {
            var result = await _companyRepository.GetByCodeAsync(companyCode);
            return _mapper.Map<CompanyInfo>(result);
        }

        public bool AddCompany(CompanyInfo companyInfo)
        {
            Company companyData = _mapper.Map<Company>(companyInfo);
            return _companyRepository.SaveCompany(companyData);
        }

        public async Task<bool> AddCompanyAsync(CompanyInfo companyInfo)
        {
            Company companyData = _mapper.Map<Company>(companyInfo);
            return await _companyRepository.SaveCompanyAsync(companyData);
        }

        public bool UpdateCompany(string siteId, string companyCode, CompanyInfo companyInfo)
        {
            companyInfo.SiteId = siteId;
            companyInfo.CompanyCode = companyCode;
            Company companyData = _mapper.Map<Company>(companyInfo);
            return _companyRepository.SaveCompany(companyData);
        }

        public async Task<bool> UpdateCompanyAsync(CompanyInfo companyInfo)
        {
            Company companyData = _mapper.Map<Company>(companyInfo);
            return await _companyRepository.SaveCompanyAsync(companyData);
        }

        public bool DeleteCompany(string siteId, string companyCode)
        {
            return _companyRepository.DeleteCompany(siteId, companyCode);
        }

        public async Task<bool> DeleteCompanyAsync(string siteId, string companyCode)
        {
            return await _companyRepository.DeleteCompanyAsync(siteId, companyCode);
        }
    }
}
