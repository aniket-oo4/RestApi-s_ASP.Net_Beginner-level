<%@ Page Language="C#" Async="true" MasterPageFile="~/SecuredFolders/Leave.Master" AutoEventWireup="true" CodeBehind="GetById.aspx.cs" Inherits="LeaveAppServerSideUIApp.SecuredFolders.GetById" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <h1>This is Get By Id  Page </h1>
    <p>
        <asp:Literal ID="ltrMessage" runat="server"></asp:Literal>
    </p>

    <!-- Button trigger modal -->

    <center>
<div class="col-md-3 " style="border:solid 2px black; display:flexbox; padding:20px;border-radius:10px">
    
        <div class="input-group input-group-sm mb-3" style="width:280px;">
            <span class="input-group-text" id="addon-wrapping">ID :</span>
            <asp:TextBox ID="txtLeaveId" runat="server" CssClass="form-control" placeholder="Leave Id" aria-label="Leave IS " aria-describedby="addon-wrapping" Width="30px"> </asp:TextBox>
           <asp:RequiredFieldValidator ID="rqfvLeaveId" runat="server" ErrorMessage="Leave Id Cannot Be Empty " ControlToValidate="txtLeaveId" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
    <asp:Button ID="btnSearchById" runat="server" Text="Search By Id"  class="btn btn-secondary btn-sm" OnClick="btnSearchById_Click"/>        
        
        <asp:ValidationSummary ID="vldId" runat="server" ShowMessageBox="True" />
        
  </div>

        <%--   Details Panel --%>
<asp:Panel ID="Panel1" runat="server">
        <div id="details" class="row g-3"  style="width:50%; border:2px solid blue;border-radius:13px;background-color:azure;margin-top:10px" >
  <div class="col-md-8" >
    <label for="txtEmpId" class="form-label">Employee Id</label>
<asp:TextBox CssClass="form-control"  ID="txtEmpId" runat="server"></asp:TextBox>

  </div>
  <div class="col-md-8">
    <label for="txtEmpName" class="form-label">Employee Name</label>
      <asp:TextBox CssClass="form-control"  ID="txtEmpName" runat="server"></asp:TextBox>
  </div>
  <div class="col-8">
    <label for="txtApplicationDate" class="form-label">Application Date</label>
<asp:TextBox CssClass="form-control"  ID="txtApplicationDate" runat="server"></asp:TextBox>
  </div>
  <div class="col-8">
    <label for="txtApplicationDate" class="form-label">leaveDateFrom</label>
<asp:TextBox CssClass="form-control"  ID="txtLeaveDateFrom" runat="server"></asp:TextBox>
  </div>
  <div class="col-8">
    <label for="txtApplicationDate" class="form-label">leaveDateTo</label>
<asp:TextBox CssClass="form-control"  ID="txtleaveDateTo" runat="server"></asp:TextBox>
  </div><br /><br />
  <div class="col-6">
    <label for="txtApplicationDate" class="form-label">Remark</label>
<asp:TextBox CssClass="form-control"  ID="txtRemark" runat="server"></asp:TextBox>
  </div>
  <div class="col-md-6">
    <label for="inputState" class="form-label">Status</label>
      <asp:DropDownList ID="ddlStatus" CssClass="form-select" runat="server">
          <asp:ListItem> Pending</asp:ListItem>
          <asp:ListItem> Approved</asp:ListItem>
          <asp:ListItem> Declined</asp:ListItem>
      </asp:DropDownList>
    
  </div>
  <div class="col-md-4">
    <label for="txtTotalLeaves" class="form-label">Total No of Leaves :</label><asp:Label ID="lblTotalLeaves" runat="server" Text=""></asp:Label>

  </div>
<div class="col-8">
    <button type="submit" class="btn btn-dark btn-sm">Update The Changes</button>
  </div>
</div>

</asp:Panel>        

        </center>





</asp:Content>
