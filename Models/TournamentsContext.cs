using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.MVCCoreWeb.Models
{
    public class TournamentsContext:DbContext
    {


        public TournamentsContext(DbContextOptions<TournamentsContext> options) : base(options)

        {


        }

        public DbSet<Tournaments> tournment { get; set; }
      
    }
}
