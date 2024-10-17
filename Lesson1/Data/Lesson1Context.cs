using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lesson1.Models;

namespace Lesson1.Data
{
    public class Lesson1Context : DbContext
    {
        public Lesson1Context (DbContextOptions<Lesson1Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Lesson1.Models.Teacher> Teacher { get; set; } = default!;
    }
}
