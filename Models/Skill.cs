namespace TestBackEnd.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

[Owned]
public class Skill
{
    [Required]
    public string Name { get; set; } = null!;

    [Range(0, 10)]
    public byte Level { get; set; }
}