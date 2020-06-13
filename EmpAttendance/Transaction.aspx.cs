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
    public partial class Transaction : System.Web.UI.Page
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
                DDlEmpID.Items.Add(new ListItem("--Select Employee--", ""));
                DDlEmpID.AppendDataBoundItems = true;
                String strConnString = ConfigurationManager
                     .ConnectionStrings["ASPDBCS"].ConnectionString;
                String strQuery = "select Eid from Advance";
                SqlConnection con = new SqlConnection(strConnString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                try
                {
                    con.Open();
                    DDlEmpID.DataSource = cmd.ExecuteReader();
                    DDlEmpID.DataTextField = "Eid";
                    DDlEmpID.DataValueField = "Eid";
                    DDlEmpID.DataBind();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            btnPay.Visible = true;
        }

        //private void LoadEmpID()
        //{
        //    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPDBCS"].ConnectionString);
        //    cmd = new SqlCommand("Select Eid from Advance", con);

        //    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adpt.Fill(dt);
        //    con.Open();
        //    DDlEmpID.DataSource = dt;
        //    DDlEmpID.DataBind();
        //    DDlEmpID.DataTextField = "Eid";
        //    DDlEmpID.DataValueField = "Eid";
        //    DDlEmpID.Items.Add(0, new ListItem("---Select Employee---", ""));
        //    DDlEmpID.DataBind();
        //    con.Close();
          

        //}

        protected void DDlEmpID_SelectedIndexChanged(object sender, EventArgs e)
        {
            String strConnString = ConfigurationManager
                            .ConnectionStrings["ASPDBCS"].ConnectionString;
            String strQuery = "select TDate,Amount,Remark  from Advance where" +
                              " Eid = @Eid";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Eid", DDlEmpID.SelectedItem.Value);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    txtdate.Text = sdr[0].ToString();
                    txtAmount.Text = sdr[1].ToString();
                    txtRemark.Text = sdr[2].ToString();                  
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
       {
            if(txtpayDate.Text.Length==0 || txtPayAmount.Text.Length==0)
            {
                Response.Write("<script>alert('Enter Date and Amount to Pay Advance')</script>");
            }

            else
            {

                cmd = new SqlCommand("Insert into EmpTransaction" + "(Eid, SDate, AdvancePay) values (@Eid, @SDate, @AdvancePay)", con);
                cmd.Parameters.AddWithValue("@SDate", txtpayDate.Text);
                cmd.Parameters.AddWithValue("@Eid", DDlEmpID.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@AdvancePay", txtPayAmount.Text);

                con.Open();

                int i = cmd.ExecuteNonQuery();

                con.Close();

                if (i != 0)
                {
                    Response.Write("<script>alert('Record Inserted in the table')</script>");

                    txtAmount.Text = txtdate.Text = txtPayAmount.Text = txtpayDate.Text = txtRemark.Text = DDlEmpID.SelectedValue = "";
                }
                else
                {
                    Response.Write("<script>alert('Record Insertion failed in the table')</script>");
                }
            }


            }

            

    }
}