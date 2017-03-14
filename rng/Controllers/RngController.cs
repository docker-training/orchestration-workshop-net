using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;

namespace rng.Controllers
{
    [Route("")]
    public class RngController : Controller
    {
        // GET api/rng
        [HttpGet]
        public string Get()
        {
            var envVars = Environment.GetEnvironmentVariables();
            var host = Environment.GetEnvironmentVariable("COMPUTERNAME");
            return host;
        }

        // GET api/rng/5
        [HttpGet("{howManyBytes}")]
        public byte[] Get(int howManyBytes)
        {
            Thread.Sleep(100);  // simulate a little bit of delay
            var generator = System.Security.Cryptography.RandomNumberGenerator.Create();
            var bytes = new byte[howManyBytes];
            generator.GetBytes(bytes);
            return bytes;
        }
    }
}
