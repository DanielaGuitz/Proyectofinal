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
using System.Windows.Shapes;

namespace crudWPF.PL
{
    /// <summary>
    /// Lógica de interacción para choosingAction.xaml
    /// </summary>
    public partial class choosingAction : Window
    {
        public choosingAction()
        {
            InitializeComponent();
        }

        private void btnCerrar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAbrirPrv(object sender, RoutedEventArgs e)
        {
            VentanaProveedores ventanaPrv =  new VentanaProveedores();
            ventanaPrv.Show();
            this.Close();
        }

        private void btnProductos(object sender, RoutedEventArgs e)
        {
            VentanaProducto ventanaPrd = new VentanaProducto();
            ventanaPrd.Show();
            this.Close();
        }
    }
}
