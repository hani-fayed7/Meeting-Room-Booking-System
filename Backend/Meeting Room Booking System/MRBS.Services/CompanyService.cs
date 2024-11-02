using MRBS.Core.Interfaces;
using MRBS.Core.Models;
using MRBS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Company> CreateCompany(Company newCompany)
        {
            await _unitOfWork.Companies.AddAsync(newCompany);
            await _unitOfWork.CommitAsync();
            return newCompany;
        }

        public async Task DeleteCompany(Company company)
        {
            _unitOfWork.Companies.Remove(company);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _unitOfWork.Companies
                .GetAllCompaniesAsync();
        }

        public async Task<Company> GetCompanyById(int id)
        {
            return await _unitOfWork.Companies.GetByIdAsync(id);
        }
    }
}
