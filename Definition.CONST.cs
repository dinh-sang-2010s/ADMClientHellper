using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMCrawlHelper
{
    public static class Definition
    {
        public const string REQUEST_CRAWL_TOKEN = "api/v1/oauth/request_crawl_token";
        public const string GET_ATTACHMENTS = "api/v1/crawler/attachments";
        public const string UPDATE_ATTACHMENT_BY_ID = "api/v1/crawler/attachment/{id}";
        public const string UPDATE_ERROR_ATTACHMENT = "api/v1/crawler/attachment/{id}/error";
    }
}
