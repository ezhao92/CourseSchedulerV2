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
    public partial class Form2 : Form
    {
        private int classNo;
        private SqlConnection myConnection;
        public Form2(SqlConnection con, int no)
        {
            InitializeComponent();
            classNo = no;
            myConnection = con;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(
                "SELECT dbo.Courses.*, dbo.Teachers.* FROM dbo.Courses LEFT JOIN dbo.Courses_Teachers ON dbo.Courses.CourseNo= dbo.Courses_Teachers.CourseNo LEFT JOIN dbo.Teachers ON dbo.Courses_Teachers.TeacherNo = dbo.Teachers.TeacherNo WHERE dbo.Courses.CourseNo = " + classNo , myConnection);
            DataTable t = new DataTable();
            adapter.Fill(t);
            dataGridView1.DataSource = t;
        }
    }
}
