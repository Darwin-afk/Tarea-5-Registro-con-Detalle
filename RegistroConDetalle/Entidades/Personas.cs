using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RegistroConDetalle.Entidades
{
    public class Personas : INotifyPropertyChanged
    {
        [Key]
        public int PersonaId { get; set; }
        private string _Nombre;
        private string _Cedula;
        private string _Direccion;
        private DateTime _FechaNacimiento;

        private List<TelefonosDetalle> _Telefonos;

        public Personas()
        {
            PersonaId = 0;
            Nombre = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            FechaNacimiento = DateTime.Now;

            Telefonos = new List<TelefonosDetalle>();
        }

        public string Nombre
        {
            get { return _Nombre; }
            set
            {
                _Nombre = value;
                OnPropertyChanged();
            }
        }
        public string Cedula
        {
            get { return _Cedula; }
            set
            {
                _Cedula = value;
                OnPropertyChanged();
            }
        }
        public string Direccion
        {
            get { return _Direccion; }
            set
            {
                _Direccion = value;
                OnPropertyChanged();
            }
        }
        public DateTime FechaNacimiento
        {
            get { return _FechaNacimiento; }
            set
            {
                _FechaNacimiento = value;
                OnPropertyChanged();
            }
        }

        public virtual List<TelefonosDetalle> Telefonos
        {
            get { return _Telefonos; }
            set
            {
                _Telefonos = value;
                OnPropertyChanged();
            }
        }

        //este evento es para que se actualiza la ventana con los cambio hechos a la persona
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
