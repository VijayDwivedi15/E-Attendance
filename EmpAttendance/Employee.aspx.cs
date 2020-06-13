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
    public partial class _Default : Page
    {
        SqlConnection con;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPDBCS"].ConnectionString);
          
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //@Eid ,@Ename, @EmpDept, @DOJ , @Salary, @EmpShift, @InTime, @OutTime, @Holiday, @Phone ,@Address
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPDBCS"].ConnectionString);
                SqlCommand cmd = new SqlCommand("Insert into Employee" + "(Eid, Ename,EmpDept,DOJ,Salary,EmpShift,Holiday,Phone,Address) values (@Eid, @Ename,@EmpDept,@DOJ,@Salary,@EmpShift,@Holiday,@Phone,@Address)", con);

                cmd.Parameters.AddWithValue("@Eid", EmpID.Text);
                cmd.Parameters.AddWithValue("@Ename", EmpName.Text);
                cmd.Parameters.AddWithValue("@EmpDept", EmpDept.Text);
                cmd.Parameters.AddWithValue("@DOJ", EmpDOJ.Text);
                cmd.Parameters.AddWithValue("@Salary", EmpSalary.Text);
                cmd.Parameters.AddWithValue("@EmpShift", ddlShift.SelectedItem.Text);
                //cmd.Parameters.AddWithValue("@InTime", ShiftIn.Text);
                //cmd.Parameters.AddWithValue("@OutTime", ShiftOut.Text);
                cmd.Parameters.AddWithValue("@Holiday", ddlholiday.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Phone", Empmob.Text);
                cmd.Parameters.AddWithValue("@Address", EmpAddress.Text);
                con.Open();
                cmd.ExecuteNonQuery();

                Response.Write("<script>alert(' Data Saved Successfully !!')</script>");
                con.Close();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert(' Data Not Saved !! Please try Again' )</script>");
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            EmpID.Text = EmpName.Text = EmpDept.Text = EmpDOJ.Text = EmpSalary.Text = Empmob.Text = EmpAddress.Text =  "";
            EmpID.Focus();
        }
    }
}