using AutoMapper;
using ConfiguringCors.Application.Contracts.Infrastructure;
using ConfiguringCors.Application.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ConfiguringCors.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private const int _DEFAULT_USERS_QUANTITY = 10;

        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public UsersController(IMapper mapper, IUsersService usersService)
        {
            _mapper = mapper;
            _usersService = usersService;
        }

        private ActionResult<IEnumerable<UserDto>> GetAll(int quantity)
        {
            var users = _usersService.GetAll().Take(quantity);
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(usersDto);
        }

        [HttpGet("cors-disabled")]
        public ActionResult<IEnumerable<UserDto>> CorsDisabled([FromQuery] int quantity = _DEFAULT_USERS_QUANTITY) => GetAll(quantity);

        [HttpGet("cors-enabled-allow-any-origin")]
        [EnableCors("AllowAnyOrigin")] // can be applied to the whole controller too
        public ActionResult<IEnumerable<UserDto>> CorsEnabledAllowAnyOrigin([FromQuery] int quantity = _DEFAULT_USERS_QUANTITY) => GetAll(quantity);

        [HttpGet("cors-enabled-with-origins")]
        [EnableCors("WithOrigins")] // can be applied to the whole controller too
        public ActionResult<IEnumerable<UserDto>> CorsEnabledWithOrigins([FromQuery] int quantity = _DEFAULT_USERS_QUANTITY) => GetAll(quantity);
        [HttpGet("cors-enabled-with-origins-methods-headers")]
        [EnableCors("WithOriginsMethodsdHeaders")] // can be applied to the whole controller too
        public ActionResult<IEnumerable<UserDto>> CorsEnabledWithOriginsMethodsHeaders([FromQuery] int quantity = _DEFAULT_USERS_QUANTITY) => GetAll(quantity);
    }
}
