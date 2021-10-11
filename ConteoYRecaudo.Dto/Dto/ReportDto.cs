using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConteoYRecaudo.Dto.Dto
{
    public class ReportDto
    {
        public List<ReportGeneralGroupByDto> reportGeneralGroupBies { get; set; }
        public List<ReportTotalsDto> reportTotals { get; set; }
    }
}
