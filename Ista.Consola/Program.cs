using Ista.Comunes;

namespace Ista.Consola {
    public abstract class Persona {
        #region Atributos
        private string nombre;
        #endregion
        #region Propiedades
        public int Id { get; set; }
        public string Nombre {
            get {
                return nombre?.ToLower();
            }
            set {
                if(nombre == value) return;
                nombre = value;
            }
        }
        public bool EsConflictivo { get; }

        public Decimal Salario { get; set; }

        #endregion
        #region Métodos

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
        #endregion
    }

#if DEBUG
    public
#else
    private
#endif
    class Alumno : Persona {
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
        public void Add(String algo) {
            Console.WriteLine($"Propio del {algo}");
        }

        public override void DebeSobreescribir() {
            throw new NotImplementedException();
        }
    }
    public class App {
        static void Main(string[] args) {
#if MODO
            Console.WriteLine("""Hello, World!""");
#endif

            Persona p = new Alumno(), pp =  new Alumno();
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
            Demo demo = new Demo();
            Console.WriteLine(demo.Saluda(""));
            Console.WriteLine(0.1M+(decimal)0.2);
            Console.WriteLine(1m-0.9m == 0.1m);
            int div = 2;
            Console.WriteLine(1 / div);
            Object o = 4; // new Int32(4)
            int? i = (int)o; // o.value()
            i = null;
            if(i.HasValue) {
                Nullable<int> j = i.Value + 1;
            }

            long l = 99999;
            int kk =checked((int) l);
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
            int x = 1, y = 1, z = 1;
            x = y = z = 0;

        }
    }
}
