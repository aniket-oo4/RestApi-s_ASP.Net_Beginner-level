<%@ Page  Async="true" Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="LeaveApplicationAPI.DemoUI.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <style type="text/css">
        .auto-style1 {
            width: 100%;
            background-color: #C0C0C0;
        }
        .auto-style2 {            text-decoration: underline;
            color: #3333CC;
            text-align: center;
            font-size: x-small;
        }
        .auto-style4 {
            height: 590px;
        }
        .auto-style5 {
            text-decoration: underline;
            text-align: center;
        }
        .auto-style6 {
            height: 590px;
            width: 179px;
            text-align: center;
        }
        .auto-style8 {
            font-size: x-large;
            text-decoration: underline;
        }
        .auto-style9 {
            height: 4px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style9" colspan="2" style="background-color: #CCCCFF">
                    <h2 class="auto-style5" style="background-color: #CCCCFF; ">&nbsp;&nbsp;&nbsp; Welcome To Leave Application Manager</h2>
                </td>
            </tr>
            <tr>
                <td class="auto-style6" style="vertical-align: top; background-color: #FFFFCC;">
                    <br />
                    <br />
                    <span class="auto-style8"><strong>Menus</strong></span>&nbsp;&nbsp;<br />
                    <br />
                    <br />
                    <asp:Button ID="btnDisplayAllApplications" runat="server" Text="View All Leave Applications" OnClick="btnDisplayAllApplications_Click" />
                    <br />
                    <br />
                    <asp:LinkButton ID="lnkJqueryPage" runat="server" PostBackUrl="~/DemoUI/indexWithJQuery.aspx">GoForJQuery</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="lnkSelectById" runat="server" PostBackUrl="~/DemoUI/SelectByIdUI.aspx">Select By Id </asp:LinkButton>
                    <br />
                    Search LeaveApplication<br />
                    <br />
                    Create new Application<br />
                    <br />
                    Update LeaveApplication<br />
                    <br />
                    Delete LeaveApplication</td>
                <td class="auto-style4" style="background-color: #FFFFFF; vertical-align: top;">
                    <h1>Hello 
                          </h1>
                    <asp:Label ID="lblDemo" Text="text" runat="server" />
                        <asp:GridView ID="grdvLeaveApplications" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Width="1088px">
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
                  


                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2"><strong>@Rights Reserved&nbsp; 2024 byAniket</strong></td>
            </tr>
        </table>
    </div>
    </form>
</body>

    <script type="text/javascript">    
        $(document).ready(function () {
            console.log("hello world !!");
            alert("Are you REady");
        }
        );
    </script>
</html>
