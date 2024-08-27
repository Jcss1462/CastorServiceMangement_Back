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

    public void createEmpleado(int cuentaId)
    {
        throw new NotImplementedException();
    }

    public void deleteEmpleado(int cuentaId)
    {
        throw new NotImplementedException();
    }

    public List<Empleado> gettAllEmpleados()
    {
        List<Empleado> empleados = context.Empleados.ToList();
        return empleados;
    }

    public void updateEmpleado(int cuentaId)
    {
        throw new NotImplementedException();
    }
}

public interface IEmpleadoService
{
    void createEmpleado(int cuentaId);

    List<Empleado> gettAllEmpleados();
    void updateEmpleado(int cuentaId);
    void deleteEmpleado(int cuentaId);
}