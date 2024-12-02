<%@ Page Language="C#" Async="true" MasterPageFile="~/SecuredFolders/Leave.Master" AutoEventWireup="true" CodeBehind="AddNew.aspx.cs" Inherits="LeaveAppServerSideUIApp.SecuredFolders.AddNew" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <h1>This is  Add new application </h1>
    <p>
        <asp:Literal ID="ltrMessage" runat="server"></asp:Literal>
    </p>




    <%--   Details Panel --%>
    <asp:Panel ID="Panel1" runat="server">
        <div id="details" class="row g-3" style=" margin:20%; text-align:center;justify-content:center; width: 40%; border: 2px solid blue; border-radius: 13px; background-color: white; margin-top: 10px">
            <div class="col-md-8">
                <label for="txtEmpId" class="form-label">Employee Id</label>
                <asp:TextBox CssClass="form-control" ID="txtEmpId" runat="server"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="rqfvEmpId" runat="server" ControlToValidate="txtEmpId" ErrorMessage="Employee Id Cannot be empty" ForeColor="Red"></asp:RequiredFieldValidator>

                <asp:RegularExpressionValidator ID="rgexEmpId" runat="server" ControlToValidate="txtEmpId" ErrorMessage="Emp id must be a numeric value" ForeColor="Red" ValidationExpression="^-?\d+$"></asp:RegularExpressionValidator>

            </div>


            <div class="col-8">
                <label for="txtLeaveType" class="form-label">LEave Type</label><asp:TextBox ID="txtLeaveType" runat="server" CssClass="form-control"></asp:TextBox>
                <br />
                <label class="form-label" for="txtApplicationDate">
                leaveDateFrom</label>
                <asp:TextBox CssClass="form-control" ID="txtLeaveDateFrom" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="rqfvLeaveDateFrom" runat="server" ControlToValidate="txtLeaveDateFrom" ErrorMessage="Leave Date From Can't be null" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="col-8">
                <label for="txtApplicationDate" class="form-label">leaveDateTo</label>
                <asp:TextBox CssClass="form-control" ID="txtleaveDateTo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqfvLeaveDateTo" runat="server" ControlToValidate="txtleaveDateTo" ErrorMessage="Leave Date To Can't be null" ForeColor="Red"></asp:RequiredFieldValidator>

            </div>

            <div class="col-6">
                <label for="txtRemark" class="form-label">Remark</label>
                <asp:TextBox CssClass="form-control" ID="txtRemark" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqfvRemark" runat="server" ControlToValidate="txtRemark" ErrorMessage="Remark must be filled " ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-6">
                <label for="inputState" class="form-label">Status</label>
                <asp:DropDownList ID="ddlStatus" CssClass="form-select" runat="server">
                    <asp:ListItem Value="Pending"> Pending</asp:ListItem>
                    <asp:ListItem Value="Approved"> Approved</asp:ListItem>
                    <asp:ListItem Value="Declined"> Declined</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rqfvStatus" runat="server" ControlToValidate="ddlStatus" ErrorMessage="please choose status" ForeColor="Red"></asp:RequiredFieldValidator>

            </div>

            <div class="col-8">
                <asp:Button ID="btnAddLeave" CssClass="btn btn-dark btn-sm" runat="server" Text="Apply For Leave" OnClick="btnAddLeave_Click" />
            </div>
        </div>

    </asp:Panel>

    </center>

</asp:Content>
