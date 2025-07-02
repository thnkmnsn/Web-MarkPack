using MarkPackReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
namespace MarkPackReport.Services
{
    public class ViewPackingListServices
    {
        private readonly MyDbContext _context;
        public ViewPackingListServices(MyDbContext context) 
        {
            _context = context;
        }

        public List<ViewPackingList> LoadData()
        {
            DateTime strDate = new DateTime(2025, 6, 27);
            var result = (from p in _context.ViewPaackingList
                          where p.OnlyDate >= strDate
                          select new ViewPackingList
                          {
                              PackingNo = p.PackingNo,
                              PackID = p.PackID,
                              ProductCode = p.ProductCode,
                              ProductName = p.ProductName,
                              MFGNo = p.MFGNo,
                              ConsigneeName = p.ConsigneeName,
                              CustomerPO = p.CustomerPO,
                              PackQty = p.PackQty,
                              ActualPackQty = p.ActualPackQty,
                          }).Take(300)
                          .ToList();
            return result;
        }

        public List<ViewPackingList> GetDataforBalance()
        {
            DateTime strDate = new DateTime(2025, 6, 27);
            var result = _context.ViewPaackingList
                .Where(x => x.MFGNo != null)
                .GroupBy(x => new
                {
                    x.MFGNo,
                    x.ProductCode,
                    x.ProductName,
                    x.OnlyDate,
                    x.PackingNo,
                    x.PackID
                })
                .Select(g => new ViewPackingList
                {
                    MFGNo = g.Key.MFGNo,
                    PackingNo = g.Key.PackingNo,
                    ProductCode = g.Key.ProductCode,
                    ProductName = g.Key.ProductName,
                    PackID = g.Key.PackID,
                    ActualPackQty = g.Sum(x => x.ActualPackQty),
                    OnlyDate = g.Key.OnlyDate
                })
                .OrderByDescending(x => x.PackingNo)
                .Take(100)
                .ToList();
            return result;
        }
    }
}
