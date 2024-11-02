using FluentValidation;
using Meeting_Room_Booking_System.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meeting_Room_Booking_System.Validators
{
      public class SaveRoomResourceValidator : AbstractValidator<SaveRoomResource>
    {
        public SaveRoomResourceValidator()
        {
            RuleFor(a => a.RoomName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(a => a.RoomLocation)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(a => a.RoomCapacity)
                .NotEmpty();

            RuleFor(a => a.RoomDescription)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(a => a.FkRoomRelatedCompany)
                .NotEmpty();
        }
    }
}
