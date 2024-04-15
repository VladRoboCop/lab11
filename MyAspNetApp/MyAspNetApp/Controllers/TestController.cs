using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private const string LogFilePath = "action_log.txt";
    private const string UsersFilePath = "unique_users.txt";

    [HttpGet("action1")]
    [LogActionFilter(LogFilePath)]
    [UniqueUsersActionFilter(UsersFilePath)]
    public IActionResult Action1()
    {
        return Ok("Action 1 executed.");
    }

    [HttpGet("action2")]
    [LogActionFilter(LogFilePath)]
    [UniqueUsersActionFilter(UsersFilePath)]
    public IActionResult Action2()
    {
        return Ok("Action 2 executed.");
    }
}
