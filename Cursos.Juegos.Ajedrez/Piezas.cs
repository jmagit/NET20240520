namespace Cursos.Juegos.Ajedrez;

/// <summary>
/// El Rey como pieza del Ajedrez.
/// </summary>
[Serializable()]
public class Rey : Pieza {
    /// <summary>
    /// Constructor �nico del Rey.
    /// </summary>
    /// <param name="color">Color del Rey.</param>
    public Rey(Color color) : base(color) {
    }

    /// <summary>
    /// Reemplazado. Indica si el Rey puede realizar el movimiento.
    /// </summary>
    /// <remarks>Verifica que el rey solo se desplaza una posici�n en cualquier direcci�n. NO CONTEMPLA EL ENROQUE.</remarks>
    /// <param name="m">Movimiento a verificar.</param>
    /// <param name="t">No utilizado.</param>
    /// <returns>Es true si el Rey puede realizar el movimiento; en caso contrario, genera una excepci�n.</returns>
    /// <exception cref="JuegoException">Genera la excepci�n con la raz�n por la que no puede realizar el movimiento.</exception>
    public override bool EsValido(Movimiento m, Tablero t) {
        if(m.SaltoHorizontal > 1 || m.SaltoVertical > 1)
            throw new JuegoException("El rey no pude desplazarse mas de una posici�n.");
        return true;
    }
}

/// <summary>
/// La Dama como pieza del Ajedrez.
/// </summary>
[Serializable()]
public class Dama : Pieza, ISustitutoDelPeon {
    /// <summary>
    /// Constructor �nico de la Dama.
    /// </summary>
    /// <param name="color">Color de la Dama.</param>
    public Dama(Color color) : base(color) {
    }

    /// <summary>
    /// Reemplazado. Indica si la Dama puede realizar el movimiento.
    /// </summary>
    /// <remarks>Verifica que la dama se desplaza horizontal, vertical y diagonal sin saltar piezas.</remarks>
    /// <param name="m">Movimiento a verificar.</param>
    /// <param name="t">Tablero para verificar que no salta piezas.</param>
    /// <returns>Es true si la Dama puede realizar el movimiento; en caso contrario, genera una excepci�n.</returns>
    /// <exception cref="JuegoException">Genera la excepci�n con la raz�n por la que no puede realizar el movimiento.</exception>
    public override bool EsValido(Movimiento m, Tablero t) {
        if(!(m.EsHorizontal || m.EsVertical || m.EsDiagonal))
            throw new JuegoException("La reina solo puede realizar desplazamientos horizontales, verticales o diagonales.");
        else if(t.HayPiezaEntre(m))
            throw new JuegoException("La reina no puede saltar piezas.");
        return true;
    }
}

/// <summary>
/// El Alfil como pieza del Ajedrez.
/// </summary>
[Serializable()]
public class Alfil : Pieza, ISustitutoDelPeon {
    /// <summary>
    /// Constructor �nico del Alfil.
    /// </summary>
    /// <param name="color">Color del Alfil.</param>
    public Alfil(Color color) : base(color) {
    }

    /// <summary>
    /// Reemplazado. Indica si el Alfil puede realizar el movimiento.
    /// </summary>
    /// <remarks>Verifica que el alfil se desplaza diagonal sin saltar piezas.</remarks>
    /// <param name="m">Movimiento a verificar.</param>
    /// <param name="t">Tablero para verificar que no salta piezas.</param>
    /// <returns>Es true si el Alfil puede realizar el movimiento; en caso contrario, genera una excepci�n.</returns>
    /// <exception cref="JuegoException">Genera la excepci�n con la raz�n por la que no puede realizar el movimiento.</exception>
    public override bool EsValido(Movimiento m, Tablero t) {
        if(!m.EsDiagonal)
            throw new JuegoException("El alfil solo puede realizar desplazamientos diagonales.");
        else if(t.HayPiezaEntre(m))
            throw new JuegoException("El alfil no puede saltar piezas.");
        return true;
    }
}

/// <summary>
/// El Caballo como pieza del Ajedrez.
/// </summary>
[Serializable()]
public class Caballo : Pieza, ISustitutoDelPeon {

    /// <summary>
    /// Constructor �nico del Caballo.
    /// </summary>
    /// <param name="color">Color del Caballo.</param>
    public Caballo(Color color) : base(color) {
    }

    /// <summary>
    /// Reemplazado. Indica si el Caballo puede realizar el movimiento.
    /// </summary>
    /// <remarks>Verifica que el caballo se desplaza dos posiciones en horizontal y una en vertical o una posici�n en horizontal y dos en vertical.</remarks>
    /// <param name="m">Movimiento a verificar.</param>
    /// <param name="t">No utilizado.</param>
    /// <returns>Es true si el Caballo puede realizar el movimiento; en caso contrario, genera una excepci�n.</returns>
    /// <exception cref="JuegoException">Genera la excepci�n con la raz�n por la que no puede realizar el movimiento.</exception>
    public override bool EsValido(Movimiento m, Tablero t) {
        //int vertical = m.SaltoVertical;
        //int horizontal = m.SaltoHorizontal;
        //if(!((horizontal == 1 && vertical == 2) || (horizontal == 2 && vertical == 1))) {
        if(!(m is { SaltoHorizontal: 1} and { SaltoVertical: 2} || m is { SaltoHorizontal: 2 } and { SaltoVertical: 1 })) {
            throw new JuegoException("El caballo solo puede saltar 2 filas y 1 columna o 1 fila y 2 columnas.");
        }
        return true;
    }
}

/// <summary>
/// La Torre como pieza del Ajedrez.
/// </summary>
[Serializable()]
public class Torre : Pieza, ISustitutoDelPeon {

    /// <summary>
    /// Constructor �nico de la Torre.
    /// </summary>
    /// <param name="color">Color de la Torre.</param>
    public Torre(Color color) : base(color) {
    }

    /// <summary>
    /// Reemplazado. Indica si la Torre puede realizar el movimiento.
    /// </summary>
    /// <remarks>Verifica que la torre se desplaza horizontal y vertical sin saltar piezas.</remarks>
    /// <param name="m">Movimiento a verificar.</param>
    /// <param name="t">Tablero para verificar que no salta piezas.</param>
    /// <returns>Es true si la Torre puede realizar el movimiento; en caso contrario, genera una excepci�n.</returns>
    /// <exception cref="JuegoException">Genera la excepci�n con la raz�n por la que no puede realizar el movimiento.</exception>
    public override bool EsValido(Movimiento m, Tablero t) {
        if(!(m.EsHorizontal || m.EsVertical))
            throw new JuegoException("La torre solo puede realizar desplazamientos horizontales o verticales.");
        if(t.HayPiezaEntre(m))
            throw new JuegoException("La torre no puede saltar piezas.");
        return true;
    }
}

/// <summary>
/// El Pe�n como pieza del Ajedrez.
/// </summary>
[Serializable()]
public class Peon : Pieza, IPromocionable {

    /// <summary>
    /// Constructor �nico del Pe�n.
    /// </summary>
    /// <param name="color">Color del Pe�n.</param>
    public Peon(Color color) : base(color) {
    }
    /// <summary>
    /// Indica si el Pe�n se encuentra en la posici�n inicial y, por lo tanto, puede saltar dos escaques.
    /// </summary>
    /// <param name="m">Movimiento con la posici�n inicial.</param>
    /// <returns>Es true si no se ha movido; en caso contrario, es false.</returns>
    private bool esApertura(Movimiento m) {
        return m.PosicionInicial.Fila == (Color == Color.Blanco ? 2 : 7);
    }

    /// <summary>
    /// Indica si el Pe�n va a alcanzar la �ltima fila y, por lo tanto, necesita promocionar.
    /// </summary>
    /// <param name="m">Movimiento con la posici�n final.</param>
    /// <returns>Es true si alcanza la �ltima fila; en caso contrario, es false.</returns>
    private bool esPromocion(Movimiento m) {
        return m.PosicionFinal.Fila == (Color == Color.Blanco ? 8 : 1);
    }

    /// <summary>
    /// Indica si el Pe�n avanza.
    /// </summary>
    /// <param name="m">Movimiento a verificar.</param>
    /// <returns>Es true si avanza; en caso contrario, es false.</returns>
    private bool Avanza(Movimiento m) {
        return m.DeltaFila == (Color == Color.Blanco ? 1 : -1)
            && (m.EsDiagonal || m.EsVertical)
            && !m.EsHorizontal;
    }

    /// <summary>
    /// Indica si en la posici�n final hay una pieza contraria.
    /// </summary>
    /// <param name="m">Movimiento a verificar.</param>
    /// <param name="t">Tablero para verificar las piezas.</param>
    /// <returns>Es true si puede capturar; en caso contrario, es false.</returns>
    private bool PuedeComer(Movimiento m, Tablero t) {
        return m.EsDiagonal && m.SaltoVertical == 1 &&
            t.HayPieza(m.PosicionFinal) && t[m.PosicionFinal].Color != Color;
    }

    /// <summary>
    /// Reemplazado. Indica si el Pe�n puede realizar el movimiento.
    /// </summary>
    /// <remarks>Verifica que el pe�n avanza. Si el movimiento es vertical comprueba que solo avance una posici�n (dos, en caso de apertura, sin saltar otras piezas) siempre que el escaque de destino no est� ocupado. En caso de ser diagonal, verifica que solo avance una posici�n y pueda capturar una pieza contraria. NO CONTEMPLA LA CAPTURA AL PASO.</remarks>
    /// <param name="m">Movimiento a verificar.</param>
    /// <param name="t">Tablero para verificar que no salta piezas.</param>
    /// <returns>Es true si el Pe�n puede realizar el movimiento; en caso contrario, genera una excepci�n.</returns>
    /// <exception cref="JuegoException">Genera la excepci�n con la raz�n por la que no puede realizar el movimiento.</exception>
    public override bool EsValido(Movimiento m, Tablero t) {
        if(!Avanza(m))
            throw new JuegoException("El pe�n solo puede avanzar.");
        else if(m.EsDiagonal && !PuedeComer(m, t))
            throw new JuegoException("El pe�n solo puede avanzar una posici�n en diagonal para capturar otra pieza.");
        else if(m.EsVertical) {
            if(m.SaltoVertical > 2)
                throw new JuegoException("El pe�n no puede desplazase " + m.SaltoVertical + " escaques.");
            else if(t.HayPieza(m.PosicionFinal))
                throw new JuegoException("El pe�n captura piezas en diagonal.");
            else if(m.SaltoVertical == 2 && (!esApertura(m) || t.HayPiezaEntre(m)))
                throw new JuegoException("El pe�n solo puede desplazase 2 escaques en la apertura sin saltar piezas.");
        }
        return true;
    }

    #region Gesti�n de la promoci�n
    /// <summary>
    /// Se produce cuando el pe�n va ha llegar a la ultima fila y necesita promocionar.
    /// </summary>
    public event PromocionEventHandler Promocion;

    /// <summary>
    /// Provoca el evento Promocion
    /// </summary>
    /// <param name="pieza">Referencia a la pieza a promocionar</param>
    protected virtual void OnPromocion(PromocionEventArgs e) {
        if(Promocion != null) {
            Promocion(this, e);
        }
    }

    /// <summary>
    /// Reemplazado. Mueve el Pe�n en el tablero. En caso de alcanzar la �ltima fila, lanza el evento de Promoci�n.
    /// </summary>
    /// <param name="m">Movimiento a realizar.</param>
    /// <param name="t">Tablero para realizar el movimiento.</param>
    /// <exception cref="JuegoException">Genera la excepci�n con la raz�n por la que no puede realizar el movimiento.</exception>
    public override void Mover(Movimiento m, Tablero t) {
        if(esPromocion(m)) {
            if(EsValido(m, t)) {
                PromocionEventArgs e = new PromocionEventArgs(Color);
                OnPromocion(e);
                Pieza p = e.Pieza;
                //if(p == null || !(p is Dama || p is Alfil || p is Caballo || p is Torre || p.Color != this.Color))
                if(p is not ISustitutoDelPeon)
                    throw new JuegoException("Es obligatorio promocionar al pe�n a una Dama, un Alfil, una Torre o un Caballo.");
                if(p.Color != Color)
                    throw new JuegoException("No se puede crear piezas del otro jugador.");
                t.QuitaPieza(m.PosicionInicial);
                t[m.PosicionFinal] = p;
            }
        } else
            base.Mover(m, t);
    }
    #endregion
}
