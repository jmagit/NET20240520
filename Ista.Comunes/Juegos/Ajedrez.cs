using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Comunes.Juegos {
    public class Pieza {
        private Color color;

        public Pieza(Color color) {
            this.color = color;
        }

        public Color Color => color;

        public virtual void Muevete(Posicion inicial, Posicion final) {
            Console.WriteLine($"{GetType().Name} Me muevo");
        }

    }


    public class Tablero {
        private Pieza[,] tablero = new Pieza[8, 8];
        //private Dictionary<(int fila, int columna), Pieza> tablero = new ();

        public Pieza? this[int fila, int columna] {
            get {
                return tablero[fila - 1, columna - 1];
            }
            set {
                tablero[fila - 1, columna - 1] = value;
            }
        }
        public Pieza this[string notacion] {
            get {
                if(tablero[0, 0] == null)
                    throw new JuegoException("No hay pieza");
                return tablero[0, 0];
            }
            set {
                tablero[0, 0] = value;
            }
        }
    }

    public class DemoAjedrez {
        private Tablero tablero;
        public DemoAjedrez() {
            tablero = new Tablero();
            tablero[1, 1] = new Pieza(Color.Blanco);
            tablero["2B"] = new Pieza(Color.Blanco);
            var p = tablero["2B"];
            //if(p != null) {
            var kk = p.Color;
            //}
        }
    }
}
