﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vicol_Lorena_Lab2.Models;

namespace Vicol_Lorena_Lab2.Data
{
    public class Vicol_Lorena_Lab2Context : DbContext
    {
        public Vicol_Lorena_Lab2Context (DbContextOptions<Vicol_Lorena_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Vicol_Lorena_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Vicol_Lorena_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Vicol_Lorena_Lab2.Models.Author>? Author { get; set; }

        public DbSet<Vicol_Lorena_Lab2.Models.Category>? Category { get; set; }

        public DbSet<Vicol_Lorena_Lab2.Models.Member>? Member { get; set; }

        public DbSet<Vicol_Lorena_Lab2.Models.Borrowing>? Borrowing { get; set; }
    }
}
