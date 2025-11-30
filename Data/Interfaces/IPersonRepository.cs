using TestBackEnd.Models;

namespace TestBackEnd.Data.Repositories
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAllPersonsAsync();
        Task<Person?> GetPersonByIdAsync(long id);
        Task<Person> CreatePersonAsync(Person person);
        Task UpdatePersonAsync(Person person);
        Task DeletePersonAsync(Person person);
    }
}