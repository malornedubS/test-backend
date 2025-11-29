using Microsoft.EntityFrameworkCore;
using TestBackEnd.Services.Interfaces;
using TestBackEnd.Data;
using TestBackEnd.Models;
using TestBackEnd.Data.Repositories;

namespace TestBackEnd.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repo;

        public PersonService(IPersonRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Person>> GetAllAsync() => _repo.GetAllAsync();

        public Task<Person?> GetByIdAsync(long id) => _repo.GetByIdAsync(id);

        public Task<Person> AddPersonAsync(Person person) => _repo.AddAsync(person);

        public async Task AddSkillAsync(long id, Skill skill)
        {
            var person = await _repo.GetByIdAsync(id);
            if (person == null) return;

            person.Skills.Add(skill);
            await _repo.UpdateAsync(person);
        }

        public async Task<Person?> UpdatePersonAsync(long id, Person updated)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return null;

            existing.Name = updated.Name;
            existing.DisplayName = updated.DisplayName;
            existing.Skills = updated.Skills;

            await _repo.UpdateAsync(existing);
            return existing;
        }

        public async Task<bool> DeletePersonAsync(long id)
        {
            var person = await _repo.GetByIdAsync(id);
            if (person == null) return false;

            await _repo.DeleteAsync(person);
            return true;
        }
    }
}
