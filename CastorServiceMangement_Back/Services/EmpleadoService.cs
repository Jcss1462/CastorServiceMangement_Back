using CastorServiceMangement_Back.Data;
using CastorServiceMangement_Back.Models;

namespace CastorServiceMangement_Back.Services;

public class EmpleadoService : IEmpleadoService
{
    CastorDbContext context;

    public EmpleadoService(CastorDbContext dbcontext)
    {
        context = dbcontext;
    }

    public void createEmpleado(Empleado newEmpleado)
    {
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

    public List<Empleado> gettAllEmpleados()
    {
        List<Empleado> empleados = context.Empleados.ToList();
        return empleados;
    }

    public void updateEmpleado(int empleadoId, Empleado empleadoToUpdate)
    {
        Empleado? empleadoActual = context.Empleados.Find(empleadoId);

        if (empleadoActual != null)
        {
            empleadoActual.Foto = empleadoToUpdate.Foto;
            empleadoActual.IdCargo = empleadoToUpdate.IdCargo;
            empleadoActual.Nombre = empleadoToUpdate.Nombre;
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
    void createEmpleado(Empleado newEmpleado);

    List<Empleado> gettAllEmpleados();
    void updateEmpleado(int empleadoId,Empleado empleadoToUpdate);
    void deleteEmpleado(int empleadoId);
}