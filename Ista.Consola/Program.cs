using Ista.Comunes;
using Ista.Comunes.Juegos;
using Ista.Comunes.Juegos.Ajedrez;
using Ista.Consola.Entidades;
using Ista.Dominio.Entidades;
using Ista.Infraestructura.Datos;
using Ista.Utilidades;
using Microsoft.EntityFrameworkCore;
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
            public bool EsConflictivo { get; init; } = false;

            public Decimal Salario { get; set; }

            #endregion
            #region Métodos
            public Persona() { }

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

            public static Decimal operator *(Persona p, int cantidad) {
                return p.Salario * cantidad;
            }

            public override string? ToString() {
                return $"{GetType().Name} => Id: {Id} Nombre: {Nombre}";
            }
        }

#if DEBUG
        public
#else
    internal
#endif
        class Alumno : Persona, ICalcula, IContable {
            public Alumno() : this("Alumno") {
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

    [Obsolete]
    public delegate int Operacion(int i, int j);

    public class App {
        static void Main(string[] args) {
            SQLite();
            //EsValido();
        }
        static void EsValido() {
            var p = new Product();
            p.Color = new string('x', 60);
            foreach(var err in p.GetValidationErrors())
                Console.WriteLine(err.ErrorMessage);
            Console.WriteLine();
            var post = new Post();
            post.Title = "xx";
            post.Content = "99";// new string('x', 260);
            if(post.IsInvalid)
                foreach(var err in post.GetValidationErrors())
                    Console.WriteLine(err.ErrorMessage);
            //using(var db = new AWContext()) {
            //    db.Products.Add(p);
            //    //db.SaveChanges();
            //}
        }
        static void SQLite() {
            using var db = new BloggingContext();

            // Note: This sample requires the database to be created before running.
            Console.WriteLine($"Database path: {db.DbPath}.");

            // Create
            Console.WriteLine("Inserting a new blog");
            db.Add(new Blog { Url = "Esta se queda" });
            db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
            db.SaveChanges();

            // Read
            Console.WriteLine("Querying for a blog");
            var blog = db.Blogs
                .OrderBy(b => b.BlogId)
                .First();

            // Update
            Console.WriteLine("Updating the blog and adding a post");
            blog.Url = "https://devblogs.microsoft.com/dotnet";
            blog.Posts.Add(
                new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
            db.SaveChanges();

            // Delete
            Console.WriteLine("Delete the blog");
            db.Remove(blog);
            db.SaveChanges();
        }
        static void SQLServer() {
            int pagina = 1, filas = 10;
            //using(var db = new AWContext()) {
            //    foreach(var item in db.Products
            //        //.Include(p => p.ProductCategory)
            //        //.AsSplitQuery()
            //        //.Include(p => p.ProductModel)
            //        //.ThenInclude(m => m.ProductModelProductDescriptions)
            //        //.AsSplitQuery()
            //        .Where(p => p.ProductId < 800)
            //        .OrderBy(p => p.ProductId)
            //        .Skip(pagina * filas)
            //        .Take(filas)
            //        ) {
            //        //db.Entry(item).Reference(p => p.ProductCategory).Load();
            //        Console.WriteLine($"{item.ProductId} - {item.Name} ({item.ProductCategory.Name})");
            //    }
            //}
            //List<Product> lista;
            //using(var db = new AWContext()) {
            //    lista = db.Products
            //        .Where(p => p.ProductId < 800)
            //        .OrderBy(p => p.ProductId)
            //        .Skip(pagina * filas)
            //        .Take(filas).ToList();
            //}

            //using(var db = new AWContext()) {
            //    foreach(var item in lista) {
            //        db.Entry(item).Reference(p => p.ProductCategory).Load();
            //        Console.WriteLine($"{item.ProductId} - {item.Name} ({item.ProductCategory.Name})");
            //    }
            //}
            //using(var db = new AWContext()) {
            //    foreach(var item in db.Products
            //        //.Include(p => p.ProductCategory)
            //        //.AsSplitQuery()
            //        //.Include(p => p.ProductModel)
            //        //.ThenInclude(m => m.ProductModelProductDescriptions)
            //        //.AsSplitQuery()
            //        .Where(p => p.ProductId < 800)
            //        .OrderBy(p => p.ProductId)
            //        .Skip(pagina * filas)
            //        .Take(filas)
            //        .Select(p => new { Id = p.ProductId, Nombre = p.Name.Mayusculas(), Categoria = p.ProductCategory.Name.ToUpper()  })
            //        ) {
            //        //db.Entry(item).Reference(p => p.ProductCategory).Load();
            //        Console.WriteLine(item);
            //    }
            //}
            using(var db = new AWContext()) {
                //int ini = 800;
                //var sqlCmd = $"SELECT TOP (10) * FROM [AdventureWorksLT2019].[SalesLT].[Product] where productid > {ini}";
                //sqlCmd = "SELECT TOP (10) * FROM [AdventureWorksLT2019].[SalesLT].[Product] where productid > " + ini;
                //foreach(var item in db.Products
                //    .FromSql($"SELECT TOP(10) * FROM [AdventureWorksLT2019].[SalesLT].[Product] where productid > {ini}")
                //    ) {
                //    //db.Entry(item).Reference(p => p.ProductCategory).Load();
                //    Console.WriteLine($"{item.ProductId} - {item.Name}");
                //}

                Console.WriteLine($"Productos: {db.Database.SqlQuery<int>($"SELECT count(*) as Value FROM [AdventureWorksLT2019].[SalesLT].[Product]").Single()}");
            }

        }
        static void Colecciones(string[] args) {
            IList<Persona> lista = new List<Persona>();
            lista.Add(new Alumno() { Id = 1, Nombre = "Pepito", Salario = 1001 });
            lista.Add(new Alumno() { Id = 2, Nombre = "Carmelo", Salario = 2000, EsConflictivo = true });
            lista.Add(new Profesor() { Id = 3, Nombre = "Profe", Salario = 3000 });
            lista.Add(new Profesor() { Id = 4, Nombre = "Profe2", Salario = 1500, Situación = SituacionLaboral.DeBaja });
            lista.Add(new Alumno() { Id = 5, Nombre = "Pepito2", Salario = 1000 });
            lista.Add(new Alumno() { Id = 6, Nombre = "Carmelo2", Salario = 2000 });

            bool paginar = true, orden = false;
            int pagina = 0, filas = 2;
            var consulta = lista.OfType<Alumno>().Where(item => !item.EsConflictivo);
            if(paginar) {
                consulta = consulta.Skip(pagina * filas).Take(filas);
            }
            if(orden) {
                consulta = consulta.OrderBy(item => item.Nombre);
            } else {
                consulta = consulta.OrderBy(item => item.Salario);
            }
            var rslt = consulta.ToList();
            Console.WriteLine(consulta.FirstOrDefault()?.ToString() ?? "Ninguna");
            //consulta = consulta.Select(item => new { Id = item.Id, Nombre = item.Nombre });
            foreach(var item in rslt) {
                Console.WriteLine(item);
            }
            foreach(var item in lista.OfType<Alumno>()
                    .Where(item => !item.EsConflictivo)
                    .Select(item => new { Id = item.Id, Nombre = item.Nombre })
                    .OrderBy(item => item.Nombre)
                    ) {
                Console.WriteLine(item);
            }
            Console.WriteLine(lista
                    .OfType<Profesor>()
                    .Where(item => item.Situación == SituacionLaboral.Activo)
                    .Average(item => item.Salario)
                 );
            var sql = from p in lista
                      where p.Salario > 1500
                      orderby p.Salario
                      select new { Id = p.Id, Nombre = p.Nombre, Salario = p.Salario };
            foreach(var item in from p in lista
                                where p.Salario > 1500
                                orderby p.Salario
                                select new { Id = p.Id, Nombre = p.Nombre, Salario = p.Salario }) {
                Console.WriteLine(item);
                Console.WriteLine(item.GetType().Name);
            }


        }
        static void DemosCSharp(string[] args) {
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
            if(p is Alumno alum) {
                alum.Add();
            }
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
            Console.WriteLine(alumno.Calcula(2, 3, alumno.Suma));
            Console.WriteLine(alumno.Calcula(2, 3, func));
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
            if(Validaciones.EsBlanco(alumno.Nombre) && alumno.Nombre.EsMuyLargo(10)) {
                Console.WriteLine(alumno.Nombre);
            }
        }

        private static void App_Promocion(object sender, PromocionEventArgs e) {
            Console.WriteLine("Piede tipo de pieza");
            e.Pieza = new Dama((sender as Peon).Color);
        }
    }
}
