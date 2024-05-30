using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Dominio.Entidades.Core {
    public abstract class EntityBase: IValidatableObject, IDataErrorInfo {
        public IEnumerable<ValidationResult> GetValidationErrors() {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(this, null, null);
            Validator.TryValidateObject(this,
                      context,
                      validationResults,
                      true);
            return validationResults;
        }

        public bool IsValid => !IsInvalid;
        public bool IsInvalid => GetValidationErrors().Any();
        public virtual string this[string columnName] => throw new NotImplementedException();
        public virtual string Error => throw new NotImplementedException();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            throw new NotImplementedException();
        }
    }
}
