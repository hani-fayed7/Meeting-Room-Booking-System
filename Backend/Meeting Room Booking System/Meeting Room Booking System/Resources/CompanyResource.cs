using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meeting_Room_Booking_System.Resources
{
    public class CompanyResource
    {
        public int PkCompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyLocation { get; set; }
        public int CompanyPhone { get; set; }
        public byte[] CompanyLogo { get; set; }
        public bool CompanyStatus { get; set; }
  }
}
