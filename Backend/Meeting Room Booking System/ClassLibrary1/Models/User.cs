using System;
using System.Collections.Generic;

#nullable disable

namespace MRBS.Core.Models
{
    public partial class User
    {
        public User()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int PkUserId { get; set; }
        public string UserName { get; set; }
        public DateTime UserDoB { get; set; }
        public string UserGender { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserRole { get; set; }
        public int? FkUserRelatedCompany { get; set; }

        public virtual Company FkUserRelatedCompanyNavigation { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
