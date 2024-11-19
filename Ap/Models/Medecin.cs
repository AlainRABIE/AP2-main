using System;
using Microsoft.AspNetCore.Identity;

namespace ASPBookProject.Models;

public class Medecin : IdentityUser
{
    public required string Identifiant { get; set; }
    public string? Username { get; set; }
    
    public List<Ordonnance> Ordonnances { get; set; } = new();
}
