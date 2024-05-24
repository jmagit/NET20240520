using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Comunes.Juegos;

/// <summary>
/// Enumeración con los posibles colores de las piezas: Blanco y Negro.
/// </summary>
public enum Color {
    Blanco,
    Negro
}

/// <summary>
/// Clase que encapsula la fila y columna de una posición.
/// </summary>
public struct Posicion {
    /// <summary>
    /// Sobrecargado. Inicializa una nueva instancia de la clase Posicion con la fila y columna especificadas.
    /// </summary>
    /// <param name="fila">Fila de la posición.</param><param name="columna">Columna de la posición.</param>
    public Posicion(int fila, int columna) {
        if(fila is (< 1 or > 8)) throw new ArgumentOutOfRangeException(nameof(fila));
        if(columna < 1 || columna > 8) throw new ArgumentOutOfRangeException(nameof(columna));

        this.fila = fila;
        this.columna = columna;
    }

    /// <summary>
    /// Sobrecargado. Inicializa una nueva instancia de la clase Posicion con la fila y columna especificadas en formato caracter.
    /// </summary>
    /// <param name="fila">Fila de la posición.</param>
    /// <param name="columna">Columna de la posición.</param>
    public Posicion(char fila, char columna) {
        if(fila is (< '1' or > '8')) throw new ArgumentOutOfRangeException(nameof(fila));
        if(columna is (< 'A' or > 'H')) throw new ArgumentOutOfRangeException(nameof(columna));
        this.fila = int.Parse(fila.ToString());
        this.columna = columna - 'A' + 1;
    }


    /// <summary>
    /// Campo con la fila de la posición.
    /// </summary>
    private readonly int fila;
    /// <summary>
    /// Obtiene la fila de esta Posición.
    /// </summary>
    public readonly int Fila => fila;


    /// <summary>
    /// Campo con la columna de la posición.
    /// </summary>
    private readonly int columna;
    /// <summary>
    /// Obtiene la columna de esta Posición.
    /// </summary>
    public readonly int Columna => columna;

    /// <summary>
    /// Sobrecarga de operador. Permite comparar dos posiciones indicando si son iguales.
    /// </summary>
    /// <param name="p1">Primera posición</param>
    /// <param name="p2">Segunda posición</param>
    /// <returns>Verdadero si son iguales</returns>
    public static bool operator ==(Posicion p1, Posicion p2) {
        return p1.columna == p2.columna && p1.fila == p2.fila;
    }

    /// <summary>
    /// Sobrecarga de operador. Permite comparar dos posiciones indicando si son distintas.
    /// </summary>
    /// <param name="p1">Primera posición</param>
    /// <param name="p2">Segunda posición</param>
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

/// <summary>
///  Excepción que se inicia cuando no se cumplen las reglas del juego. 
/// </summary>
public class JuegoException : Exception {
    /// <summary>
    ///  Inicializa una nueva instancia de la clase Ajedrez.JuegoException con un mensaje de error especificado.
    /// </summary>
    /// <param name="msg">Mensaje que describe el error.</param>
    public JuegoException(String msg) : base(msg) { }
}

