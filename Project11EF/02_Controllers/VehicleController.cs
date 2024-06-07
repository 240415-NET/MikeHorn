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

    /** Create **************************************************************************/
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

    //Store Truck
     [HttpPost("/Vehicle/Truck")]
    public async Task<ActionResult<Truck>> PostNewTruck(Truck newTruckfromFrontEnd)
    {
        try
        {
            Truck newTruck = new Truck(newTruckfromFrontEnd.PolicyId, newTruckfromFrontEnd.year, newTruckfromFrontEnd.make, newTruckfromFrontEnd.model, newTruckfromFrontEnd.VehicleStatus, newTruckfromFrontEnd.NumberWheels, newTruckfromFrontEnd.TruckType);
            await vehicleService.CreateNewTruckAsync(newTruck);

            return Ok(newTruck);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }

    }

    /** Get All **************************************************************************/
    //Cars
    [HttpGet("/Vehicle/Car")]
    public List<Vehicle> GetAllVehicles()
    {
        return vehicleService.GetAllVehicles();
    }

    //Trucks
    [HttpGet("/Vehicle/Truck")]
    public List<Truck> GetAllTrucks()
    {
        return vehicleService.GetAllTrucks();
    }
    /** Get by VehicleId **************************************************************************/
    //Cars
    [HttpGet("/Vehicle/Car/{VehicleId}")]
    public async Task<Vehicle?> GetVehicleById(Guid VehicleId)
    {
        return await vehicleService.GetVehicleByIdAsync(VehicleId);
    }

    /** Update **************************************************************************/
    //Car
    [HttpPut("/Vehicle/Car")]
    public async Task<Vehicle> UpdateVehicle(Vehicle vehicleToUpdateFromFrontEnd)
    {
        return await vehicleService.UpdateVehicleAsync(vehicleToUpdateFromFrontEnd);
    }
}