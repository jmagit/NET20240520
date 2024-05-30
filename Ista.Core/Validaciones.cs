using System.ComponentModel.DataAnnotations;

namespace Ista.Utilidades {
    public static class Validaciones {
        public static bool EsBlanco(this string cad) {
            return string.IsNullOrEmpty(cad?.Trim());
        }
        public static bool EsMuyLargo(this string cad, int longMax) {
            return cad?.Length > longMax;
        }
        public static bool NoEsBlanco(this string cad) {
            return !EsBlanco(cad);
        }
        public static bool EsPositivo(this int num) {
            return num > 0;
        }
        public static string Mayusculas(this string cad) {
            return cad?.ToUpper();
        }
    }
    public static class ValidacionesPersonalizadas {
        public static ValidationResult NoEsBlanco(string cad) {
            return cad.NoEsBlanco() ? ValidationResult.Success : new ValidationResult("No puede estar en blanco");
        }
     }
}
