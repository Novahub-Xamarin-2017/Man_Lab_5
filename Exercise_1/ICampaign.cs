using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;

namespace Exercise_1
{
    public interface ICampaign
    {
        [Post("campaigns")]
        RestResponse<object> CreateCampaign([Body] object campaignObject);

        [Put("campaigns/{campaignId}/content")]
        RestResponse<object> SetCampaignContent([Path("campaignId")] string campainId, [Body] object contentOnject);

        [Post("campaigns/{campaignId}/actions/send")]
        RestResponse<object> SendEmail([Path("campaignId")] string campaignId);
    }
}
