using Microsoft.AspNetCore.Mvc;

namespace DotNetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
	DataContextDapper _dapper;
	public UserController(IConfiguration config)
    {
        _dapper = new DataContextDapper(config);
    }

    [HttpGet("Testing")]
    public DateTime Testing()
    {
		return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
	}

    [HttpGet("GetUsers/{testValue}")]
    public string[] GetUsers(string testValue)
    {
		return new string[] { "user1", "user2", testValue, "user4" };
	}
}
