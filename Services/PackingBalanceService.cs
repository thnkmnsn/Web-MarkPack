using MarkPackReport.Models;
using MarkPackReport.Pages;
using System.Collections.Generic;
using System.Linq;

namespace MarkPackReport.Services
{
    public class PackingBalanceService
    {
        private readonly AppBoxmarkingTrackingServices markingService;
        private readonly ViewPackingListServices viewpackingService;

        public PackingBalanceService(AppBoxmarkingTrackingServices marking,ViewPackingListServices views)
        {
            markingService = marking;
            viewpackingService = views;
        }

        //public List<PackingBalance> GetBalance()
        //{
        //    var mData = markingService.LoadData();
        //    var pData = viewpackingService.LoadData();

        //    var result = (from m in mData
        //                  join p in pData
        //                  on new { m.MFG ,  });

        //    return result;
        //}

    }
}
