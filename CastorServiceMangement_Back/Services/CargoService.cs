using CastorServiceMangement_Back.Data;
using CastorServiceMangement_Back.Models;

namespace CastorServiceMangement_Back.Services;

public class CargoService : ICargoService
{
    CastorDbContext context;

    public CargoService(CastorDbContext dbcontext)
    {
        context = dbcontext;
    }

    public List<Cargo> getAllCargos()
    {
        List<Cargo> cargos = context.Cargos.ToList();
        return cargos;
    }
}

public interface ICargoService
{
    List<Cargo> getAllCargos();
}