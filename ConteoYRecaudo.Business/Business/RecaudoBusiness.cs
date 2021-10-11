using AutoMapper;
using ConteoYRecaudo.Business.Profiles;
using ConteoYRecaudo.Data.Interface;
using ConteoYRecaudo.Data.Repositorio;
using ConteoYRecaudo.Dto.Dto;
using ConteoYRecaudo.Model.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConteoYRecaudo.Business.Business
{
    public class RecaudoBusiness
    {
        private readonly IRecaudoRepositorio _recaodoRepositorio = new RecaudoRepositorio();

        private readonly MapperConfiguration config = new MapperConfiguration(m => m.AddProfile(new AppProfile()));
        

        public Recaudos Add(List<RecaudosDto> recaudos, string date)
        {
            var mapper = new Mapper(config);
            var ListRecaudos = mapper.Map<List<Recaudos>>(recaudos);
            for (int i = 0 ; i < ListRecaudos.Count; i++)
            {
                ListRecaudos[i].Fecha = DateTime.ParseExact(date, "yyyy-MM-dd", new CultureInfo("es-CO", true));
            }
            return _recaodoRepositorio.Add(ListRecaudos);
        }

        public List<RecaudosDto> Get(int skip, int limit)
        {
            var mapper = new Mapper(config);
            var ListRecaudos = mapper.Map<List<RecaudosDto>>(_recaodoRepositorio.Get(skip, limit));
            return ListRecaudos;
        }

        public ReportDto Reporte()
        {
            var mapper = new Mapper(config);
            var reporteM = _recaodoRepositorio.GetReport();
            var reporte = mapper.Map<ReportDto>(reporteM);
            for (int i = 0; i < reporte.reportGeneralGroupBies.Count; i++)
            {
                if (reporte.reportGeneralGroupBies[i].Estacion.Equals(reporteM.reportGeneralGroupBies[i].Estacion))
                {
                    var lista = new ListaEstacionData();

                    if (i - 1 >= 0 && reporte.reportGeneralGroupBies[i - 1].Estacion.Equals(reporteM.reportGeneralGroupBies[i].Estacion))
                    {

                        lista.TotalCant = reporteM.reportGeneralGroupBies[i].TotalCant;
                        lista.TotalValor = reporteM.reportGeneralGroupBies[i].TotalValor;
                        lista.Fecha = reporteM.reportGeneralGroupBies[i].Fecha;
                        reporte.reportGeneralGroupBies[i - 1].DataProperties.Add(lista);
                        reporte.reportGeneralGroupBies.Remove(reporte.reportGeneralGroupBies[i]);
                        reporteM.reportGeneralGroupBies.Remove(reporteM.reportGeneralGroupBies[i]);
                        i--;
                    }
                    else
                    {
                        lista.TotalCant = reporteM.reportGeneralGroupBies[i].TotalCant;
                        lista.TotalValor = reporteM.reportGeneralGroupBies[i].TotalValor;
                        lista.Fecha = reporteM.reportGeneralGroupBies[i].Fecha;
                        reporte.reportGeneralGroupBies[i].DataProperties.Add(lista);
                    }
                
 
                }
            }

            return reporte;
        }
    }
}

