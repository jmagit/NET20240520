﻿namespace Cursos.Juegos.Ajedrez;

/// <summary>
/// Clase principal del juego de Ajedrez.
/// </summary>
[Serializable()]
public class Juego : IJuego {

    /// <summary>
    /// Indica que la partida a empezado y no a terminado
    /// </summary>
    private bool partidaActiva;

    /// <summary>
    /// Guarda el color del jugador que le toca jugar.
    /// </summary>
    private Color turno;
    /// <summary>
    /// Obtiene el color del jugador que tiene el turno.
    /// </summary>
    /// <value>Color del jugador.</value>
    public Color Turno => turno;

    /// <summary>
    /// Mantiene las piezas y el desarrollo del juego.
    /// </summary>
    private Tablero tablero;
    /// <summary>
    /// Obtiene el tablero para que el contenedor pueda implementar el interfaz de usuario.
    /// </summary>
    public Tablero Tablero => (Tablero)tablero.Clone();

    /// <summary>
    /// Inicializa el juego.
    /// </summary>
    public Juego() {
        Inicializar();
    }

    #region Gestión de la promoción
    /// <summary>
    /// Se produce cuando el peón va ha llegar a la ultima fila y necesita promocionar.
    /// </summary>
    public event PromocionEventHandler Promocion {
        add {
            foreach(var p in tablero.Where(item => item.Value is IPromocionable)
                .Select(item => item.Value as IPromocionable))
                p.Promocion += new PromocionEventHandler(value);
            //for(int i = 1; i <= 8; i++)
            //    for(int j = 1; j <= 8; j++)
            //        if(tablero[i, j] is IPromocionable p)
            //            p.Promocion += new PromocionEventHandler(value);
        }
        remove {
            for(int i = 1; i <= 8; i++)
                for(int j = 1; j <= 8; j++)
                    if(tablero[i, j] is IPromocionable p)
                        p.Promocion -= new PromocionEventHandler(value);
        }
    }
    #endregion

    /// <summary>
    /// Pone el turno a Blanco y crea un nuevo tablero introduciendo las piezas en su posición inicial.
    /// </summary>
    public void Inicializar() {
        turno = Color.Blanco;
        tablero = new Tablero();

        tablero[1, 1] = new Torre(Color.Blanco);
        tablero[1, 2] = new Caballo(Color.Blanco);
        tablero[1, 3] = new Alfil(Color.Blanco);
        tablero[1, 4] = new Dama(Color.Blanco);
        tablero[1, 5] = new Rey(Color.Blanco);
        tablero[1, 6] = new Alfil(Color.Blanco);
        tablero[1, 7] = new Caballo(Color.Blanco);
        tablero[1, 8] = new Torre(Color.Blanco);

        tablero[8, 1] = new Torre(Color.Negro);
        tablero[8, 2] = new Caballo(Color.Negro);
        tablero[8, 3] = new Alfil(Color.Negro);
        tablero[8, 4] = new Dama(Color.Negro);
        tablero[8, 5] = new Rey(Color.Negro);
        tablero[8, 6] = new Alfil(Color.Negro);
        tablero[8, 7] = new Caballo(Color.Negro);
        tablero[8, 8] = new Torre(Color.Negro);

        for(byte i = 1; i <= 8; i++) {
            tablero[2, i] = new Peon(Color.Blanco);
            tablero[7, i] = new Peon(Color.Negro);
        }
        partidaActiva = true;

#if DEBUG
        // Caso de prueba para la promoción
        tablero[7, 1] = new Peon(Color.Blanco);
        tablero[2, 1] = new Peon(Color.Negro);
#endif
    }

    /// <summary>
    /// Método principal que desarrolla el juego.
    /// </summary>
    /// <param name="cad">Cadena con el movimiento.</param>
    /// <remarks>NO CONTEMPLA EL JAQUE. Así mismo, no contempla las reglas de finalización como el jaque mate, el abandono o las tablas. Para terminar la partida es necesario teclear "FIN" o "TABLAS".</remarks>
    public void Jugada(string cad) {
        if(!partidaActiva)
            throw new JuegoException("El juego ha terminado.");
        if(cad.ToUpper() == "FIN") {
            partidaActiva = false;
            return;
        }
        Movimiento m = new Movimiento(cad);
        this.Mover(m);
        this.CambiaTurno();
    }

    /// <summary>
    /// Pasa el turno de Blanco a Negro y viceversa.
    /// </summary>
    protected void CambiaTurno() {
        turno = turno == Color.Blanco ? Color.Negro : Color.Blanco;
    }

    /// <summary>
    /// Realiza el movimiento en caso de ser posible.
    /// </summary>
    /// <param name="m">Movimiento a realizar</param>
    /// <exception cref="JuegoException">No se pueden realizar movimientos no permitidos.</exception>
    /// <remarks>Antes de mover, valida que hay una pieza del jugador en la posición inicial, que no intente capturar sus propias piezas y que la pieza puede realizar el movimiento.</remarks>
    protected void Mover(Movimiento m) {
        if(!tablero.HayPieza(m.PosicionInicial))
            throw new JuegoException("No hay pieza en la posición inicial.");
        else if(tablero[m.PosicionInicial]?.Color != turno)
            throw new JuegoException("No puede mover piezas del otro jugador.");
        else if(tablero[m.PosicionFinal]?.Color == turno)
            throw new JuegoException("No puede capturar sus propias piezas.");
        else
            tablero[m.PosicionInicial]?.Mover(m, tablero);
    }
}

