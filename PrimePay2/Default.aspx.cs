using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace PrimePay2
{
    //This is the code for the main page where all the contacts are displayed
    public partial class Default : System.Web.UI.Page
    {   
        SqlConnection conn;
        SqlCommand cmd;
        string qryStr;
        SqlDataReader read;
        public static int lastID = 1;
        public static string changeID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            generateTable();
        }
        protected void generateTable()
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
                Console.WriteLine(ex.ToString());
            }
            qryStr = "select * from People";
            cmd = new SqlCommand(qryStr, conn);
            read = cmd.ExecuteReader();
            //While there is information in the reader it is inserted into an asp table
            while (read.Read())
            {
                TableCell t1 = new TableCell();
                t1.Text = read["first_name"].ToString();
                TableCell t2 = new TableCell();
                t2.Text = read["last_name"].ToString();
                TableCell t3 = new TableCell();
                t3.Text = read["email"].ToString();
                TableCell t4 = new TableCell();
                t4.Text = read["phone_num"].ToString();
                TableCell change = new TableCell();
                Button buttonChange = new Button();
                buttonChange.Text = "Edit";
                buttonChange.ID = "change_" + read["id"].ToString();
                buttonChange.Click += new EventHandler(ChangeEvent);
                change.Controls.Add(buttonChange);
                TableCell delete = new TableCell();
                Button buttonDelete = new Button();
                buttonDelete.Text = "Delete";
                buttonDelete.ID = "delete_" + read["id"].ToString();
                buttonDelete.OnClientClick = "return confirm('Are you sure you wish to delete?');";
                buttonDelete.Click += new EventHandler(DeleteEvent);
                delete.Controls.Add(buttonDelete);
                TableRow row = new TableRow();
                row.Controls.Add(t1);
                row.Controls.Add(t2);
                row.Controls.Add(t3);
                row.Controls.Add(t4);
                row.Controls.Add(change);
                row.Controls.Add(delete);
                contactList.Controls.Add(row);
                lastID = (int)read["id"];
            }
            lastID++;

            conn.Close();
        }
        protected void addEventMethod(object sender, EventArgs e) {
            Response.Redirect("Add.aspx", true);
        }
        private void DeleteEvent(object sender, EventArgs e)
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
                Console.WriteLine(ex.ToString());
            }
            //The unique id of the contact is stored as part of the ID and is extracted here.
            Button b = (Button)sender;
            string idStr = b.ID.Substring(b.ID.IndexOf('_') + 1);
            qryStr = "delete from People where id = @id";
            cmd = new SqlCommand(qryStr, conn);
            cmd.Parameters.AddWithValue("@id", idStr);
            cmd.ExecuteNonQuery();
            conn.Close();
            contactList.Controls.Clear();
            generateTable();
        }
        private void ChangeEvent(object sender, EventArgs e)
        {
            //The unique id of the contact is stored as part of the ID and is extracted here.
            Button b = (Button)sender;
            changeID = b.ID.Substring(b.ID.IndexOf('_') + 1);
            Response.Redirect("Edit.aspx", true);
        }
    }
}