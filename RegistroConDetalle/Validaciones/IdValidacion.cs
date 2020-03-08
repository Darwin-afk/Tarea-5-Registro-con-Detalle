using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace RegistroConDetalle.Validaciones
{
    public class IdValidacion : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value != null)
            {
                int id = 0;
                try
                {
                    id = Convert.ToInt32(value);
                }
                catch
                {
                    return new ValidationResult(false, "El ID debe ser un numero");
                }

                if (id >= 0)
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "El ID debe mayor o igual a cero");

            }
            return new ValidationResult(false, "Debes poner un ID");
        }
    }
}
