using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarkPackReport.Models;


namespace MarkPackReport.Models
{
    public class ViewPackingAndMarkingTracking
    {
        public string MFG { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string PackingNos { get; set; }
        public string PackIDs { get; set; }
        public int? TotalInputQty { get; set; }
        public int? TotalStock { get; set; } //add 2025-07-09 by art
        public int? ActualPackQty { get; set; }
        public int? RemainQty { get; set; }
    }
}
