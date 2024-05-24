﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Comunes.Juegos
{
    public class Pieza
    {

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
            if(fila is (<1 or >8)) throw new ArgumentOutOfRangeException(nameof(fila));
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
        private int fila;
        /// <summary>
        /// Obtiene la fila de esta Posición.
        /// </summary>
        public int Fila {
            get {
                return fila;
            }
        }


        /// <summary>
        /// Campo con la columna de la posición.
        /// </summary>
        private int columna;
        /// <summary>
        /// Obtiene la columna de esta Posición.
        /// </summary>
        public int Columna {
            get {
                return columna;
            }
        }

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


    public class Tablero
    {
        private Pieza[,] tablero = new Pieza[8, 8];
        //private Dictionary<(int fila, int columna), Pieza> tablero = new ();

        public Pieza this[int fila, int columna]
        {
            get
            {
                return tablero[fila - 1, columna - 1];
            }
            set
            {
                tablero[fila - 1, columna - 1] = value;
            }
        }
        public Pieza this[string notacion]
        {
            get
            {
                return tablero[0, 0];
            }
            set
            {
                tablero[0, 0] = value;
            }
        }
    }

    public class Ajedrez
    {
        private Tablero tablero;
        public Ajedrez()
        {
            tablero = new Tablero();
            tablero[1, 1] = new Pieza();
            tablero["2B"] = new Pieza();
            var p = tablero["2B"];
        }
    }
}
