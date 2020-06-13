<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Excel.aspx.cs" Inherits="EmpAttendance.Excel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <h2 style="font-weight:bold; color:black;background-color:bisque;">Attendance From Excel Sheet</h2>

    <div style="margin-top:30px; background-color:bisque;">
        <asp:FileUpload ID="FileUpload1" runat="server" Style="background-color:beige; font-weight:bold" /> 
        <br />
        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" Style="background-color:beige; width:100px; font-weight:bold;margin-left:10px;" BackColor="#99FF99"/>
        <br />
        <asp:Label ID="Label1" runat="server" Text="" Style="font-style:italic; color:maroon;margin-left:300px;"></asp:Label>
    </div>
    <br /><br />

    <div style="background-image:url(imagesb.jpg);background-size:cover; margin-top:0px;">
    <asp:GridView ID="GridView1" runat="server"  AlternatingRowStyle-BackColor="#ffffff" AlternatingRowStyle-ForeColor="#996633"  Style="margin-left:100px; border:2px black solid; font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif"
        RowStyle-BackColor="#ccffff" HeaderStyle-Font-Size="Large" >

    </asp:GridView>

    </div>
    <br /> <br />

    <asp:Button ID="btnInsert" runat="server" Text="Insert Data" OnClick="btnInsert_Click" />


</asp:Content>
