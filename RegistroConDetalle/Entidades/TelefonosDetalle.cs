using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RegistroConDetalle.Entidades
{
    public class TelefonosDetalle
    {
        [Key]
        public int Id { get; set; }
        public string Telefono { get; set; }
        public string TipoTelefono { get; set; }

        public TelefonosDetalle()
        {
            Id = 0;
            Telefono = string.Empty;
            TipoTelefono = string.Empty;
        }

        public TelefonosDetalle(string telefono, string tipoTelefono)
        {
            Id = 0;
            Telefono = telefono;
            TipoTelefono = tipoTelefono;
        }
    }
}
