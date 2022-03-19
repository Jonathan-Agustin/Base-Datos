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
using System.Data;
using System.Data.SqlClient;

namespace AccederBaseDatos
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string sCnn;
            sCnn = "data source = ServidorSQL; initial catalog = BaseDatos; user id = Usuario; password = Contraseña";

            string sSel = "SELECT * FROM NombreTabla";

            SqlDataAdapter da;
            DataTable dt = new DataTable();

            try
            {
                da = new SqlDataAdapter(sSel, sCnn);
                da.Fill(dt);

                this.GridView1.DataSource = dt;
                this.GridView1.DataBind();
                LabelInfo.Text = string.Format("Total datos en la tabla: {0}", dt.Rows.Count);
            }
            catch (Exception ex)
            {
                LabelInfo.Text = "Error: " + ex.Message;
            }
        }

        public object GridView1 { get; }
        public object LabelInfo { get; }
    }
}