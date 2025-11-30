using Microsoft.EntityFrameworkCore;
using TestBackEnd.Data;
using TestBackEnd.Data.Repositories;
using TestBackEnd.Models;


namespace TestBackEnd.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _db;

        public PersonRepository(AppDbContext db)
        {
            _db = db;
        }


        public async Task<List<Person>> GetAllPersonsAsync()
        {
            return await _db.Persons.Include(p => p.Skills).ToListAsync();
        }


        public async Task<Person?> GetPersonByIdAsync(long id)
        {
            return await _db.Persons
                .Include(p => p.Skills)
                .FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<Person> CreatePersonAsync(Person person)
        {
            _db.Persons.Add(person);
            await _db.SaveChangesAsync();
            return person;
        }


        public async Task UpdatePersonAsync(Person person)
        {
            _db.Persons.Update(person);
            await _db.SaveChangesAsync();
        }


        public async Task DeletePersonAsync(Person person)
        {
            _db.Persons.Remove(person);
            await _db.SaveChangesAsync();
        }
    }
}
