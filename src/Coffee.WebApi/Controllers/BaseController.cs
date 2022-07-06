namespace Coffee.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BaseController : ControllerBase
{
    public IMediator Mediator { get; }
    private readonly ILogger<BaseController> _logger;

    public BaseController(ILogger<BaseController> logger, IMediator mediator)
    {
        Mediator = mediator;
        _logger = logger;
    }
}