﻿namespace CustomerAPI.Dtos
{
    public class CustomerReadDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? EmailAddress { get; set; }
    }
}
