using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDbWrapper<Company> _companyDbWrapper;

        public CompanyRepository(IDbWrapper<Company> companyDbWrapper)
        {
            _companyDbWrapper = companyDbWrapper;
        }

        public IEnumerable<Company> GetAll()
        {
            return _companyDbWrapper.FindAll();
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _companyDbWrapper.FindAllAsync();
        }

        public Company GetByCode(string companyCode)
        {
            return _companyDbWrapper.Find(t => t.CompanyCode.Equals(companyCode))?.FirstOrDefault();
        }

        public async Task<Company> GetByCodeAsync(string companyCode)
        {
            var companies = await _companyDbWrapper.FindAsync(t => t.CompanyCode.Equals(companyCode));
            return companies.FirstOrDefault();
        }

        public bool SaveCompany(Company company)
        {
            var itemRepo = _companyDbWrapper.Find(t =>
                t.SiteId.Equals(company.SiteId) && t.CompanyCode.Equals(company.CompanyCode))?.FirstOrDefault();
            if (itemRepo != null)
            {
                itemRepo.CompanyName = company.CompanyName;
                itemRepo.AddressLine1 = company.AddressLine1;
                itemRepo.AddressLine2 = company.AddressLine2;
                itemRepo.AddressLine3 = company.AddressLine3;
                itemRepo.Country = company.Country;
                itemRepo.EquipmentCompanyCode = company.EquipmentCompanyCode;
                itemRepo.FaxNumber = company.FaxNumber;
                itemRepo.PhoneNumber = company.PhoneNumber;
                itemRepo.PostalZipCode = company.PostalZipCode;
                itemRepo.LastModified = company.LastModified;
                return _companyDbWrapper.Update(itemRepo);
            }
            return _companyDbWrapper.Insert(company);
        }

        public async Task<bool> SaveCompanyAsync(Company company)
        {
            var companies = await _companyDbWrapper.FindAsync(t =>
                t.SiteId.Equals(company.SiteId) && t.CompanyCode.Equals(company.CompanyCode));
            var itemRepo = companies?.FirstOrDefault();
            if (itemRepo != null)
            {
                itemRepo.CompanyName = company.CompanyName;
                itemRepo.AddressLine1 = company.AddressLine1;
                itemRepo.AddressLine2 = company.AddressLine2;
                itemRepo.AddressLine3 = company.AddressLine3;
                itemRepo.Country = company.Country;
                itemRepo.EquipmentCompanyCode = company.EquipmentCompanyCode;
                itemRepo.FaxNumber = company.FaxNumber;
                itemRepo.PhoneNumber = company.PhoneNumber;
                itemRepo.PostalZipCode = company.PostalZipCode;
                itemRepo.LastModified = company.LastModified;
                return await _companyDbWrapper.UpdateAsync(itemRepo);
            }
            return await _companyDbWrapper.InsertAsync(company);
        }

        public bool DeleteCompany(string siteId, string companyCode)
        {
            Expression<Func<Company, bool>> expression = n => n.CompanyCode == companyCode && n.SiteId == siteId;
            return _companyDbWrapper.Delete(expression);
        }

        public async Task<bool> DeleteCompanyAsync(string siteId, string companyCode)
        {
            Expression<Func<Company, bool>> expression = n => n.CompanyCode == companyCode && n.SiteId == siteId;
            return await _companyDbWrapper.DeleteAsync(expression);
        }

    }
}
