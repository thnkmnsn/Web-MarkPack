using MarkPackReport.Models;
using System.Collections.Generic;
using System.Linq;
namespace MarkPackReport.Services
{
    public class AppBoxmarkingTrackingServices
    {
        private readonly MyDbContext _context;
        public AppBoxmarkingTrackingServices(MyDbContext context)
        {
            _context = context;
        }


        //Load data table 2025-06-27
        public List<AppBoxMarkingTracking> LoadData()
        {
            var result = _context.AppBoxMarkingTracking
                .AsEnumerable()
                .GroupBy(x => new
                {
                    x.MFG,
                    x.ProductName,
                    OnlyDate = x.CreatedDate.Date
                })
                .Select(g => new AppBoxMarkingTracking
                {
                    MFG = g.Key.MFG,
                    ProductName = g.Key.ProductName,
                    CreatedDate = g.Key.OnlyDate,
                    InputQty = g.Sum(x=> x.InputQty)
                }).ToList();
            return result;
        }

        //Load data table for balance add 2025-06-30
        public List<AppBoxMarkingTracking> GetDataforbalance()
        {
            var result = _context.AppBoxMarkingTracking
                .AsEnumerable()
                .GroupBy(x => new
                {
                    x.MFG,
                    x.ProductCode,
                    x.ProductName
                })
                .Select(g => new AppBoxMarkingTracking
                {
                    MFG = g.Key.MFG,
                    ProductCode = g.Key.ProductCode,
                    ProductName = g.Key.ProductName,
                    InputQty = g.Sum (x=> x.InputQty)
                }).ToList();
            return result;
        }

    }
}
