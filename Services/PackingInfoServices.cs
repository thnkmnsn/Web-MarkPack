using MarkPackReport.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Data.SqlClient;

namespace MarkPackReport.Services
{
    public class PackingInfoServices
    {
        private readonly MyDbContext _context;
        public PackingInfoServices(MyDbContext context)
        {
            _context = context;
        }
        public List<PackingInfo> GetAllPackingInfo(DateTime fromDate)
        {
            var fromDateParam = new SqlParameter("@FromDate", fromDate);

            var result = _context.PackingInfo
                .FromSqlRaw("EXEC sp_GetPackingInfo @MFG=NULL, @ProductCode=NULL, @ProductName=NULL, @FromDate=@FromDate", fromDateParam)
                .ToList();

            return result;
        }
    }
}
