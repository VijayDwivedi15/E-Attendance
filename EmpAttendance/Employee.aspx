<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="EmpAttendance._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2 style="font-weight:bold;color:black;background-color:bisque">Add New Employee </h2>
       
    </div>

    <div style="margin-top:35px;background-image:url(imagesb.jpg);background-size:cover; width:100%; height:100%">
        <table style="margin-left:350px; ">
    <tr>
        <td><h4 style="font-weight:bold">Employee ID</h4></td>
        <td>
            <asp:TextBox ID="EmpID" runat="server" Style="margin-left:80px" Width="250px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="rfvID" runat="server" ControlToValidate="EMPID" ForeColor="Red" SetFocusOnError="true" 
                ErrorMessage="Employee ID Requiered" Font-Bold="true" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>

    <tr>
        <td><h4 style="font-weight:bold">Employee Name</h4></td>
        <td><asp:TextBox ID="EmpName" runat="server" Style="margin-left:80px" Width="250px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rvfName" runat="server" ControlToValidate="EmpName" ForeColor="Red" SetFocusOnError="true" 
                ErrorMessage="Name Can't be empty" Font-Bold="true" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>

    <tr>
        <td><h4 style="font-weight:bold"> Department</h4></td>
        <td><asp:TextBox ID="EmpDept" runat="server" Style="margin-left:80px" Width="250px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rvfDept" runat="server" ControlToValidate="EmpDept" ForeColor="Red" SetFocusOnError="true" 
                ErrorMessage="Enter Department" Font-Bold="true" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>

    <tr>
        <td><h4 style="font-weight:bold">Date Of Join</h4></td>
        <td><asp:TextBox ID="EmpDOJ" runat="server" Style="margin-left:80px" Width="250px" TextMode="Date" ></asp:TextBox>
             <asp:RequiredFieldValidator ID="rvfDOB" runat="server" ControlToValidate="EmpDOJ" ForeColor="Red" SetFocusOnError="true" 
                ErrorMessage="Select Joining Date" Font-Bold="true" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>

    <tr>
        <td ><h4 style="font-weight:bold"> Fixed Salary</h4></td>
        <td><asp:TextBox ID="EmpSalary" runat="server" Style="margin-left:80px" Width="250px"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rvfSalary" runat="server" ControlToValidate="EmpSalary" ForeColor="Red" SetFocusOnError="true" 
                ErrorMessage="Salary Requiered" Font-Bold="true" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>


     <tr>
        <td><h4 style="font-weight:bold">Employee Shift</h4></td>
        <td>
            <asp:DropDownList ID="ddlShift" runat="server" Style="margin-left:80px" Width="250px">
                <asp:ListItem Value="0">--Select Shift---</asp:ListItem>
                    <asp:ListItem>Day (8 AM-8 PM)</asp:ListItem>
                    <asp:ListItem >Night(8 PM-8 AM)</asp:ListItem>
                    <asp:ListItem >General(8 AM-5 PM)</asp:ListItem>
                     <asp:ListItem >Office(10 AM-6 PM)</asp:ListItem>
            </asp:DropDownList>

            <asp:RequiredFieldValidator ID="rfvShift" runat="server" ControlToValidate="ddlShift" ForeColor="Red" SetFocusOnError="true" 
                ErrorMessage="Select Shift" Font-Bold="true" Display="Dynamic"></asp:RequiredFieldValidator>

        </td>
    </tr>

     

    <tr>
        <td><h4 style="font-weight:bold">Fixed Holiday</h4></td>
        <td>
            <asp:DropDownList ID="ddlholiday" runat="server" Style="margin-left:80px" Width="250px">
               <asp:ListItem Value="0">--Select Day---</asp:ListItem>
                    <asp:ListItem >Sunday</asp:ListItem>
                    <asp:ListItem >Monday</asp:ListItem>
                    <asp:ListItem >Tuesday</asp:ListItem>
                    <asp:ListItem >Wednesday</asp:ListItem>
                   <asp:ListItem >Thusday</asp:ListItem>
                   <asp:ListItem >Friday</asp:ListItem>
                   <asp:ListItem >Saturday</asp:ListItem>
                </asp:DropDownList>

            <asp:RequiredFieldValidator ID="rfvHoliday" runat="server" ControlToValidate="ddlholiday" ForeColor="Red" SetFocusOnError="true" 
                ErrorMessage="Select Day" Font-Bold="true" Display="Dynamic"></asp:RequiredFieldValidator>
             
        </td>
    </tr>

    <tr>
        <td><h4 style="font-weight:bold">Contact No</h4></td>
        <td><asp:TextBox ID="Empmob" runat="server" Style="margin-left:80px" Width="250px"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfvmob" runat="server" ControlToValidate="Empmob" ForeColor="Red" SetFocusOnError="true" 
                ErrorMessage="Enter Contact No." Font-Bold="true" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>

    <tr>
        <td><h4 style="font-weight:bold">Address</h4></td>
        <td><asp:TextBox ID="EmpAddress" runat="server" Style="margin-left:80px" Width="250px"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="EmpAddress" ForeColor="Red" SetFocusOnError="true" 
                ErrorMessage="Enter Address" Font-Bold="true" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>

    <tr>
        <td colspan="2"> <asp:Button ID="btnSubmit" runat="server" Text="Submit" Style="margin-left:100px;margin-top:20px;font-weight:bold;background-color:burlywood; border:groove 2px black;" Width="157px"  BackColor="White" Font-Bold="True" ForeColor="Maroon" Height="35px" OnClick="btnSubmit_Click" />

            <asp:Button ID="btnReset" runat="server" Text="Reset" Style="margin-left:50px;font-weight:bold;background-color:burlywood; border:groove 2px black;" Width="157px"  BackColor="White"  ForeColor="Maroon" Height="35px" OnClick="btnReset_Click"  />
        </td>

       
    </tr>


</table>
    </div>

</asp:Content>
