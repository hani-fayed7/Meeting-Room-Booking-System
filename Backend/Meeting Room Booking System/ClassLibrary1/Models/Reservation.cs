using System;
using System.Collections.Generic;

#nullable disable

namespace MRBS.Core.Models
{
    public partial class Reservation
    {
        public int PkReservationId { get; set; }
        public DateTime DateOfMeeting { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int NumberOfAttendees { get; set; }
        public bool MeetingStatus { get; set; }
        public int? FkReservationRelatedRoom { get; set; }
        public int? FkRoomUserId { get; set; }

        public virtual Room FkReservationRelatedRoomNavigation { get; set; }
        public virtual User FkRoomUser { get; set; }
    }
}
