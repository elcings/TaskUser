using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskUser.Api.Helper;
using TaskUser.Application.Services;

namespace TaskUser.Api.Controllers
{
   
    public class UserController : BaseController
    {
        UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            return Response(_userService.GetByEmail(email));
        }

        

        [HttpGet("init")]
        public IActionResult Init()
        {
            return Response(_userService.Init());
        }
    }
}
