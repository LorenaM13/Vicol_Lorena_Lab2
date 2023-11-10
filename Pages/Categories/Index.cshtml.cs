﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vicol_Lorena_Lab2.Data;
using Vicol_Lorena_Lab2.Models;
using Vicol_Lorena_Lab2.ViewModels;

namespace Vicol_Lorena_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Vicol_Lorena_Lab2.Data.Vicol_Lorena_Lab2Context _context;

        public IndexModel(Vicol_Lorena_Lab2.Data.Vicol_Lorena_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        /* public async Task OnGetAsync()
         {
             if (_context.Category != null)
             {
                 Category = await _context.Category.ToListAsync();
             }
         }*/

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(i => i.BookCategories)
            .ThenInclude(i => i.Book)
            .ThenInclude(c => c.Author)
            .OrderBy(i => i.CategoryName)
            .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                .Where(i => i.ID == id.Value).Single();
                CategoryData.BookCategories = category.BookCategories;
                ;
            }
        }
    }
}
