using MarkPackReport.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Http;
using System.Linq;
namespace MarkPackReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewPackingListController : Controller
    {
        private readonly ViewPackingListServices _services;
        public ViewPackingListController(ViewPackingListServices services)
        {
            _services = services;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _services.LoadData();
            return Ok(data);
        }

        [HttpGet("Balance")]
        public IActionResult GetBalance()
        {
            var data = _services.GetDataforBalance();
            return Ok(data);
        }
    }
}
