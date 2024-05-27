using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Juegos.Ajedrez;

/// <summary>
/// Proporciona datos para los eventos de Promocion.
/// </summary>
public class PromocionEventArgs(Color Color) : EventArgs {
    /// <summary>
    /// Informa del color del peón a promocionar
    /// </summary>
    public Color Color { get; } = Color;
    /// <summary>
    /// Obtiene o establece la pieza a promocionar
    /// </summary>
    public Pieza Pieza { get; set; }
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
public interface ISustitutoDelPeon { }
