using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace Ista.Presentacion.WPF.Core.Converters {
    /// <summary>
    /// Invierte la visibilidad recibida a la contraria, de visible a colapsado y viceversa.
    /// Permite mostrar objetos alternativos, si uno se ve el otro no.
    /// </summary>
    public class InvertVisibilityConverter : IValueConverter {
        #region Miembros de IValueConverter

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            if(value is Visibility v)
                return v == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            else
                throw new InvalidOperationException("El tipo debe ser System.Windows.Visibility.");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }

        #endregion
    }
}
