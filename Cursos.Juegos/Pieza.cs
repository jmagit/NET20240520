namespace Cursos.Juegos;

/// <summary>
/// Clase abstracta que representa las Piezas del Juego.
/// </summary>
[Serializable()]
public abstract class Pieza {
    /// <summary>
    /// Campo con el Color de la pieza
    /// </summary>
    private Color color;

    /// <summary>
    /// Constructor único de la pieza.
    /// </summary>
    /// <param name="color">Color de la pieza.</param>
    public Pieza(Color color) {
        this.color = color;
    }

    /// <summary>
    /// Obtiene el color de la pieza.
    /// </summary>
    /// <remarks>
    /// Permite a los herederos de pieza cambiar de color si
    /// la lógica de su juego lo necesita.
    /// </remarks>
    public Color Color {
        get {
            return color;
        }
        protected set {
            color = value;
        }
    }

    /// <summary>
    /// Abstracto. Indica si la pieza puede realizar el movimiento.
    /// </summary>
    /// <param name="m">Movimiento a verificar.</param>
    /// <param name="t">Tablero para verificar que no salta piezas.</param>
    /// <returns>Es true si la pieza puede realizar el movimiento; en caso contrario, genera una excepción.</returns>
    /// <exception cref="JuegoException">Genera la excepción con la razón por la que no puede realizar el movimiento.</exception>
    public abstract bool EsValido(Movimiento m, Tablero t);

    /// <summary>
    /// Reemplazable. Mueve la pieza en el tablero.
    /// </summary>
    /// <param name="m">Movimiento a realizar.</param>
    /// <param name="t">Tablero para realizar el movimiento.</param>
    /// <exception cref="JuegoException">Genera la excepción con la razón por la que no puede realizar el movimiento.</exception>
    public virtual void Mover(Movimiento m, Tablero t) {
        if(EsValido(m, t))
            t.Mover(m);
    }

    public override string ToString() {
        return $"{GetType().Name} ({color.ToString()[0]})";
    }
}
