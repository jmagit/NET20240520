using System;
using System.Collections;
using System.Collections.Generic;

namespace Cursos.Juegos;
/// <summary>
/// Representa al Tablero del juego como contenedor de piezas.
/// </summary>
[Serializable()]
public class Tablero : ICloneable, IEnumerable<KeyValuePair<Posicion, Pieza>> {
#if VERSION_1 // Versión: 1.0

        /// <summary>
        /// Matriz de 8x8 posiciones, que representa al tablero y permite almacenar las piezas del juego.
        /// </summary>
        private Pieza[,] piezas = new Pieza[8, 8];

        /// <summary>
        /// Obtiene o establece la pieza del tablero indicada por la fila y la columna.
        /// </summary>
        /// <param name="fila">Fila de la posición en el tablero.</param>
        /// <param name="columna">Columna de la posición en el tablero.</param>
        /// <value>Pieza en el tablero, nulo en caso de que no haya pieza.</value>
        /// <exception cref="IndexOutOfRangeException">Posición fuera del tablero.</exception>
        [System.Runtime.CompilerServices.IndexerName("Escaque")]
        public Pieza? this[int fila, int columna] {
            get {
                if(!EsValido(fila) || !EsValido(columna))
                    throw new IndexOutOfRangeException("Posición fuera del tablero.");
                return piezas[fila - 1, columna - 1];
            }
            set {
                if(!EsValido(fila) || !EsValido(columna))
                    throw new IndexOutOfRangeException("Posición fuera del tablero.");
                piezas[fila - 1, columna - 1] = value;
            }
        }
        /// <summary>
        /// Obtiene o establece la pieza del tablero indicada por la posición.
        /// </summary>
        /// <param name="p">Posición en el tablero.</param>
        /// <value>Pieza en el tablero, nulo en caso de que no haya pieza.</value>
        [System.Runtime.CompilerServices.IndexerName("Escaque")]
        public Pieza? this[Posicion p] {
            get {
                return this[p.Fila, p.Columna];
            }
            set {
                this[p.Fila, p.Columna] = value;
            }
        }

    public IEnumerator<KeyValuePair<Posicion, Pieza>> GetEnumerator() {
        for(int f = 1; f <= 8; f++)
            for(int c = 1; c <= 8; c++)
                if(this[f, c] != null)
                    yield return new KeyValuePair<Posicion, Pieza>(new Posicion(f, c), this[f, c]);
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

#else // Versión: 2.0

    /// <summary>
    /// Diccionario indexado por posiciones, que representa al tablero y permite almacenar las piezas del juego.
    /// </summary>
    private Dictionary<Posicion, Pieza> piezas = new Dictionary<Posicion, Pieza>(32);

    /// <summary>
    /// Obtiene o establece la pieza del tablero indicada por la fila y la columna.
    /// </summary>
    /// <param name="fila">Fila de la posición en el tablero.</param>
    /// <param name="columna">Columna de la posición en el tablero.</param>
    /// <value>Pieza en el tablero, nulo en caso de que no haya pieza.</value>
    /// <exception cref="IndexOutOfRangeException">Posición fuera del tablero.</exception>
    [System.Runtime.CompilerServices.IndexerName("Escaque")]
    public Pieza? this[int fila, int columna] {
        get {
            if (!EsValido(fila) || !EsValido(columna))
                throw new IndexOutOfRangeException("Posición fuera del tablero.");
            return this[new Posicion(fila, columna)];
        }
        set {
            if (!EsValido(fila) || !EsValido(columna))
                throw new IndexOutOfRangeException("Posición fuera del tablero.");
            this[new Posicion(fila, columna)] = value;
        }
    }
    /// <summary>
    /// Obtiene o establece la pieza del tablero indicada por la posición.
    /// </summary>
    /// <param name="p">Posición en el tablero.</param>
    /// <value>Pieza en el tablero, nulo en caso de que no haya pieza.</value>
    [System.Runtime.CompilerServices.IndexerName("Escaque")]
    public Pieza? this[Posicion p] {
        get => piezas.TryGetValue(p, out Pieza? pieza) ? pieza : null;
        set {
            if(!piezas.TryAdd(p, value))
                if(value == null)
                    piezas.Remove(p);
                else
                    piezas[p] = value;
        }
    }

    public IEnumerator<KeyValuePair<Posicion, Pieza>> GetEnumerator() {
        return piezas.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
#endif

    /// <summary>
    /// Verifica que la fila o columna se encuentra dentro del
    /// tablero. Valor entre 1 y 8.
    /// </summary>
    /// <param name="indice">Valor a verificar</param>
    /// <returns>true si es valido</returns>
    private static bool EsValido(int indice) {
        return indice is (>0 and <= 8);
    }
    /// <summary>
    /// Muestra si hay una pieza ocupando una posición del tablero indicada por la fila y la columna.
    /// </summary>
    /// <param name="fila">Fila de la posición en el tablero.</param>
    /// <param name="columna">Columna de la posición en el tablero.</param>
    /// <returns>Es true si hay pieza en el tablero; en caso contrario, es false.</returns>
    public bool HayPieza(int fila, int columna) {
        return this[fila, columna] != null;
    }

    /// <summary>
    /// Muestra si hay una pieza ocupando una posición del tablero.
    /// </summary>
    /// <param name="p">Posición en el tablero.</param>
    /// <returns>Es true si hay pieza en el tablero; en caso contrario, es false.</returns>
    public bool HayPieza(Posicion p) {
        return HayPieza(p.Fila, p.Columna);
    }

    /// <summary>
    /// Quita la pieza que ocupa la posición del tablero indicada por la fila y la columna.
    /// </summary>
    /// <param name="fila">Fila de la posición en el tablero.</param>
    /// <param name="columna">Columna de la posición en el tablero.</param>
    public void QuitaPieza(int fila, int columna) {
        if(this[fila, columna] is IDisposable)
            (this[fila, columna] as IDisposable).Dispose();
        this[fila, columna] = null;
    }

    /// <summary>
    /// Indica si hay piezas en el tablero entre la posición inicial y la posición final indicada por el movimiento, sin incluir dichas posiciones.
    /// </summary>
    /// <param name="m">Movimiento a verificar.</param>
    /// <returns>Es true si hay piezas en la trayectoria; en caso contrario, es false.</returns>
    /// <exception cref="JuegoException">Genera la excepción si el movimiento no es horizontal, vertical o diagonal.</exception>
    public bool HayPiezaEntre(Movimiento m) {
        if(!m.EsDiagonal && !m.EsHorizontal && !m.EsVertical)
            throw new JuegoException("El movimiento debe ser horizontal, vertical o diagonal para verificar si hay piezas entre la posición inicial y la posición final.");
        int deltaColumna = m.DeltaColumna;
        int deltaFila = m.DeltaFila;
        Posicion pos = new Posicion(m.PosicionInicial.Fila + deltaFila,
            m.PosicionInicial.Columna + deltaColumna);
        for(; pos != m.PosicionFinal; pos = new Posicion(pos.Fila + deltaFila, pos.Columna + deltaColumna))
            if(HayPieza(pos)) return true;
        return false;
    }

    /// <summary>
    /// Quita la pieza que ocupa la posición del tablero indicada por la fila y la columna.
    /// </summary>
    /// <param name="p">Posición en el tablero.</param>
    public void QuitaPieza(Posicion p) {
        QuitaPieza(p.Fila, p.Columna);
    }

    /// <summary>
    /// Mueve la pieza del tablero desde la posición inicial a la posición final indicada por el movimiento.
    /// </summary>
    /// <param name="m">Movimiento a realizar.</param>
    public void Mover(Movimiento m) {
        if(!HayPieza(m.PosicionInicial))
            throw new JuegoException("No hay pieza para mover.");
        if(HayPieza(m.PosicionFinal))
            QuitaPieza(m.PosicionFinal);
        this[m.PosicionFinal] = this[m.PosicionInicial];
        this[m.PosicionInicial] = null;
    }

    /// <summary>
    /// Realiza una copia del tablero.
    /// </summary>
    /// <returns>Tablero copiado.</returns>
    public object Clone() {
        Tablero t = new Tablero();
        for(int i = 1; i <= 8; i++)
            for(int j = 1; j <= 8; j++)
                t[i, j] = this[i, j];
        // Mejor
        // t.piezas = (Pieza[,])this.piezas.Clone();
        // Mal
        // t.piezas = this.piezas;

        return t;
        // Copia superficial 
        // return this.MemberwiseClone();
    }

    /// <summary>
    /// Método de clase para informar al interfaz gráfico 
    /// de que color es el escaque. 
    /// </summary>
    /// <param name="fila">Fila de la posición en el tablero.</param>
    /// <param name="columna">Columna de la posición en el tablero.</param>
    /// <returns>Color del escaque.</returns>
    public static Color ColorEscaque(int fila, int columna) {
        return (fila + columna) % 2 == 0 ? Color.Negro : Color.Blanco;
    }
}
