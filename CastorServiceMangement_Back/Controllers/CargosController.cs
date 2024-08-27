using CastorServiceMangement_Back.Models;
using CastorServiceMangement_Back.Services;
using Microsoft.AspNetCore.Mvc;

namespace CastorServiceMangement_Back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CargosController : ControllerBase
{
    ICargoService cargoService;
   
    public CargosController(ICargoService service)
    {
        cargoService = service;
    }


    [HttpGet("GetAllCargos")]
    public IActionResult GetAllCargos()
    {
        List<Cargo> cargos = cargoService.getAllCargos();
        return Ok(cargos);
    }


}