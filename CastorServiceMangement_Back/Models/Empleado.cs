using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CastorServiceMangement_Back.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public long Cedula { get; set; }

    public string Nombre { get; set; } = null!;

    public byte[]? Foto { get; set; }

    public DateOnly FechaIngreso { get; set; }

    public string? IdCargo { get; set; }

    [JsonIgnore]
    public virtual Cargo? IdCargoNavigation { get; set; }
}
