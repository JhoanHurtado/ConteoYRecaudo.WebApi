using ConteoYRecaudo.Data.Interface;
using ConteoYRecaudo.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConteoYRecaudo.Data.Repositorio
{
    public class RecaudoRepositorio : IRecaudoRepositorio
    {
        private readonly AppDbContext _dbContext = new AppDbContext();

        public Recaudos Add(List<Recaudos> recaudos)
        {
            var res = _dbContext.Recaudos.AddRange(recaudos);
            _dbContext.SaveChanges();
            return res.First();
        }

        public List<Recaudos> FindApi(DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<Recaudos> Get(int skip, int limit)
        {
            var Recaudos = _dbContext.Recaudos.OrderBy(x => x.Id).Skip(skip).Take(limit).ToList();
            return Recaudos;
        }

        public Report GetReport()
        {
            var reportP1 = _dbContext.Database.SqlQuery<ReportGeneralGroupBy>("SELECT Estacion,COUNT(ValorTabulado) as 'TotalCant', SUM(ValorTabulado)  as 'TotalValor', Fecha FROM Recaudos where DATEDIFF(MM, Fecha,  GETDATE()) <=3 Group By Fecha, Estacion").ToList();
            var reportP2 = _dbContext.Database.SqlQuery<ReportTotals>("SELECT  COUNT(Id) as 'TotalFCant', SUM(ValorTabulado) as 'TotalFValor' FROM Recaudos where DATEDIFF(MM, Fecha,  GETDATE()) <=3 Group By Estacion").ToList();

            var report = new Report();
            report.reportGeneralGroupBies = reportP1;
            report.reportTotals = reportP2;
            return report;
        }
    }
}
