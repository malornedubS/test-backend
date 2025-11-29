using TestBackEnd.Models;

namespace TestBackEnd.Services.Interfaces
{
    public interface IPersonService
    {
        Task<List<Person>> GetAllAsync();
        Task<Person?> GetByIdAsync(long id);
        Task<Person> AddPersonAsync(Person person);
        Task<Person?> UpdatePersonAsync(long id, Person person);
        Task<bool> DeletePersonAsync(long id);
        Task AddSkillAsync(long personId, Skill skill);
    }
}
