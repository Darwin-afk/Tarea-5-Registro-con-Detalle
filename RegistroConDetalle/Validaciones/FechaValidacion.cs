using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace RegistroConDetalle.Validaciones
{
    public class FechaValidacion : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value != null)
            {
                DateTime fecha = new DateTime();
                DateTime.TryParse(value.ToString(), out fecha);

                if (fecha > DateTime.Now)
                    return new ValidationResult(false, "Debes poner una Fecha valida");

                return ValidationResult.ValidResult;

            }
            return new ValidationResult(false, "Debes poner una Fecha");
            //return ValidationResult.ValidResult;
        }
    }
}
