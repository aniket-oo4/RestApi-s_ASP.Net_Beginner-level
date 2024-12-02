<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JQueryHome.aspx.cs" Inherits="MyUI.JQueryHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.7.1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
         <div>
            <table id="tblLeaveApplications" class="auto-style1">
                <tr>
                    <td class="auto-style9" colspan="2" style="background-color: #CCCCFF">
                        <h2 class="auto-style5" style="background-color: #CCCCFF;">&nbsp;&nbsp;&nbsp; Welcome To Leave Application Manager</h2>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6" style="vertical-align: top; background-color: #FFFFCC;">
                        <br />
                        <br />
                        <span class="auto-style8"><strong>Menus</strong></span>&nbsp;&nbsp;<br />
                        <br />
                        <br />
                        <asp:Button ID="btnDisplayAllApplications" runat="server" Text="View All Leave Applications" />
                        <br />
                        <br />
                        <input id="btnIndex" type="button" value="Display" " /><br />
                        <br />
                        <br /> 
                        <input type="button" id="btnDisplayByid"  value="Search by Id:"/>
                        <input type="number" id="LeaveId"    style="width:50px;" />
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

                        <table cellspacing="2" cellpadding="4" rules="all" id="grdvLeaveApplications"  style="color: Black; background-color: #CCCCCC; border-color: #999999; border-width: 3px; border-style: Solid; width: 1088px;">
                      <%--      <tr style="color: White; background-color: Black; font-weight: bold;">
                                <th scope="col">leaveId</th>
                                <th scope="col">empId</th>
                                <th scope="col">leaveType</th>
                                <th scope="col">applicationDate</th>
                                <th scope="col">leaveDateFrom</th>
                                <th scope="col">leaveDateTo</th>
                                <th scope="col">remark</th>
                                <th scope="col">status</th>
                                <th scope="col">totalLeaves</th>
                            </tr>--%>


                        </table>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" colspan="2"><strong>@Rights Reserved&nbsp; 2024 byAniket</strong></td>
                </tr>
            </table>
        </div>
  
    </form>
</body>

    <script>
        $('#btnIndex').on('click', function () {

            var $leaveApplications = $('#grdvLeaveApplications');

            $.ajax(
                {
                    type: 'GET',
                    //headers: { "Authorization": "Bearer " + myToken },
                    url: 'http://localhost:61170/api/LeaveApplications/',
                    success: function (leaves) {
                        console.log('sucess', leaves);
                        if (!leaves.IsSuccess)
                            alert(leaves.ErrorList);
                        var data = leaves.Data;  <%--  Js is Strictly case sensitive   --%>
                    console.log(data);
                    $leaveApplications.empty();
                    $leaveApplications.append(
                       '<tr style="color: White; background-color: Black; font-weight: bold;">'
                                + '<th scope="col">leaveId</th>'
                               + '<th scope="col">empId</th>'
                               + ' <th scope="col">leaveType</th>'
                                + '<th scope="col">applicationDate</th>'
                               + ' <th scope="col">leaveDateFrom</th>'
                               + '<th scope="col">leaveDateTo</th>'
                               + ' <th scope="col">remark</th>'
                               + '<th scope="col">status</th>'
                                + '<th scope="col">totalLeaves</th>'
                            + '</tr>'

                        );
                    $.each(data, function (i, leave) {
                        $leaveApplications.append('<tr style=background-color: White;>'
                            + '<td>' + leave.leaveId + '</td>'
                            + '<td>' + leave.empId + '</td>'
                            + '<td>' + leave.leaveType + '</td>'
                            + '<td>' + leave.applicationDate + '</td>'
                            + '<td>' + leave.leaveDateFrom + '</td>'
                            + '<td>' + leave.leaveDateTo + '</td>'
                            + '<td>' + leave.remark + '</td>'
                            + '<td>' + leave.status + '</td>'
                             + '<td>' + leave.totalLeaves + '</td>' +
                            +'</tr>'
                            )
                    })

                }
            });


            });

    </script>
    <script>

        $(document).ready(
     function () {

         var id = $('#LeaveId');
         $('#btnDisplayByid').click(function () {

             $.ajax({
                 type: 'GET',
                 //headers: { "Authorization": "Bearer " + myToken },
                 url: "http://localhost:61170/api/LeaveApplications/" + id.val(),
                 datatype: 'json',
                 success: function (data) {

                     var returnMsg = "";
                     if (data.IsSuccess != true) {

                         console.log(data.returnMsg);
                         alert(data.ErrorList);
                     }
                     else {
                         var leave = data.Data;
                         document.write('<br/>'
                             + 'leaveId :' + leave.leaveId + '<br />'
                             + 'empId  :' + leave.empId + '<br/>'
                             + 'leaveType  :' + leave.leaveType + '<br />'
                             + 'applicationDate  :' + leave.applicationDate + '<br />'
                             + 'leaveDateFrom  :' + leave.leaveDateFrom + '<br />'
                             + 'leaveDateTo   :' + leave.leaveDateTo + '<br />'
                             + 'remark  :' + leave.remark + '<br />'
                             + 'status   :' + leave.status + '<br />'
                              + 'totalLeaves  :' + leave.totalLeaves + '<br />'
                             );
                     }
                 }
             });

         });


     }


     );
    </script>
</html>
