using Microsoft.AspNetCore.Mvc;
using usermgmt.Data;

[ApiController]
[Route("[controller]")]

public class UserMgmtController : ControllerBase
{
    private readonly IUserMgmtRepository _usermgmtRepository;

    public UserMgmtController(IUserMgmtRepository usermgmtRepository)
    {
        _usermgmtRepository = usermgmtRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var usermgmts = await _usermgmtRepository.GetAllUserMgmtsAsync();
        return Ok(usermgmts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var usermgmt = await _usermgmtRepository.GetUserMgmtByIdAsync(id);
        if (usermgmt == null)
        {
            return NotFound();
        }
        return Ok(usermgmt);
    }
    [HttpPost]
    public async Task<IActionResult> Post(UserMgmt usermgmt)
    {
        await _usermgmtRepository.AddUserMgmtAsync(usermgmt);
        return CreatedAtAction(nameof(Get), new { id = usermgmt.Id }, usermgmt);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UserMgmt usermgmt)
    {
        if (id != usermgmt.Id)
        {
            return BadRequest();
        }

        await _usermgmtRepository.UpdateUserMgmtAsync(usermgmt);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _usermgmtRepository.DeleteUserMgmtAsync(id);
        return NoContent();
    }
}