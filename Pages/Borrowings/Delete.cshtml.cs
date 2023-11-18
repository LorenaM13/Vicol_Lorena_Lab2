using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vicol_Lorena_Lab2.Data;
using Vicol_Lorena_Lab2.Models;

namespace Vicol_Lorena_Lab2.Pages.Borrowings
{
    public class DeleteModel : PageModel
    {
        private readonly Vicol_Lorena_Lab2.Data.Vicol_Lorena_Lab2Context _context;

        public DeleteModel(Vicol_Lorena_Lab2.Data.Vicol_Lorena_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Borrowing == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowing.FirstOrDefaultAsync(m => m.ID == id);

            if (borrowing == null)
            {
                return NotFound();
            }
            
            Borrowing = borrowing;
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
            ViewData["BookID"] = new SelectList(_context.Book, "ID", "Title");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Borrowing == null)
            {
                return NotFound();
            }
            var borrowing = await _context.Borrowing.FindAsync(id);

            if (borrowing != null)
            {
                Borrowing = borrowing;
                _context.Borrowing.Remove(Borrowing);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
