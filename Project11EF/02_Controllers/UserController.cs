using Microsoft.AspNetCore.Mvc;
using Project11EF.API.Models;

namespace Project11EF.API.Controllers;

[ApiController]
[Route("User")]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userServiceFromBuilder)
    {
        userService = userServiceFromBuilder;
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostNewUser(string usernameFromFrontEnd, string userRoleFromFrontEnd)
    {
        try
        {
            User newUser = new User(usernameFromFrontEnd, userRoleFromFrontEnd);
            await userService.CreateNewUserAsync(newUser);

            return Ok(newUser);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }

    }

    [HttpGet]
    public async Task<ActionResult<User>> GetUserByUsername(string usernameToFindFromFrontEnd)
    {
        try
        {
            return await userService.GetUserByUsernameAsync(usernameToFindFromFrontEnd);

        }
        catch(Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete]
    public async Task<User> DeleteUserByUsername(string usernameToDeleteFromFrontEnd)
    {
        try
        {
            return await userService.DeleteUserByUsernameAsync(usernameToDeleteFromFrontEnd);
        }
        catch(Exception e)
        {
            return null;
        }
    }
}