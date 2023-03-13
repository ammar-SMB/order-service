
namespace usermgmt.Data;

public interface IUserMgmtRepository
{
    Task<IEnumerable<UserMgmt>> GetAllUserMgmtsAsync();
    Task<UserMgmt> GetUserMgmtByIdAsync(int id);
    Task AddUserMgmtAsync(UserMgmt usermgmt);
    Task UpdateUserMgmtAsync(UserMgmt usermgmt);
    Task DeleteUserMgmtAsync(int id);
}