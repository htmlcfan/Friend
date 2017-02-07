$(function () {
   //异步加载显示典型信息
   initList();
   //添加信息
   AddList();
   //修改信息
   UpdateList();
   InitDictItem();
   //搜索框
   $('#divtoolbar').appendTo('.datagrid-toolbar');
   //加载搜索功能
   InitSearch();
});
//异步加载显示典型信息
function initList(queryData) {
   $('#grid').datagrid({
       url: bgAdmin+'/Admin/GetAll?r=' + Math.random(),//数据接收URL地址
      iconCls: 'icon-view',//图标
      fit: true,//自动适屏功能
      nowrap: true,
      autoRowHeight: false,//自动行高
      striped: true,
      collapsible: true,
      //sortName: 'Id',//排序列名为ID
      sortOrder: 'asc',//排序为将序
      remoteSort: false,
      idField: 'ID',//主键值
      pagination: true,//启用分页
      rownumbers: true,//显示行号
      multiSort: true,//启用排序 sortable: true //启用排序列
      queryParams: queryData, //搜索条件查询
      singleSelect:true,
      columns: [[
          { field: 'ck', checkbox: true, width: 50, align: 'left', rowspan:1 },
          { field: 'ID', title: 'ID', width: 50, sortable: true },
          { field: 'UserName', title: '用户名', width: 100, sortable: true },
          { field: 'Password', title: '密码', width: 100, sortable: true },
      ]],
      rowStyler: function (index, row) {
         if (index % 2 == 0) {
            return 'background-color:#F0F5FC;'
         } else {
            return 'background-color:#ffffff;'
         }
      },
      toolbar: [{
         id: 'btnadd',
         text: '添加',
         iconCls: 'icon-add',
         handler: function () {
            $('#AddDialog').dialog('open').dialog('setTitle', '添加信息');
         }
      }, '-', {
         id: 'btnedit',
         text: '修改',
         iconCls: 'icon-edit',
         handler: function () {
            var RowUpdateByID = $('#grid').datagrid('getSelections');
            if (RowUpdateByID.length == 1) {
               //实现绑定数据显示
               BindUpdateList();
               $("#UpdateDialog").dialog('open').dialog('setTitle', '修改信息');
            }
            else {
               $.messager.alert("友情提示！", "每次只能修改一条，你已经选择了<font color='red'  size='6'>" + RowUpdateByID.length + "</font>条");
            }
         }
      }, '-', {
         id: 'btndel',
         text: '删除',
         iconCls: 'icon-remove',
         handler: function () {
            var RowDeleteByID = $('#grid').datagrid("getSelections");
            if (RowDeleteByID.length == 1) {
               $.messager.confirm("删除信息", "您确认删除该条信息吗？", function (deleteClient) {
                  if (deleteClient) {
                      $.post(bgAdmin + "/Admin/Delete?r=" + Math.random(), { Id: RowDeleteByID[0].Id }, function (data) {
                        if (data == "OK") {
                           $.messager.alert("系统提示！", "删除成功");
                           //这里要将上次删除的Id清空，否则下次再删除的时候会报错
                           RowDeleteByID.length = "";
                           $("#grid").datagrid('reload') //重新刷新整个页面
                        }
                        else {
                           $.messager.alert("系统提示！", "删除失败");
                        }
                     });
                  }
               });
            }
            else {
               $.messager.alert("友情提示！", "每次只能删除一行，你已经选择了<font color='red' size='6'>" + RowDeleteByID.length + "</font>行");
            }
         }
      }, '-',
      //{
      //   id: 'btndelall',
      //   text: '批量删除',
      //   iconCls: 'icon-no',
      //   handler: function () {
      //      var RowDeleteByID = $('#grid').datagrid("getSelections");
      //      if (RowDeleteByID.length >= 1) {
      //         $.messager.confirm("批量删除信息", "您确认批量删除信息吗？", function (deleteAllClient) {
      //            if (deleteAllClient) {
      //               //遍历出用户选择的数据的信息，这就是用户用户选择删除的用户ID的信息
      //               var ids = "";   //1,2,3,4,5
      //               for (var i = 0; i < RowDeleteByID.length; i++) {
      //                  //异步将删除的ID发送到后台，后台删除之后，返回前台，前台刷新表格
      //                  ids += RowDeleteByID[i].Id + ",";
      //               }
      //               //最后去掉最后的那一个,
      //               ids = ids.substring(0, ids.length - 1);
      //               $.post("/Admin/DeleteALL?r=" + Math.random(), { Ids: ids }, function (data) {
      //                  if (data == "OK") {
      //                     $.messager.alert("系统提示！", "批量删除成功,一共删除了<font color='red' size='6'>" + RowDeleteByID.length + "</font>行");
      //                     //这里要将上次批量删除的Id清空，否则下次再批量删除的时候会报错
      //                     RowDeleteByID.length = "";
      //                     $("#grid").datagrid('reload') //批量重新刷新整个页面
      //                  }
      //                  else {
      //                     $.messager.alert("系统提示！", "批量删除失败");
      //                  }
      //               });
      //            }
      //         });
      //      }
      //      else {
      //         $.messager.alert("友情提示！", "请选择你要批量删除的数据！");
      //      }
      //   }
      //},

      //'-',
      //{
      //   id: 'btndetails',
      //   text: '详情',
      //   iconCls: 'icon-table',
      //   handler: function () {
      //      var RowDetailByID = $('#grid').datagrid('getSelections');
      //      if (RowDetailByID.length == 1) {
      //         //实现绑定数据显示
      //         BindDetailList();
      //         $("#DetailDialog").dialog('open').dialog('setTitle', '详细信息');
      //      }
      //      else {
      //         $.messager.alert("友情提示！", "每次只能修改一条，你已经选择了<font color='red'  size='6'>" + RowDetailByID.length + "</font>条");
      //      }
      //   }
      //},

      '-', {
         id: 'btnreload',
         text: '刷新',
         iconCls: 'icon-reload',
         handler: function () {
            $("#grid").datagrid("reload");
         }
      },

      //'-', {
      //   id: 'btnExport',
      //   text: '导出Excel',
      //   iconCls: 'icon-excel',
      //   handler: function () {
      //      ExportExcel();
      //   }
      //}
      ]
   });
}

//初始化搜索框
function InitSearch() {
   $("#btnSearch").searchbox({
      width: 300,
      iconCls: 'icon-save',
      searcher: function (value, name) {
         $('#grid').datagrid('options').queryParams.search_text = name;
         $('#grid').datagrid('options').queryParams.search_value = value;
         $('#grid').datagrid('reload');
      },
      prompt: '请输入要查询的信息'
   });
}

//异步实现添加信息
function AddList() {
   $("#btnAdd").click(function () {
      //在前台对用户输入的信息做判断，不符合要求时“添加用户”就不能提交给后台
      var valid = $("#addForm").form('validate');
      if (valid == false) {
         return false;
      }
      var postData = $("#addForm").serializeArray();
      //Ajax异步实现加载
      $.ajax({
          url: bgAdmin+"/Admin/Create?r=" + Math.random(),
         data: postData,
         type: "post",
         success: function (data) {
            if (data == "OK") {
               $.messager.alert("系统提示！", "添加成功");
               $('#AddDialog').dialog('close');
               $("#grid").datagrid("reload");
               $("#addForm").form("clear")
            }
            else {
               $.messager.alert("系统提示！", "添加失败");
            }
         }
      })
   });
};
//绑定修改Div中的信息控件
function BindUpdateList() {
   var RowEditById = $("#grid").datagrid('getSelections')[0];
           $("#txtIDUpdate").val(RowEditById.ID);
           $("#txtUserNameUpdate").val(RowEditById.UserName);
           $("#txtPasswordUpdate").val(RowEditById.Password);
}
//异步实现修改信息,btnUpdate
function UpdateList() {
   var RowUpdateByID = $('#grid').datagrid('getSelections');
   //首先执行加载绑定数据显示在页面上面
   $("#btnUpdate").click(function () {
      //在前台验证用户提交的信息是否符合要求，若不合要求不提交
      var valid = $("#updateForm").form('validate');
      if (valid == false) {
         return false;
      }
      var postUpdate = $("#updateForm").serializeArray();//构造参数发送给后台
      //实现异步修改数据
      $.post(bgAdmin + "/Admin/Edit?r=" + Math.random(), postUpdate, function (data) {
         if (data == "OK") {
            $.messager.alert("系统提示！", "修改成功");
            $("#UpdateDialog").dialog('close');
            $("#grid").datagrid("reload");
         }
         else {
            $.messager.alert("系统提示！", "修改失败，请您检查");
         }
      });
   });
};
//异步绑定详情的的时候显示数据
function BindDetailList() {
   //把用户选中的ID发送到后台，后台根据接收的ID查询出的详细信息
   var RowDetailById = $("#grid").datagrid('getSelections')[0];
            $("#txtUserNameDetail").val(RowDetailById.UserName);
            $("#txtPasswordDetail").val(RowDetailById.Password);
}

function InitDictItem() {

};

function ExportExcel() {
   // 返回grid的所有可见行给后端供导出Excel用
   var rows = $('#grid').datagrid("getRows");
   if (rows.length == 0) {
      $.messager.alert("系统提示！", "没有数据可供导出");
      return;
   }
   //导出Excel方法
   var name = $('#grid').datagrid('options').queryParams.search_text;
   var value = $('#grid').datagrid('options').queryParams.search_value;
   var filename = "/FileManager.ashx?action=exportexcel&Type=Admin&Query=" + name + "|" + value;
   location.href = filename;
}
