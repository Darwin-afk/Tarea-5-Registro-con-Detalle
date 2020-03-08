using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace RegistroConDetalle.Validaciones
{
    public class TipoValidacion : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            /*string cadena = value as string;

            if (cadena != null)
            {
                if (cadena.Length <= 0)
                    return new ValidationResult(false, "Debes poner un Tipo");

                return ValidationResult.ValidResult;

            }
            return new ValidationResult(false, "Debes poner un Tipo");*/
            return ValidationResult.ValidResult;
        }
    }
}