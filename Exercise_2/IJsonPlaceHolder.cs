using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Retrofit.Net.Attributes.Methods;

namespace Exercise_2
{
    public interface IJsonPlaceHolder
    {
        [Get("/users")]
        RestResponse<List<User>> Get();
    }
}
