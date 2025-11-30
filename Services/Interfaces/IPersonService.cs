using TestBackEnd.Dto;

namespace TestBackEnd.Services.Interfaces
{
    public interface IPersonService
    {
        Task<List<PersonDto>> GetAllPersonsAsync();
        Task<PersonDto> GetPersonByIdAsync(long id);
        Task<PersonDto> CreatePersonAsync(CreatePersonDto person);
        Task<PersonDto> UpdatePersonAsync(long id, UpdatePersonDto person);
        Task DeletePersonAsync(long id);
    }
}
