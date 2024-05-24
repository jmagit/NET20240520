using Ista.Comunes;
using Ista.Comunes.Juegos;
using Ista.Comunes.Juegos.Ajedrez;
using Ista.Consola.Entidades;
using System.Reflection;
using System.Text;

namespace Ista.Consola {
    namespace Entidades {
        public interface ICalcula {
            public double Avg(double value1, params double[] valores);
        }
        public interface IContable {
            public double Avg(double value1, params double[] valores);
        }
        public abstract class Persona : IDisposable {
            #region Atributos
            private string nombre;
            #endregion
            #region Propiedades
            public int Id { get; set; }
            public string? Nombre {
                get {
                    return nombre?.ToLower();
                }
                set {
                    if(nombre == value) return;
                    nombre = value;
                }
            }
            public bool EsConflictivo { get; } = true;

            public Decimal Salario { get; set; }

            #endregion
            #region Métodos
            public Persona() {}

            public Persona(string nombre) {
                this.nombre = nombre;
            }
            public virtual void Dime() {
                Console.WriteLine("Soy el padre");

            }
            public void Add() {
                Console.WriteLine("Propio del Padre");
            }

            public abstract void DebeSobreescribir();

            public string DameId() {
                return nameof(Id); // "Id";
            }

            public void Dispose() {
                // libero;
            }

            public override bool Equals(object? obj) {
                if(obj is int) {
                    int id = (int)obj;
                    return Id == id;
                }
                return obj is Persona persona &&
                       Id == persona.Id;
            }

            public override int GetHashCode() {
                return HashCode.Combine(Id);
            }
            #endregion

            public static Decimal operator * (Persona p, int cantidad) {
                return p.Salario * cantidad;
            }

        }

#if DEBUG
        public
#else
    private
#endif
        class Alumno : Persona, ICalcula, IContable {
            public Alumno(): this("Alumno") { 
            }
            public Alumno(string nombre) : base(nombre) { 
            }
            public override void Dime() {
                Console.WriteLine("Soy el Hijo");
            }
            public void Add() {
                Console.WriteLine("Propio del Hijo");
            }
            public Persona Add(decimal p) {
                Salario = Salario + p;
                return this;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="algo"></param>
            public string Add(ref string algo, string saludo = "Propio del") {
#if DEBUG
                if(String.IsNullOrEmpty(algo)) 
                    throw new ArgumentNullException(nameof(algo));
#endif
                Console.WriteLine($"{saludo} {algo}");
                algo = algo.ToUpper();
                return $"Propio del {algo}";
            }

            double ICalcula.Avg(double value1, params double[] valores) {
                double result = value1;
                foreach(var d in valores) {
                    result += d;
                }
                return result / (valores.Length + 1);
            }
            double IContable.Avg(double value1, params double[] valores) {
                double result = value1;
                foreach(var d in valores) {
                    result += d;
                }
                return result / (valores.Length + 1);
            }
            public double Avg2(double[] valores) {
                double result = 0;
                foreach(var d in valores) {
                    result += d;
                }
                return result / valores.Length;
            }

            public override void DebeSobreescribir() {
                throw new NotImplementedException();
            }
            public int Suma(int i, int j) {
                return i + j;
            }
            public int Calcula(int i, int j, Operacion func) {
                return func(i, j);
            }
        }

        public class Direccion {
            public string Calle { get; set; }
        }
    }

    public delegate int Operacion(int i, int j);

    public class App {
        static void Main(string[] args) {
#if MODO
            Console.WriteLine("""Hello, World!""");
#endif

            Persona p = new Alumno(), pp = new Alumno();
            using(Persona profe = new Alumno()) {
                profe.Add();
            }

            p.Nombre = "algo";
#if DEBUG
            Console.WriteLine(p.Nombre);
#else
            Console.WriteLine("p.Nombre");
#endif
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            (p as Alumno).Add();
            ((Alumno)p).Add();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            p.Dime();
            Console.WriteLine(p.Nombre);
            //p.Add();
            //Demo demo = new Demo();
            Demo demo = Demo.Create();
            Console.WriteLine(Demo.Saluda(""));
            Console.WriteLine(0.1M + (decimal)0.2);
            Console.WriteLine(1m - 0.9m == 0.1m);
            int div = 2;
            Console.WriteLine(1 / div);
            Object o = 4; // new Int32(4)
            int? i = (int)o; // o.value()
            i = null;
            if(i.HasValue) {
                Nullable<int> j = i.Value + 1;
            }

            long l = 99999;
            int kk = checked((int)l);
            char a = 'a';
            a = (char)(a + l);
            Console.WriteLine((char)('a' - 32));
            if(int.MaxValue > l) {
                i = unchecked((int)l);
            }
            Console.WriteLine((double)l / 7);
            if(string.IsNullOrEmpty(p.Nombre) && p.Nombre == "kk") {
            }
            if("kk".Equals(p.Nombre)) {
            }
            pp = p;
            if(p.Nombre == pp.Nombre && p.Nombre.Equals(pp.Nombre)) {
                using Persona profe = new Alumno();
            }
            String? cad = null;
            cad = p != null ? p.Nombre : null;
            cad = p != null && p.Nombre != null ? p.Nombre.ToUpper() : null;
            cad = p?.Nombre?.ToUpper();
            cad = cad?.ToLower();
            cad = p != null && p.Nombre != null ? p.Nombre : "(anonimo)";
            cad = p?.Nombre ?? "(anonimo)";

            if(p == pp && p.Equals(pp)) {

            }
            p = (p as Alumno).Add(5m); // p + 5;
                                       //int x = 1, y = 1, z = 1;
                                       //x = y = z = 0;

            //Alumno x = new();
            //dynamic x = new Alumno();
            //x.kkkkk();
            //x = 1.0;
            StringBuilder sb = new StringBuilder("Cad");
            for(int ele = 0; ele < 10; ele++) {
                cad += "x";
                sb.Append("x");
            }
            cad = sb.ToString();
            //p.Dispose();
            //p.Add();

            (int id, string nombre) par = (1, "Pepito");
            cad = par.nombre;
            par.nombre = "kk";
            par = (1, "kk");
            var punto = (x: 10, Y: 10);
            var punto2 = (x: 20, Y: 20);
            punto.x = 11;
            punto2 = punto;
            punto = (x: 12, Y: 10);
            Console.WriteLine(punto == punto2 ? "Iguales" : "Distintos");
            Alumno alumno = new Alumno { Id = 1, Nombre = "PP", Salario = 1000m };
            cad = "algo";
            string? result = alumno.Add(saludo: "hola", algo: ref cad);
            Console.WriteLine(cad);
            if(result != null) { }
            Console.WriteLine((alumno as ICalcula).Avg(1, 2, 3));
            Console.WriteLine((alumno as IContable).Avg(1));
            Console.WriteLine(alumno * 3);
            //Console.WriteLine(alumno.Avg(1, [1, 2, 3]));
            //Console.WriteLine(alumno.Avg2(new Double[] { 1, 2, 3 }));

            Operacion func = alumno.Suma;
            Console.WriteLine(func(2, 2));
            func = (a, b) => a - b;
            //func = delegate(a, b) { return a - b; };
            Func<int, int, bool> pred = (a, b) => a > b;
            Action<string> pinta = cad => Console.WriteLine($"{cad} => {func(kk, kk)}");

            pinta("9999");

            Console.WriteLine(func(2, 2));
            Console.WriteLine(alumno.Calcula(2,3, alumno.Suma));
            Console.WriteLine(alumno.Calcula(2,3, func));
            List<int> list = new List<int>();

            Elemento<int, string> provincia = new(28, "Madrid");
            // provincia = new("28", "Madrid");
            ElementoCadena<char> genero = new('H', "Hombre");
            Elemento<string, string> abre = new("AVG", "Media");
            var anonimo = new { Id = 1, Nombre = "PP", Salario = 1000m };
            Console.WriteLine(provincia.GetType().Name);
            Console.WriteLine(provincia is Elemento<int, string>);
            Console.WriteLine(provincia is Elemento<string, string>);
            Console.WriteLine(abre.GetType().Name);
            Console.WriteLine(abre is Elemento<char, string>);
            Console.WriteLine(genero.GetType().Name);
            Console.WriteLine(anonimo.GetType().Name);

            Pieza peon = new Peon(Color.Blanco);
            (peon as Peon).Promocion += (s, args) => Console.WriteLine("Segundo controlador");
            (peon as Peon).Promocion += App_Promocion;
            Pieza dama = new Dama(Color.Blanco);
            dama.Muevete(new Posicion(1, 1), new Posicion(8, 1));
            peon.Muevete(new Posicion(7, 1), new Posicion(8, 1));
            (peon as Peon).Promocion -= App_Promocion;
            peon.Muevete(new Posicion(7, 1), new Posicion(8, 1));
        }

        private static void App_Promocion(object sender, PromocionEventArgs e) {
            Console.WriteLine("Piede tipo de pieza");
            e.Pieza = new Dama((sender as Peon).Color);
        }
    }
}
namespace Ista.Utilidades {
    public class Validaciones {
    }
}