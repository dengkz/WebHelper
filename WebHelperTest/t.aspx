<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="t.aspx.cs" Inherits="WebHelperTest.t" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <link rel="stylesheet" href="/css/bootstrap.min.css">    <script src="https://cdn.bootcss.com/jquery/1.12.4/jquery.min.js"></script>    <script src="/js/bootstrap.min.js" type="text/javascript"></script>

<script type="text/javascript">            
      function initTable() {  
        //先销毁表格  
        $('#cusTable').bootstrapTable('destroy');  
        //初始化表格,动态从服务器加载数据  
        $("#cusTable").bootstrapTable({  
            method: "get",  //使用get请求到服务器获取数据  
            url: "<c:url value='/SellServlet?act=ajaxGetSellRecord'/>", //获取数据的Servlet地址  
            striped: true,  //表格显示条纹  
            pagination: true, //启动分页  
            pageSize: 1,  //每页显示的记录数  
            pageNumber:1, //当前第几页  
            pageList: [5, 10, 15, 20, 25],  //记录数可选列表  
            search: false,  //是否启用查询  
            showColumns: true,  //显示下拉框勾选要显示的列  
            showRefresh: true,  //显示刷新按钮  
            sidePagination: "server", //表示服务端请求  
            //设置为undefined可以获取pageNumber，pageSize，searchText，sortName，sortOrder  
            //设置为limit可以获取limit, offset, search, sort, order  
            queryParamsType : "undefined",   
            queryParams: function queryParams(params) {   //设置查询参数  
              var param = {    
                  pageNumber: params.pageNumber,    
                  pageSize: params.pageSize,  
                  orderNum : $("#orderNum").val()  
              };    
              return param;                   
            },  
            onLoadSuccess: function(){  //加载成功时执行  
              layer.msg("加载成功");  
            },  
            onLoadError: function(){  //加载失败时执行  
              layer.msg("加载数据失败", {time : 1500, icon : 2});  
            }  
          });  
      }  
  
      $(document).ready(function () {          
          //调用函数，初始化表格  
          initTable();  
  
          //当点击查询按钮的时候执行  
          $("#search").bind("click", initTable);  
      });  
</script>  

</head>
<body>
    

    <table class="table table-hover" id="cusTable"  
       data-pagination="true"  
       data-show-refresh="true"  
       data-show-toggle="true"  
       data-showColumns="true">  
       <thead>  
          <tr>                                                           
              <th  data-field="sellRecordId" data-sortable="true">  
                           销售记录id  
              </th>  
              <th data-field="srNumber" >  
                           销售单号  
              </th>  
              <!-- 在此省略表格列的代码，代码和上面差不多 -->  
              <th class="col-xs-2" data-field="action" data-formatter="actionFormatter" data-events="actionEvents">Action</th>     
          </tr>  
           <tr>
               <td>1</td>
               <td>2</td>
               <td>3</td>
           </tr>
       </thead>  
       <tbody>  
       </tbody>  
</table>  





</body>
</html>
