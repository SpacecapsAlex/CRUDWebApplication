﻿namespace WebApplication2.Models;

public class User
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Country { get; set; }
    public int Age { get; set; }
}