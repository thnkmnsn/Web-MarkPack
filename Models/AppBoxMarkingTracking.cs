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
    public class AppBoxMarkingTracking
    {
        public int ID { get; set; }
        public string MFG { get; set; }
        public string BoxNo { get; set; }
        public string SubBoxNo { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int LabelQty { get; set; }
        public int InputQty { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
