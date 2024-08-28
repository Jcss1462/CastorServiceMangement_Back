using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CastorServiceMangement_Back.Dtos;

public partial class EmpleadoDTO
{

    public long Cedula { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Foto { get; set; }

    public string? IdCargo { get; set; }
}
