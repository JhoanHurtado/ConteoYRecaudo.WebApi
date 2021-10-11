using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConteoYRecaudo.Dto.Dto
{
    public class ReportTotalsDto
    {
        public int TotalFCant { get; set; }
        public Decimal TotalFValor { get; set; }
    }
}
