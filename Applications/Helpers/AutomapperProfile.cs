using AutoMapper;
using ChessApp.Applications.Models;
using ChessApp.Applications.Models.DTOs;

namespace ChessApp.Applications.Helpers
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Match,LobbyMatchDTO>()
            .ForMember(mem => mem.HostUsername, opts => opts.MapFrom(src => src.Host.Player.Username))
            .ForMember(mem => mem.HostLoseCount, opts => opts.MapFrom(src => src.Host.Player.WinCount))
            .ForMember(mem => mem.HostDrawCount, opts => opts.MapFrom(src => src.Host.Player.DrawCount));
        }
    }
}