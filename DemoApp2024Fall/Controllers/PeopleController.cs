using DemoApp2024Fall.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp2024Fall.Controllers;

[ApiController]
[Route("people")]
public class PeopleController : ControllerBase
{
    private IPersonService _personService;

    public PeopleController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Person person)
    {
        var existingPerson = await _personService.GetAsync(person.Id);

        if (existingPerson is not null)
        {
            return Conflict();
        }

        await _personService.AddAsync(person);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var person = await _personService.GetAsync(id);

        if (person is null)
        {
            return NotFound();
        }

        await _personService.DeleteAsync(id);

        return Ok();
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Person>> Get(Guid id)
    {
        var person = await _personService.GetAsync(id);

        if (person is null)
        {
            return NotFound();
        }

        return Ok(person);
    }

    [HttpGet]
    public async Task<ActionResult<List<Person>>> Get()
    {
        return Ok(await _personService.GetAllAsync());
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Person newPerson)
    {
        if (id != newPerson.Id)
        {
            return BadRequest();
        }

        var existingPerson = await _personService.GetAsync(id);

        if (existingPerson is null)
        {
            return NotFound();
        }

        await _personService.UpdateAsync(newPerson);

        return Ok();
    }
}