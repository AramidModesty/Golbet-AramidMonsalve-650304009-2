// Profile, where the mapping is declared
// scans proyect in startup
// and finds profiles and adds them to the configuration
using AutoMapper;
using GolBet.Entities;
using GolBet.Services.DTOs;
 
namespace GolBet.Services.Mapping;
 
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Flattening by convention:
        // MatchDto.HomeTeamName  <- Match.HomeTeam.Name
        // MatchDto.AwayTeamCrestUrl <- Match.AwayTeam.CrestUrl
        CreateMap<Match, MatchDto>();

        // MatchDetailDto inherits from MatchDto, so we only need to add the extra property
        CreateMap<Match, MatchDetailDto>()
            .ForMember(dto => dto.TotalBets,
               options => options.MapFrom(match => match.Bets.Count));
       
        CreateMap<Team, TeamDto>();
        // ReverseMap() allows mapping in both directions
        CreateMap<TeamFormDto, Team>().ReverseMap();
        CreateMap<MatchFormDto, Match>().ReverseMap();
    }
}