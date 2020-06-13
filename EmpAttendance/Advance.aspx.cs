using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace EmpAttendance
{
    public partial class Contact : Page
    {
        SqlConnection con;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPDBCS"].ConnectionString);
            cmd = new SqlCommand();
            cmd.Connection = con;
            if (!IsPostBack)
            {
                LoadEmpID();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Insert into Adtrans" + "(Eid, AdDate, AdAmount, Remark) values (@Eid, @AdDate, @AdAmount, @Remark)", con);
            cmd.Parameters.AddWithValue("@AdDate", txtdate.Text);
            cmd.Parameters.AddWithValue("@Eid", DDlEmpID.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@AdAmount", txtAamount.Text);
            cmd.Parameters.AddWithValue("@Remark", txtRemark.Text);
            con.Open();

            int i = cmd.ExecuteNonQuery();

            con.Close();

            if (i != 0)
            {
                Response.Write("<script>alert('Record Inserted in the table')</script>");
            }
            else
            {
                Response.Write("<script>alert('Record Insertion failed in the table')</script>");
            }
        }

        private void LoadEmpID()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPDBCS"].ConnectionString);
            cmd = new SqlCommand("Select Eid, Ename from Employee", con);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DDlEmpID.DataSource = dt;
            DDlEmpID.DataBind();
            DDlEmpID.DataTextField = "Ename";
            DDlEmpID.DataValueField = "Eid";
            DDlEmpID.DataBind();
            con.Close();

        }
    }
}