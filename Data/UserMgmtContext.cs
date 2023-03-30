using Microsoft.EntityFrameworkCore;

namespace usermgmt.Data;
public class UserMgmtContext : DbContext
{
    public UserMgmtContext(DbContextOptions<UserMgmtContext> options) : base(options)
    {
    }

    public DbSet<UserMgmt> UserMgmts { get; set; }
}
