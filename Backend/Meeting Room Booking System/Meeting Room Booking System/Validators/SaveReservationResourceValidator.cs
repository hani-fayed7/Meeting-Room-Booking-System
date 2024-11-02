using FluentValidation;
using Meeting_Room_Booking_System.Resources;

namespace Meeting_Room_Booking_System.Validators
{
    public class SaveReservationResourceValidator : AbstractValidator<SaveReservationResource>
    {
        public SaveReservationResourceValidator()
        {
            RuleFor(a => a.DateOfMeeting)
                .NotEmpty();

            RuleFor(a => a.StartTime)
                .NotEmpty();

            RuleFor(a => a.EndTime)
                .NotEmpty();

            RuleFor(a => a.NumberOfAttendees)
                .NotEmpty();

            RuleFor(a => a.MeetingStatus)
                .NotEmpty();

            RuleFor(a => a.FkRoomUserId)
                .NotEmpty();

            RuleFor(a => a.FkReservationRelatedRoom)
                .NotEmpty();

        }
    }
}
