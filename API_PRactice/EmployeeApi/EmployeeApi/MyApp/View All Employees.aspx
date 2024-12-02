<%@ Page   Async="true" MasterPageFile="~/MyApp/Employee.Master" Language ="C#" AutoEventWireup="true" CodeBehind="View All Employees.aspx.cs" Inherits="EmployeeApi.MyApp.View_All_Employees" %>




<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">


    <asp:DropDownList ID="ddlEmp" runat="server"></asp:DropDownList>

    <br />
    <br />
&nbsp;&nbsp;
    <asp:GridView ID="grdvEmp" runat="server" Width="1051px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>

</asp:Content>