using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMCrawlHelper
{
    class Program
    {
        private static CrawlerHelper _crawlerHelper;
        static void Main(string[] args)
        {
            _crawlerHelper = new CrawlerHelper("http://localhost:8080/","68c78ad9b22b4d1aa1c62682695309ef");
            var res = _crawlerHelper.GetAttachmentInfos();
        }
    }
}
