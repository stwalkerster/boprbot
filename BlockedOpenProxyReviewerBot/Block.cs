using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace BlockedOpenProxyReviewerBot
{
    class Block
    {
        int ipb_id;
        IPAddress ipb_address;
        int ipb_user;
        int ipb_by;
        string ipb_reason;
        DateTime ipb_timestamp;
        bool ipb_auto;
        bool ipb_anon_only;
        bool ipb_create_account;
        string ipb_expiry;
        IPAddress ipb_range_start;
        IPAddress ipb_range_end;
        bool ipb_enable_autoblock;
        bool ipb_deleted;
        bool ipb_block_email;
        string ipb_by_text;

        public static Block newFromDataRow( object[ ] values )
        {
            Block b = new Block( );
            b.ipb_id = (int)( values[ 0 ] );

            return b;
        }

        private Block( )
        {

        }

    }
}