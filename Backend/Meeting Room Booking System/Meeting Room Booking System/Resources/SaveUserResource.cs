using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meeting_Room_Booking_System.Resources
{
    public class SaveUserResource
    {
        public string UserName { get; set; }
        public DateTime UserDoB { get; set; }
        public string UserGender { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserRole { get; set; }
        public int? FkUserRelatedCompany { get; set; }
    }
}
