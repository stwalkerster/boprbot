using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
namespace BlockedOpenProxyReviewerBot
{
    class Blacklist
    {
        public Blacklist( IPAddress openProxyResult, string zoneSuffix )
        {
            result = openProxyResult;
            suffix = zoneSuffix;
        }

        IPAddress result;
        string suffix;
        

        

        public bool openProxy( IPAddress ip )
        {
            return true;
        }
    }
}
