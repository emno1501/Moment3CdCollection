using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Moment3CdCollection.Data;
using Moment3CdCollection.Models;

namespace Moment3CdCollection.Controllers
{
    public class LoansController : Controller
    {
        private readonly CdContext _context;

        public LoansController(CdContext context)
        {
            _context = context;
        }

        // GET: Loans
        public async Task<IActionResult> Index()
        {
            var cdContext = _context.Loan.Include(l => l.Cd).Include(l => l.User);
            return View(await cdContext.ToListAsync());
        }

        // GET: Loans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loan
                .Include(l => l.Cd)
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.LoanId == id);
            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        // GET: Loans/Create
        public IActionResult Create()
        {
            List<SelectListItem> cdLoanSelectlist = new List<SelectListItem>();
            var allCDs = _context.Cd.ToList();

            for (var i = 0; i < allCDs.Count; ++i)
            {
                var loanExists = _context.Loan.Where(l => l.CdId == allCDs[i].Id).ToList();
                if (loanExists.Count == 0)
                {
                    var cdWithID = _context.Cd.Single(cd => cd.Id == allCDs[i].Id);
                    cdLoanSelectlist.Add(new SelectListItem { Text = cdWithID.Title, Value = cdWithID.Id.ToString(), Disabled = false });
                }
            }

            ViewData["CdId"] = cdLoanSelectlist;
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "FullName");
            return View();
            
        }

        // POST: Loans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoanId,LoanDate,UserId,CdId")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            List<SelectListItem> cdLoanSelectlist = new List<SelectListItem>();
            var allCDs = _context.Cd.ToList();

            for (var i = 0; i < allCDs.Count; ++i)
            {
                var loanExists = _context.Loan.Where(l => l.CdId == allCDs[i].Id).ToList();
                if (loanExists.Count == 0)
                {
                    var cdWithID = _context.Cd.Single(cd => cd.Id == allCDs[i].Id);
                    cdLoanSelectlist.Add(new SelectListItem { Text = cdWithID.Title, Value = cdWithID.Id.ToString(), Disabled = false });
                }
            }

            ViewData["CdId"] = cdLoanSelectlist;
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "FullName", loan.UserId);
            return View(loan);
        }

        // GET: Loans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loan
                .Include(l => l.Cd)
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.LoanId == id);
            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        // POST: Loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loan = await _context.Loan.FindAsync(id);
            _context.Loan.Remove(loan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoanExists(int id)
        {
            return _context.Loan.Any(e => e.LoanId == id);
        }
    }
}
