namespace Coffee.WebApi.Controllers;

public class TodosController : BaseController
{
    public TodosController(ILogger<TodosController> logger, IMediator mediator) : base(logger, mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddTodoCommand request)
    {
        var result = await Mediator.Send(request);
        return Created(string.Empty, result);
    }
}