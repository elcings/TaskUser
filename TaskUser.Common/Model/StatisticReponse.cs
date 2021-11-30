using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskUser.Common.Model
{
   public  class StatisticReponse
    {
        public StatisticReponse()
        {
            Year = new List<Data>();
            Month = new List<Data>();
            Day = new List<Data>();
        }
        public List<Data> Day { get; set; }
        public List<Data> Month { get; set; }
        public List<Data> Year { get; set; }
    }

    public class Data {
        public dynamic Period { get; set; }
        public int Value { get; set; }
    }
}
