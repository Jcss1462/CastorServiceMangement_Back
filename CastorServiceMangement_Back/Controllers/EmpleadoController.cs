using CastorServiceMangement_Back.Models;
using CastorServiceMangement_Back.Services;
using Microsoft.AspNetCore.Mvc;

namespace CastorServiceMangement_Back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpleadoController : ControllerBase
{
    IEmpleadoService empleadoService;
   
    public EmpleadoController(IEmpleadoService service)
    {
        empleadoService = service;
    }

  

    [HttpGet("GettAllEmpleados")]
    public IActionResult GettAllEmpleados()
    {
        List<Empleado> empleados = empleadoService.gettAllEmpleados();
        return Ok(empleados);
    }


}