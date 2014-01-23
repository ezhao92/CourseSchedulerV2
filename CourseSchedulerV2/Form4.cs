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

namespace CourseSchedulerV2
{
    public partial class Form4 : Form
    {
        private int studentNo;
        private SqlConnection myConnection;
        public Form4(SqlConnection con, int sNo)
        {
            InitializeComponent();
            myConnection = con;
            studentNo = sNo;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand("SELECT dbo.Students.*, dbo.Courses.* FROM dbo.Students LEFT JOIN dbo.Courses_Students ON dbo.Students.StudentNo = dbo.Courses_Students.StudentNo LEFT JOIN dbo.Courses ON dbo.Courses_Students.CourseNo = dbo.Courses.CourseNo WHERE dbo.Students.StudentNo = " + studentNo +"AND dbo.Students.Status = 'TRUE'", myConnection);
            DataTable t = new DataTable();
            adapter.Fill(t);
            dataGridView1.DataSource = t;
        }
    }
}
