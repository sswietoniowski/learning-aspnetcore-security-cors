using AutoMapper;
using ConfiguringCors.Application.Contracts.Infrastructure;
using ConfiguringCors.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ConfiguringCors.WebAPI.Controllers
{
    [Route("api/nocors")]
    [ApiController]
    public class NoCorsController : ControllerBase
    {
        private const int _DEFAULT_USERS_QUANTITY = 10;

        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public NoCorsController(IMapper mapper, IUsersService usersService)
        {
            _mapper = mapper;
            _usersService = usersService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAll([FromQuery] int quantity = _DEFAULT_USERS_QUANTITY)
        {
            var users = _usersService.GetAll().Take(quantity);
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(usersDto);
        }
    }
}
