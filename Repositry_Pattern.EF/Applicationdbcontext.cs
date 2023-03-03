using Microsoft.EntityFrameworkCore;
using Repositry_Pattern.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositry_Pattern.EF
{
    public class Applicationdbcontext:DbContext
    {
        public Applicationdbcontext( DbContextOptions<Applicationdbcontext>options):base(options)
        {

        }

        public DbSet<Author> authors { set; get; }
        public DbSet<book> books { set; get; }
    }
}
