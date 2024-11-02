using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meeting_Room_Booking_System.Resources
{
    public class RoomResource
    {
        public int PkRoomId { get; set; }
        public string RoomName { get; set; }
        public string RoomLocation { get; set; }
        public int RoomCapacity { get; set; }
        public string RoomDescription { get; set; }
        public int? FkRoomRelatedCompany { get; set; }
    }
}
