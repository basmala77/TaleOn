﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Success { get; set; }
        public List<string> ErrorMessages { get; set; } = new List<string>();

    }
}
