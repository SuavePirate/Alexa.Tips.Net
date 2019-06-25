using AbstractingSamples.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractingSamples.Contexts
{
    public class SampleMessageDbContext : DbContext
    {
        public DbSet<SampleMessage> SampleMessages { get; set; }

        public SampleMessageDbContext(DbContextOptions options) : base(options)
        {
        }

        protected SampleMessageDbContext()
        {
        }

    }
}
