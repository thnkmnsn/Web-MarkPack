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
    public class PackingListModel : PageModel
    {
        private readonly ViewPackingListServices _viewPackingList;
        public PackingListModel(ViewPackingListServices viewPackingList)
        {
            _viewPackingList = viewPackingList;
        }
        public List<ViewPackingList> viewPackingList { get; set; }
        public void OnGet()
        {
            viewPackingList = _viewPackingList.LoadData().Take(1000).ToList();
        }
    }
}
