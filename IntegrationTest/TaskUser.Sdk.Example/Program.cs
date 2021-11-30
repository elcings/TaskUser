using Newtonsoft.Json;
using Refit;
using System;
using System.Threading.Tasks;

namespace TaskUser.Sdk.Example
{
    class Program
    {
        static async Task  Main(string[] args)
        {
            var apikey = string.Empty;
            var userApi = RestService.For<IUserApi>("https://localhost:44330");
            var statistic = RestService.For<IUserLoginAttempApi>("https://localhost:44330");
            apikey = "_5gdeWa1hgUtbC11LmNzXds!";
            var userResult = await userApi.GetByEmail("99Email@gmail.com", apikey);
            var loginAttempStatistic = await statistic.GetStatistic(new Common.Model.StatisticRequest {Startdate=DateTime.Now,EndDate=null }, apikey);

            Console.WriteLine($"{ userResult.Email}-{ userResult.Name}");
            Console.WriteLine($"{ JsonConvert.SerializeObject(loginAttempStatistic)}");





            Console.ReadLine();
        }
    }
}
