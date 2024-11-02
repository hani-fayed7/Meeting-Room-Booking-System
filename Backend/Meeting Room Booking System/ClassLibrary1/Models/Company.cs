using System;
using System.Collections.Generic;

#nullable disable

namespace MRBS.Core.Models
{
    public partial class Company
    {
        public Company()
        {
            Rooms = new HashSet<Room>();
            Users = new HashSet<User>();
        }

        public int PkCompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyLocation { get; set; }
        public int CompanyPhone { get; set; }
        public byte[] CompanyLogo { get; set; }
        public bool CompanyStatus { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
