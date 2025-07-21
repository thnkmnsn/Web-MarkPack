using MarkPackReport.Models;
using MarkPackReport.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MarkPackReport.Pages
{
    public class PackingListModel : PageModel
    {
        private readonly ViewPackingListServices _viewPackingList;
        private readonly MyDbContext _context;
        public PackingListModel(ViewPackingListServices viewPackingList, MyDbContext context)
        {
            _viewPackingList = viewPackingList;
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string PackingNo { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PackID { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ProductName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string MFGNo { get; set; }

        public List<ViewPackingList> viewPackingList { get; set; }
        public void OnGetAsync()
        {
            var query = _viewPackingList.LoadData().ToList();

            if (!string.IsNullOrEmpty(PackingNo))
            {
                query = query.Where(x => x.PackingNo.Contains(PackingNo)).ToList();
            }

            if (!string.IsNullOrEmpty(PackID))
            {
                query = query.Where(x => x.PackID.ToString() == PackID
                  || x.PackID.ToString().StartsWith(PackID) && x.PackID.ToString().Length == PackID.Length + 1).ToList();
            }


            if (!string.IsNullOrEmpty(ProductName))
            {
                query = query.Where(x => x.ProductName.Contains(ProductName)).ToList();
            }

            if (!string.IsNullOrEmpty(MFGNo))
            {
                query = query.Where(x => x.MFGNo?.Contains(MFGNo) == true).ToList(); // << �Ӥѭ
            }

            viewPackingList = query;
        }
        public JsonResult OnGetSearchProductName(string term)
        {
            var data = _viewPackingList.LoadData()
                .Where(x => x.ProductName != null && x.ProductName.Contains(term))
                .Select(x => new { productName = x.ProductName })
                .Distinct()
                .Take(10)
                .ToList();

            return new JsonResult(data);
        }
    }
}



