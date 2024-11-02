using FluentValidation;
using Meeting_Room_Booking_System.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meeting_Room_Booking_System.Validators
{
    public class SaveUserResourceValidator : AbstractValidator<SaveUserResource>
    {
        public SaveUserResourceValidator()
        {
            RuleFor(a => a.UserName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(a => a.UserDoB)
               .NotEmpty();

            RuleFor(a => a.UserGender)
               .NotEmpty()
               .MaximumLength(50);

            RuleFor(a => a.UserEmail)
               .NotEmpty()
               .MaximumLength(500);

            RuleFor(a => a.UserPassword)
               .NotEmpty()
               .MaximumLength(50);

            RuleFor(a => a.UserRole)
               .NotEmpty()
               .MaximumLength(50);

            RuleFor(a => a.FkUserRelatedCompany)
               .NotEmpty();
        }
    }
}
