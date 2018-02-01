using PipeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebPipeTest.API.Controllers
{
    public class ValuesController : ApiController
    {
        private const string PipeName = "WebPipeTest";
        private static StringPipeClient _client;

        static ValuesController()
        {
            _client = new StringPipeClient(PipeName);
            _client.ConnectAsync();
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IHttpActionResult> PutAsync([FromBody]string value)
        {
            await _client.WriteStringAsync(value);
            return this.Ok("Done.");
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(10);
        }
    }
}
