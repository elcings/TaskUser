using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskUser.Application.BusinesLogic;
using TaskUser.Application.DTO;
using TaskUser.Common;
using TaskUser.Common.Abstract;

namespace TaskUser.Application.Services
{
    public class UserService
    {
        private IActionInvoker _actionInvoker;
        private ICacheService _cacheService;
        private IUserBusinessLogic _userBusinessLogic;
        public UserService(ICacheService cacheService, IUserBusinessLogic userBusinessLogic, IActionInvoker actionInvoker)
        {
            _cacheService = cacheService;
            _userBusinessLogic = userBusinessLogic;
            _actionInvoker = actionInvoker;
        }

        public ActionResult Save(UserDTO dto)
        {
            return _actionInvoker.Invoke(() => {
                _userBusinessLogic.Create(dto);
            }, "UserService.Create", false);
        }

        public ActionResult Init()
        {
            return _actionInvoker.Invoke(() => {
                _userBusinessLogic.Init();
            }, "UserService.Init",true);
        }

        public ActionResult Remove(Guid Id)
        {
            return _actionInvoker.Invoke(() => {
                _userBusinessLogic.Remove(Id);
            }, "UserService.Remove", false);
        }

        public ActionResult<UserDTO> GetByEmail(string email)
        {
            return _actionInvoker.Invoke<UserDTO>(() => {
               return _userBusinessLogic.GetByEmail(email);
            }, "UserService.GetByEmail", false);
        }
    }
}
