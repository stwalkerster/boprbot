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
            b.ipb_address = Utility.Net.IPAddress.newFromEncodedString( (byte[ ])values[ 1 ] );
            b.ipb_user = (int)values[ 2 ];
            b.ipb_by = (int)values[ 3 ];
            b.ipb_reason = ASCIIEncoding.ASCII.GetString( (byte[ ])values[ 4 ] );
            b.ipb_timestamp = new MySql.Data.Types.MySqlDateTime( ASCIIEncoding.ASCII.GetString( (byte[ ])values[ 5 ] ) ).GetDateTime( );
            b.ipb_auto = ( (int)values[ 6 ] ) == 1 ? true : false;
            b.ipb_anon_only = ( (int)values[ 7 ] ) == 1 ? true : false;
            b.ipb_create_account = ( (int)values[ 8 ] ) == 1 ? true : false;
            b.ipb_expiry = ASCIIEncoding.ASCII.GetString( (byte[ ])values[ 9 ] );
            b.ipb_range_start = Utility.Net.IPAddress.newFromEncodedString( (byte[ ])values[ 10 ] );
            b.ipb_range_end = Utility.Net.IPAddress.newFromEncodedString( (byte[ ])values[ 11 ] );
            b.ipb_enable_autoblock = ( (int)values[ 12 ] ) == 1 ? true : false;
            b.ipb_deleted = ( (int)values[ 13 ] ) == 1 ? true : false;
            b.ipb_block_email = ( (int)values[ 14 ] ) == 1 ? true : false;
            b.ipb_by_text = ASCIIEncoding.ASCII.GetString( (byte[ ])values[ 15 ] );

            return b;
        }

        private Block( )
        {

        }

    }
}