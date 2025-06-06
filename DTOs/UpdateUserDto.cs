﻿using System;

namespace OracleJwtApiFull.DTOs
{
    public class UpdateUserDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }
        public DateTime Dob { get; set; }
        public string? Role { get; set; }
    }
}
