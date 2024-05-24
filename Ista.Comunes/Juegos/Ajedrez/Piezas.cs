using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Comunes.Juegos.Ajedrez {

    public class Dama : Pieza, ISiPuedeSustituirAlPeon {
        public Dama(Color color) : base(color) {
        }
    }
    public class Peon : Pieza, IPromocionable {
        public Peon(Color color) : base(color) {
        }

        public event PromocionEventHandler Promocion;

        protected virtual void OnPromocion(PromocionEventArgs arg) {
            if(Promocion != null) Promocion(this, arg);
            // Promocion?.Invoke(this, arg);
        }

        public override void Muevete(Posicion inicial, Posicion final) {
            if((Color == Color.Blanco && final.Fila == 8) || (Color == Color.Negro && final.Fila == 1)) {
                PromocionEventArgs arg = new(new Dama(Color));
                OnPromocion(arg);
                // ...
            }
            base.Muevete(inicial, final);
        }
    }

}
