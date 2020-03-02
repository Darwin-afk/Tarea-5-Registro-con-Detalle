using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroConDetalle.Entidades
{
    public class TelefonosDetalle : INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }
        private string _Telefono;
        private string _TipoTelefono;

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

        public string Telefono
        {
            get { return _Telefono; }
            set
            {
                _Telefono = value;
                OnPropertyChanged();
            }
        }

        public string TipoTelefono
        {
            get { return _TipoTelefono; }
            set
            {
                _TipoTelefono = value;
                OnPropertyChanged();
            }
        }

        //este evento es para que se actualiza la ventana con los cambio hechos a al telefono
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
