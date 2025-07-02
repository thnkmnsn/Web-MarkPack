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
    public class ViewPackingList
    {
        public string PackingNo { get; set; }
        public string SaleConfNo { get; set; }
        public int SOLineNo { get; set; }
        public string ConsigneeName { get; set; }
        public string CustomerPO { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal UnitWeightKg { get; set; }
        public int PackID { get; set; }
        public int PackQty { get; set; }
        public decimal NetWeightKg { get; set; }
        public string MFGNo { get; set; }
        public int ActualPackQty { get; set; }
        public DateTime OnlyDate { get; set; }
    }
}
