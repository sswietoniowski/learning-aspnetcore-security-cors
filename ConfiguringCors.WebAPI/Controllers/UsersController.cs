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
        private const string _PAGINATION_PAGE_NO = "PageNo";
        private const string _PAGINATION_PAGE_SIZE = "PageSize";
        private const string _PAGINATION_PAGE_COUNT = "PageCount";
        private const string _PAGINATION_PAGE_TOTAL_RECORDS = "PageTotalRecords";

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
        [EnableCors("AllowAnyOrigin")] // can be applied to the whole controller too (same with other actions)
        public ActionResult<IEnumerable<UserDto>> CorsEnabledAllowAnyOrigin([FromQuery] int quantity = _DEFAULT_USERS_QUANTITY) => GetAll(quantity);

        [HttpGet("cors-enabled-with-origins")]
        [EnableCors("WithOrigins")]
        public ActionResult<IEnumerable<UserDto>> CorsEnabledWithOrigins([FromQuery] int quantity = _DEFAULT_USERS_QUANTITY) => GetAll(quantity);

        [HttpGet("cors-enabled-with-origins-methods-headers")]
        [EnableCors("WithOriginsMethodsdHeaders")]
        public ActionResult<IEnumerable<UserDto>> CorsEnabledWithOriginsMethodsHeaders([FromQuery] int quantity = _DEFAULT_USERS_QUANTITY) => GetAll(quantity);

        private void SetPaginationHeader(int pageSize, int pageNo, int pageCount, int pageTotalRecords)
        {
            HttpContext.Response.Headers.Add(_PAGINATION_PAGE_NO, pageNo.ToString());
            HttpContext.Response.Headers.Add(_PAGINATION_PAGE_SIZE, pageSize.ToString());
            HttpContext.Response.Headers.Add(_PAGINATION_PAGE_COUNT, pageCount.ToString());
            HttpContext.Response.Headers.Add(_PAGINATION_PAGE_TOTAL_RECORDS, pageTotalRecords.ToString());
        }

        [HttpGet("cors-enabled-with-some-extra-options")]
        [EnableCors("WithSomeExtraOptions")]
        public ActionResult<IEnumerable<UserDto>> CorsEnabledWithSomeExtraOptions([FromQuery] int quantity = _DEFAULT_USERS_QUANTITY)
        {
            int pageNo = 1;
            int pageSize = 10;
            int pageCount = 10;
            int totalRecords = 100;
            SetPaginationHeader(pageNo, pageSize, pageCount, totalRecords);

            return GetAll(quantity);
        }

        [HttpGet("cors-enabled-with-programmatic-origin-check")]
        [EnableCors("WithProgrammaticOriginCheck")]
        public ActionResult<IEnumerable<UserDto>> CorsEnabledWithProgrammaticOriginCheck([FromQuery] int quantity = _DEFAULT_USERS_QUANTITY) => GetAll(quantity);
    }
}
