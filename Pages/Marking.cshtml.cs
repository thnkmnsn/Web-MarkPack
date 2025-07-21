using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarkPackReport.Models;
using MarkPackReport.Services;

namespace MarkPackReport.Pages
{
    public class MarkingModel : PageModel
    {
        private readonly AppBoxmarkingTrackingServices _service;

        public MarkingModel(AppBoxmarkingTrackingServices service)
        {
            _service = service;
        }
        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? StartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? EndDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ProductName { get; set; }
        public List<AppBoxMarkingTracking> AppBoxMarkingTracking { get; set; }

        public async Task OnGetAsync()
        {
            var query = _service.LoadData(); // สมมุติว่าเป็น List<AppBoxMarkingTracking>

            if (!string.IsNullOrEmpty(Search))
            {
                query = query.Where(x => x.MFG.Contains(Search)).ToList();
            }

            if (StartDate.HasValue && EndDate.HasValue)
            {
                query = query.Where(x =>
                    x.CreatedDate.Date >= StartDate.Value.Date &&
                    x.CreatedDate.Date <= EndDate.Value.Date).ToList();
            }

            if (!string.IsNullOrEmpty(ProductName))
            {
                query = query.Where(x => x.ProductName.Contains(ProductName)).ToList();
            }

            AppBoxMarkingTracking = query;
        }

        public JsonResult OnGetSearchProductName(string term)
        {
            var data = _service.LoadData()
                .Where(x => x.ProductName != null && x.ProductName.Contains(term))
                .Select(x => new { productName = x.ProductName })
                .Distinct()
                .Take(10)
                .ToList();

            return new JsonResult(data);
        }
    }
}