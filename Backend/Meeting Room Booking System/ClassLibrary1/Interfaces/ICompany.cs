using MRBS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Core.Interfaces
{
    public interface ICompany : IRepository<Company>
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync();
        Task<Company> GetWithCompanyByIdAsync(int id); 
    }
}
