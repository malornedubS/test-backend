using System.ComponentModel.DataAnnotations;


namespace TestBackEnd.Models;

/// <summary>
/// Сотрудник компании.
/// </summary>
public class Person
{
    public long Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string DisplayName { get; set; } = null!;


    public List<Skill> Skills { get; set; } = new();
}