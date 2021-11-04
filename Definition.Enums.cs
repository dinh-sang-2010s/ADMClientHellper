using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMCrawlHelper
{
    public enum ErrorLevel
    {
        Debug = 0
        , Info
        , Warn
        , Error
        , Fatal
    }

    public enum DataType
    {
        AccountAvatar = 0,
        GroupAvatar = 2,
        MessageAttachment = 1
    }
}
