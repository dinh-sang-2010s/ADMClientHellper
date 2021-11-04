using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMCrawlHelper
{
    public class CrawlerHelper : BaseHelper
    {
        public CrawlerHelper(string url, string token) : base(url, token)
        {
        }

        public List<AttachmentInfo> GetAttachmentInfos()
        {
            return SendRequest<List<AttachmentInfo>>(Definition.GET_ATTACHMENTS
               , Method.GET
               , null
               , null
               );
        }

        public void UpdateAttachment(string attachmentID, byte[] data, DataType dataType, bool origID, string name, long size, string extension, int pos)
        {
            SendRequest<object>(Definition.UPDATE_ATTACHMENT_BY_ID
               , Method.POST
               , data
               , new List<Parameter>
               {
                   new Parameter{ Name = "id", Value = attachmentID, Type = ParameterType.UrlSegment },
                   new Parameter{ Name = "dataType", Value = dataType, Type = ParameterType.QueryString },
                   new Parameter{ Name = "origID", Value = origID, Type = ParameterType.QueryString },
                   new Parameter{ Name = "name", Value = name, Type = ParameterType.QueryString },
                   new Parameter{ Name = "size", Value = size, Type = ParameterType.QueryString },
                   new Parameter{ Name = "extension", Value = extension, Type = ParameterType.QueryString },
                   new Parameter{ Name = "pos", Value = pos, Type = ParameterType.QueryString },
               });
        }

        public void UpdateErrorAttachment(string attachmentID, object zz002, DataType dataType, bool origID)
        {
            SendRequest<List<object>>(Definition.UPDATE_ERROR_ATTACHMENT
              , Method.POST
              , zz002
              , new List<Parameter>
              {
                   new Parameter{ Name = "id", Value = attachmentID, Type = ParameterType.UrlSegment },
                   new Parameter{ Name = "dataType", Value = dataType, Type = ParameterType.QueryString },
                   new Parameter{ Name = "origID", Value = origID, Type = ParameterType.QueryString },
              });
        }
    }
}
