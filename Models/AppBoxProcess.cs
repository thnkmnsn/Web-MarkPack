using Microsoft.VisualBasic;
using System;

namespace MarkPackReport.Models
{
    public class AppBoxProcess
    {
        public int ID { get; set; }
        public string ProcessRelated { get; set; }
        public string BoxStart { get; set; }
        public string BoxEnd { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
