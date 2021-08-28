using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyApiController : ControllerBase
    {
        private readonly IOptionsMonitor<Settings> _optionsMonitor;

        public MyApiController(IOptionsMonitor<Settings> optionsMonitor)
        {
            _optionsMonitor = optionsMonitor ?? throw new System.ArgumentNullException(nameof(optionsMonitor));
        }

        [HttpGet]
        public IActionResult Get()
        {
            string address = _optionsMonitor.CurrentValue.Address;
            Person p = new(1, "Jon Doe", address);
            return new JsonResult(p);
        }
    }
}
