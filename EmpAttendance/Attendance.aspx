<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="EmpAttendance.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <h2 style="font-weight:bold; color:black;background-color:bisque;">Employee Attendance </h2>
    
    <div style="background-image:url(imagesb.jpg);background-size:cover;" >

    <table style="margin-left:350px; background-image:url(imagesb.jpg);background-size:cover; margin-top:20px;">
        <tr>
            <td><h4 style="font-weight:bold">Employee Name</h4></td>
            <td>
                <asp:DropDownList ID="DDlEmpID" runat="server" Style="margin-left:80px" Width="250px">
                   <asp:ListItem Value="0">---Select Employee---</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>


         <tr>
            <td><h4 style="font-weight:bold">Date</h4></td>
            <td>
                <asp:TextBox ID="txtdate" runat="server" Style="margin-left:80px" Width="250px" TextMode="Date" ></asp:TextBox> 
               <%-- <asp:ImageButton ID="ImgDate" runat="server" ImageUrl="~/icon/calendar_view_week.png" OnClick="ImgDate_Click" />
                <asp:Calendar ID="Clddate" runat="server" Visible="False" PrevMonthText=""  OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender" OnVisibleMonthChanged="Calendar1_VisibleMonthChanged" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" Width="330px" >
                    <DayHeaderStyle BackColor="#FFFF99" Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                    <DayStyle BackColor="#CCCCCC" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                    <TodayDayStyle BackColor="#999999" ForeColor="White"  />

                </asp:Calendar>--%>

                <%--  <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="txtdate" ForeColor="Red" SetFocusOnError="true" 
                ErrorMessage="Select Date" Font-Bold="true" Display="Dynamic"></asp:RequiredFieldValidator>--%>

            </td>
        </tr>
       
         <tr>
            <td><h4 style="font-weight:bold">In-Time</h4></td>
            <td>
                <asp:TextBox ID="txtIn" runat="server" Style="margin-left:80px" Width="250px" TextMode="Time"></asp:TextBox> 

                  <%--<asp:RequiredFieldValidator ID="rfvInTime" runat="server" ControlToValidate="txtIn" ForeColor="Red" SetFocusOnError="true" 
                ErrorMessage="Enter In-Time" Font-Bold="true" Display="Dynamic"></asp:RequiredFieldValidator>--%>

            </td>
        </tr>

        <tr>
            <td><h4 style="font-weight:bold">Out-Time</h4></td>
            <td>
                <asp:TextBox ID="txtOut" runat="server" Style="margin-left:80px" Width="250px" TextMode="Time"></asp:TextBox></td>
        </tr>

        </table>

    <asp:Button ID="btnSubmit" runat="server" Text="Submit" Style="margin-left:500px;margin-top:20px;font-weight:bold;background-color:burlywood; border:groove 2px black;" Width="157px"  BackColor="White" Font-Bold="True" ForeColor="Maroon" Height="35px" OnClick="btnSubmit_Click" />

        </div>

    <div style="margin-left:30px">
    <asp:FileUpload ID="FileUpload1" runat="server" />

    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Upload File</asp:LinkButton>

    <br /> <br />

    <asp:Button ID="Button1" runat="server" Text="Save File " Visible="false" OnClick="Button1_Click" />

       <%-- <asp:GridView ID="GridView1" runat="server" Style="margin-top:50px; margin-left:50px"></asp:GridView>--%>
        
        </div>

</asp:Content>
