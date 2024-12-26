using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Drawing;
//using System.Data.SqlClient;



namespace DataBaseGui
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=DESKTOP-9NCDMII;Initial Catalog=university;Integrated Security=True;trust server certificate=true;";

        public Form1()
        {
            InitializeComponent();
        }


        private void label2_Click(object sender, EventArgs e)  //email error notice that 
        {


        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string querey = "insert into studentss (ssn,student_name,student_email,student_address,student_birthDate )values(@ssn,@name,@email,@address,@birthdate )";
                //string querey = "insert into studentss values( textBox1.Text,namefield.Text,emailfield.Text,addressfield.text, birthdatefield.Text)";
                SqlCommand cmd = new SqlCommand(querey, conn);
                cmd.Parameters.AddWithValue("@ssn", textBox1.Text);
                cmd.Parameters.AddWithValue("@name", namefield.Text);
                cmd.Parameters.AddWithValue("@email", emailfield.Text);
                cmd.Parameters.AddWithValue("@address", addressfield.Text);
                cmd.Parameters.AddWithValue("@birthdate", birthdatefield.Text);
      
               
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("new student addded successfully");
                fetchstudents();




            }

        }

        private void fetchstudents()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string querey = "select * from studentss";
               // string querey = "select * from students";
                SqlDataAdapter adapter = new SqlDataAdapter(querey, con);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fetchstudents();
          
        }

         

          
         

        private void deletebtn_Click(object sender, EventArgs e)

        {
            
            using (SqlConnection conn = new SqlConnection(connectionString)) { 
                if (dataGridView1.SelectedRows.Count > 0)
            {
                int ssn = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ssn"].Value);
                string querey = "delete from studentss where ssn=@ssnd";
                    SqlCommand cmd = new SqlCommand(querey, conn);
                    cmd.Parameters.AddWithValue("@ssnd",ssn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

               
                    //test
                    fetchstudents();


            }
            }

        }
    }
}
