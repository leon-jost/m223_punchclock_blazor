using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M223PunchclockBlazor.Poco.User
{
    public class PostUser
    {
        public string username { get; set; }
        public string password { get; set; }
        public PostRole role { get; set; }
    }

    public class PostRole
    {
        public int id { get; set; }
    }
}
