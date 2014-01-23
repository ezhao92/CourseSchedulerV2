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
    public partial class Form3 : Form
    {
        private int teacherNo;
        private SqlConnection myConnection;

        public Form3(SqlConnection con, int tNo)
        {
            InitializeComponent();
            myConnection = con;
            teacherNo = tNo;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(
                "SELECT dbo.Teachers.*, dbo.Courses.* FROM dbo.Teachers LEFT JOIN dbo.Courses_Teachers ON dbo.Teachers.TeacherNo = dbo.Courses_Teachers.TeacherNo LEFT JOIN dbo.Courses ON dbo.Courses_Teachers.CourseNo = dbo.Courses.CourseNo WHERE dbo.Teachers.TeacherNo = " + teacherNo + "AND dbo.Teachers.Status = 'True'", myConnection);
            DataTable t = new DataTable();
            adapter.Fill(t);
            dataGridView1.DataSource = t;
        }
    }
}
