namespace usermgmt.Data;
public class MockUserMgmtRepository : IUserMgmtRepository
{
    private readonly List<UserMgmt> _usermgmts;

    public MockUserMgmtRepository()
    {
        _usermgmts = new List<UserMgmt>() {
            new UserMgmt{Id= 1, Name= "John Doe", Email= "john.doe@flr.com"},
            new UserMgmt{Id = 2, Name = "Lisa Ray", Email = "lisa.ray@flr.com"},
        };
    }

    public async Task<IEnumerable<UserMgmt>> GetAllUserMgmtsAsync()
    {
        return await Task.FromResult(_usermgmts);
    }

    public async Task<UserMgmt> GetUserMgmtByIdAsync(int id)
    {
        return await Task.FromResult(_usermgmts.FirstOrDefault(p => p.Id == id));
    }

    public async Task AddUserMgmtAsync(UserMgmt usermgmt)
    {
        usermgmt.Id = _usermgmts.Max(p => p.Id) + 1;
        _usermgmts.Add(usermgmt);
        await Task.CompletedTask;
    }

    public async Task UpdateUserMgmtAsync(UserMgmt usermgmt)
    {
        var index = _usermgmts.FindIndex(p => p.Id == usermgmt.Id);
        _usermgmts[index] = usermgmt;
        await Task.CompletedTask;
    }

    public async Task DeleteUserMgmtAsync(int id)
    {
        var usermgmt = _usermgmts.FirstOrDefault(p => p.Id == id);
        _usermgmts.Remove(usermgmt);
        await Task.CompletedTask;
    }
}
