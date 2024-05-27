
namespace Cursos.Juegos {
    public interface IJuego {
        Tablero Tablero { get; }
        Color Turno { get; }

        void Inicializar();
        void Jugada(string cad);
    }
}