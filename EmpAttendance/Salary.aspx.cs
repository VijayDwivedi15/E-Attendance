using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;
using System.IO;


namespace EmpAttendance
{
    public partial class Salary : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPDBCS"].ConnectionString);
            cmd = new SqlCommand();
            cmd.Connection = con;
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                ViewState["dt"] = dt;

                LoadEmpID();
                BindGridView();
                LoadMonth();

            }
           

        }

        private void LoadEmpID()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPDBCS"].ConnectionString);
            cmd = new SqlCommand("Select distinct Eid, Ename from GrandSal order by Eid ", con);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            ddlEmpid.DataSource = dt;
            ddlEmpid.DataBind();
            ddlEmpid.DataTextField = "Ename";
            ddlEmpid.DataValueField = "Eid";
            ddlEmpid.DataBind();
            ddlEmpid.Items.Insert(0, new ListItem("---All Employee---", ""));
          
            con.Close();

        }


        protected void BindGridView()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select Eid,Ename, Salary, AttDate, TotalAttendance_OfMonth, Total_OverTimeSalary, Advance,AdvancePay,RemainAdvance, GrandSalary from GrandSal order by Eid", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "GrandSal");
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }

        protected void ddlEmpid_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPDBCS"].ConnectionString);
            con.Open();
            if(ddlEmpid.SelectedValue!="")
            {
                SqlCommand cmd = new SqlCommand("Select Eid,Ename, Salary, AttDate, TotalAttendance_OfMonth, Total_OverTimeSalary,Advance,AdvancePay,RemainAdvance, GrandSalary from GrandSal where Eid= @Eid order by Eid", con);
                cmd.Parameters.AddWithValue("@Eid", ddlEmpid.SelectedValue);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
             
            }

           
            else
            {
                cmd = new SqlCommand("Select Eid,Ename, Salary, AttDate, TotalAttendance_OfMonth, Total_OverTimeSalary,Advance,AdvancePay,RemainAdvance, GrandSalary from GrandSal order by Eid", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            con.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        private void LoadMonth()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPDBCS"].ConnectionString);
            cmd = new SqlCommand("Select distinct AttDate from GrandSal", con);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            ddlmonth.DataSource = dt;
            ddlmonth.DataBind();
            ddlmonth.DataTextField = "AttDate";
            ddlmonth.DataValueField = "AttDate";
            ddlmonth.DataBind();
            ddlmonth.Items.Insert(0, new ListItem("---Select Month---", ""));
            con.Close();
        }

        protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPDBCS"].ConnectionString);
            con.Open();
            if (ddlmonth.SelectedValue != "")
            {
                SqlCommand cmd = new SqlCommand("Select Eid,Ename, Salary, AttDate, TotalAttendance_OfMonth, Total_OverTimeSalary,Advance,AdvancePay,RemainAdvance, GrandSalary from GrandSal where AttDate=@AttDate order by Eid", con);
                cmd.Parameters.AddWithValue("@AttDate", ddlmonth.SelectedValue);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }


            else
            {
                cmd = new SqlCommand("Select Eid,Ename, Salary, AttDate, TotalAttendance_OfMonth, Total_OverTimeSalary,Advance,AdvancePay,RemainAdvance, GrandSalary from GrandSal order by Eid", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            con.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView1.PageIndex = e.NewPageIndex;
            this.BindGridView();


        }


        protected void ExportToExcel(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                GridView1.AllowPaging = false;
                this.BindGridView();

                GridView1.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in GridView1.HeaderRow.Cells)
                {
                    cell.BackColor = GridView1.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridView1.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridView1.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                GridView1.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           
            try
            {
                int Eid = int.Parse(GridView1.Rows[e.RowIndex].Cells[0].Text);
                decimal AdAmount = decimal.Parse(((TextBox)GridView1.Rows[e.RowIndex].Cells[6].Controls[0]).Text);
                decimal AdvancePay = decimal.Parse(((TextBox)GridView1.Rows[e.RowIndex].Cells[7].Controls[0]).Text);
                

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPDBCS"].ConnectionString);
                SqlCommand cmd = new SqlCommand("AdvancePay", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Eid", Eid);
                cmd.Parameters.AddWithValue("@Advance", AdAmount);
                cmd.Parameters.AddWithValue("@AdvancePay", AdvancePay);
                con.Open();
                cmd.ExecuteNonQuery();
                GridView1.DataBind();
                BindGridView();
                con.Close();

                //cmd.Connection = con;

                //cmd = new SqlCommand("Update EditSalary set AdvancePay='" + AdvanceP.Text + "' where Eid='" + Eid.Text + "'", con);
                ////cmd.CommandText = "Update EditSalary set AdvancePay='" + AdvanceP.Text + "' where Eid='" + Eid.Text + "'";
                ////cmd.Connection = con;

                //con.Open();
                //cmd.ExecuteNonQuery();
                //con.Close();
                //GridView1.EditIndex = -1;
                //BindGridView();

            }

            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}