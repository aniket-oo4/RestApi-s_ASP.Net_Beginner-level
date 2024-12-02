<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="indexWithJQuery.aspx.cs"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <style type="text/css">
        .auto-style1 {
            width: 100%;
            background-color: #C0C0C0;
        }

        .auto-style2 {
            text-decoration: underline;
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
                        Create new Application<br />
                        <br />
                        Update LeaveApplication<br />
                        <br />
                        Delete LeaveApplication</td>
                    <td class="auto-style4" style="background-color: #FFFFFF; vertical-align: top;">
                        <h1>Hello 
                        </h1>
                        <asp:Label ID="lblDemo" Text="text" runat="server" />

                        <table  id="grdvLeaveApplications" hidden="hidden" style="color: Black; background-color: #CCCCCC; border-color: #999999; border-width: 3px; border-style: Solid; width: 1088px;">
                            <tr style="color: White; background-color: Black; font-weight: bold;">
                                <th scope="col">leaveId</th>
                                <th scope="col">empId</th>
                                <th scope="col">leaveType</th>
                                <th scope="col">applicationDate</th>
                                <th scope="col">leaveDateFrom</th>
                                <th scope="col">leaveDateTo</th>
                                <th scope="col">remark</th>
                                <th scope="col">status</th>
                                <th scope="col">totalLeaves</th>
                            </tr>
                            <tr style="background-color: White;">
                                <td>1</td>
                                <td>1</td>
                                <td>sick</td>
                                <td>21-08-2024 10:52:01</td>
                                <td>21-08-2024 10:52:01</td>
                                <td>21-08-2024 10:52:01</td>
                                <td>Reviewed</td>
                                <td>pending</td>
                                <td>0</td>
                            </tr>

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
<script src="Scripts/jquery-1.7.1.js"></script>
<script src="Scripts/jquery-1.7.1.min.js"></script>
<script src="Scripts/jquery-ui-1.8.20.js"></script>
<script src="Scripts/jquery-ui-1.8.20.min.js"></script>

    <script type="text/javascript">
         // using fetch method 
        var p = fetch("http://localhost:53842/api/LeaveApi",{mode:'no-cors'});
        p.then((response)=>{
            console.log(response.status)
           console.log(response.ok)
        return response.json()
        }).then((value)=>{
            console.log(value)
        });

    </script>
<script type="text/javascript">


    function Ok() {
        alert("Are you Ready");
        document.getElementById("grdvLeaveApplications").hidden = false;
    }

    $('#btnIndex'). on('click', function () {

        var $leaveApplications = $('#grdvLeaveApplications');
        if (document.getElementById("grdvLeaveApplications").hidden) {
            document.getElementById("grdvLeaveApplications").hidden = false;
       
            $.ajax(
                {
                    type: 'GET',
                    headers: {"Authorization": "Bearer " + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhbmlrZXQiLCJyb2xlIjoiYW5pa2V0IiwiZXhwIjoiMjAyNC0wOC0yOFQwNjoxMTo1MS4yMzgxMzA5KzAwOjAwIn0.2oAsIMvcDbiWQXx3tUgctPuh_8Gk5tyQ2H0dSVGTjbw"},
                    url: 'http://localhost:53842/api/LeaveApi',
                    success: function (leaves) {
                        console.log('sucess', leaves);
                        if (!leaves.IsSuccess)
                            alert(leaves.ErrorList);
                        var data = leaves.Data;  <%--  Js is Strictly case sensitive   --%>
                    console.log(data);
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
        }

    });   

</script>
</html>

