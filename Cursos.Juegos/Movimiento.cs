namespace Cursos.Juegos;

/// <summary>
/// Representa un movimiento del Ajedrez, desde una posici�n inicial hasta una posici�n final.
/// </summary>
public class Movimiento {
    /// <summary>
    /// Crea una nueva instancia de movimiento es funci�n a una cadena dada. La cadena debe representar un movimiento en notaci�n internacional. 
    /// </summary>
    /// <param name="cad">Cadena en formato "CFCF", donde C es la columna con valores: A-H; y F es la fila con valores: 1-8.</param>
    /// <exception cref="JuegoException">Genera la excepci�n si la cadena no est� en formato internacional o la posici�n inicial es igual a la posici�n final.</exception>
    public Movimiento(string cad) {
        cad = cad.ToUpper();

        if(!System.Text.RegularExpressions.Regex.IsMatch(cad, "^([A-H][1-8]){2}$"))
            throw new JuegoException("El movimiento no es correcto seg�n la notaci�n internacional.");
        else if(cad.Substring(0, 2) == cad.Substring(2, 2))
            throw new JuegoException("La posici�n inicial debe ser distinta de la posici�n final.");
        this.PosicionInicial = new Posicion(cad[1] - '0', cad[0] - 'A' + 1);
        this.PosicionFinal = new Posicion(cad[3], cad[2]);
    }

    /// <summary>
    /// Obtiene un valor que indica la posici�n inicial del movimiento.
    /// </summary>
    /// <value>Posici�n Inicial</value>
    public Posicion PosicionInicial { get; }

    /// <summary>
    /// Obtiene un valor que indica la posici�n final del movimiento.
    /// </summary>
    /// <value>Posici�n Final</value>
    public Posicion PosicionFinal { get; }

    /// <summary>
    /// Obtiene un valor que indica si el movimiento es vertical.
    /// </summary>
    /// <returns>Es true si el movimiento es vertical; en caso contrario, es false.</returns>
    public bool EsVertical => PosicionInicial.Columna == PosicionFinal.Columna;

    /// <summary>
    /// Obtiene un valor que indica si el movimiento es horizontal.
    /// </summary>
    /// <returns>Es true si el movimiento es horizontal; en caso contrario, es false.</returns>
    public bool EsHorizontal => PosicionInicial.Fila == PosicionFinal.Fila;

    /// <summary>
    /// Obtiene un valor que indica si el movimiento es diagonal.
    /// </summary>
    /// <returns>Es true si el movimiento es diagonal; en caso contrario, es false.</returns>
    public bool EsDiagonal => SaltoHorizontal == SaltoVertical;

    /// <summary>
    /// Obtiene un valor que indica cuantos escaques en vertical desde la posici�n inicial (fila) y la posici�n final (fila).
    /// </summary>
    /// <returns>Valor absoluto con el n�mero de escaques.</returns>
    public int SaltoVertical => Math.Abs(PosicionInicial.Fila - PosicionFinal.Fila);

    /// <summary>
    /// Obtiene un valor que indica cuantos escaques en horizontal desde la posici�n inicial (columna) y la posici�n final (columna).
    /// </summary>
    /// <returns>Valor absoluto con el n�mero de escaques.</returns>
    public int SaltoHorizontal => Math.Abs(PosicionInicial.Columna - PosicionFinal.Columna);

    /// <summary>
    /// Obtiene el valor que indica cuanto hay que ir incrementando la fila para que recorra todos los escaques entre la posici�n inicial y la posici�n final.
    /// </summary>
    /// <returns>Valores posibles:
    ///		-1	Fila inicial menor que Fila final.
    ///		0	Fila inicial igual a la Fila final.
    ///		+1	Fila inicial mayor que Fila final.
    /// </returns>
    public int DeltaFila {
        get {
            if(PosicionInicial.Fila == PosicionFinal.Fila)
                return 0;
            else if(PosicionInicial.Fila > PosicionFinal.Fila)
                return -1;
            else
                return 1;
        }
    }

    /// <summary>
    /// Obtiene el valor que indica cuanto hay que ir incrementando la columna para que recorra todos los escaques entre la posici�n inicial y la posici�n final.
    /// </summary>
    /// <returns>Valores posibles:
    ///		-1	Columna inicial menor que Columna final.
    ///		0	Columna inicial igual a la Columna final.
    ///		+1	Columna inicial mayor que Columna final.
    /// </returns>
    public int DeltaColumna => Math.Sign(PosicionFinal.Columna - PosicionInicial.Columna);
}

