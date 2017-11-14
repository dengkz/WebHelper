<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebHelperTest.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="/css/bootstrap.min.css">    <script src="https://cdn.bootcss.com/jquery/1.12.4/jquery.min.js"></script>    <script src="/js/bootstrap.min.js" type="text/javascript"></script>

    <script>

        $('#myTabs a').click(function (e) {
            e.preventDefault()
            $(this).tab('show')
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--<button type="button" class="btn btn-primary" data-loading-text="Loading...">Loading state</button>


        <a href="#" data-toggle="tooltip" title="first tooltip">hover over me</a>
        <button type="button" class="btn btn-primary" data-loading-text="Loading...">Loading state</button>


        <br /><br />--%>

        <div style="margin-top:4px;">
          <ul class="nav nav-tabs" role="tablist">
            <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">人员</a></li>
            <li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">岗位</a></li>
            <li role="presentation"><a href="#messages" aria-controls="messages" role="tab" data-toggle="tab">权限</a></li>
          </ul>

          <!-- Tab panes -->
          <div class="tab-content">
            <div role="tabpanel" class="tab-pane active" id="home">
                 <table  class='table table-bordered table-hove'>
                    <tr>
                        <td>1</td>
                        <td>2</td>
                    </tr>
                </table>
                <div  class="padlr" align="right">
　　<ul id="data-pagination" class="pagination">
   　　<li  class="disabled"><a href="#">&laquo;</a></li>
      <li class="active"><a href="#">1</a></li>
      <li><a href="#">2</a></li>
      <li><a href="#">3</a></li>
      <li><a href="#">4</a></li>
      <li><a href="#">5</a></li>
      <li><a href="#">&raquo;</a></li>
   </ul>
</div>
            </div>
            <div role="tabpanel" class="tab-pane" id="profile">岗位</div>
            <div role="tabpanel" class="tab-pane" id="messages">权限</div>
          </div>

        </div>

        <br /><br /><br /><br />
        <div class="row show-grid">
                  <div class="col-md-2">.col-md-8</div>
                  <div class="col-md-8">.col-md-4</div>
                </div>
    </div>
    </form>
</body>
</html>
