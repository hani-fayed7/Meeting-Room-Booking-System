
using MRBS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Services.Interface
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<Company> CreateCompany(Company newCompany);
        Task DeleteCompany(Company company);
        Task<Company> GetCompanyById(int id);
    }
}
