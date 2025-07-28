using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Univesity_Grade_Calculator
{
    public partial class Form1 : Form
    {
        private object tb_attendence;

        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tb_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(tb_attendance.Text=="" || tb_Final.Text == "" || tb_Mid.Text=="" ||tb_quiz1.Text=="" ||tb_quiz2.Text=="" || tb_quiz3.Text=="" || tb_quiz4.Text=="")
            {
                MessageBox.Show("Marking fields are left empty.");
            }
            else 
            {
            int inatt, finalatt, total, percentage,mid,final;
                float quizsum = 0;

                inatt = int.Parse(tb_attendance.Text);
            finalatt = (inatt * 100) / 42;
            lb_attendance.Text = finalatt.ToString();
            lb_attendance.Visible = true;
            mid = int.Parse(tb_Mid.Text);
            lb_mid.Text = mid.ToString() + "/25";
            lb_mid.Visible = true;
            final = int.Parse(tb_Final.Text);
            lb_Final.Text = final.ToString() + "/100";
            lb_Final.Visible = true;

            int quiz1, quiz2, quiz3, quiz4;
            quiz1 = int.Parse(tb_quiz1.Text);
            quiz2 = int.Parse(tb_quiz2.Text);
            quiz3 = int.Parse(tb_quiz3.Text);
            quiz4 = int.Parse(tb_quiz4.Text);
            int[] array = { quiz1, quiz2, quiz3, quiz4 };

            for (int i = 0; i <= 2; i++)
            {
                Array.Sort(array);
                Array.Reverse(array);
                quizsum += array[i];
            }
            lb_quiz.Text = quizsum.ToString()+"/40";
            lb_quiz.Visible = true;

            total =  mid + int.Parse(quizsum.ToString()) + final;
            lb_total.Text = total.ToString() + "/165";
            lb_total.Visible = true;
            percentage = (total * 100) / 165;

            if (percentage >= 80)
                lb_Grade.Text = "A+";
            else if (percentage >= 75 && percentage <= 79)
                lb_Grade.Text = "A";
            else if (percentage >= 70 && percentage <= 74)
                lb_Grade.Text = "A-";
            else if (percentage >= 65 && percentage <= 69)
                lb_Grade.Text = "B+";
            else if (percentage >= 64 && percentage <= 60)
                lb_Grade.Text = "B";
            else if (percentage >= 55 && percentage <= 59)
                lb_Grade.Text = "B-";
            else if (percentage >= 50 && percentage <= 54)
                lb_Grade.Text = "C+";
            else if (percentage >= 45 && percentage <= 49)
                lb_Grade.Text = "C";
            else if (percentage >= 40 && percentage <= 44)
                lb_Grade.Text = "D";
            else
                lb_Grade.Text = "F";

            lb_Grade.Visible = true;


            lb_displayresult.Text = tb_Name.Text +" - student id "+ tb_studentID.Text + "\nobtained " + percentage.ToString() + "% marks in " +tb_semester.Text+" Semester.";
            lb_displayresult.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tb_attendance.Text = "";
            tb_Final.Text = "";
            tb_Mid.Text = "";
            tb_Name.Text = "";
            tb_quiz1.Text = "";
            tb_quiz2.Text = "";
            tb_quiz3.Text = "";
            tb_quiz4.Text = "";
            tb_semester.Text = "";
            tb_studentID.Text = "";
            lb_attendance.Text = "";
            lb_displayresult.Text = "";
            lb_Final.Text = "";
            lb_Grade.Text = "";
            lb_mid.Text = "";
            lb_quiz.Text = "";
            lb_total.Text = "";
           
        }

        private void tb_attendance_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {


            SqlConnection conn = new SqlConnection(@"Data Source=AHSAN-KHAN\SQLEXPRESS;Initial Catalog=MySql;Integrated Security=True;");
            try
            {
              conn.Open();
                string query = "INSERT INTO Student(studentID, name, Mid, Total_quiz, Semester, total_attendance, Final, SemesterTotal, Grade) VALUES (@studentID, @name, @Mid, @Total_quiz, @Semester, @total_attendance, @Final, @SemesterTotal, @Grade)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", tb_studentID.Text);
                cmd.Parameters.AddWithValue("@name", tb_Name.Text);
                cmd.Parameters.AddWithValue("@Semester", tb_semester.Text);
                cmd.Parameters.AddWithValue("@Mid", tb_Mid.Text);
                cmd.Parameters.AddWithValue("@Total_quiz", lb_quiz.Text);
                cmd.Parameters.AddWithValue("@Final", tb_Final.Text); 
                cmd.Parameters.AddWithValue("@SemesterTotal", lb_total.Text);
                cmd.Parameters.AddWithValue("@Grade", lb_Grade.Text);
                cmd.Parameters.AddWithValue("@total_attendance", tb_attendance.Text);

                cmd.ExecuteNonQuery();
                conn.Close ();


                MessageBox.Show("Data is Saved", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tb_studentID_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_Mid_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_Final_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_semester_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
