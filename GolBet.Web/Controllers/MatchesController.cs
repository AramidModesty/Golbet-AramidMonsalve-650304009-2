using GolBet.Entities.Enums;
using GolBet.Services.DTOs;
using GolBet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;   // SelectList
using Microsoft.AspNetCore.Authorization;
using GolBet.Repositories.Data;
namespace GolBet.Web.Controllers;


public class MatchesController(IMatchService matchService) : Controller
{
    private readonly IMatchService _matchService = matchService;

    // GET /Matches            -> all matches
    // GET /Matches?status=Scheduled -> filtered board
    public async Task<IActionResult> Index(MatchStatus? status, string? searchTeam)
    {
        ViewBag.CurrentStatus = status;
        ViewBag.SearchTeam = searchTeam;
        var board = await _matchService.GetBoardAsync(status, searchTeam);
        return View(board);
    }
    // GET /Matches/Detail/3
    public async Task<IActionResult> Detail(int id)
    {
        var match = await _matchService.GetDetailAsync(id);
        if (match is null) return NotFound();   // HTTP 404
 
        return View(match);
    }
    private readonly ITeamService? _teamService;
    /* After being a dummy, I realized each match already contains the teams
        it means I made a lot of unnecessary things to teams.
        Then I also saw the message of just putting the string on the index function.
        The deltatime guys are yelling at me, what do I do?
       I've got an idea, I'll just make another page
       Post methods should be called through post declared functions
        calling them without declaring will disallow it and cause error,
        better is not putting the method as post unless it saves something in the database.
    */
    public async Task<IActionResult> IndexByTeams(string? homeTeam,string? awayTeam)
    {
        ViewBag.homeTeam=homeTeam;
        ViewBag.awayTeam=awayTeam;
        var board = await _matchService.GetForTeamsAsync(homeTeam,awayTeam);
        return View(board);
    }
    // GET /Matches/Create    
    [Authorize(Roles = DbSeeder.AdminRole)]   // only Admins can create matches
    public async Task<IActionResult> Create()
    {
        await LoadTeamsAsync();
        return View(new MatchFormDto());
    }
    
    [HttpPost, ValidateAntiForgeryToken]
    
    [Authorize(Roles = DbSeeder.AdminRole)]   // only Admins can create matches
    public async Task<IActionResult> Create(MatchFormDto dto)
    {
        if (!ModelState.IsValid)
        {
            await LoadTeamsAsync();
            return View(dto);
        }
    
        try
        {
            await _matchService.CreateAsync(dto);
            TempData["Success"] = "Partido creado correctamente.";
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException ex)      // business rule violated
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            await LoadTeamsAsync();
            return View(dto);
        }
    }
    
    // GET /Matches/Edit/5  y  POST /Matches/Edit  siguen el mismo molde
    // (con GetForEditAsync y UpdateAsync);
    // POST /Matches/Deactivate/5 es idéntico al de Teams.

    private async Task LoadTeamsAsync()
    {
        var teams = await _teamService.GetAllAsync();
        ViewBag.Teams = new SelectList(teams, "Id", "Name");
    }
}
