using Meeting_Room_Booking_System.Resources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meeting_Room_Booking_System.Validators
{
    public class SaveCompanyResourceValidator : AbstractValidator<SaveCompanyResource>
    {
        public SaveCompanyResourceValidator()
        {
            RuleFor(a => a.CompanyName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(a => a.CompanyDescription)
                .MaximumLength(500);

            RuleFor(a => a.CompanyEmail)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(a => a.CompanyLocation)
                .MaximumLength(500);

            RuleFor(a => a.CompanyPhone)
                .NotEmpty();

            RuleFor(a => a.CompanyStatus)
                .NotEmpty();
        }
    }
}
