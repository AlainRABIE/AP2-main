using System;
using ASPBookProject.Models;

namespace ASPBookProject.ViewModels;

public class RegisterViewModel 
{
    public required string Identifiant { get; set; }
    public string? Username { get; set; }
    public bool RememberMe { get; set; }

}

