using System.ComponentModel.DataAnnotations;

namespace TestBackEnd.Dto
{
    public class SkillDto
    {
        [Required(ErrorMessage = "Название навыка обязательно")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Уровень навыка обязателен")]
        [Range(0, 10, ErrorMessage = "Уровень навыка должен быть от 0 до 10")]
        public int Level { get; set; }
    }

    public class CreatePersonDto
    {
        [Required(ErrorMessage = "Имя обязательно")]
        [StringLength(100, ErrorMessage = "Имя не должно превышать 100 символов")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Отображаемое имя обязательно")]
        [StringLength(100, ErrorMessage = "Отображаемое имя не должно превышать 100 символов")]
        public string DisplayName { get; set; } = null!;

        [Required(ErrorMessage = "Список навыков обязателен")]
        [MinLength(1, ErrorMessage = "Должен быть указан хотя бы один навык")]
        public List<SkillDto> Skills { get; set; } = new();
    }

    public class UpdatePersonDto
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string DisplayName { get; set; } = null!;

        [MinLength(1)]
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