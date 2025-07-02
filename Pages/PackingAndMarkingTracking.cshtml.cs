using MarkPackReport.Models;
using MarkPackReport.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace MarkPackReport.Pages
{
    public class PackingAndMarkingTrackingModel : PageModel
    {
        private readonly ViewPackingAndMarkingTrackingServices _viewPackingAndMarkingTracking;
        public PackingAndMarkingTrackingModel(ViewPackingAndMarkingTrackingServices viewPackingAndNarkingTracking)
        {
            _viewPackingAndMarkingTracking = viewPackingAndNarkingTracking;
        }
        public List<ViewPackingAndMarkingTracking> viewPackingAndMarkingTrackings { get; set; }
        public void OnGet()
        {
            viewPackingAndMarkingTrackings = _viewPackingAndMarkingTracking.LoadData().ToList();
        }
    }
}
