using MarkPackReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace MarkPackReport.Services
{
    public class ViewPackingAndMarkingTrackingServices
    {
        private readonly MyDbContext _context;
        public ViewPackingAndMarkingTrackingServices(MyDbContext context)
        {
            _context = context;
        }
        public List<ViewPackingAndMarkingTracking> LoadData()
        {
            var result = (from p in _context.ViewPackingAndMarkingTracking
                        select new ViewPackingAndMarkingTracking
                        {
                            MFG = p.MFG,
                            ProductCode = p.ProductCode,
                            ProductName = p.ProductName,
                            TotalInputQty = p.TotalInputQty ?? 0,
                            ActualPackQty = p.ActualPackQty ?? 0,
                            PackingNos = p.PackingNos,
                            PackIDs = p.PackIDs,
                            RemainQty = p.TotalInputQty - p.ActualPackQty ?? 0,
                        }).ToList();
            return result;
        }
    }
}
