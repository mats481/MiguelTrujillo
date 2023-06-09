using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiguelTrujillo.Data;
using MiguelTrujillo.Models;

namespace MiguelTrujillo.Controllers
{
    public class PlayersController : Controller
    {
        private readonly PlayerContext _context;

        public PlayersController(PlayerContext context)
        {
            _context = context;
        }

        // GET: Players
        public async Task<IActionResult> Index()
        {
            var players = _context.Player
                .Include(p => p.SnatchRecord)
                .Include(p => p.CleanAndJerkRecord)
                .ToList();
            var playerViewModels = players.Select(player => new PlayerViewModel
            {
                Id = player.Id,
                Name = player.Name,
                Country = player.Country,
                SnatchRegister = player.SnatchRecord.OrderByDescending(r => r.Weight).FirstOrDefault()?.Weight,
                CleanAndJerkRecord = player.CleanAndJerkRecord.OrderByDescending(r => r.Weight).FirstOrDefault()?.Weight
            }).ToList();
            return Ok(playerViewModels);
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Player == null)
            {
                return NotFound();
            }

            var player = await _context.Player
                .FirstOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Country")] Player player, string kindof, int weight)
        {
            //if (ModelState.IsValid)
            //{
                _context.Player.Add(player);
                await _context.SaveChangesAsync();

                var savedPlayer = _context.Player.SingleOrDefault(p => p.Id == player.Id);
                if (kindof == "RegisterSnatch")
                {
                    var registerSnatch = new RegisterSnatch
                    {
                        PlayerId = savedPlayer.Id,
                        Weight = weight
                    };
                    _context.RegisterSnatches.Add(registerSnatch);
                }
                else if (kindof == "RegisterCleanAndJerk")
                {
                    var registerCleanAndJerk = new RegisterCleanAndJerk
                    {
                        PlayerId = savedPlayer.Id,
                        Weight = weight
                    };
                    _context.RegisterCleanAndJerks.Add(registerCleanAndJerk);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            return View(player);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Player == null)
            {
                return NotFound();
            }

            var player = await _context.Player.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Country")] Player player)
        {
            if (id != player.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Player == null)
            {
                return NotFound();
            }

            var player = await _context.Player
                .FirstOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Player == null)
            {
                return Problem("Entity set 'PlayerContext.Player'  is null.");
            }
            var player = await _context.Player.FindAsync(id);
            if (player != null)
            {
                _context.Player.Remove(player);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerExists(int id)
        {
          return (_context.Player?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
