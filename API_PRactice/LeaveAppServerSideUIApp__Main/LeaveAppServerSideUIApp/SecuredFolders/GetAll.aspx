<%@ Page Language="C#" Async="true" MasterPageFile="~/SecuredFolders/Leave.Master" AutoEventWireup="true" CodeBehind="GetAll.aspx.cs" Inherits="LeaveAppServerSideUIApp.SecuredFolders.GetAll" %>

 
<asp:Content runat="server" ContentPlaceHolderID="MainContent">


        <h1>This is Get All Applicationns</h1>
        <h1>&nbsp;<asp:Literal ID="ltrMessage" runat="server" ></asp:Literal>
        </h1>


        <div >
        <asp:Button ID="btnDisplayAll" runat="server" Text="DisplayAll" OnClick="btnDisplayAll_Click" style="height: 35px" />
            <asp:GridView  CssClass="table table-hover" ID="grdvLeaveApplications" runat="server" Width="910px" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle CssClass="table-dark" BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
    </div>
 

    </asp:Content>