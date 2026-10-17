// GolBet.Repositories/Interfaces/IMatchRepository.cs
using GolBet.Entities;
using GolBet.Entities.Enums;
 
namespace GolBet.Repositories.Interfaces;
 
public interface IMatchRepository : IGenericRepository<Match>
{
    Task<IEnumerable<Match>> GetAllWithTeamsAsync(MatchStatus? status = null, string? team=null);
    Task<Match?> GetByIdWithDetailsAsync(int id);
    Task<IEnumerable<Match>> GetForTeamsAsync(string? homeTeam, string? awayTeam);
}
