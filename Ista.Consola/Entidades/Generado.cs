using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Consola.Entidades;

public partial class Profesor : Persona {
    public void generado() {
        // ...
        porSiAcaso();
        // ...
    }

    partial void porSiAcaso();
}