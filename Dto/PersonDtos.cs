using System.ComponentModel.DataAnnotations;

namespace TestBackEnd.Dto
{
    public class SkillDto
    {
        [Required]
        public string Name { get; set; } = null!;

        [Range(0, 10)]
        public int Level { get; set; }
    }

    public class CreatePersonDto
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string DisplayName { get; set; } = null!;

        [MinLength(1, ErrorMessage = "Список навыков должен содержать хотя бы один навык.")]
        public List<SkillDto> Skills { get; set; } = new();
    }

    public class UpdatePersonDto
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string DisplayName { get; set; } = null!;

        [MinLength(1, ErrorMessage = "Список навыков должен содержать хотя бы один навык.")]
        public List<SkillDto> Skills { get; set; } = new();
    }

    public class PersonDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public List<SkillDto> Skills { get; set; } = new();
    }
}