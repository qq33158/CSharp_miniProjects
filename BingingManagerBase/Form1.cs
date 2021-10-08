using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BingingManagerBase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" + "AttachDbFilename=|DataDirectory|Northwind.mdf;" + "Integrated Security=True";
                DataSet ds = new DataSet();
                SqlDataAdapter daCategory = new SqlDataAdapter("SELECT * FROM 產品類別", cn);
                daCategory.Fill(ds, "產品類別");
                SqlDataAdapter daProduct = new SqlDataAdapter("SELECT * FROM 產品資料", cn);
                daProduct.Fill(ds, "產品資料");
                ds.Relations.Add("FK_產品資料_產品類別", ds.Tables["產品類別"].Columns["類別編號"],
                                                         ds.Tables["產品資料"].Columns["類別編號"]);
                dgvCategory.DataSource = ds;
                dgvCategory.DataMember = "產品類別";
                dgvCategory.Dock = DockStyle.Top;
                dgvProduct.DataSource = ds;
                dgvProduct.DataMember = "產品類別.FK_產品資料_產品類別";
                dgvProduct.Dock = DockStyle.Fill;

            }
        }
    }
}
