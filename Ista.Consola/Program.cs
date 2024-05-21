using Ista.Comunes;

namespace Ista.Consola {
    public abstract class Persona {
        private string nombre;

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

        public virtual void Dime() {
            Console.WriteLine("Soy el padre");
            
        }
        public void Add() {
            Console.WriteLine("Propio del Padre");
        }

        public abstract void DebeSobreescribir();

    }

    public class Alumno: Persona {
        public override void Dime() {
            Console.WriteLine("Soy el Hijo");
        }
        public void Add() {
            Console.WriteLine("Propio del Hijo");
        }
        public void Add(String algo) {
            Console.WriteLine($"Propio del {algo}");
        }

        public override void DebeSobreescribir() {
            throw new NotImplementedException();
        }
    }
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
            Persona p = new Alumno();
            p.Nombre = "algo";
            Console.WriteLine(p.Nombre);
            (p as Alumno).Add();
            p.Dime();
            Console.WriteLine(p.Nombre);
            //p.Add();
            Demo demo = new Demo();
            Console.WriteLine(demo.Saluda());
        }
    }
}
