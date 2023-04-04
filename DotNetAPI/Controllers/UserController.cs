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

	[HttpGet("GetUsers")]
	public IEnumerable<User> GetUsers()
	{
		string query = @"SELECT [UserId],
        [FirstName],
        [LastName],
        [Email],
        [Gender],
        [Active] 
      FROM TutorialAppSchema.Users";

		IEnumerable<User> users = _dapper.LoadData<User>(query);
		return users;
	}

	[HttpGet("GetSingleUser/{userId}")]
	public User GetSingleUser(int userId)
	{
		string query = @"SELECT [UserId],
        [FirstName],
        [LastName],
        [Email],
        [Gender],
        [Active] 
      FROM TutorialAppSchema.Users WHERE UserId = " + userId.ToString();

		System.Console.WriteLine(query);

		User user = _dapper.LoadDataSingle<User>(query);

		// if(user == null)
		// {
		// 	return "no user";
		// }
		return user;
	}

	[HttpPut("EditUser")]
	public IActionResult EditUser(User user)
	{
		string query = @"
      UPDATE TutorialAppSchema.Users
        SET [FirstName] = '" + user.FirstName +
				"', [LastName] = '" + user.LastName +
				"', [Email] = '" + user.Email +
				"', [Gender] = '" + user.Gender +
				"', [Active] = '" + user.Active +
				"' WHERE UserId = " + user.UserId;

    System.Console.WriteLine(query);

		if (_dapper.ExecuteSql(query))
		{
			return Ok();
		}

		throw new Exception("Failed to Update User");
	}

	[HttpPost("AddUser")]
	public IActionResult AddUser(User user)
	{
		string query = @"
      INSERT INTO TutorialAppSchema.Users(
          [FirstName],
          [LastName],
          [Email],
          [Gender],
          [Active]
      ) VALUES (" +
        "'" + user.FirstName +
				"', '" + user.LastName +
				"', '" + user.Email +
				"', '" + user.Gender +
				"', '" + user.Active +
				"')";

		System.Console.WriteLine(query);

		if (_dapper.ExecuteSql(query))
		{
			return Ok();
		}

		throw new Exception("Failed to Add User");
	}
}
