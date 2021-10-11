using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConteoYRecaudo.Dto.Dto
{
    public class ReportGeneralGroupByDto
    {
        public string Estacion { get; set; }
        public List<ListaEstacionData> DataProperties = new List<ListaEstacionData>();
    }
}
