

<%@ Page Language="C#" MasterPageFile="~/SecuredFolder/Leave.Master" Async="true"  AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="FinalApp.SecuredFolder.Index" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">


  

    <div>
        <asp:Button ID="btnDisplayAll" runat="server" Text="DisplayAll" OnClick="btnDisplayAll_Click" style="height: 35px" />
            <asp:GridView ID="grdvLeaveApplications" runat="server" Width="910px" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
    </div>
 
    <asp:Button ID="btnMyDisplay" runat="server" Text="Button" OnClick="btnMyDisplay_Click" PostBackUrl="~/SecuredFolders/Index.aspx" />
    </asp:Content>

