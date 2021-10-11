using AutoMapper;
using ConteoYRecaudo.Dto.Dto;
using ConteoYRecaudo.Model.Models;

namespace ConteoYRecaudo.Business.Profiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            this.CreateMap<Recaudos, RecaudosDto>().ReverseMap();
            this.CreateMap<Report, ReportDto>().ReverseMap();
            this.CreateMap<ReportGeneralGroupBy, ReportGeneralGroupByDto>().ReverseMap();
            this.CreateMap<ReportTotals, ReportTotalsDto>().ReverseMap();
        }
    }
}