﻿using System;
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
using System.Globalization;

namespace RegistroConDetalle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Personas persona = new Personas();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = persona; //se le asigna el objeto al DataContext para hacer el binding
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
                return;

            if(persona.PersonaId == 0)
            {
                paso = PersonasBLL.Guardar(persona);
            }
            else
            {
                if(existeEnLaBaseDeDatos())
                {
                    paso = PersonasBLL.Modificar(persona);
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
            Personas personaAnterior = PersonasBLL.Buscar(persona.PersonaId);

            if (persona!=null)
            {
                persona = personaAnterior;
                reCargar();
            }
            else
            {
                MessageBox.Show("Persona no encontrada");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if(PersonasBLL.Eliminar(persona.PersonaId))
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
            persona.Telefonos.Add(new TelefonosDetalle(TelefonoTextBox.Text,TipoTextBox.Text));

            reCargar();

            TelefonoTextBox.Clear();
            TipoTextBox.Clear();

            TelefonoTextBox.Focus();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if(TelefonosDataGrid.Items.Count > 1 && TelefonosDataGrid.SelectedIndex < TelefonosDataGrid.Items.Count - 1)
            {
                persona.Telefonos.RemoveAt(TelefonosDataGrid.SelectedIndex);
                reCargar();
            }
        }

        private void limpiar()
        {
            PersonaIdTextBox.Text = "0";
            NombreTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            FechaDatePicker.SelectedDate = DateTime.Now;
            TelefonosDataGrid.ItemsSource = new List<TelefonosDetalle>();
        }

        private bool existeEnLaBaseDeDatos()
        {
            Personas personaAnterior = PersonasBLL.Buscar(persona.PersonaId);

            return persona != null;
        }

        private void reCargar()
        {
            this.DataContext = null;
            this.DataContext = persona;
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(PersonaIdTextBox.Text))
                paso = false;
            else
            {
                try
                {
                    int i = Convert.ToInt32(PersonaIdTextBox.Text);
                }
                catch(FormatException)
                {
                    paso = false;
                }
            }

            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
                paso = false;
            else
            {
                foreach(var caracter in NombreTextBox.Text)
                {
                    if (!char.IsLetter(caracter))
                        paso = false;
                }
            }

            //faltan las demas validaciones

            if (paso == false)
                MessageBox.Show("Datos invalidos");

            return paso;
        }
    }
}
