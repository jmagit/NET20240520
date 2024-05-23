using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Comunes {
    public class Pieza {

    }
    public class Tablero {
        private Pieza[,] tablero = new Pieza[8, 8];
        //private Dictionary<(int fila, int columna), Pieza> tablero = new ();

        public Pieza this[int fila, int columna] {
            get {
                return tablero[fila - 1, columna - 1];
            }
            set {
                tablero[fila - 1, columna - 1] = value;
            }
        }
        public Pieza this[string notacion] {
            get {
                return tablero[0, 0];
            }
            set {
                tablero[0, 0] = value;
            }
        }
    }

    internal class Ajedrez {
        private Tablero tablero;
        public Ajedrez() {
            tablero = new Tablero();
            tablero[1, 1] = new Pieza();
            tablero["2B"] = new Pieza();
            var p = tablero["2B"];
        }
    }
}
