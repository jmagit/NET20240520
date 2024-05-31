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
    public enum ModoCRUD { List, Add, Edit, View, Delete }
    public class BlogViewModel : ObservableClassBase {
        private Blog elemento = new Blog { Url = "Inicio" };
        private ModoCRUD modo = ModoCRUD.List;
        private ObservableCollection<Blog> listado;

        public ModoCRUD Modo { 
            get => modo; set { 
                modo = value;
                OnPropertyChanged(nameof(Modo));
                OnPropertyChanged(nameof(IsList));
                OnPropertyChanged(nameof(IsAdd));
                OnPropertyChanged(nameof(IsEdit));
                OnPropertyChanged(nameof(IsView));
                OnPropertyChanged(nameof(IsDelete));
            } 
        }
        public bool IsList => modo == ModoCRUD.List;
        public bool IsAdd => modo == ModoCRUD.Add;
        public bool IsEdit => modo == ModoCRUD.Edit;
        public bool IsView => modo == ModoCRUD.View;
        public bool IsDelete => modo == ModoCRUD.Delete;
        public ObservableCollection<Blog> Listado { 
            get => listado; 
            set { listado = value; OnPropertyChanged(nameof(Listado)); } }
        public Blog Elemento {
            get => elemento; private set {
                if(elemento == value) return;
                elemento = value;
            OnPropertyChanged(nameof(Elemento));
            }
        }
        public BlogViewModel() {
            Elemento = new Blog { Url = "Inicio" };
            Listado = new ObservableCollection<Blog>([new Blog { Url = "Uno" }, new Blog { Url = "Dos" }, new Blog { Url = "Tres" }]);
        }


        public ICommand List => new DelegateCommand(cmd => {
            using var db = new BloggingContext();
            Listado = new ObservableCollection<Blog>(db.Blogs.Include(b => b.Posts).ToList());
            Modo = ModoCRUD.List;
        });

        public ICommand Add => new DelegateCommand(cmd => {
            Elemento = new Blog { Url = "Nuevo"};
            Modo = ModoCRUD.Add;
        });

        public ICommand Modify => new DelegateCommand(cmd => {
            using var db = new BloggingContext();
            Elemento = db.Blogs.Include(b => b.Posts).Where(item => item.BlogId == int.Parse(cmd.ToString())).FirstOrDefault();
            Modo = ModoCRUD.Edit;
        });
        public ICommand View => new DelegateCommand(cmd => {
            using var db = new BloggingContext();
            Elemento = db.Blogs.Include(b => b.Posts).Where(item => item.BlogId == int.Parse(cmd.ToString())).FirstOrDefault();
            Modo = ModoCRUD.View;
        });
        public ICommand Delete => new DelegateCommand(cmd => {
            using var db = new BloggingContext();
            db.Blogs.Where(item => item.BlogId == int.Parse(cmd.ToString())).ExecuteDelete();
            List.Execute(null);
        });

        public ICommand Save => new DelegateCommand(cmd => {
            using var db = new BloggingContext();
            if(modo == ModoCRUD.Add)
                db.Blogs.Add(Elemento);
            else
                db.Blogs.Update(Elemento);
            db.SaveChanges();
            List.Execute(null);
        });

        public ICommand Cancel => new DelegateCommand(cmd => {
            Elemento = null;
            List.Execute(null);
        });

    }
}
