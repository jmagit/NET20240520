namespace Cursos.Juegos;

/// <summary>
/// Clase que encapsula la fila y columna de una posici�n en el tablero.
/// </summary>
public struct Posicion {
    /// <summary>
    /// Sobrecargado. Inicializa una nueva instancia de la clase Posicion con la fila y columna especificadas.
    /// </summary>
    /// <param name="fila">Fila de la posici�n.</param><param name="columna">Columna de la posici�n.</param>
    public Posicion(int fila, int columna) {
        if(fila is (< 1 or > 8)) throw new ArgumentOutOfRangeException(nameof(fila));
        if(columna < 1 || columna > 8) throw new ArgumentOutOfRangeException(nameof(columna));

        this.fila = fila;
        this.columna = columna;
    }

    /// <summary>
    /// Sobrecargado. Inicializa una nueva instancia de la clase Posicion con la fila y columna especificadas en formato caracter.
    /// </summary>
    /// <param name="fila">Fila de la posici�n.</param>
    /// <param name="columna">Columna de la posici�n.</param>
    public Posicion(char fila, char columna) {
        if(fila is (< '1' or > '8')) throw new ArgumentOutOfRangeException(nameof(fila));
        if(columna is (< 'A' or > 'H')) throw new ArgumentOutOfRangeException(nameof(columna));
        this.fila = int.Parse(fila.ToString());
        this.columna = columna - 'A' + 1;
    }


    /// <summary>
    /// Campo con la fila de la posici�n.
    /// </summary>
    private readonly int fila;
    /// <summary>
    /// Obtiene la fila de esta Posici�n.
    /// </summary>
    public readonly int Fila => fila;


    /// <summary>
    /// Campo con la columna de la posici�n.
    /// </summary>
    private readonly int columna;
    /// <summary>
    /// Obtiene la columna de esta Posici�n.
    /// </summary>
    public readonly int Columna => columna;

    /// <summary>
    /// Sobrecarga de operador. Permite comparar dos posiciones indicando si son iguales.
    /// </summary>
    /// <param name="p1">Primera posici�n</param>
    /// <param name="p2">Segunda posici�n</param>
    /// <returns>Verdadero si son iguales</returns>
    public static bool operator ==(Posicion p1, Posicion p2) {
        return p1.columna == p2.columna && p1.fila == p2.fila;
    }

    /// <summary>
    /// Sobrecarga de operador. Permite comparar dos posiciones indicando si son distintas.
    /// </summary>
    /// <param name="p1">Primera posici�n</param>
    /// <param name="p2">Segunda posici�n</param>
    /// <returns>Verdadero si son distintas</returns>
    public static bool operator !=(Posicion p1, Posicion p2) {
        return p1.columna != p2.columna || p1.fila != p2.fila;
    }

    /// <summary>
    /// Remplazo. 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode() {
        return base.GetHashCode();
    }

    /// <summary>
    /// Remplazo. 
    /// </summary>
    /// <returns></returns>
    public override bool Equals(object obj) {
        if(!(obj is Posicion))
            return false;
        else
            return this == (Posicion)obj;
    }
}
