using System.Collections.Generic;
using BusinessLayer.Model.Models;
using System.Threading.Tasks;

namespace BusinessLayer.Model.Interfaces
{
    public interface ICompanyService
    {
        IEnumerable<CompanyInfo> GetAllCompanies();
        CompanyInfo GetCompanyByCode(string companyCode);
        bool AddCompany(CompanyInfo company);
        bool UpdateCompany(string siteId, string companyCode, CompanyInfo company);
        Task<IEnumerable<CompanyInfo>> GetAllCompaniesAsync();
        Task<CompanyInfo> GetCompanyByCodeAsync(string companyCode);
        Task<bool> AddCompanyAsync(CompanyInfo companyInfo);
        Task<bool> UpdateCompanyAsync(CompanyInfo companyInfo);
        bool DeleteCompany(string siteId, string companyCode);
        Task<bool> DeleteCompanyAsync(string siteId, string companyCode);
    }
}
