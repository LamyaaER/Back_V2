using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppQuizz.Data;
using AppQuizz.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppQuizz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuizsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Quizs
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var quizs = _context.Quizs.Include(q => q.Agent).Include(q => q.Candidate).Include(q => q.Technology);
            return View(await quizs.ToListAsync());
        }

        // GET: api/Quizs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quizs
                .Include(q => q.Agent)
                .Include(q => q.Candidate)
                .Include(q => q.Technology)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        // POST: api/Quizs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,CreatedAt,Url,AgentId,CandidateId,TechnologyId")] Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quiz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgentId"] = new SelectList(_context.Agents, "Id", "Name", quiz.AgentId);
            ViewData["CandidateId"] = new SelectList(_context.Candidates, "Id", "Name", quiz.CandidateId);
            ViewData["TechnologyId"] = new SelectList(_context.Technologies, "Id", "Name", quiz.TechnologyId);
            return View(quiz);
        }

        // PUT: api/Quizs/Edit/5
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,CreatedAt,Url,AgentId,CandidateId,TechnologyId")] Quiz quiz)
        {
            if (id != quiz.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quiz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizExists(quiz.Id))
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
            ViewData["AgentId"] = new SelectList(_context.Agents, "Id", "Name", quiz.AgentId);
            ViewData["CandidateId"] = new SelectList(_context.Candidates, "Id", "Name", quiz.CandidateId);
            ViewData["TechnologyId"] = new SelectList(_context.Technologies, "Id", "Name", quiz.TechnologyId);
            return View(quiz);
        }

        // DELETE: api/Quizs/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quizs
                .Include(q => q.Agent)
                .Include(q => q.Candidate)
                .Include(q => q.Technology)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        // POST: api/Quizs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quiz = await _context.Quizs.FindAsync(id);
            _context.Quizs.Remove(quiz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuizExists(int id)
        {
            return _context.Quizs.Any(e => e.Id == id);
        }
    }
}
