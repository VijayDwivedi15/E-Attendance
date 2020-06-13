<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Advance.aspx.cs" Inherits="EmpAttendance.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="color:black; font-weight:bold; background-color:bisque; ">Create Advance </h2>
   
    <div style="background-image:url(imagesb.jpg);background-size:cover;" >

    <table style="margin-left:350px;background-image:url(imagesb.jpg);background-size:cover;">
        <tr>
            <td><h4 style="font-weight:bold">Employee Name</h4></td>
            <td>
                <asp:DropDownList ID="DDlEmpID" runat="server" Style="margin-left:80px" Width="250px"></asp:DropDownList>
            </td>
        </tr>


         <tr>
            <td><h4 style="font-weight:bold">Advance Date</h4></td>
            <td>
                <asp:TextBox ID="txtdate" runat="server" Style="margin-left:80px" Width="250px" TextMode="Date"  ></asp:TextBox> 
                
                <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="txtdate" ForeColor="Red" SetFocusOnError="true" 
                ErrorMessage="Select Date" Font-Bold="true" Display="Dynamic"></asp:RequiredFieldValidator>

           </td>
        </tr>
        
         <tr>
            <td><h4 style="font-weight:bold">Advance Amount</h4></td>
            <td>
                <asp:TextBox ID="txtAamount" runat="server" Style="margin-left:80px" Width="250px" ></asp:TextBox> 
             <asp:RequiredFieldValidator ID="rvfAmount" runat="server" ControlToValidate="txtAamount" ForeColor="Red" SetFocusOnError="true" 
                ErrorMessage="Amount Requiered" Font-Bold="true" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
        </tr>

        <tr>
            <td><h4 style="font-weight:bold">Remark</h4></td>
            <td>
                <asp:TextBox ID="txtRemark" runat="server" Style="margin-left:80px" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvRemark" runat="server" ControlToValidate="txtRemark" ForeColor="Red" SetFocusOnError="true" 
                ErrorMessage="Remark Requiered" Font-Bold="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
            
        </tr>

        </table>

     <asp:Button ID="btnSubmit" runat="server" Text="Submit" Style="margin-left:500px;margin-top:20px;font-weight:bold;background-color:burlywood; border:groove 2px black;" Width="157px"  BackColor="White" Font-Bold="True" ForeColor="Maroon" Height="35px" OnClick="btnSubmit_Click"  />

        </div>
</asp:Content>
