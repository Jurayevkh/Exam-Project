﻿namespace QRCode.API.DTOs;

public class UpdateUserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
}

