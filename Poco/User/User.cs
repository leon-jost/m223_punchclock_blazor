using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M223PunchclockBlazor.Poco.User
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Role role { get; set; }
    }

    public class Role
    {
        public int id { get; set; }
        public string title { get; set; }
        public string keyword { get; set; }
    }
}
