using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace PrimePay2
{
    //This is the code for the page where contacts are added.
    public partial class Add : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        string qryStr;

        protected void Page_Load(object sender, EventArgs e)
        {
 
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

                qryStr = "insert into People(id, first_name, last_name, email, phone_num) values(@id,@fName,@lName,@email,@phone_num)";
                cmd = new SqlCommand(qryStr, conn);
                cmd.Parameters.AddWithValue("@id", Default.lastID);
                cmd.Parameters.AddWithValue("@fName", fName);
                cmd.Parameters.AddWithValue("@lName", lName);
                cmd.Parameters.AddWithValue("@email", emailStr);
                cmd.Parameters.AddWithValue("@phone_num", phone_num);
                cmd.ExecuteNonQuery();
                conn.Close();
                //There is one more contact now so the lastID needs to increase by one.
                Default.lastID++;
                Response.Redirect("Default.aspx", true);
            }
        }
        protected void cancelEventMethod(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", true);
        }

    }
}