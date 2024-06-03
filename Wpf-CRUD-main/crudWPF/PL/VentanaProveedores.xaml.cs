using System.Windows;
using System.Windows.Controls;
using crudWPF.DAL;
using crudWPF.BLL;

namespace crudWPF.PL
{
    /// <summary>
    /// Lógica de interacción para VentanaProveedores.xaml
    /// </summary>
    public partial class VentanaProveedores : Window
    {
        choosingAction ventanaPrincipial;
        proveedoresDAL oProveedor;
        public VentanaProveedores()
        {
            InitializeComponent();
            oProveedor = new proveedoresDAL();
            ventanaPrincipial = new choosingAction();
            GridUpdate();
        }




        private void btnVolver(object sender, RoutedEventArgs e)
        {
            this.Close();
            ventanaPrincipial.Show();
        }




        private void btnAgregar(object sender, RoutedEventArgs e)
        {
            oProveedor.Agregar(RecuperarInfo());
            MessageBox.Show($"{RecuperarInfo().nombre} ha sido agregado.","Proveedor");
            GridUpdate();
            LimpiarEntradas();
        }



        private void btnBorrar(object sender, RoutedEventArgs e)
        {
            bool opcion = MensajePregunta("Eliminar", txtID);
            if (opcion!=false)
            {
                oProveedor.Eliminar(RecuperarInfo());
                GridUpdate();
                LimpiarEntradas();
            }
        }


        private void btnModificar(object sender, RoutedEventArgs e)
        {
            bool opcionModificar = MensajePregunta("Modificar", txtID);
            if (opcionModificar != false)
            {
                oProveedor.Modificar(RecuperarInfo());
                GridUpdate();
                LimpiarEntradas();
            }
        }


        private void btnCancelar(object sender, RoutedEventArgs e)
        {
            LimpiarEntradas();
        }





        //Funciones
        private void GridUpdate()
        {
            //Actualiza el datagrid cada vez que es llamado.
            dgvProveedores.DataContext = oProveedor.MostrarProveedores().Tables[0];
        }

        private proveedoresBLL RecuperarInfo()
        {
            //Obtiene los datos del txtbox, los obtiene de la clase proveedoresBLL,
            //despues devuelve un objeto de la misma clase con los datos necesarios.
            proveedoresBLL oProveedorBLL = new proveedoresBLL();

            int ID = 0; int.TryParse(txtID.Text, out ID);

            oProveedorBLL.id = ID;
            oProveedorBLL.nombre = txtNombre.Text;
            oProveedorBLL.telefono = txtTelefono.Text;

            return oProveedorBLL;

        }


        private void LimpiarEntradas()
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
        }



        private void dgvProveedores_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            int indice = dgvProveedores.SelectedIndex;


            //txtID.Text = dgvProveedores.SelectedIndex[1];

            //MessageBox.Show(indice.ToString());
        }

    
        private bool MensajePregunta(string opcion,TextBox txtbox)
        {
            string msj = $"Deseas {opcion} el proveedor con ID {txtbox.Text}?";
            string msjcaption = $"{opcion} registro";

            MessageBoxButton botones = MessageBoxButton.YesNo;

            var result = MessageBox.Show(msj, msjcaption, botones, MessageBoxImage.Exclamation);

            if (result == MessageBoxResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //End Funciones
    }
}
