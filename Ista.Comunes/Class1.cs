namespace Ista.Comunes {
    /// <summary>
    /// Ejemplos del curso
    /// </summary>
    public class Demo {
        /// <summary>
        /// Bien educado que saluda
        /// </summary>
        /// <param name="nombre">El nombre a quien saluda,  por defecto a "Mundo"</param>
        /// <returns>La cadena con el saludo</returns>
        public String Saluda(String nombre = "Mundo") {
            return $"Hola {nombre}";
        }
    }
}
