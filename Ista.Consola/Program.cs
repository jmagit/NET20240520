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
        #endregion
        #region Métodos

        public virtual void Dime() {
            Console.WriteLine("Soy el padre");

        }
        public void Add() {
            Console.WriteLine("Propio del Padre");
        }

        public abstract void DebeSobreescribir();
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

            Persona p = new Alumno();
            p.Nombre = "algo";
#if DEBUG
            Console.WriteLine(p.Nombre);
#else
            Console.WriteLine("p.Nombre");
#endif
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            (p as Alumno).Add();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            p.Dime();
            Console.WriteLine(p.Nombre);
            //p.Add();
            Demo demo = new Demo();
            Console.WriteLine(demo.Saluda(""));
            Console.WriteLine(0.1M+(decimal)0.2);
            Console.WriteLine(1m-0.9m == 0.1m);
            int div = 0;
            Console.WriteLine((1 / div) * 0);
            Object o = 4; // new Int32(4)
            int? i = (int)o; // o.value()
            i = null;
            if(i.HasValue) {
                Nullable<int> j = i.Value + 1;
            }

            long l = 99999999999;
            int kk =(int) l;
        }
    }
}
