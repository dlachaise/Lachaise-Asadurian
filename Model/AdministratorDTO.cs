﻿using System;

namespace Model
{
    public class AdministratorDTO
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}