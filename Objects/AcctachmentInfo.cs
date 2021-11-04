using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMCrawlHelper
{
    public class AttachmentInfo
    {
        public long ID { get; set; }

        public int ContentType { get; set; }

        public string Content { get; set; }

        public ErrorLevel ErrorLevel { get; set; }

        public int ErrorPosition { get; set; }

        public string Error { get; set; }

        public DataType AttachmentType { get; set; }
    }
}
