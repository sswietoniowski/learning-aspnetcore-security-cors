using AutoMapper;
using ConfiguringCors.Application.Contracts.Infrastructure;
using ConfiguringCors.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ConfiguringCors.MVC.Controllers
{
    public class UsersController : Controller
    {
        private const int _DEFAULT_USERS_QUANTITY = 10;

        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public UsersController(IMapper mapper, IUsersService usersService)
        {
            _mapper = mapper;
            _usersService = usersService;
        }

        #region API_CALLS

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAll([FromQuery] int quantity = _DEFAULT_USERS_QUANTITY)
        {
            var users = _usersService.GetAll().Take(quantity);
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
            return Json(usersDto);
        }

        #endregion
    }
}
