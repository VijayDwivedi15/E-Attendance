<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Salary.aspx.cs" Inherits="EmpAttendance.Salary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h2 style="color:black; font-weight:bold; background-color:bisque; ">All Employee Salary</h2>

    <div style="background-image:url(imagesb.jpg);background-size:cover; margin-top:30px;">

       <b style="margin-left:200px;">Filter By -</b>

        <asp:DropDownList ID="ddlEmpid" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlEmpid_SelectedIndexChanged" 
            BackColor="#CCFFCC" Font-Bold="True" ForeColor="#663300" Height="35px" Width="150px" style="margin-left:70px">
           
        </asp:DropDownList>

         
         <asp:DropDownList ID="ddlmonth" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlmonth_SelectedIndexChanged"
             BackColor="#CCFFCC" Font-Bold="True" ForeColor="#663300" Height="35px" Width="150px" style="margin-left:50px;">
           
              
        </asp:DropDownList>

        &nbsp &nbsp &nbsp &nbsp &nbsp
         
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="20" OnPageIndexChanging="GridView1_PageIndexChanging" 
            OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting"
            Style="margin-left:20px; margin-top:30px;  border: 2px groove black;" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="#990000">

            <PagerStyle BackColor="#FFCCFF" BorderColor="Black" BorderStyle="Groove" BorderWidth="2px" />

            <RowStyle ForeColor="#333300" BackColor="#ccffcc" Font-Bold="true"/>
                <AlternatingRowStyle BackColor="#ffffff" ForeColor="#663300" />
            
                <Columns>
                    <asp:BoundField HeaderText="Employee ID " DataField="Eid" ItemStyle-HorizontalAlign="Center" ReadOnly="true" ItemStyle-Font-Bold="true" ControlStyle-ForeColor="#663300" ControlStyle-BackColor="#ccffcc" ControlStyle-Font-Bold="true" ControlStyle-Font-Size="X-Large" >
<ControlStyle BackColor="#CCFFCC" Font-Bold="True" Font-Size="X-Large" ForeColor="#663300"></ControlStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="True"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Employee Name " DataField="Ename" ItemStyle-Font-Bold="true" ReadOnly="true" ControlStyle-Font-Bold="true" >
                    
<ControlStyle Font-Bold="True"></ControlStyle>

<ItemStyle Font-Bold="True"></ItemStyle>
                    </asp:BoundField>
                    
                   <%-- <asp:BoundField HeaderText="Department" DataField="EmpDept" />--%>
                    
                    <asp:BoundField HeaderText="Month" DataField="AttDate" ReadOnly="true" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true" ControlStyle-Font-Bold="true">
<ControlStyle Font-Bold="True"></ControlStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="True"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Fixed Salary" DataField="Salary" ReadOnly="true" ControlStyle-Font-Bold="true" >
<ControlStyle Font-Bold="True"></ControlStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="No. of Present" DataField="TotalAttendance_OfMonth" ReadOnly="true" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true" ControlStyle-Font-Bold="true">
<ControlStyle Font-Bold="True"></ControlStyle>

<ItemStyle HorizontalAlign="Center" Font-Bold="True"></ItemStyle>
                    </asp:BoundField>
                     <asp:BoundField HeaderText="OverTime_Money" DataField="Total_OverTimeSalary" ReadOnly="true" ItemStyle-Font-Bold="true" ControlStyle-Font-Bold="true">
<ControlStyle Font-Bold="True"></ControlStyle>


                         <ItemStyle Font-Bold="True"></ItemStyle>
                    </asp:BoundField>
                     <asp:BoundField HeaderText="Advance" DataField="Advance" ReadOnly="true" ItemStyle-Font-Bold="true" ControlStyle-Font-Bold="true" >

                         <ItemStyle Font-Bold="True"></ItemStyle>
                    </asp:BoundField>
                     <asp:BoundField HeaderText="Pay Advance" DataField="AdvancePay" ItemStyle-Font-Bold="true" ControlStyle-Font-Bold="true" >

                         <ItemStyle Font-Bold="True"></ItemStyle>
                    </asp:BoundField>
                     <asp:BoundField HeaderText="Advance Remain" ReadOnly="true" DataField="RemainAdvance" ItemStyle-Font-Bold="true" ControlStyle-Font-Bold="true" >

<ItemStyle Font-Bold="True"></ItemStyle>
                    </asp:BoundField>
                     <asp:BoundField HeaderText="Grand Salary" DataField="GrandSalary" ReadOnly="true" ItemStyle-Font-Bold="true" ControlStyle-Font-Bold="true" >
                    
                 
<ControlStyle Font-Bold="True"></ControlStyle>

<ItemStyle Font-Bold="True"></ItemStyle>
                    </asp:BoundField>

                     <asp:CommandField ShowEditButton="true" ButtonType="Link" ControlStyle-ForeColor="#0066ff" />
                    
                     <asp:TemplateField>
                        <ItemTemplate>


           
            <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are You sure of deleting the record?')"/>

                           

                        </ItemTemplate>

                    </asp:TemplateField>

                 
                </Columns>


        </asp:GridView>

         <br />
    <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick = "ExportToExcel" Style="margin-left:100px; background-color:moccasin; color:darkblue; font:italic;" />

    </div>
    <script type='text/javascript' >
        $(function () {
            $('#ddlEmpid').ufd({ log: true });
        });    
    </script>
  
</asp:Content>
