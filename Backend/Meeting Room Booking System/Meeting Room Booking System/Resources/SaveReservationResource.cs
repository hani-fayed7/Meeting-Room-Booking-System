using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meeting_Room_Booking_System.Resources
{
    public class SaveReservationResource
    {
        public DateTime DateOfMeeting { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int NumberOfAttendees { get; set; }
        public bool MeetingStatus { get; set; }
        public int? FkReservationRelatedRoom { get; set; }
        public int? FkRoomUserId { get; set; }
    }
}
