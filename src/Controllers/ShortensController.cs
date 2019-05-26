using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using UrlShortener.Web.Services;

namespace UrlShortener.Web.Controllers
{
    /// <summary>
    /// Simple REST API controller that shows Autofac injecting dependencies.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("")]
    public class ShortensController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly IShortensService _shortensService;

        public ShortensController(IConfiguration configuration, IShortensService shortensService)
        {
            _configuration = configuration;
            this._shortensService = shortensService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return this._shortensService.FindAll();
        }


        [HttpGet("{code}")]
        public IActionResult Go(string code)
        {
            var url = _shortensService.Find(code);
            return Redirect(url);
        }
    }
}
