using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskUser.Application.Services;
using TaskUser.Common.Model;

namespace TaskUser.Api.Controllers
{
   
    public class UserLoginAttemptController : BaseController
    {
        UserLoginAttempService _service;
        public UserLoginAttemptController(UserLoginAttempService service)
        {
            _service = service;
        }

        [HttpPost("statistic")]
        public IActionResult GetLoginStatistic(StatisticRequest request)
        {
            return Response(_service.Get(request));
        }
    }
}
