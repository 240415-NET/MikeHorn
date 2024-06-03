using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Project11EF.API.Models;
using Project11EF.API.Services;

namespace Project11EF.API.Controllers;

[ApiController]
[Route("User")]
public class UserContoller : ControllerBase
{
    private readonly IUserService userService;

    public UserContoller(IUserService userServiceFromBuilder)
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

}