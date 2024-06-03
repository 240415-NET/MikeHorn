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
    public async Task<ActionResult<User>> PostNewUser(User userfromFrontEnd)
    {
        try
        {
            await userService.CreateNewUserAsync(userfromFrontEnd);

            return Ok(userfromFrontEnd);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }

    }

    [HttpGet]
    public async Task<ActionResult<User>> GetUserByUsername(User userToFindFromFrontEnd)
    {
        try
        {
            return await userService.GetUserByUsernameAsync(userToFindFromFrontEnd);

        }
        catch(Exception e)
        {
            return NotFound(e.Message);
        }
    }

}