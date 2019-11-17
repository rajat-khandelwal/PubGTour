using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asp.MVCCoreWeb.Models;
using Microsoft.AspNetCore.Identity;

namespace Asp.MVCCoreWeb.Controllers
{
    public class TournamentController : Controller
    {
        private readonly EmployeeContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;

        public TournamentController(EmployeeContext context, UserManager<ApplicationUser> _usermanager)
        {
            _context = context;
            this._usermanager = _usermanager;
        }

        // GET: Tournament
        public async Task<IActionResult> Index()
        {
            return View(await _context.tournment.ToListAsync());
        }

        // GET: Tournament/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournaments = await _context.tournment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tournaments == null)
            {
                return NotFound();
            }

            return View(tournaments);
        }

        // GET: Tournament/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tournament/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,title,Date_Time,type,Slots,fee,Prize,Details")] Tournaments tournaments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tournaments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tournaments);
        }

        // GET: Tournament/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournaments = await _context.tournment.FindAsync(id);
            if (tournaments == null)
            {
                return NotFound();
            }
            return View(tournaments);
        }

        // POST: Tournament/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Date_Time,type,Slots,fee,Prize,Details")] Tournaments tournaments)
        {
            if (id != tournaments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tournaments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TournamentsExists(tournaments.Id))
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
            return View(tournaments);
        }

        // GET: Tournament/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournaments = await _context.tournment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tournaments == null)
            {
                return NotFound();
            }

            return View(tournaments);
        }

        // POST: Tournament/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tournaments = await _context.tournment.FindAsync(id);
            _context.tournment.Remove(tournaments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TournamentsExists(long id)
        {
            return _context.tournment.Any(e => e.Id == id);
        }

        [HttpPost]
        public async Task<JsonResult> GetTournamentList(int skp)
        {
            try
            {
                var loggedin = await _usermanager.GetUserAsync(HttpContext.User);
                if (loggedin == null)
                {
                    loggedin = new ApplicationUser();
                    loggedin.Id = "0";
                }
                var dd = await _context.tournment.Select(m => new
                {
                    title = m.title,
                    date_Time = m.Date_Time.ToString("dddd, dd MMMM yyyy hh:mm tt 'IST'"),
                    fee = m.fee,
                    prize = m.Prize,
                    tourId = m.Id,
                    slots = m.Slots,
                    type = m.type,
                    Isjoined = _context.Payments.Any(p => p.UserId == loggedin.Id && p.TournamentID == m.Id && p.RESPCODE == "01"),
                    avail = _context.Payments.Where(p => p.TournamentID == m.Id && p.RESPCODE == "01").Count()

                }).Skip(skp).ToListAsync();
                return Json(dd);
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        public async Task<JsonResult> GetJoinedPlayers(long id)
        {

            var plyaerslist = (from tr in _context.tournment
                               join py in _context.Payments on tr.Id equals py.TournamentID
                               join usr in _context.Users on py.UserId equals usr.Id
                               where tr.Id == id
                               select new
                               {
                                   UserName = usr.PubG_UserName,
                                   Country = "India",

                               }).Take(10);

            return Json(plyaerslist);
        }
    }
}
