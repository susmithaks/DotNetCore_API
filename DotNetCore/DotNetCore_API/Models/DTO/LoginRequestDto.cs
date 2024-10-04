﻿using System.ComponentModel.DataAnnotations;

namespace DotNetCore_API.Models.DTO
{
    public class LoginRequestDto
    {
        [Required]

        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
