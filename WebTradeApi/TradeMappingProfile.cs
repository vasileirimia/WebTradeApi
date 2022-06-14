using AutoMapper;
using WebTradeApi.Models;
using WebTradeApi.Persistece.Entities;

namespace WebTradeApi
{
    public class TradeMappingProfile : Profile
    {
        public TradeMappingProfile()
        {
            CreateMap<TradeDb, Trade>().ForMember(t => t.TradeId, opt => opt.Ignore()).ReverseMap();
            CreateMap<PortofolioDb, Portofolio>().ForMember(t => t.PortofolioId, opt => opt.Ignore()).ReverseMap();
            CreateMap<Market, MarketDb>();
        }
    }
}
