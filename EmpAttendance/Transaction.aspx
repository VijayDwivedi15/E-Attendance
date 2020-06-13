<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Transaction.aspx.cs" Inherits="EmpAttendance.Transaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <h2 style="color:black; font-weight:bold; background-color:bisque; "> Advance Transaction</h2>
   
    <div style="background-image:url(imagesb.jpg);background-size:cover;" >

    <table style="margin-left:350px;background-size:cover;">
        <tr>
            <td><h4 style="font-weight:bold">Employee Name</h4></td>
            <td>
                <asp:DropDownList ID="DDlEmpID" runat="server" Style="margin-left:80px" Width="250px" OnSelectedIndexChanged="DDlEmpID_SelectedIndexChanged"></asp:DropDownList>

                 <asp:RequiredFieldValidator ID="rfvEmpID" runat="server" ControlToValidate="DDlEmpID" ForeColor="Red" SetFocusOnError="true" 
                ErrorMessage="Select Employee ID" Font-Bold="true" Display="Dynamic"></asp:RequiredFieldValidator>

            </td>
        </tr>


         <tr>
            <td><h4 style="font-weight:bold">Advance Date</h4></td>
            <td>
                <asp:TextBox ID="txtdate" runat="server" Style="margin-left:80px" Width="250px" ReadOnly="true" ></asp:TextBox> 
                
               

           </td>
        </tr>
        
         <tr>
            <td><h4 style="font-weight:bold">Advance Amount</h4></td>
            <td>
                <asp:TextBox ID="txtAmount" runat="server" Style="margin-left:80px" Width="250px" ReadOnly="true" ></asp:TextBox> 
            
                </td>
        </tr>

        <tr>
            <td><h4 style="font-weight:bold">Remark</h4></td>
            <td>
                <asp:TextBox ID="txtRemark" runat="server" Style="margin-left:80px" Width="250px" ReadOnly="true"></asp:TextBox>
                
            </td>
            
        </tr>

         <tr>
            <td><h4 style="font-weight:bold">Pay Date</h4></td>
            <td>
                <asp:TextBox ID="txtpayDate" runat="server" Style="margin-left:80px" Width="250px" TextMode="Date"></asp:TextBox>
                 
                <%--<asp:RequiredFieldValidator ID="rfvPayDate" runat="server" ControlToValidate="txtpayDate" ForeColor="Red" SetFocusOnError="true" 
                ErrorMessage="Select Date" Font-Bold="true" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                
            </td>
            
        </tr>

         <tr>
            <td><h4 style="font-weight:bold">Advance Pay Amount</h4></td>
            <td>
                <asp:TextBox ID="txtPayAmount" runat="server" Style="margin-left:80px" Width="250px"></asp:TextBox>
                 
               <%-- <asp:RequiredFieldValidator ID="rfvPayAmunt" runat="server" ControlToValidate="txtPayAmount" ForeColor="Red" SetFocusOnError="true" 
                ErrorMessage="Enter Amount to Pay " Font-Bold="true" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                
            </td>
            
        </tr>



        </table>

        <asp:Button ID="btnStatus" runat="server" Text="See Status" Style="margin-left:465px;margin-top:20px;font-weight:bold;background-color:burlywood; border:groove 2px black;" Width="157px"  BackColor="White" Font-Bold="True" ForeColor="Maroon" Height="35px" OnClick="btnSubmit_Click" />

        <asp:Button ID="btnPay" runat="server" Text="Pay Advance" Style="margin-left:50px;margin-top:20px;font-weight:bold;background-color:burlywood; border:groove 2px black;" Width="157px"  BackColor="White" Font-Bold="True" ForeColor="Maroon" Height="35px" OnClick="Button1_Click" Visible="false"/>

     

        </div>

</asp:Content>
