using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace EmpAttendance
{
    public partial class Excel : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        string conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            con= new SqlConnection(ConfigurationManager.ConnectionStrings["ASPDBCS"].ConnectionString);
        }



        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFiles)
            {
                HttpPostedFile selectedfile = FileUpload1.PostedFile;
                string fileExtension = Path.GetExtension(selectedfile.FileName);

                string path = Path.GetFileName(FileUpload1.FileName);
                path = path.Replace(" ", "");
                if (fileExtension == ".xls" || fileExtension == ".xlsx" || fileExtension == ".xlsm" || fileExtension == "..xlsb")
                {
                    FileUpload1.SaveAs(Server.MapPath("~/ExcelFile/") + path);
                    String ExcelPath = Server.MapPath("~/ExcelFile/") + path;
                    OleDbConnection mycon = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False");
                    mycon.Open();
                    OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", mycon);
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    mycon.Close();
                    Label1.Text = "File Has Been Saved and Data Captured";
                }
                else
                {
                    Response.Write("<script>alert('Select Only Excel File for Upload !!')</script>");
                }

            }

            else
            {
                Response.Write("<script>alert('Select Any File for Upload !!')</script>");
            }
        }



        //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView1.PageIndex = e.NewPageIndex;
        //   this.GridView1.DataBind();
        //}



        protected void btnInsert_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                foreach (GridViewRow g1 in GridView1.Rows)
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPDBCS"].ConnectionString);
                    //cmd = new SqlCommand("INSERT INTO EAttend(EmpId, AttDate, InTime, OutTime) VALUES( '" + g1.Cells[0].Text + "', ' " + g1.Cells[1].Text + "','" + g1.Cells[2].Text + "','" + g1.Cells[3].Text + "')", con);
                    cmd = new SqlCommand("FileAttend", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //cmd = new SqlCommand("Insert into Empl" + "(EmpId, AttDate, InTime, OutTime) values (@EmpId, @AttDate,@InTime, @OutTime)", con);
                    cmd.Parameters.AddWithValue("@EmpId", g1.Cells[0].Text);
                    cmd.Parameters.AddWithValue("@AttDate", g1.Cells[1].Text);
                    cmd.Parameters.AddWithValue("@InTime", g1.Cells[2].Text);
                    cmd.Parameters.AddWithValue("@OutTime", g1.Cells[3].Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    GridView1.Visible = false;
                    GridView1.EnableViewState = false;
                    con.Close();
                   
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Something Wrong !!! Please check your Data')</script>");

                //Response.Write(ex.Message);
            }
          
        }

    }
}


