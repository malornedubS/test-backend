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



        // Получение всех пользователей вместе с навыками      
        public async Task<List<Person>> GetAllAsync()
        {
            return await _db.Persons.Include(p => p.Skills).ToListAsync();
        }



        // Получение пользователя по идентификатору вместе с навыками
        public async Task<Person?> GetByIdAsync(long id)
        {
            return await _db.Persons
                .Include(p => p.Skills)
                .FirstOrDefaultAsync(x => x.Id == id);
        }



        // Добавление нового пользователя
        public async Task<Person> AddAsync(Person person)
        {
            _db.Persons.Add(person);
            await _db.SaveChangesAsync();
            return person;
        }



        // Обновление информации о пользователе
        public async Task UpdateAsync(Person person)
        {
            _db.Persons.Update(person);
            await _db.SaveChangesAsync();
        }



        // Удаление пользователя
        public async Task DeleteAsync(Person person)
        {
            _db.Persons.Remove(person);
            await _db.SaveChangesAsync();
        }
    }
}
