using MarkPackReport.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Http;
using System.Linq;
namespace MarkPackReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewPackingAndMarkingTrackingController : Controller
    {
        private readonly ViewPackingAndMarkingTrackingServices _services;
        public ViewPackingAndMarkingTrackingController(ViewPackingAndMarkingTrackingServices services)
        {
            _services = services;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _services.LoadData();
            return Ok(data);
        }
    }
}
