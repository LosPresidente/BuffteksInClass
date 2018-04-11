using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Buffteks.Models;

namespace Buffteks.Controllers
{
    public class BuffController : Controller
    {
        private readonly BuffteksContext _context;

        public BuffController(BuffteksContext context)
        {
            _context = context;
        }

        // GET: Movies
        

      public async Task<IActionResult> Index(string movieGenre, string searchString)
{
    // Use LINQ to get list of genres.
    IQueryable<string> genreQuery = from m in _context.Member
                                    orderby m.LastName
                                    select m.LastName;
    var buffs = from m in _context.Member
                 select m;
    if (!String.IsNullOrEmpty(searchString))
    {
        buffs = buffs.Where(s => s.LastName.Contains(searchString));
    }
    if (!String.IsNullOrEmpty(movieGenre))
    {
        buffs = buffs.Where(x => x.LastName == movieGenre);
    }
    var movieGenreVM = new BuffMemberViewModel();
    movieGenreVM.genres = new SelectList(await genreQuery.Distinct().ToListAsync());
    movieGenreVM.buffs = await buffs.ToListAsync();
    return View(movieGenreVM);
}

public async Task<IActionResult> Client(string buffie, string searchString)
{
    // Use LINQ to get list of genres.
    IQueryable<string> genreQuery = from m in _context.Client
                                    orderby m.ClientName
                                    select m.ClientName;
    var Clientbuffs = from m in _context.Client
                 select m;
    if (!String.IsNullOrEmpty(searchString))
    {
        Clientbuffs = Clientbuffs.Where(s => s.ClientName.Contains(searchString));
    }
    if (!String.IsNullOrEmpty(buffie))
    {
        Clientbuffs = Clientbuffs.Where(x => x.ClientName == buffie);
    }
    var buffieVM = new BuffMemberViewModel();
    buffieVM.Clientgenres = new SelectList(await genreQuery.Distinct().ToListAsync());
    buffieVM.Clientbuffs = await Clientbuffs.ToListAsync();
    return View(buffieVM);
}


    public async Task<IActionResult> Project(string projie, string searchString)
{
    IQueryable<string> genreQuery = from m in _context.Project
                                    orderby m.ProjectName
                                    select m.ProjectName;
                                    
    var Projectbuffs = from m in _context.Project
                 select m;
    if (!String.IsNullOrEmpty(searchString))
    {
        Projectbuffs = Projectbuffs.Where(s => s.ProjectName.Contains(searchString));
    }
    if (!String.IsNullOrEmpty(projie))
    {
        Projectbuffs = Projectbuffs.Where(x => x.ProjectName == projie);
    }
    var projieVM = new BuffMemberViewModel();
    projieVM.Projectgenres = new SelectList(await genreQuery.Distinct().ToListAsync());
    projieVM.Projectbuffs = await Projectbuffs.ToListAsync();
    return View(projieVM);
}

//here are the action methods for the CRUD options:
 /*
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ID,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (id != movie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.ID))
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
            return View(movie);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .SingleOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
*/
        private bool MovieExists(int id)
        {
            return _context.Member.Any(e => e.ID == id);
        }
    }
}