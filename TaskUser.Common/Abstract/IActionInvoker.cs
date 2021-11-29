using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskUser.Common.Abstract
{
    public interface IActionInvoker
    {
        ActionResult<T> Invoke<T>(Func<T> function, string actionName = null, bool useTransaction = false, bool useLog = false, params object[] args);

        ActionResult Invoke(Action action, string actionName = null, bool useTransaction = false, params object[] args);
    }
}
