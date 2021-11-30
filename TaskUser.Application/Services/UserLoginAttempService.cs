using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskUser.Application.BusinesLogic;
using TaskUser.Common;
using TaskUser.Common.Abstract;
using TaskUser.Common.Model;

namespace TaskUser.Application.Services
{
    public class UserLoginAttempService
    {
        private IActionInvoker _actionInvoker;
        private ICacheService _cacheService;
        private IUserLoginAttemptBusinessLogic _userBusinessLogic;
        public UserLoginAttempService(ICacheService cacheService, IUserLoginAttemptBusinessLogic userBusinessLogic, IActionInvoker actionInvoker)
        {
            _cacheService = cacheService;
            _userBusinessLogic = userBusinessLogic;
            _actionInvoker = actionInvoker;
        }
        public ActionResult<object> Get(StatisticRequest request)
        {
            return _actionInvoker.Invoke<object>(() => {
                return _userBusinessLogic.Get(request);
            }, "UserLoginAttempService.Get", false);
        }
    }
}
