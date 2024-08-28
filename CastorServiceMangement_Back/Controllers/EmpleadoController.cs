using CastorServiceMangement_Back.Dtos;
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


    [HttpPost("createEmpleado")]
    public IActionResult createEmpleado([FromBody] EmpleadoDTO newEmpleado)
    {
        empleadoService.createEmpleado(newEmpleado);
        return Ok();
    }


    [HttpPut("{empleadoId}")]
    public IActionResult Put(int empleadoId, [FromBody] Empleado empleadoToUpdate)
    {
        empleadoService.updateEmpleado(empleadoId, empleadoToUpdate);
        return Ok();
    }

    [HttpDelete("{empleadoId}")]
    public IActionResult Delete(int empleadoId)
    {
        empleadoService.deleteEmpleado(empleadoId);
        return Ok();
    }



}