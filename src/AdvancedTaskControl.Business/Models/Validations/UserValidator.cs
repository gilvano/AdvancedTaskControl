using AdvancedTaskControl.API.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedTaskControl.Business.Models.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Username).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
        }
    }
}
