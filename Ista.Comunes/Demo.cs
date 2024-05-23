namespace Ista.Comunes {
    /// <summary>
    /// Ejemplos del curso
    /// </summary>
    public sealed class Demo {
        /// <summary>
        /// Bien educado que saluda
        /// </summary>
        /// <param name="nombre">El nombre a quien saluda,  por defecto a "Mundo"</param>
        /// <returns>La cadena con el saludo</returns>
        public static String Saluda(String nombre = "Mundo") {
            return $"Hola {nombre}";
        }
        private Demo() { }

        public static Demo Create() { return new Demo(); }
    }
    //public class OtraDemo: Demo {
    //    /// <summary>
    //    /// Bien educado que saluda
    //    /// </summary>
    //    /// <param name="nombre">El nombre a quien saluda,  por defecto a "Mundo"</param>
    //    /// <returns>La cadena con el saludo</returns>
    //    public static String Saluda(String nombre = "Mundo") {
    //        return $"Hola {nombre}";
    //    }
    //    private Demo() { }
    //}
}
