using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace usermgmt.Data;
public class UserMgmtRepository : IUserMgmtRepository
{
    private readonly UserMgmtContext _context;

    public UserMgmtRepository(UserMgmtContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserMgmt>> GetAllUserMgmtsAsync()
    {
        return await _context.UserMgmts.ToListAsync();
    }


    public async Task<UserMgmt> GetUserMgmtByIdAsync(int id)
    {
        return await _context.UserMgmts.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddUserMgmtAsync(UserMgmt usermgmt)
    {
        _context.UserMgmts.Add(usermgmt);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUserMgmtAsync(UserMgmt usermgmt)
    {
        _context.Entry(usermgmt).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserMgmtAsync(int id)
    {
        var usermgmt = await _context.UserMgmts.FindAsync(id);
        _context.UserMgmts.Remove(usermgmt);
        await _context.SaveChangesAsync();
    }
}
