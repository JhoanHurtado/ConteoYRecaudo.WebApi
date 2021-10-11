using ConteoYRecaudo.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConteoYRecaudo.Data.Interface
{
    public interface IRecaudoRepositorio
    {
        List<Recaudos> Get(int skip, int limit);
        List<Recaudos> FindApi(DateTime date);
        Recaudos Add(List<Recaudos> recaudos);
        Report GetReport();
    }
}
