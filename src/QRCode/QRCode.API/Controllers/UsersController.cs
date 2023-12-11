namespace QRCode.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDistributedCache _distributedCache;


        public UsersController(IMediator mediator, IDistributedCache distributedCache)
        {
            _mediator = mediator;
            _distributedCache = distributedCache;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdUser(int id)
        {
            var fromCache = await _distributedCache.GetStringAsync($"GetByIdUser{id}");

            if (fromCache is null)
            {
                var user = await _mediator.Send(new GetByIdUserQuery() { Id=id});

                fromCache = JsonSerializer.Serialize(user);
                await _distributedCache.SetStringAsync($"GetByIdUser{user.Id}", fromCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60)
                });
            }
            var result = JsonSerializer.Deserialize<User>(fromCache);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllUsers()
        {
            var fromCache = await _distributedCache.GetStringAsync($"GetAllUsers");

            if (fromCache is null)
            {
                var users = await _mediator.Send(new GetAllUsersQuery());

                fromCache = JsonSerializer.Serialize(users);
                await _distributedCache.SetStringAsync($"GetAllUsers", fromCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60)
                });
            }
            var result = JsonSerializer.Deserialize<List<User>>(fromCache);

            return Ok(result);
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

