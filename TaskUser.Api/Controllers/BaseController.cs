using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskUser.Api.Helper;
using CM = TaskUser.Common;

namespace TaskUser.Api.Controllers
{
    [ApiKeyAuth]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected new IActionResult Response(CM.ActionResult response, Action<CM.ActionResult> success = null, Action<CM.ActionResult> error = null)
        {
            if (response.IsSucceed)
            {
                if (success != null) success.Invoke(response);
                return Ok("Ok");
            }
            else
            {
                if (error != null) error.Invoke(response);
                return BadRequest(response);
            }
        }

        protected new IActionResult Response<T>(CM.ActionResult<T> response, Action<CM.ActionResult<T>> success = null, Action<CM.ActionResult> error = null)
        {
            if (response.IsSucceed)
            {
                if (success != null) success.Invoke(response);
                return Ok(response.Data);
            }
            else
            {
                if (error != null) error.Invoke(response);
                return BadRequest(response);
            }
        }
    }
}


