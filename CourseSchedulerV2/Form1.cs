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
    public partial class Form1 : Form
    {
        private SqlConnection myConnection = new SqlConnection("Data Source=EDWARD-PC\\SQLEXPRESS;Initial Catalog=CourseSchedulerV2;Integrated Security=True");
        
        public Form1()
        {
            InitializeComponent();

        }

        //Courses

        private void getCInfo_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection.Open();
                int classNo = Convert.ToInt32(courseNo.Text);
                Form2 courseInfoForm = new Form2(myConnection, classNo);
                courseInfoForm.Show();
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input needs to be an Integer");
                myConnection.Close();
            }
            courseNo.Text = "";
        }

        private void insertCourse_Click(object sender, EventArgs e)
        {
            if (courseNo.Text != "" && name.Text != "" && startTime.Text != "" && dOW.Text != "" && credits.Text != "" && hours.Text != "" && loc.Text != "" && sub.Text != "" && cap.Text != "")
            {
                try
                {
                    myConnection.Open();
                    int classNo = Convert.ToInt32(courseNo.Text);
                    int credit = Convert.ToInt32(credits.Text);
                    decimal hour = Convert.ToDecimal(hours.Text);
                    int maxCap = Convert.ToInt32(cap.Text);
                    SqlCommand myCommand = new SqlCommand("INSERT INTO dbo.Courses (CourseNo, Name, StartTime,  DaysOfWeek, Credits, Hours, Location, Subject, MaxCapacity) VALUES('" +  classNo + "','" + name.Text + "','" + startTime.Text + "','" + dOW.Text + "','" + credit + "','" + hour + "','" + loc.Text + "','" + sub.Text + "','" + cap.Text + "')", myConnection);
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    MessageBox.Show("Row Inserted Successfully");
                    courseNo.Text = "";
                    name.Text = "";
                    startTime.Text = "";
                    dOW.Text = "";
                    credits.Text = "";
                    hours.Text = "";
                    loc.Text = "";
                    sub.Text = "";
                    cap.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Inputs");
                    myConnection.Close();
                }
            }else{
                MessageBox.Show("Must fill in all entries");
            }
        }

        private void deleteCourse_Click(object sender, EventArgs e)
        {
            if (courseNo.Text != "")
            {
                try
                {
                    myConnection.Open();
                    int classNo = Convert.ToInt32(courseNo.Text);
                    SqlCommand myCommand = new SqlCommand("DELETE FROM dbo.Courses_Teachers WHERE dbo.Courses_Teachers.CourseNo = " + classNo, myConnection);
                    SqlCommand myCommand2 = new SqlCommand("DELETE FROM dbo.Courses WHERE dbo.Courses.CourseNo = " + classNo, myConnection);
                    myCommand.ExecuteNonQuery();
                    myCommand2.ExecuteNonQuery();
                    myConnection.Close();
                    MessageBox.Show("Row Deleted Successfully");
                    courseNo.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Input");
                    myConnection.Close();
                }
            }
            else
            {
                MessageBox.Show("Must enter valid Course Number");
            }
        }

        private void updateCourse_Click(object sender, EventArgs e)
        {
            if (courseNo.Text != "")
            {
                try
                {
                    int classNo = Convert.ToInt32(courseNo.Text);
                    if (newCN.Text != "")
                    {
                        myConnection.Open();
                        int change = Convert.ToInt32(newCN.Text);
                        SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Courses_Teachers WHERE dbo.Courses_Teachers.CourseNo = " + classNo, myConnection);
                        SqlCommand cmd2 = new SqlCommand("DELETE FROM dbo.Courses_Students WHERE dbo.Courses_Students.CourseNo = " + classNo, myConnection);
                        SqlCommand cmd3 = new SqlCommand("UPDATE dbo.Courses SET dbo.Courses.CourseNo = '" + change + "'WHERE dbo.Courses.CourseNo = " + classNo, myConnection);
                        cmd.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        cmd3.ExecuteNonQuery();
                        myConnection.Close();
                        newCN.Text = "";
                    }
                    if (name.Text != "")
                    {
                        myConnection.Open();
                        String n = name.Text;
                        SqlCommand myCommand = new SqlCommand("UPDATE dbo.Courses SET dbo.Courses.Name = '" + n + "'WHERE dbo.Courses.CourseNo = " + classNo, myConnection);
                        myCommand.ExecuteNonQuery();
                        name.Text = "";
                        myConnection.Close();
                    }
                    if (startTime.Text != "")
                    {
                        myConnection.Open();
                        String start = startTime.Text;
                        SqlCommand myCommand = new SqlCommand("UPDATE dbo.Courses SET dbo.Courses.StartTime = '" + start + "'WHERE dbo.Courses.CourseNo = " + classNo, myConnection);
                        myCommand.ExecuteNonQuery();
                        startTime.Text = "";
                        myConnection.Close();
                    }
                    if (dOW.Text != "")
                    {
                        myConnection.Open();
                        String day = dOW.Text;
                        SqlCommand myCommand = new SqlCommand("UPDATE dbo.Courses SET dbo.Courses.DaysOfWeek = '" + day + "'WHERE dbo.Courses.CourseNo = " + classNo, myConnection);
                        myCommand.ExecuteNonQuery();
                        dOW.Text = "";
                        myConnection.Close();
                    }
                    if (credits.Text != "")
                    {
                        myConnection.Open();
                        int c = Convert.ToInt32(credits.Text);
                        SqlCommand myCommand = new SqlCommand("UPDATE dbo.Courses SET dbo.Courses.Credits = '" + c + "'WHERE dbo.Courses.CourseNo = " + classNo, myConnection);
                        myCommand.ExecuteNonQuery();
                        credits.Text = "";
                        myConnection.Close();
                    }
                    if (hours.Text != "")
                    {
                        myConnection.Open();
                        int h = Convert.ToInt32(hours.Text);
                        SqlCommand myCommand = new SqlCommand("UPDATE dbo.Courses SET dbo.Courses.Hours = '" + h + "'WHERE dbo.Courses.CourseNo = " + classNo, myConnection);
                        myCommand.ExecuteNonQuery();
                        hours.Text = "";
                        myConnection.Close();
                    }
                    if (loc.Text != "")
                    {
                        myConnection.Open();
                        String l = loc.Text;
                        SqlCommand myCommand = new SqlCommand("UPDATE dbo.Courses SET dbo.Courses.Location = '" + l + "'WHERE dbo.Courses.CourseNo = " + classNo, myConnection);
                        myCommand.ExecuteNonQuery();
                        loc.Text = "";
                        myConnection.Close();
                    }
                    if (sub.Text != "")
                    {
                        myConnection.Open();
                        String s = sub.Text;
                        SqlCommand myCommand = new SqlCommand("UPDATE dbo.Courses SET dbo.Courses.Subject = '" + s + "'WHERE dbo.Courses.CourseNo = " + classNo, myConnection);
                        myCommand.ExecuteNonQuery();
                        sub.Text = "";
                        myConnection.Close();
                    }
                    if (cap.Text != "")
                    {
                        myConnection.Open();
                        int c = Convert.ToInt32(cap.Text);
                        SqlCommand myCommand = new SqlCommand("UPDATE dbo.Courses SET dbo.Courses.MaxCapacity = '" + c + "'WHERE dbo.Courses.CourseNo = " + classNo, myConnection);
                        myCommand.ExecuteNonQuery();
                        cap.Text = "";
                        myConnection.Close();
                    }
                    MessageBox.Show("Course Updated Successfully");
                    courseNo.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid inputs");
                    myConnection.Close();
                }

            }
            else
            {
                MessageBox.Show("Must enter valid CourseNo");
            }
        }

        //Teachers

        private void getTInfo_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection.Open();
                int teacherNo = Convert.ToInt32(tNo.Text);
                Form3 courseInfoForm = new Form3(myConnection, teacherNo);
                courseInfoForm.Show();
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input needs to be an Integer");
                myConnection.Close();
            }
            tNo.Text = "";
        }

        private void insertTeacher_Click(object sender, EventArgs e)
        {
            if (tNo.Text != "" && tName.Text != "" && tGender.Text != "" && tTitle.Text != "" && tDept.Text != "" && tStat.Text != "")
            {
                try
                {
                    myConnection.Open();
                    int teacherNo = Convert.ToInt32(tNo.Text);
                    Boolean s = Convert.ToBoolean(tStat.Text);
                    SqlCommand myCommand = new SqlCommand("INSERT INTO dbo.Teachers (TeacherNo, Name, Gender,  Title, Department, Status) VALUES('" + teacherNo + "','" + tName.Text + "','" + tGender.Text + "','" + tTitle.Text + "','" + tDept.Text + "','" + s + "')", myConnection);
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    MessageBox.Show("Teacher Inserted Successfully");
                    tNo.Text = "";
                    tName.Text = "";
                    tGender.Text = "";
                    tTitle.Text = "";
                    tDept.Text = "";
                    tStat.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Inputs");
                    myConnection.Close();
                }
            }
            else
            {
                MessageBox.Show("Must fill in all entries");
            }
        }

        private void deleteTeacher_Click(object sender, EventArgs e)
        {
            if (tNo.Text != "")
            {
                try
                {
                    myConnection.Open();
                    int teacherNo = Convert.ToInt32(tNo.Text);
                    SqlCommand myCommand = new SqlCommand("UPDATE dbo.Teachers SET dbo.Teachers.Status = 'FALSE' WHERE dbo.Teachers.TeacherNo = " + teacherNo, myConnection);
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    MessageBox.Show("Teacher Deleted Successfully");
                    tNo.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid input");
                    myConnection.Close();
                }
            }
            else
            {
                MessageBox.Show("Must enter valid Teacher Number");
            }
        }

        private void updateTeacher_Click(object sender, EventArgs e)
        {
            if (tNo.Text != "")
            {
                try
                {
                    int teacherNo = Convert.ToInt32(tNo.Text);
                    if (newTN.Text != "")
                    {
                        myConnection.Open();
                        int ch = Convert.ToInt32(newTN.Text);
                        SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Courses_Teachers WHERE dbo.Courses_Teachers.TeacherNo = " + teacherNo, myConnection);
                        SqlCommand cmd2 = new SqlCommand("UPDATE dbo.Teachers SET dbo.Teachers.TeacherNO = '" + ch + "'WHERE dbo.Teachers.TeacherNo = " + teacherNo, myConnection);
                        cmd.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        myConnection.Close();
                        newTN.Text = "";
                    }
                    if (tName.Text != "")
                    {
                        myConnection.Open();
                        String n = tName.Text;
                        SqlCommand myCommand = new SqlCommand("UPDATE dbo.Teachers SET dbo.Teachers.Name = '" + n + "'WHERE dbo.Teachers.TeacherNo = " + teacherNo, myConnection);
                        myCommand.ExecuteNonQuery();
                        tName.Text = "";
                        myConnection.Close();
                    }
                    if (tGender.Text != "")
                    {
                        myConnection.Open();
                        String g = tGender.Text;
                        SqlCommand myCommand = new SqlCommand("UPDATE dbo.Teachers SET dbo.Teachers.Gender = '" + g + "'WHERE dbo.Teachers.TeacherNo = " + teacherNo, myConnection);
                        myCommand.ExecuteNonQuery();
                        tGender.Text = "";
                        myConnection.Close();
                    }
                    if (tTitle.Text != "")
                    {
                        myConnection.Open();
                        String t = tTitle.Text;
                        SqlCommand myCommand = new SqlCommand("UPDATE dbo.Teachers SET dbo.Teachers.Title = '" + t + "'WHERE dbo.Teachers.TeacherNo = " + teacherNo, myConnection);
                        myCommand.ExecuteNonQuery();
                        tTitle.Text = "";
                        myConnection.Close();
                    }
                    if (tDept.Text != "")
                    {
                        myConnection.Open();
                        String d = tDept.Text;
                        SqlCommand myCommand = new SqlCommand("UPDATE dbo.Teachers SET dbo.Teachers.Department = '" + d + "'WHERE dbo.Teachers.TeacherNo = " + teacherNo, myConnection);
                        myCommand.ExecuteNonQuery();
                        tDept.Text = "";
                        myConnection.Close();
                    }
                    if (tStat.Text != "")
                    {
                        myConnection.Open();
                        Boolean s = Convert.ToBoolean(tStat.Text);
                        SqlCommand myCommand = new SqlCommand("UPDATE dbo.Teachers SET dbo.Teachers.Status = '" + s + "'WHERE dbo.Teachers.TeacherNo = " + teacherNo, myConnection);
                        myCommand.ExecuteNonQuery();
                        tStat.Text = "";
                        myConnection.Close();
                    }
                    MessageBox.Show("Teacher Updated Successfully");
                    tNo.Text = "";
                }
                catch (Exception er)
                {
                    MessageBox.Show("Invalid Input");
                    myConnection.Close();
                }

            }
            else
            {
                MessageBox.Show("Must enter valid TeacherNo");
            }
        }

        private void assignCT_Click(object sender, EventArgs e)
        {
            if (tNoA.Text != "" && cNoA.Text != "")
            {
                try
                {
                    myConnection.Open();
                    int courseNo = Convert.ToInt32(cNoA.Text);
                    int teacherNo = Convert.ToInt32(tNoA.Text);
                    SqlCommand myCommand = new SqlCommand("INSERT INTO dbo.Courses_Teachers (CourseNo, TeacherNo) VALUES ('" + courseNo + "','" + teacherNo + "')", myConnection);
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    MessageBox.Show("Assignment Successful");
                    cNoA.Text = "";
                    tNoA.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Assignment");
                    myConnection.Close();
                }
            }
            else
            {
                MessageBox.Show("Must enter valid Course Number and Teacher Number");
            }
        }

        private void assignCS_Click(object sender, EventArgs e)
        {
            if (cNoA.Text != "" && sNoA.Text != ""){
                try
                {
                    myConnection.Open();
                    int courseNo = Convert.ToInt32(cNoA.Text);
                    int studentNo = Convert.ToInt32(sNoA.Text);
                    SqlCommand myCommand = new SqlCommand("INSERT INTO dbo.Courses_Students (CourseNo, StudentNo) VALUES ('" + courseNo + "','" + studentNo + "')",myConnection);
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    MessageBox.Show("Assignment Successful");
                    cNoA.Text = "";
                    sNoA.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Assignment");
                    myConnection.Close();
                }
            }else{
                MessageBox.Show("Must enter valid Course Number and Student Number");
            }
        }

        private void getSInfo_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection.Open();
                int studentNo = Convert.ToInt32(sNo.Text);
                Form4 studentInfoForm = new Form4(myConnection, studentNo);
                studentInfoForm.Show();
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Input");
                myConnection.Close();
            }
            sNo.Text = "";
        }

        private void insertStudent_Click(object sender, EventArgs e)
        {
            if (sNo.Text != "" && sName.Text != "" && sGender.Text != "" & sClass.Text != "" && sMajor.Text != "" && sStat.Text != "")
            {
                try
                {
                    myConnection.Open();
                    int studentNo = Convert.ToInt32(sNo.Text);
                    int sCl = Convert.ToInt32(sClass.Text);
                    Boolean status = Convert.ToBoolean(sStat.Text);
                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Students (StudentNo, Name, Gender, Class, Major, Status) VALUES ('" + studentNo + "','" + sName.Text + "','" + sGender.Text + "','" + sCl + "','" + sMajor.Text + "','" + status + "')", myConnection);
                    cmd.ExecuteNonQuery();
                    myConnection.Close();
                    MessageBox.Show("Student inserted successfully");
                    sNo.Text = "";
                    sName.Text = "";
                    sGender.Text = "";
                    sClass.Text = "";
                    sMajor.Text = "";
                    sStat.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid inputs");
                    myConnection.Close();
                }
            }
            else
            {
                MessageBox.Show("Must fill in all entries.");
            }
        }

        private void deleteStudent_Click(object sender, EventArgs e)
        {
            if (sNo.Text != "")
            {
                try
                {
                    myConnection.Open();
                    int studentNo = Convert.ToInt32(sNo.Text);
                    SqlCommand myCommand = new SqlCommand("UPDATE dbo.Students SET dbo.Students.Status = 'FALSE' WHERE dbo.Students.StudentNo = " + studentNo, myConnection);
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    MessageBox.Show("Student Deleted Successfully");
                    sNo.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid input");
                    myConnection.Close();
                }
            }
            else
            {
                MessageBox.Show("Must enter valid Student Number");
            }
        }

        private void updateStudent_Click(object sender, EventArgs e)
        {
            if (sNo.Text != "")
            {
                try
                {
                    int studentNo = Convert.ToInt32(sNo.Text);
                    if (newSN.Text != "")
                    {
                        myConnection.Open();
                        int change = Convert.ToInt32(newSN.Text);
                        SqlCommand cmd = new SqlCommand("UPDATE dbo.Students SET dbo.Students.StudentNo = '" + change + "'WHERE dbo.Students.StudentNo = " + studentNo, myConnection);
                        SqlCommand cmd2 = new SqlCommand("DELETE FROM dbo.Courses_Students WHERE dbo.Courses_Students.StudentNo = " + studentNo, myConnection);
                        cmd2.ExecuteNonQuery();
                        cmd.ExecuteNonQuery();
                        newSN.Text = "";
                        myConnection.Close();
                    }
                    if (sName.Text != "")
                    {
                        myConnection.Open();
                        String n = tName.Text;
                        SqlCommand myCommand = new SqlCommand("UPDATE dbo.Students SET dbo.Students.Name = '" + n + "'WHERE dbo.Students.StudentNo = " + studentNo, myConnection);
                        myCommand.ExecuteNonQuery();
                        sName.Text = "";
                        myConnection.Close();
                    }
                    if (sGender.Text != "")
                    {
                        myConnection.Open();
                        String g = sGender.Text;
                        SqlCommand myCommand = new SqlCommand("UPDATE dbo.Students SET dbo.Students.Gender = '" + g + "'WHERE dbo.Students.StudentNo = " + studentNo, myConnection);
                        myCommand.ExecuteNonQuery();
                        sGender.Text = "";
                        myConnection.Close();
                    }
                    if (sClass.Text != "")
                    {
                        myConnection.Open();
                        int t = Convert.ToInt32(sClass.Text);
                        SqlCommand myCommand = new SqlCommand("UPDATE dbo.Students SET dbo.Students.Class = '" + t + "'WHERE dbo.Students.StudentNo = " + studentNo, myConnection);
                        myCommand.ExecuteNonQuery();
                        sClass.Text = "";
                        myConnection.Close();
                    }
                    if (sMajor.Text != "")
                    {
                        myConnection.Open();
                        String m = sMajor.Text;
                        SqlCommand myCommand = new SqlCommand("UPDATE dbo.Students SET dbo.Students.Major = '" + m + "'WHERE dbo.Students.StudentNo = " + studentNo, myConnection);
                        myCommand.ExecuteNonQuery();
                        tDept.Text = "";
                        myConnection.Close();
                    }
                    if (sStat.Text != "")
                    {
                        myConnection.Open();
                        Boolean s = Convert.ToBoolean(sStat.Text);
                        SqlCommand myCommand = new SqlCommand("UPDATE dbo.Students SET dbo.Students.Status = '" + s + "'WHERE dbo.Students.StudentNo = " + studentNo, myConnection);
                        myCommand.ExecuteNonQuery();
                        sStat.Text = "";
                        myConnection.Close();
                    }
                    MessageBox.Show("Student Updated Successfully");
                    sNo.Text = "";
                }
                catch (Exception er)
                {
                    MessageBox.Show("Invalid Input");
                    myConnection.Close();
                }

            }
            else
            {
                MessageBox.Show("Must enter valid Student No");
            }
        }
    }
}
