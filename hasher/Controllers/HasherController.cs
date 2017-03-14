using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;

namespace hasher.Controllers
{
    [Route("")]
    public class HasherController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return Environment.GetEnvironmentVariable("COMPUTERNAME");
        }

        [HttpPost("{value}")]
        public string Post(string value)
        {
            Thread.Sleep(100);
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var byteArray = sha1.ComputeHash(Convert.FromBase64String(value));
            var hash = Convert.ToBase64String(sha1.ComputeHash(byteArray));
            return hash;
        }
    }
}
