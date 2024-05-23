using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using persona = Ista.Consola.Entidades;

namespace Ista.Consola.Infraestructura;

public class Direccion {
    public string IP { get; set; }
}

public class Servidor {
    public Direccion IP { get; set; }
    public persona.Direccion Ubicacion { get; set; }
    public Red Red { get; set; }
}

