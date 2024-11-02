using MRBS.Core.Interfaces;
using MRBS.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Core.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompany
    {
        public CompanyRepository(meetingRoomBookingSystemContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            return await MyDbContext.Companies
                .ToListAsync();
        }

        public Task<Company> GetWithCompanyByIdAsync(int id)
        {
            return MyDbContext.Companies
                .SingleOrDefaultAsync(a => a.PkCompanyId == id);
        }

        private meetingRoomBookingSystemContext MyDbContext
        {
            get { return Context as meetingRoomBookingSystemContext; }
        }
    } 
}
