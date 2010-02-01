using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockedOpenProxyReviewerBot
{
    struct BlackListCheckResult
    {
        public int blackListCount;
        public Block blockInfo;

        public BlackListCheckResult(int x, Block b )
        {
            blackListCount = x;
            blockInfo = b;
        }
    }
}
