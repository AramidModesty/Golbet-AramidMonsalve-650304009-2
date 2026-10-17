// GolBet.Repositories/Implementations/MatchRepository.cs
using GolBet.Entities;
using GolBet.Entities.Enums;
using GolBet.Repositories.Data;
using GolBet.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace GolBet.Repositories.Implementations;
 
public class MatchRepository : GenericRepository<Match>, IMatchRepository
{
    public MatchRepository(AppDbContext context) : base(context) { }
 
    public async Task<IEnumerable<Match>> GetAllWithTeamsAsync(MatchStatus? status = null, string? team = null)
    {
        var query = _dbSet
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .Where(m => m.IsActive)
            .AsNoTracking()
            .AsQueryable();
 
        if (status.HasValue)
            query = query.Where(m => m.Status == status.Value);
        if (!team.IsNullOrEmpty())
        {
            query = query.Where(m => 
                m.HomeTeam != null &&
                m.AwayTeam != null &&
                (m.HomeTeam.Name.ToLower().Contains(team!.ToLower()) ||
                m.AwayTeam.Name.ToLower().Contains(team!.ToLower()))
            );
        }
        return await query.OrderBy(m => m.Date).ToListAsync();
    }
    public async Task<IEnumerable<Match>> GetForTeamsAsync(string? homeTeam, string? awayTeam)
    {
        var query = _dbSet
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .Where(m => m.IsActive)
            .AsNoTracking()
            .AsQueryable();
        
        if (!homeTeam.IsNullOrEmpty())
        {
            // Change m.HomeTeam.ToString() to m.HomeTeam.Name (or whichever property holds the team's name)
            query = query.Where(m => 
                m.HomeTeam != null && 
                m.HomeTeam.Name.ToLower().Contains(homeTeam!.ToLower())
            );
        }
    
        if (!awayTeam.IsNullOrEmpty())
        {
            // Note: Removed "!query.IsNullOrEmpty()" because Queryable doesn't have IsNullOrEmpty() 
            // and it would cause a compilation error.
            query = query.Where(m => 
                m.AwayTeam != null && 
                m.AwayTeam.Name.ToLower().Contains(awayTeam!.ToLower())
            );
        }
        return await query.OrderBy(m => m.Date).ToListAsync();
    }

    public async Task<Match?> GetByIdWithDetailsAsync(int id)
        => await _dbSet
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .Include(m => m.Bets)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

}