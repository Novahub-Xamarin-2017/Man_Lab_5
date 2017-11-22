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
    public interface IList
    {
        [Post("lists")]
        RestResponse<object> CreateList([Body] object list);

        [Put("lists/{listId}/members/{hashedEmailAddress}")]
        RestResponse<object> AddEmailToList([Path("listId")] string listId, [Path("hashedEmailAddress")] string hashedEmailAddress, [Body] object emailObject);
    }
}
