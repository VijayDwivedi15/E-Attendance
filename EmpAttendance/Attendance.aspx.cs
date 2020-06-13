using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using System.Text;

namespace EmpAttendance
{
    public partial class About : Page
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
            cmd = new SqlCommand("EmpAttend", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Date", txtdate.Text);
            cmd.Parameters.AddWithValue("@Eid", DDlEmpID.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@InTime", txtIn.Text);
            cmd.Parameters.AddWithValue("@OutTime", txtOut.Text);
            con.Open();

            int i = cmd.ExecuteNonQuery();

            con.Close();

            if (i != 0)
            {
                Response.Write("<script>alert('Record updated  in the table')</script>");
            }
            else
            {
                Response.Write("<script>alert('Record updation failed in the table')</script>");
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPDBCS"].ConnectionString);
            con.Open();

            StreamReader reader = new StreamReader(Server.MapPath(ViewState["file"].ToString()));
            string line = string.Empty;
            string[] lines = new string[5];

            while ((line = reader.ReadLine()) != null)//reading file line by line
            {
                lines = line.Split('\n');//spliting each line by comma sign
                                         //saving into database
                SqlCommand cmd = new SqlCommand();
              
                cmd.CommandText = "insert into TextAttend values(@EmpID,@Ename,@Date,@InTime,@OutTime)";
                cmd.Connection = con;
                cmd.Parameters.Add("@EmpID", SqlDbType.NVarChar, 50).Value = lines[0];
                cmd.Parameters.Add("@Ename", SqlDbType.NVarChar, 50).Value = lines[1];
                cmd.Parameters.Add("@Date", SqlDbType.Date).Value = lines[2];
                cmd.Parameters.Add("@InTime", SqlDbType.Time).Value = lines[3];
                cmd.Parameters.Add("@OutTime", SqlDbType.Time).Value = (lines[4]);

                cmd.ExecuteNonQuery();
            }
            Response.Write("Record Saved");
            //reading file end
            con.Close();//closing connection to database
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //saving file uploaded file in root directory of application
            FileUpload1.PostedFile.SaveAs(Server.MapPath(FileUpload1.FileName));
            ViewState["file"] = FileUpload1.FileName;
            FileUpload1.Visible = false;
            LinkButton1.Visible = false;
            Button1.Visible = true;
        }

        //protected void ImgDate_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (Clddate.Visible)
        //        Clddate.Visible = false;
        //    else
        //        Clddate.Visible = true;
        //}

        //protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        //{
        //    txtdate.Text = Clddate.SelectedDate.ToShortDateString();
        //    Clddate.Visible = false;
        //}

        //protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        //{
        //    if (e.Day.Date < DateTime.Now || e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
        //    {
        //        e.Day.IsSelectable = false;
        //        e.Cell.ForeColor = System.Drawing.Color.Red;
        //    }
        //}

        //protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        //{
        //    if (e.NewDate.Month == DateTime.Now.Month && e.NewDate.Year == DateTime.Now.Year)

        //        Clddate.PrevMonthText = "";
        //    else
        //        Clddate.PrevMonthText = "&lt;";
        //}



    }
}