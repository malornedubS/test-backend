using Microsoft.AspNetCore.Mvc;
using TestBackEnd.Dto;
using TestBackEnd.Services.Interfaces;

namespace TestBackEnd.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllPersonsAsync();
            return Ok(persons);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var person = await _personService.GetPersonByIdAsync(id);
            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePersonDto dto)
        {

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                throw new BadRequestException($"Ошибка валидации: {string.Join("; ", errors)}");
            }
            var created = await _personService.CreatePersonAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdatePersonDto dto)
        {
            var updated = await _personService.UpdatePersonAsync(id, dto);
            return Ok(updated);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _personService.DeletePersonAsync(id);
            return NoContent();
        }
    }
}