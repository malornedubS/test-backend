using Microsoft.EntityFrameworkCore;
using TestBackEnd.Data;
using TestBackEnd.Models;

namespace TestBackEnd.Services
{
    public class PersonService
    {
        private readonly AppDbContext _dbContext;

        public PersonService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _dbContext.Persons
                .Include(p => p.Skills)
                .ToListAsync();
        }

        public async Task<Person?> GetByIdAsync(long id)
        {
            return await _dbContext.Persons
                .Include(p => p.Skills)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Person> AddPersonAsync(Person person)
        {
            _dbContext.Persons.Add(person);
            await _dbContext.SaveChangesAsync();
            return person;
        }

        public async Task AddSkillAsync(long personId, Skill skill)
        {
            var person = await GetByIdAsync(personId);
            if (person != null)
            {
                person.Skills.Add(skill);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<Person?> UpdatePersonAsync(long id, Person person)
        {
            var existing = await _dbContext.Persons
                .Include(p => p.Skills)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existing == null) return null;

            existing.Name = person.Name;
            existing.DisplayName = person.DisplayName;
            existing.Skills = person.Skills;

            await _dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeletePersonAsync(long id)
        {
            var existing = await _dbContext.Persons.FindAsync(id);
            if (existing == null) return false;

            _dbContext.Persons.Remove(existing);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
