﻿using Core.Entities;

namespace Entities.Dtos
{
    public class UserForLoginRegisterDto:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
