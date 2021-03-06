using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M223PunchclockBlazor.Poco.Entry
{
    public class Entry
    {
        public int id { get; set; }
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
        public Category category { get; set; }
        public Project project { get; set; }
    }
}
