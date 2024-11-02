using System;
using System.Collections.Generic;

#nullable disable

namespace MRBS.Core.Models
{
    public partial class Room
    {
        public Room()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int PkRoomId { get; set; }
        public string RoomName { get; set; }
        public string RoomLocation { get; set; }
        public int RoomCapacity { get; set; }
        public string RoomDescription { get; set; }
        public int? FkRoomRelatedCompany { get; set; }

        public virtual Company FkRoomRelatedCompanyNavigation { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
