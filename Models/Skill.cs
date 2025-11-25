namespace TestBackEnd.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

[Owned]
/// <summary>
/// Навык с названием и уровнем (1-10).
/// </summary>
public class Skill
{
    [Required]
    public string Name { get; set; } = null!;

    [Range(0, 10)]
    public byte Level { get; set; }
}