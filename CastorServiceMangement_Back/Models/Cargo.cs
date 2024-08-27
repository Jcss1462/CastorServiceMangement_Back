using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CastorServiceMangement_Back.Models;

public partial class Cargo
{
    public string IdCargo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
