using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;

namespace PROMVC5_Chapter4.Models
{
    public  class MyAsyncMethods
    {
        public async static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpMessage = await client.GetAsync("http://apress.com");

            //Other code here

            return httpMessage.Content.Headers.ContentLength;
        }
    }
}