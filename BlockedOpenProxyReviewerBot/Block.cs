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
        uint ipb_user;
        uint ipb_by;
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
            Block b = null;
            try
            {

                b = new Block( );
                b.ipb_id = (int)( values[ 0 ] );
                b.ipb_address = Utility.Net.IPAddress.newFromEncodedString( (byte[ ])values[ 1 ] );
                b.ipb_user = (uint)values[ 2 ];
                b.ipb_by = (uint)values[ 3 ];
                b.ipb_reason = ASCIIEncoding.ASCII.GetString( (byte[ ])values[ 4 ] );

                //System.OverflowException was unhandled
                //Message="Value was either too large or too small for an Int32."
                //Source="mscorlib"
                //StackTrace:
                //     at System.Number.ParseInt32(String s, NumberStyles style, NumberFormatInfo info)
                //     at MySql.Data.Types.MySqlDateTime.ParseMySql(String s, Boolean is41)
                //     at MySql.Data.Types.MySqlDateTime.Parse(String s)
                //     at MySql.Data.Types.MySqlDateTime..ctor(String s)
                //     at BlockedOpenProxyReviewerBot.Block.newFromDataRow(Object[] values) in C:\Users\stwalkerster\Documents\Visual Studio 2008\Projects\BlockedOpenProxyReviewerBot\BlockedOpenProxyReviewerBot\Block.cs:line 37
                //     at BlockedOpenProxyReviewerBot.Database.getProxyBlocks() in C:\Users\stwalkerster\Documents\Visual Studio 2008\Projects\BlockedOpenProxyReviewerBot\BlockedOpenProxyReviewerBot\Database.cs:line 44
                //     at BlockedOpenProxyReviewerBot.Program.runBot() in C:\Users\stwalkerster\Documents\Visual Studio 2008\Projects\BlockedOpenProxyReviewerBot\BlockedOpenProxyReviewerBot\Program.cs:line 37
                //     at BlockedOpenProxyReviewerBot.Program..ctor(String[] args) in C:\Users\stwalkerster\Documents\Visual Studio 2008\Projects\BlockedOpenProxyReviewerBot\BlockedOpenProxyReviewerBot\Program.cs:line 24
                //     at BlockedOpenProxyReviewerBot.Program.Main(String[] args) in C:\Users\stwalkerster\Documents\Visual Studio 2008\Projects\BlockedOpenProxyReviewerBot\BlockedOpenProxyReviewerBot\Program.cs:line 12
                //     at System.AppDomain._nExecuteAssembly(Assembly assembly, String[] args)
                //     at Microsoft.VisualStudio.HostingProcess.HostProc.RunUsersAssembly()
                //     at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state)
                //     at System.Threading.ThreadHelper.ThreadStart()
                //InnerException: 

                byte[ ] x = (byte[ ])values[ 5 ];
                string y = ASCIIEncoding.ASCII.GetString( x );
                MySql.Data.Types.MySqlDateTime z = new MySql.Data.Types.MySqlDateTime(
                    int.Parse( y.Substring( 0, 4 ) ),
                    int.Parse( y.Substring( 4, 2 ) ),
                    int.Parse( y.Substring( 6, 2 ) ),
                    int.Parse( y.Substring( 8, 2 ) ),
                    int.Parse( y.Substring( 10, 2 ) ),
                    int.Parse( y.Substring( 12, 2 ) )
                    );
                b.ipb_timestamp = z.GetDateTime( );

                //  b.ipb_timestamp = new MySql.Data.Types.MySqlDateTime( ASCIIEncoding.ASCII.GetString( (byte[ ])values[ 5 ] ) ).GetDateTime( );


                b.ipb_auto = (bool)values[ 6 ];
                b.ipb_anon_only = (bool)values[ 7 ];
                b.ipb_create_account = (bool)values[ 8 ];
                b.ipb_expiry = ASCIIEncoding.ASCII.GetString( (byte[ ])values[ 9 ] );
                if( ( (byte[ ])values[ 10 ] ).Length == 4 )
                {
                    b.ipb_range_start = new IPAddress( (byte[ ])values[ 10 ] );
                }
                if( ( (byte[ ])values[ 11 ] ).Length == 4 )
                {
                    b.ipb_range_end = new IPAddress( (byte[ ])values[ 11 ] );
                }
                b.ipb_enable_autoblock = (bool)values[ 12 ];
                b.ipb_deleted = (bool)values[ 13 ];
                b.ipb_block_email = (bool)values[ 14 ];
                b.ipb_by_text = ASCIIEncoding.ASCII.GetString( (byte[ ])values[ 15 ] );
            }
            catch( OverflowException )
            {
            }
            return b;
        }

        private Block( )
        {

        }

        public int ID
        {
            get
            {
                return ipb_id;
            }
        }
        public IPAddress IP
        {
            get
            {
                return ipb_address;
            }
        }
        public DateTime Date
        {
            get
            {
                return ipb_timestamp;
            }
        }
        public string Expiry
        {
            get
            {
                return ipb_expiry;
            }
        }
        public string By 
        {
            get
            {
                return ipb_by_text;
            }
        }
        public override string ToString( )
        {
            return ipb_address.ToString( );
        }
    }
}