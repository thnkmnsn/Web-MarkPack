using MarkPackReport.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Data.SqlClient;

namespace MarkPackReport.Services
{
    public class ViewPackingAndMarkingTrackingServices
    {
        private readonly MyDbContext _context;
        private readonly PackingInfoServices _packingInfoService;

        public ViewPackingAndMarkingTrackingServices(MyDbContext context, PackingInfoServices packingInfoService)
        {
            _context = context;
            _packingInfoService = packingInfoService;
        }
        public List<ViewPackingAndMarkingTracking> LoadData()
        {
            var fromDate = new DateTime(2025, 7, 1);

            var baseData = _context.ViewPackingAndMarkingTracking
                .Select(am => new ViewPackingAndMarkingTracking
                {
                    MFG = am.MFG,
                    ProductCode = am.ProductCode,
                    ProductName = am.ProductName,
                    TotalInputQty = am.TotalInputQty,
                    ActualPackQty = am.ActualPackQty ?? 0,
                    TotalStock = am.TotalStock ?? 0, // add 2025-07-09 by art                   
                })
                .ToList();

            var packingList = _packingInfoService.GetAllPackingInfo(fromDate)
                .Select(p => new PackingInfo
                {
                    MFG = p.MFG,
                    ProductCode = p.ProductCode,
                    ProductName = p.ProductName,

                    PackingNos = string.Join(", ",
                        p.PackingNos?
                            .Split(',', StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.Trim())
                            .Distinct() ?? Enumerable.Empty<string>()
                    ),

                    //PackIDs = string.Join(", ",
                    //    p.PackIDs?
                    //        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    //        .Select(x => x.Trim())
                    //        .Distinct() ?? Enumerable.Empty<string>()
                    //)
                })
                .ToList();

            var dict = packingList.ToDictionary(
                x => $"{x.MFG}_{x.ProductCode}_{x.ProductName}",
                x => x
            );

            foreach (var item in baseData)
            {
                var key = $"{item.MFG}_{item.ProductCode}_{item.ProductName}";
                if (dict.TryGetValue(key, out var info))
                {
                    item.PackingNos = info.PackingNos;
                    //item.PackIDs = info.PackIDs;
                }

                item.RemainQty = item.TotalInputQty - (item.ActualPackQty + item.TotalStock);
            }

            return baseData;
        }
    }
}
