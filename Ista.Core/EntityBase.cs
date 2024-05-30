using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Dominio.Entidades.Core {
    public abstract class EntityBase {
        public IEnumerable<ValidationResult> GetValidationErrors() {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(this, null, null);
            Validator.TryValidateObject(this,
                      context,
                      validationResults,
                      true);
            return validationResults;
        }

        public bool IsValid => GetValidationErrors().Any();
        public bool IsNotValid => !IsValid;
    }
}
