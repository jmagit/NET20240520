using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Dominio.ComponentModel.Core; 
public class ObservableClassBase : INotifyPropertyChanged {
    public ObservableClassBase() {
#if DEBUG
        ThrowOnInvalidPropertyName = true;
#endif
    }
    #region Miembros de INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string property) {
#if DEBUG
        this.VerifyPropertyName(property);
#endif
        if(PropertyChanged != null) {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
#if DEBUG
    //[DebuggerStepThrough]
    //[System.Diagnostics.Conditional("DEBUG")]
    public void VerifyPropertyName(string propertyName) {
        if(TypeDescriptor.GetProperties(this)[propertyName] == null) {
            string msg = "NotifyPropertyChanged - Invalid property name: " + propertyName;
            if(this.ThrowOnInvalidPropertyName)
                throw new Exception(msg);
            else
                System.Diagnostics.Debug.Fail(msg);
        }
    }
#endif
    #endregion

#if DEBUG
    [System.Xml.Serialization.XmlIgnore]
    [NotMapped]
    public bool ThrowOnInvalidPropertyName { get; set; }
#endif
}

