using Ista.Presentacion.WPF.Core;
using Ista.Presentacion.WPF.Demo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ista.Presentacion.WPF.Demo {
    internal class NavigationController {
        public static ContentControl Host { get; set; }

        public ICommand VerAjedrez => new DelegateCommand(cmd => {
            Host.Content = new AjedrezWin.ucAjedrez();
        });

        public ICommand VerBlog => new DelegateCommand(cmd => {
            var vista = new BlogView();
            var vm = new BlogViewModel();
            vm.List.Execute(null);
            vista.DataContext = vm;
            Host.Content = vista;
        });

    }
}
