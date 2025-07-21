using MarkPackReport.Models;
using MarkPackReport.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkPackReport.Pages
{
    public class PackingAndMarkingTrackingModel : PageModel
    {
        private readonly ViewPackingAndMarkingTrackingServices _service;
        public PackingAndMarkingTrackingModel(ViewPackingAndMarkingTrackingServices viewPackingAndNarkingTracking)
        {
            _service = viewPackingAndNarkingTracking;
        }
        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        [BindProperty(SupportsGet = true)]
        
        public string ProductName { get; set; }
        public List<ViewPackingAndMarkingTracking> viewPackingAndMarkingTrackings { get; set; }
        public async Task OnGetAsync()
        {
            var query = _service.LoadData();

            if (!string.IsNullOrEmpty(Search))
            {
                query = query.Where(x => x.MFG.Contains(Search)).ToList();
            }


            if (!string.IsNullOrEmpty(ProductName))
            {
                query = query.Where(x => x.ProductName.Contains(ProductName)).ToList();
            }

            viewPackingAndMarkingTrackings = query;
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
