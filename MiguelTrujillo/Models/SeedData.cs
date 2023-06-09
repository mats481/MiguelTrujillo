using Microsoft.EntityFrameworkCore;
using MiguelTrujillo.Data;

namespace MiguelTrujillo.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PlayerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PlayerContext>>()))
            {
                if (context.Player.Any())
                {
                    return;
                }
                context.Player.AddRange(
                    new Player
                    {
                        Name = "Miguel",
                        Country = "COP",
                        CleanAndJerkRecord = new List<RegisterCleanAndJerk> { new RegisterCleanAndJerk
                        {
                            Weight = 132
                        } },
                        SnatchRecord = new List<RegisterSnatch> { new RegisterSnatch
                        {
                            Weight = 128
                        } }
                    },
                    new Player
                    {
                        Name = "Angel",
                        Country = "CAD",
                        SnatchRecord = new List<RegisterSnatch> { new RegisterSnatch
                        {
                            Weight = 110
                        }
                        }
                    }
                    );
                context.SaveChanges();
            }
            
        }
    }
}
