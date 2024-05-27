using Ista.Comunes.Juegos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Comunes.Juegos.Ajedrez;

/// <summary>
/// Proporciona datos para los eventos de Promocion.
/// </summary>
public class PromocionEventArgs : EventArgs {
    /// <summary>
    /// Inicializa una nueva instancia de la clase PromocionEventArgs.
    /// </summary>
    /// <param name="pieza">Pieza a promocionar</param>
    public PromocionEventArgs(Pieza pieza) {
        this.pieza = pieza;
    }

    /// <summary>
    /// La pieza
    /// </summary>
    private Pieza pieza;

    /// <summary>
    /// Obtiene o establece la pieza a promocionar
    /// </summary>
    public Pieza Pieza {
        get {
            return pieza;
        }
        set {
            pieza = value;
        }
    }

}

/// <summary>
/// Representa el método que controlará el evento Promocion.
/// </summary>
public delegate void PromocionEventHandler(object sender, PromocionEventArgs e);

/// <summary>
/// Establece el evento Promocion para las piezas que requieren notificar la promoción
/// </summary>
public interface IPromocionable {
    /// <summary>
    /// Evento que solicita la pieza para promocionar
    /// </summary>
    event PromocionEventHandler Promocion;
}

/// <summary>
/// Indica si un tipo de pieza puede sustituir al peón en la promoción
/// </summary>
public interface ISiPuedeSustituirAlPeon { }

