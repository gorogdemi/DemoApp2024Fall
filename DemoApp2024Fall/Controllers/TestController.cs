using Microsoft.AspNetCore.Mvc;

namespace DemoApp2024Fall.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private IDemoService _service;

    public TestController(IDemoService service)
    {
        _service = service;
    }

    [HttpGet("count")]
    public ActionResult<int> Count()
    {
        return Ok(_service.NextCount());
    }
}