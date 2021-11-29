using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TaskUser.Common.Abstract;
using TaskUser.Common.Exceptions;

namespace TaskUser.Common.Concrete
{
    public class BaseActionInvoker : IActionInvoker
    {
        private ILogger logger;
        public BaseActionInvoker()
        {
            logger = LogManager.GetCurrentClassLogger();
        }
        public ActionResult<T> Invoke<T>(Func<T> function, string actionName = null, bool useTransaction = false, bool useLog = false, params object[] args)
        {
            try
            {
                T result;
                if (useTransaction)
                    result = (T)TransactionInvoker(function);
                else
                    result = (T)function.Invoke();
                if (useLog)
                    logger.Info(string.Format("{0}.Result:{1}", actionName, JsonConvert.SerializeObject(ActionResult<T>.Succeed(result))));
                return ActionResult<T>.Succeed(result);
            }

            catch (GeneralValidateException exc)
            {
                logger.Error(exc, string.Format("{0}.Exception:{1}", actionName, $"{exc.Message} <---->ErrorCause: {exc.ErrorCause}"));
                return ActionResult<T>.Failure(exc.Message);
            }
            catch (Exception exc)
            {
                logger.Error(exc, string.Format("{0}.Exception:{1}", actionName, exc.Message));
                return ActionResult<T>.Failure("Problem Occured");
            }
            finally
            {

            }
        }
        public ActionResult Invoke(Action action, string actionName = null, bool useTransaction = false, params object[] args)
        {
            var result = Invoke<object>(() =>
            {
                action.Invoke();
                return null;
            }, actionName, useTransaction);

            if (result.IsSucceed)
                return ActionResult.Succeed();
            else
                return ActionResult.Failure(result.ExceptionMessage);

        }



        private T TransactionInvoker<T>(Func<T> function)
        {
            using (var scope = new TransactionScope())
            {

                T result = (T)function.Invoke();

                scope.Complete();

                return result;
            }

        }

       


    }
}
