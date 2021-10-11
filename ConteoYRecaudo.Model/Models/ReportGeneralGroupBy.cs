using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConteoYRecaudo.Model.Models
{
    public class ReportGeneralGroupBy
    {
        public string Estacion { get; set; }
        public int TotalCant { get; set; }
        public Decimal TotalValor { get; set; }
        public DateTime Fecha { get; set; }
    }
}
