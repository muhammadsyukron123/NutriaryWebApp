using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutriaryWebApp.BLL.DTOs
{
    public class UpdateUserAccountDTO
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
    }

    public class UpdateUserAccountDTOValidator : AbstractValidator<UpdateUserAccountDTO>
    {
        public UpdateUserAccountDTOValidator()
        {
            RuleFor(x => x.username).NotEmpty().WithMessage("Username is required.");
            RuleFor(x => x.email).EmailAddress().NotEmpty().Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Invalid email format.");
            RuleFor(x => x.email).NotEmpty().WithMessage("Email is required.");
            RuleFor(x => x.firstname).NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.lastname).NotEmpty().WithMessage("Last name is required.");
        }
    }
}
