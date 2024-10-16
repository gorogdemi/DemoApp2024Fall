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
    public IActionResult Add([FromBody] Person person)
    {
        var existingPerson = _personService.Get(person.Id);

        if (existingPerson is not null)
        {
            return Conflict();
        }

        _personService.Add(person);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var person = _personService.Get(id);

        if (person is null)
        {
            return NotFound();
        }

        _personService.Delete(id);

        return Ok();
    }

    [HttpGet("{id:guid}")]
    public ActionResult<Person> Get(Guid id)
    {
        var person = _personService.Get(id);

        if (person is null)
        {
            return NotFound();
        }

        return Ok(person);
    }

    [HttpGet]
    public ActionResult<List<Person>> Get()
    {
        return Ok(_personService.GetAll());
    }

    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, [FromBody] Person newPerson)
    {
        if (id != newPerson.Id)
        {
            return BadRequest();
        }

        var existingPerson = _personService.Get(id);

        if (existingPerson is null)
        {
            return NotFound();
        }

        _personService.Update(newPerson);

        return Ok();
    }
}