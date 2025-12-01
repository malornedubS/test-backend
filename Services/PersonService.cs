
using TestBackEnd.Services.Interfaces;
using TestBackEnd.Data.Repositories;
using TestBackEnd.Models;
using TestBackEnd.Dto;
using TestBackEnd.Exceptions;


namespace TestBackEnd.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repo;

        public PersonService(IPersonRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<PersonDto>> GetAllPersonsAsync()
        {
            var persons = await _repo.GetAllPersonsAsync();
            return persons.Select(ToDto).ToList();
        }

        public async Task<PersonDto> GetPersonByIdAsync(long id)
        {
            var person = await _repo.GetPersonByIdAsync(id);
            if (person == null)
                throw new NotFoundException($"Сотрудник с id:{id} не найден");

            return ToDto(person);
        }

        public async Task<PersonDto> CreatePersonAsync(CreatePersonDto dto)
        {
            var entity = new Person
            {
                Name = dto.Name,
                DisplayName = dto.DisplayName,
                Skills = dto.Skills?.Select(s => new Skill
                {
                    Name = s.Name,
                    Level = (byte)s.Level
                }).ToList() ?? new List<Skill>()
            };

            var created = await _repo.CreatePersonAsync(entity);
            return ToDto(created);
        }

        public async Task<PersonDto> UpdatePersonAsync(long id, UpdatePersonDto dto)
        {
            var existing = await _repo.GetPersonByIdAsync(id);
            if (existing == null)
                throw new NotFoundException($"Сотрудник с id:{id} не найден");

            existing.Name = dto.Name;
            existing.DisplayName = dto.DisplayName;

            existing.Skills.Clear();
            if (dto.Skills != null)
            {
                foreach (var skillDto in dto.Skills)
                {
                    existing.Skills.Add(new Skill
                    {
                        Name = skillDto.Name,
                        Level = (byte)skillDto.Level
                    });
                }
            }

            await _repo.UpdatePersonAsync(existing);
            return ToDto(existing);
        }

        public async Task DeletePersonAsync(long id)
        {
            var person = await _repo.GetPersonByIdAsync(id);
            if (person == null)
                throw new NotFoundException($"Сотрудник с id:{id} не найден");

            await _repo.DeletePersonAsync(person);
        }

        // преобразования Person в PersonDto
        private PersonDto ToDto(Person person)
        {
            return new PersonDto
            {
                Id = person.Id,
                Name = person.Name,
                DisplayName = person.DisplayName,
                Skills = person.Skills.Select(s => new SkillDto
                {
                    Name = s.Name,
                    Level = s.Level
                }).ToList()
            };
        }
    }
}
