using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RegistroConDetalle.Entidades;
using RegistroConDetalle.BLL;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Globalization;

namespace RegistroConDetalle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Contenedor contenedor = new Contenedor();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = contenedor; //se le asigna el objeto contenedor al DataContext para hacer el binding
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if(contenedor.persona.PersonaId == 0)
            {
                paso = PersonasBLL.Guardar(contenedor.persona);
            }
            else
            {
                if(existeEnLaBaseDeDatos())
                {
                    paso = PersonasBLL.Modificar(contenedor.persona);
                }
                else
                {
                    MessageBox.Show("No se puede modificar una persona que no existe");
                    return;
                }
            }

            if(paso)
            {
                limpiar();
                MessageBox.Show("Guardado");
            }
            else
            {
                MessageBox.Show("No se pudo guardar");
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Personas persona = PersonasBLL.Buscar(contenedor.persona.PersonaId);

            if (persona!=null)
            {
                contenedor.persona = persona;
                cargarGrid();
            }
            else
            {
                MessageBox.Show("Persona no encontrada");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if(PersonasBLL.Eliminar(contenedor.persona.PersonaId))
            {
                MessageBox.Show("Eliminado");
                limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar una persona que no existe");
            }
        }

        private void MasButton_Click(object sender, RoutedEventArgs e)
        {
            contenedor.persona.Telefonos.Add(new TelefonosDetalle(TelefonoTextBox.Text,TipoTextBox.Text));

            cargarGrid();

            TelefonoTextBox.Clear();
            TipoTextBox.Clear();

            TelefonoTextBox.Focus();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if(TelefonosDataGrid.Items.Count > 1 && TelefonosDataGrid.SelectedIndex < TelefonosDataGrid.Items.Count - 1)
            {
                contenedor.persona.Telefonos.RemoveAt(TelefonosDataGrid.SelectedIndex);
                cargarGrid();
            }
        }

        private void limpiar()
        {
            PersonaIdTextBox.Text = "0";
            NombreTextBox.Clear();
            DireccionTextBox.Clear();
            CedulaTextBox.Clear();
            FechaDatePicker.SelectedDate = DateTime.Now;
            TelefonosDataGrid.ItemsSource = new List<TelefonosDetalle>();
        }

        private bool existeEnLaBaseDeDatos()
        {
            Personas persona = PersonasBLL.Buscar(contenedor.persona.PersonaId);

            return persona != null;
        }

        private void cargarGrid()
        {
            List<TelefonosDetalle> actual = contenedor.persona.Telefonos;
            contenedor.persona.Telefonos = null;
            contenedor.persona.Telefonos = actual;
        }

        //clase para poder aplicarle el propertyChanged a la entidad
        public class Contenedor : INotifyPropertyChanged
        {
            private Personas _persona { get; set; }

            public Contenedor()
            {
                persona = new Personas();
            }

            public Personas persona
            {
                get { return _persona; }
                set
                {
                    _persona = value;
                    OnPropertyChanged();
                }
            }

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
}
