using Microsoft.AspNetCore.Mvc;
using Project11EF.API.Models;

namespace Project11EF.API.Controllers;

[ApiController]
[Route("Vehicle")]
public class VehicleContoller : ControllerBase
{
    private readonly IVehicleService vehicleService;

    public VehicleContoller(IVehicleService vehicleServiceFromBuilder)
    {
        vehicleService = vehicleServiceFromBuilder;
    }

    //Store Car
     [HttpPost("/Vehicle/Car")]
    public async Task<ActionResult<Vehicle>> PostNewVehicle(Vehicle newVehiclefromFrontEnd)
    {
        try
        {
            Vehicle newVehicle = new Vehicle(newVehiclefromFrontEnd.PolicyId, newVehiclefromFrontEnd.year, newVehiclefromFrontEnd.make, newVehiclefromFrontEnd.model);
            await vehicleService.CreateNewVehicleAsync(newVehicle);

            return Ok(newVehicle);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }

    }
}