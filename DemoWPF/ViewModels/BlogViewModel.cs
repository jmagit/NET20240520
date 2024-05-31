using Ista.Dominio.ComponentModel.Core;
using Ista.Presentacion.WPF.Core;
using Ista.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ista.Infraestructura.Datos;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace Ista.Presentacion.WPF.Demo {
    public enum Modo { List, Add, Edit, View, Delete }
    public class BlogViewModel : ObservableClassBase {
        private Blog elemento = new Blog { Url = "Inicio" };
        private Modo modo = Modo.List;


        public Modo Modo { get => modo; set { 
                modo = value;
                OnPropertyChanged(nameof(Modo));
            } 
        }
        public ObservableCollection<Blog> Listado { get; private set; }
        public Blog Elemento {
            get => elemento; private set {
                if(elemento == value) return;
                elemento = value;
            OnPropertyChanged(nameof(Elemento));
            }
        }
        public BlogViewModel() {
            Elemento = new Blog { Url = "Inicio" };
            //Listado = new ObservableCollection<Blog>([new Blog { Url = "Uno" }, new Blog { Url = "Dos" }, new Blog { Url = "Tres" }]);
        }


        public ICommand List => new DelegateCommand(cmd => {
            using var db = new BloggingContext();
            Listado = new ObservableCollection<Blog>(db.Blogs.ToList());
            OnPropertyChanged(nameof(Listado));
            Modo = Modo.List;
        });

        public ICommand Add => new DelegateCommand(cmd => {
            Elemento = new Blog { Url = "Nuevo"};
            Modo = Modo.Add;
        });

        public ICommand Modify => new DelegateCommand(cmd => {
            using var db = new BloggingContext();
            Elemento = db.Blogs.Where(item => item.BlogId == int.Parse(cmd.ToString())).FirstOrDefault();
            Modo = Modo.Edit;
        });
        public ICommand View => new DelegateCommand(cmd => {
            using var db = new BloggingContext();
            Elemento = db.Blogs.Where(item => item.BlogId == int.Parse(cmd.ToString())).FirstOrDefault();
            Modo = Modo.View;
        });
        public ICommand Delete => new DelegateCommand(cmd => {
            using var db = new BloggingContext();
            db.Blogs.Where(item => item.BlogId == int.Parse(cmd.ToString())).ExecuteDelete();
            List.Execute(null);
        });

        public ICommand Save => new DelegateCommand(cmd => {
            using var db = new BloggingContext();
            if(modo == Modo.Add)
                db.Blogs.Add(Elemento);
            else
                db.Blogs.Update(Elemento);
            db.SaveChanges();
            List.Execute(null);
        });

    }
}
