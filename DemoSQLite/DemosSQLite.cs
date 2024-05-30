using Ista.Dominio.Entidades;
using Ista.Dominio.Entidades.Core;
using Ista.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Ista.Infraestructura.Datos {
    public class BloggingContext : DbContext {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public string DbPath { get; }

        public BloggingContext() {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "blogging.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}").LogTo(msg => Debug.WriteLine(msg));
    }
}
namespace Ista.Dominio.Entidades {

    public class Blog : EntityBase {
        public int BlogId { get; set; }
        [Required][Url]
        public string Url { get; set; }

        public List<Post> Posts { get; } = new();
    }

    public class Post : EntityBase {

        public int PostId { get; set; }
        [Display(Name = "Título")]
        [CustomValidation(typeof(ValidacionesPersonalizadas), nameof(ValidacionesPersonalizadas.NoEsBlanco), 
            ErrorMessage = "El título no puede estar en blanco.")]
        public string Title { get; set; }
        [Required]
        [Phone]
        [MaxLength(250)]
        [RegularExpression("([A-Z]\\s?)+", ErrorMessage = "Debe tener una o varias palabras en mayúsculas separadas por un blanco")]
        [Display(Name = "Contenido")]
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }

    }
}