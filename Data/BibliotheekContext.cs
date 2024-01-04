using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bibliotheek.Datamodels;

namespace Bibliotheek.Data
{
    public class BibliotheekContext : DbContext
    {
        public BibliotheekContext (DbContextOptions<BibliotheekContext> options)
            : base(options)
        {
        }

        public DbSet<Bibliotheek.Datamodels.Boek> Boek { get; set; } = default!;
    }
}
