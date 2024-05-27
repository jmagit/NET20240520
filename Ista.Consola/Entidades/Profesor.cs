using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Consola.Entidades; 

public enum SituacionLaboral { Activo = 1, DeBaja, Parado, Jubilado }

public partial class Profesor: Persona {
    public SituacionLaboral Situación { get; set; } = SituacionLaboral.Activo;

    public override void DebeSobreescribir() {
        throw new NotImplementedException();
    }

    partial void porSiAcaso() {
        // ...
    }
}

public class Factura {
    public enum Estado { Pendiente, Cancelada, Pagada }
    public Estado Situacion { get; set; } = Estado.Pendiente;
    public Pedido.Estado Situacion2 { get; set; } = Pedido.Estado.Pendiente;

}

public class Pedido {
    public enum Estado { Pendiente, Cancelado, Preparado }
    public Estado Situacion { get; set; } = Estado.Cancelado;
}
