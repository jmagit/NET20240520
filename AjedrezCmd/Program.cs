using Cursos.Juegos;
using Cursos.Juegos.Ajedrez;
using System.Reflection;

string jugada;
IJuego juego = new Cursos.Juegos.Ajedrez.Juego();
juego.Inicializar();
((Cursos.Juegos.Ajedrez.Juego)juego).Promocion += Juego_Promocion;

do {
    PintaTablero(juego.Tablero);
    Console.Write($"Juegan las {(juego.Turno == Color.Blanco ? "BLANCAS" : "NEGRAS")}. Dame movimiento (FIN para terminar): ");
    jugada = Console.ReadLine() ?? "";
    if(jugada.ToUpper() == "FIN" || "TABLAS".Equals(jugada, StringComparison.CurrentCultureIgnoreCase))
        break;
    try {
        juego.Jugada(jugada);
    } catch(JuegoException ex) {
        Console.WriteLine("ERROR: " + ex.Message);
    } catch(Exception ex) {
        Console.WriteLine(ex.Message);
        break;
    }
} while(true);

void PintaTablero(Tablero t) {
    const int ANCHO = 11;
        Console.WriteLine();
    for(int f = 8; f > 0; f--) {
        Console.Write($" {f} ");
        for(int c = 1; c <= 8; c++) {
            if(t.HayPieza(f, c))
                Console.Write($" {t[f, c],ANCHO} ");
                else
                Console.Write(new string(Tablero.ColorEscaque(f, c) == Color.Blanco ? ' ' : '-', ANCHO+2));
        }
        Console.WriteLine();
    }
    Console.Write("   ");
    for(char c = 'A'; c <= 'H'; c++) {
        var d = (int)Math.Ceiling((double)ANCHO / 2);
        Console.Write($"{" ",5}{c,2}{" ",6}");
    }
    Console.WriteLine("\n");
}

void Juego_Promocion(object sender, PromocionEventArgs e) {
    Console.Write("\t1: Dama\n\t2: Alfil\n\t3: Torre\n\t4: Caballo\nDame tipo de pieza: ");
    e.Pieza = Console.ReadLine() switch {
        "1" => new Dama(e.Color),
        "2" => new Alfil(e.Color),
        "3" => new Torre(e.Color),
        "4" => new Caballo(e.Color),
        _ => throw new JuegoException("La pieza debe ser: Dama, Alfil, Torre o Caballo"),
    };
}