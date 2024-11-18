using Microsoft.Data.SqlClient;
using System.Data;

namespace DBMS.SQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //ประเภทหน้าเชื่อมต่อ
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;

        //method สำหรับเชื่อมต่อ
        private void connect()
        {
            string server = @"LAPTOP-5N08LR59\SQLEXPRESS";
            string db = "Minimart";
            string strCon = string.Format(@"Data Source={0}; Initial Catalog={1};"
                      + "Integrated Security=True;Encrypt=False", server, db);
            conn = new SqlConnection(strCon);
            conn.Open();
        }

        private void disconnect()
        {
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connect();
            string sql = "select * from Products";
            da = new SqlDataAdapter(sql,conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
