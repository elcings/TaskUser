using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskUser.Common.Model;

namespace TaskUser.Sdk
{
    public interface IUserLoginAttempApi
    {
        [Post("/api/UserLoginAttempt/statistic")]
        Task<StatisticReponse> GetStatistic(StatisticRequest request, [Header("ApiKey")] string key);
    }
}
