using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using RegistroConDetalle.Entidades;

namespace RegistroConDetalle.Validaciones
{
    public class TelefonosValidacion : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value != null)
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Debes poner algun Telefono");
        }
    }
}
