<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectByIdUI.aspx.cs" Inherits="LeaveApplicationAPI.DemoUI.SelectByIdUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Enter Leave Id Here::<input type="text" id="LeaveId" />
            <input type="button" id="btnDisplayByid" value="Search by Id:" />
        </div>
        <br />
    </form>
</body>
<script src="../Scripts/jquery-1.7.1.js"></script>
<script type="text/javascript">

const myToken='eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhbmlrZXQiLCJyb2xlIjoiYW5pa2V0IiwiZXhwIjoiMjAyNC0wOS0wMlQwNjoxMjoyMi4zNzA3ODUrMDA6MDAifQ.0MwYCdJIgnLxnsAK1lPVAsMTCZAk8V0HAIGGmFfXzRI';

    $(document).ready(
        function(){
                
            var id=$('#LeaveId');
            $('#btnDisplayByid').click(function(){

                $.ajax({
                    type:'GET',
                    headers: {"Authorization": "Bearer " +myToken},
                    url:"http://localhost:53842/api/LeaveApi/"+id.val(),
                    datatype:'json',
                    success:function(data){
                           
                        var returnMsg="";
                        if (data.IsSuccess!=true) {
                              
                            console.log(data.returnMsg);
                            alert(data.ErrorList);
                        }
                        else{
                            var leave= data.Data;                               
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
