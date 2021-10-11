using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConteoYRecaudo.Model.Models
{
    public class Report
    {

        public List<ReportGeneralGroupBy> reportGeneralGroupBies { get; set; }
        public List<ReportTotals> reportTotals { get; set; }

    }
}
