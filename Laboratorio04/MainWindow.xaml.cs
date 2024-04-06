using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laboratorio04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            LoadProvidersData();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=LAB1504-03\\SQLEXPRESS;Initial Catalog=NeptunoDB;User Id=Mario;Password=1234"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("USP_ListarCategorias", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridCategorias.ItemsSource = dt.DefaultView;
                }
            }
        }

        private void LoadProvidersData()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=LAB1504-03\\SQLEXPRESS;Initial Catalog=NeptunoDB;User Id=Mario;Password=1234"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("USP_ListarProveedores", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridSuppliers.ItemsSource = dt.DefaultView;
                }
            }
        }
    }
}