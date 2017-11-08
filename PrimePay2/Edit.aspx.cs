using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace PrimePay2
{
    //This is the code for the page where the contacts are edited.
    public partial class Edit : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        string qryStr;
        SqlDataReader read;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Only load the values the first loading of the page.
            if (!IsPostBack)
            {
                conn = new SqlConnection("user id=LAPTOP\\David;" +
                                           "server=LAPTOP\\SQLEXPRESS;" +
                                           "Trusted_Connection=yes;" +
                                           "database=Contacts; " +
                                           "connection timeout=30");
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    first_name.Text = ex.ToString();
                }
                qryStr = "select * from People where id = @id";
                cmd = new SqlCommand(qryStr, conn);
                cmd.Parameters.AddWithValue("@id", Default.changeID);
                read = cmd.ExecuteReader();
                read.Read();
                first_name.Text = read["first_name"].ToString();
                last_name.Text = read["last_name"].ToString();
                email.Text = read["email"].ToString();
                phone.Text = read["phone_num"].ToString();
                conn.Close();
            }
        }
        protected void submitEventMethod(object sender, EventArgs e)
        {
            //The if statement checks to see if all feilds have a value.
            if (first_name.Text.Length == 0 || last_name.Text.Length == 0 || email.Text.Length == 0 || phone.Text.Length == 0)
            {
                errorDiv.InnerText = "All fields must be filled in";
            }
            else
            {
                conn = new SqlConnection("user id=LAPTOP\\David;" +
                                               "server=LAPTOP\\SQLEXPRESS;" +
                                               "Trusted_Connection=yes;" +
                                               "database=Contacts; " +
                                               "connection timeout=30");
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    first_name.Text = ex.ToString();
                }
                string fName = first_name.Text;
                string lName = last_name.Text;
                string emailStr = email.Text;
                string phone_num = phone.Text;

                qryStr = "update People set first_name = @fName, last_name = @lName, email = @email, phone_num = @phone_num where id = @id";
                cmd = new SqlCommand(qryStr, conn);
                cmd.Parameters.AddWithValue("@id", Default.changeID);
                cmd.Parameters.AddWithValue("@fName", fName);
                cmd.Parameters.AddWithValue("@lName", lName);
                cmd.Parameters.AddWithValue("@email", emailStr);
                cmd.Parameters.AddWithValue("@phone_num", phone_num);
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("Default.aspx", true);
            }
        }

        protected void cancelEventMethod(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", true);
        }

    }
}