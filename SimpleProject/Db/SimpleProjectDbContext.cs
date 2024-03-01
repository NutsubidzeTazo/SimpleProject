using Microsoft.EntityFrameworkCore;
using SimpleProject.Db.Entities;

namespace SimpleProject.Db;

public class SimpleProjectDbContext : DbContext
{
    public SimpleProjectDbContext(DbContextOptions<SimpleProjectDbContext> options) : base(options)
    {
        
    }
    public virtual DbSet<User> User { get; set; }
    public virtual DbSet<Bet> Bet { get; set; }
    public virtual DbSet<Event> Event{ get; set; }

}
