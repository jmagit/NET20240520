namespace Ista.Consola {
    class Persona {
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
    }
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
            var p = new Persona();
            p.Nombre = "algo";
            Console.WriteLine(p.Nombre);
        }
    }
}
