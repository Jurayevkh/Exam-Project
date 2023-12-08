namespace QRCode.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdUser(int id)
        {
            var user = await _mediator.Send(new GetByIdUserQuery() { Id = id });

            return Ok(user);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllUsers()
        {
            var user = await _mediator.Send(new GetAllUsersQuery());

            return Ok(user);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateUser(CreateUserDto request)
        {
            CreateUserCommand user = new CreateUserCommand()
           {
                FirstName=request.FirstName,
                LastName=request.LastName,
                MiddleName=request.MiddleName,
                Age=request.Age,
                Email=request.Email
            };
            var result = await _mediator.Send(user);

            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateUser(UpdateUserDto request)
        {
            UpdateUserCommand user = new UpdateUserCommand()
            {
                Id=request.Id,
                FirstName=request.FirstName,
                LastName=request.LastName,
                MiddleName=request.MiddleName,
                Age=request.Age,
                Email=request.Email
            };

            var result = await _mediator.Send(user);

            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteUser(int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand() {Id=id});

            return Ok(result);
        }
    }
}

