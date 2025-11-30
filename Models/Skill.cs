namespace TestBackEnd.Models;

using Microsoft.EntityFrameworkCore;

[Owned]
/// <summary>
/// Навык с названием и уровнем (1-10).
/// </summary>
public class Skill
{

    public string Name { get; set; } = null!;

    public byte Level { get; set; }
}