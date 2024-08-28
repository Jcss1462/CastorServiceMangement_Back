using CastorServiceMangement_Back.Data;
using CastorServiceMangement_Back.Dtos;
using CastorServiceMangement_Back.Models;

namespace CastorServiceMangement_Back.Services;

public class EmpleadoService : IEmpleadoService
{
    CastorDbContext context;

    public EmpleadoService(CastorDbContext dbcontext)
    {
        context = dbcontext;
    }

    public void createEmpleado(EmpleadoDTO newEmpleadoDto)
    {

        //valido que no halla un empleado con la misma cedula
        bool existeEmpleadoConMismaCedula = context.Empleados
            .Any(e => e.Cedula == newEmpleadoDto.Cedula);

        if (existeEmpleadoConMismaCedula) {
            throw new Exception("Ya existe un empleado con cedula: " + newEmpleadoDto.Cedula);
        }


        //creo el empleado
        Empleado newEmpleado= new Empleado();
        newEmpleado.Cedula = newEmpleadoDto.Cedula;
        newEmpleado.Nombre = newEmpleadoDto.Nombre;
        newEmpleado.IdCargo = newEmpleadoDto.IdCargo;
        if (newEmpleadoDto.Foto!.Length>0) {
          newEmpleado.Foto = Convert.FromBase64String(newEmpleadoDto.Foto!.Split(",")[1]);
        }
        //coloco la fecha de creacion
        newEmpleado.FechaIngreso = DateOnly.FromDateTime(DateTime.Now);
        context.Empleados.Add(newEmpleado);
        context.SaveChanges();
    }

    public void deleteEmpleado(int empleadoId)
    {
        Empleado? empleadoActual = context.Empleados.Find(empleadoId);

        if (empleadoActual != null)
        {
            context.Remove(empleadoActual);
            context.SaveChanges();
        }
        else
        {
            throw new InvalidOperationException("El empleado no fue encontrado.");
        }
    }

    public Empleado getEmpleadoById(int empleadoId)
    {
        Empleado? empleadoActual = context.Empleados.Find(empleadoId);

        if (empleadoActual == null)
        {
            throw new InvalidOperationException("El empleado no fue encontrado.");
        }

        return empleadoActual;
    }

    public List<Empleado> gettAllEmpleados()
    {
        List<Empleado> empleados = context.Empleados.ToList();
        return empleados;
    }

    public void updateEmpleado(int empleadoId, EmpleadoDTO empleadoToUpdate)
    {
        Empleado? empleadoActual = context.Empleados.Find(empleadoId);

        if (empleadoActual != null)
        {
            empleadoActual.IdCargo = empleadoToUpdate.IdCargo;
            empleadoActual.Nombre = empleadoToUpdate.Nombre;
            if (empleadoToUpdate.Foto!.Length > 0)
            {
                empleadoActual.Foto = Convert.FromBase64String(empleadoToUpdate.Foto!.Split(",")[1]);
            }
            context.SaveChanges();
        }
        else
        {
            throw new InvalidOperationException("El empleado no fue encontrado.");
        }

    }
}





public interface IEmpleadoService
{
    void createEmpleado(EmpleadoDTO newEmpleadoDto);
    Empleado getEmpleadoById(int empleadoId);
    List<Empleado> gettAllEmpleados();
    void updateEmpleado(int empleadoId, EmpleadoDTO empleadoToUpdate);
    void deleteEmpleado(int empleadoId);
}