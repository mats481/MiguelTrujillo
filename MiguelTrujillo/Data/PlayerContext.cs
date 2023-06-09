using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiguelTrujillo.Models;

namespace MiguelTrujillo.Data
{
    public class PlayerContext : DbContext
    {
        public PlayerContext (DbContextOptions<PlayerContext> options)
            : base(options)
        {
        }

        public DbSet<MiguelTrujillo.Models.Player> Player { get; set; } = default!;
        public DbSet<MiguelTrujillo.Models.RegisterSnatch> RegisterSnatches { get; set; } = default!;
        public DbSet<MiguelTrujillo.Models.RegisterCleanAndJerk> RegisterCleanAndJerks { get; set; } = default!;
    }
}
