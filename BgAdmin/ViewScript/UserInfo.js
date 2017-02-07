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
   InitCropper();
});
//异步加载显示典型信息
function initList(queryData) {
    $('#grid').datagrid({
        url: bgAdmin + '/UserInfo/GetAll?r=' + Math.random(),//数据接收URL地址
        iconCls: 'icon-view',//图标
        fit: true,//自动适屏功能
        nowrap: true,
        autoRowHeight: false,//自动行高
        striped: true,
        collapsible: true,
        //sortName: 'Id',//排序列名为ID
        sortOrder: 'asc',//排序为将序
        remoteSort: false,
        idField: 'UID',//主键值
        pagination: true,//启用分页
        rownumbers: true,//显示行号
        singleSelect:true,
        multiSort: true,//启用排序 sortable: true //启用排序列
        queryParams: queryData, //搜索条件查询
        columns: [[
            { field: 'ck', checkbox: true, width: 50, align: 'left', rowspan: 1 },
             {
                 field: 'Ope', title: '操作', width: 60, sortable: true, formatter: function (val, rec, index) {
                     var btn = '';
                     btn += '<a class="editcls" onclick="ShowDetail(\'' + rec.UID + '\')" href="javascript:void(0)">查看明细</a>';
                     return btn;
                 }
             },
            { title: '用户ID', field: 'UID', width: 50, sortable: true },
            { title: '姓名', field: 'NAME', width: 100, sortable: true },
            { title: '性别', field: 'SEX', width: 100, sortable: true },
            { title: '出生年月', field: 'DATA', width: 100, sortable: true },
            { title: '籍贯', field: 'PLACE', width: 100, sortable: true },
            { title: '民族', field: 'NATION', width: 100, sortable: true },
            { title: '身高', field: 'HEIGHT', width: 100, sortable: true },
          //  { field: 'IMG', title: 'IMG', width: 100, sortable: true },
          //  { field: 'HISTORY', title: 'HISTORY', width: 100, sortable: true },
            { title: '学历', field: 'EDUCATION', width: 100, sortable: true },
            { title: '毕业院校', field: 'SCHOOL', width: 100, sortable: true },
           // { title: '地址', title: 'ADDRESS', width: 100, sortable: true },
          //  { field: 'WORKT', title: 'WORKT', width: 100, sortable: true },
            { field: 'WORKPLACE', title: '工作单位', width: 150, sortable: true },
             { field: 'IMG', title: '图片', width: 150, sortable: true,hidden:true },
            { field: 'PHONE', title: '手机', width: 100, sortable: true },
            //{ field: 'INTEREST', title: 'INTEREST', width: 100, sortable: true },
            //{ field: 'OHEIGHT', title: 'OHEIGHT', width: 100, sortable: true },
            { field: 'OWORK', title: '职业', width: 100, sortable: true },
            //{ field: 'OINTEREST', title: 'OINTEREST', width: 100, sortable: true },
            //{ field: 'OSTRENGTH', title: 'OSTRENGTH', width: 100, sortable: true },
            //{ field: 'MIN', title: 'MIN', width: 100, sortable: true },
            //{ field: 'MAX', title: 'MAX', width: 100, sortable: true },
            //{ field: 'OWORKPLACE', title: 'OWORKPLACE', width: 100, sortable: true },
            //{ field: 'FAMILY', title: 'FAMILY', width: 100, sortable: true },
             { field: 'UserType', title: '审核', width: 100, sortable: true, formatter: function (val, rec) { if (val == 1) { return "通过"; } else if (val ==0) { return "未审核" } else { return "未通过" } } },
        ]],
        rowStyler: function (index, row) {
            if (index % 2 == 0) {
                return 'background-color:#F0F5FC;'
            } else {
                return 'background-color:#ffffff;'
            }
        },   
        toolbar: [
            {
                id: 'btnadd',
                text: '添加',
                iconCls: 'icon-edit',
                handler: function () {
                    $('#AddDialog').dialog('open').dialog('setTitle', '添加信息');
                }
            }, '-',
             {
                 id: 'btnadd',
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
             }, '-',
              {
                  id: 'btnUploadPic',
                  text: '上传图片',
                  iconCls: 'icon-photo_add',
                  handler: function () {
                    
                    //  $("#btnUploadPic").on("click", function () {

                          var RowUpdateByID = $('#grid').datagrid('getSelections');
                          if (RowUpdateByID.length <= 0) {
                              $.messager.alert("友情提示！", "请先选择一条记录！");
                              return;
                          }

                          if (RowUpdateByID.length > 1) {
                              $.messager.alert("友情提示！", "不能选择多条记录！");
                              return;
                          }


                          var $image = $('#image');

                          var UID = RowUpdateByID[0].UID;

                          console.log(UID);

                          //$("#uploadify").uploadify({
                          //    'swf': bgAdmin + '/Content/Uploadify/uploadify.swf',
                          //    'uploader': bgAdmin + '/UserInfo/UploadImg/',
                          //    'cancelImg': bgAdmin + '/Content/Uploadify/uploadify-cancel.png',
                          //    'folder': bgAdmin + '/Upload',
                          //    'queueID': 'fileQueue',
                          //    'auto': true,
                          //    'multi': false,
                          //    'fileTypeDesc': 'Image Files',
                          //    'fileTypeExts': '*.gif; *.jpg; *.png; *.bmp',
                          //    'buttonText': '选择图片',
                          //    'buttonClass': 'easyui-linkbutton',
                          //    'onUploadSuccess': function (file, data, response) {
                          //        console.log(data);
                          //        console.log(file);
                          //        console.log(response);
                          //        data = eval('(' + data + ')');
                          //        $(".trZome").show();
                          //        $(".trZomeSmallPic").hide();
                          //        $image.one('built.cropper', function () {
                          //        }).cropper('reset').cropper('replace', bgAdmin+"/Upload/" + data.data + "?r=" + Math.random());
                          //    },
                          //    'onUploadStart': function (file) {
                          //        $("#uploadify").uploadify("settings", "formData", { 'UID': UID });
                          //        //在onUploadStart事件中，也就是上传之前，把参数写好传递到后台。  
                          //    }
                          //});

                          $('#UpLoadPicDialog').dialog('open').dialog('setTitle', '上传图片');
                          $(".trZome").hide();
                          $(".trZomeSmallPic").hide();
                          $("#demo_result").hide();
                          $("#imgRedult").attr("src","");
                          $("#demo_input").val("");


                          $.ajax({
                              url: bgAdmin + "/UserInfo/GetModel?r=" + Math.random(),
                              dataType: "json",
                              type: "post",
                              data: { UID: UID },
                              success: function (res) {
                                  if (res.success) {
                                      $("#hidProID").val(UID);
                                      $('#UpLoadPicDialog').dialog('open').dialog('setTitle', '上传图片');
                                      if (res.data.IMG) {
                                          $(".trZomeSmallPic").show();
                                          $("#imageSmall").attr("src", res.data.IMG + "?r=" + Math.random());
                                      }
                                  }
                              }
                          });
                     // });

                  }
              }, '-',
            {
            id: 'btnadd',
            text: '审核通过',
            iconCls: 'icon-edit',
            handler: function () {
                var curRows = $('#grid').datagrid('getSelections');
                if (curRows.length < 1) {
                    $.messager.alert("友情提示！", "请先选择一条记录！");
                    return;
                }

                //Ajax异步实现加载
                $.ajax({
                    url: bgAdmin + "/UserInfo/CheckUser?r=" + Math.random(),
                    data: { UID: curRows[0].UID, userType: "1" },
                    type: "post",
                    dataType: 'json',
                    success: function (data) {
                        if (data.success) {
                            $.messager.alert("系统提示！", "操作成功");
                            $("#grid").datagrid("reload");
                        }
                        else {
                            $.messager.alert("系统提示！", data.msg);
                        }
                    }
                })
            }},"-",{
                id: 'btnadd',
                text: '审核未通过',
                iconCls: 'icon-edit',
                handler: function () {
                    var curRows = $('#grid').datagrid('getSelections');
                    if (curRows.length < 1) {
                        $.messager.alert("友情提示！", "请先选择一条记录！");
                        return;
                    }

                    //Ajax异步实现加载
                    $.ajax({
                        url: bgAdmin + "/UserInfo/CheckUser?r=" + Math.random(),
                        data: { UID: curRows[0].UID, userType: "-1" },
                        type: "post",
                        dataType: 'json',
                        success: function (data) {
                            if (data.success) {
                                $.messager.alert("系统提示！", "操作成功");
                                $("#grid").datagrid("reload");
                            }
                            else {
                                $.messager.alert("系统提示！", data.msg);
                            }
                        }
                    })
                }
            }]
      //toolbar: [{
      //   id: 'btnadd',
      //   text: '添加',
      //   iconCls: 'icon-add',
      //   handler: function () {
      //      $('#AddDialog').dialog('open').dialog('setTitle', '添加信息');
      //   }
      //}, '-', {
      //   id: 'btnedit',
      //   text: '修改',
      //   iconCls: 'icon-edit',
      //   handler: function () {
      //      var RowUpdateByID = $('#grid').datagrid('getSelections');
      //      if (RowUpdateByID.length == 1) {
      //         //实现绑定数据显示
      //         BindUpdateList();
      //         $("#UpdateDialog").dialog('open').dialog('setTitle', '修改信息');
      //      }
      //      else {
      //         $.messager.alert("友情提示！", "每次只能修改一条，你已经选择了<font color='red'  size='6'>" + RowUpdateByID.length + "</font>条");
      //      }
      //   }
      //}, '-', {
      //   id: 'btndel',
      //   text: '删除',
      //   iconCls: 'icon-remove',
      //   handler: function () {
      //      var RowDeleteByID = $('#grid').datagrid("getSelections");
      //      if (RowDeleteByID.length == 1) {
      //         $.messager.confirm("删除信息", "您确认删除该条信息吗？", function (deleteClient) {
      //            if (deleteClient) {
      //               $.post("/UserInfo/Delete?r=" + Math.random(), { Id: RowDeleteByID[0].Id }, function (data) {
      //                  if (data == "OK") {
      //                     $.messager.alert("系统提示！", "删除成功");
      //                     //这里要将上次删除的Id清空，否则下次再删除的时候会报错
      //                     RowDeleteByID.length = "";
      //                     $("#grid").datagrid('reload') //重新刷新整个页面
      //                  }
      //                  else {
      //                     $.messager.alert("系统提示！", "删除失败");
      //                  }
      //               });
      //            }
      //         });
      //      }
      //      else {
      //         $.messager.alert("友情提示！", "每次只能删除一行，你已经选择了<font color='red' size='6'>" + RowDeleteByID.length + "</font>行");
      //      }
      //   }
      //}, '-', {
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
      //               $.post("/UserInfo/DeleteALL?r=" + Math.random(), { Ids: ids }, function (data) {
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
      //}, '-', {
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
      //}, '-', {
      //   id: 'btnreload',
      //   text: '刷新',
      //   iconCls: 'icon-reload',
      //   handler: function () {
      //      $("#grid").datagrid("reload");
      //   }
      //}, '-', {
      //   id: 'btnExport',
      //   text: '导出Excel',
      //   iconCls: 'icon-excel',
      //   handler: function () {
      //      ExportExcel();
      //   }
      //}]
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
          url: bgAdmin + "/UserInfo/Create?r=" + Math.random(),
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
                $.messager.alert("系统提示！", "添加失败:" + data);
            }
         }
      })
   });



   $("#btnImageAdd").on("click", function () {

       var $image = $("#imgRedult");

       if ($image == undefined)
       {
           return;
       }

       var src = $image.attr("src");
       var UID = $("#hidProID").val();
       if (src != ""&&src!=undefined) {

               $.ajax({
                   type: 'post',
                   url: bgAdmin + "/UserInfo/SaveImage?r=" + Math.random(),
                   data: { UID: UID, base64Str: src },
                   dataType: "text",
                   async: false,
                   success: function (data) {
                       var result = eval('(' + data + ')');
                       if (result.success) {
                           $("#grid").datagrid("reload");
                           $.messager.alert("系统提示！", "保存成功");
                           $('#UpLoadPicDialog').dialog('close');
                       }
                       else {
                           $.messager.alert("系统提示！", result.msg);
                       }
                   }
               });
       }
       else {
           $.messager.alert("系统提示！", "请选择图片！");
       }
   })



};
//绑定修改Div中的信息控件
function BindUpdateList() {
    var RowEditById = $("#grid").datagrid('getSelections')[0];
    $.ajax({
        url: bgAdmin + "/UserInfo/GetModel?r=" + Math.random(),
        data: { UID: RowEditById.UID },
        type: "post",
        dataType: 'json',
        success: function (data) {
            console.log(data);
          
            if (data.success) {
                RowEditById = data.data;
                $("#txtUIDUpdate").val(RowEditById.UID);
                $("#txtNAMEUpdate").val(RowEditById.NAME);
                $("#txtSEXUpdate").val(RowEditById.SEX);
                $("#txtDATAUpdate").val(RowEditById.DATA);
                $("#txtPLACEUpdate").val(RowEditById.PLACE);
                $("#txtNATIONUpdate").val(RowEditById.NATION);
                $("#txtHEIGHTUpdate").val(RowEditById.HEIGHT);
                $("#txtIMGUpdate").val(RowEditById.IMG);
                $("#txtHISTORYUpdate").val(RowEditById.HISTORY);
                $("#txtEDUCATIONUpdate").val(RowEditById.EDUCATION);
                $("#txtSCHOOLUpdate").val(RowEditById.SCHOOL);
                $("#txtADDRESSUpdate").val(RowEditById.ADDRESS);
                $("#txtWORKTUpdate").val(RowEditById.WORKT);
                $("#txtWORKPLACEUpdate").val(RowEditById.WORKPLACE);
                $("#txtPHONEUpdate").val(RowEditById.PHONE);
                $("#txtINTERESTUpdate").val(RowEditById.INTEREST);
                $("#txtOHEIGHTUpdate").val(RowEditById.OHEIGHT);
                $("#txtOWORKUpdate").val(RowEditById.OWORK);
                $("#txtOINTERESTUpdate").val(RowEditById.OINTEREST);
                $("#txtOSTRENGTHUpdate").val(RowEditById.OSTRENGTH);
                $("#txtMINUpdate").val(RowEditById.MIN);
                $("#txtMAXUpdate").val(RowEditById.MAX);
                $("#txtOWORKPLACEUpdate").val(RowEditById.OWORKPLACE);
                $("#txtFAMILYUpdate").val(RowEditById.FAMILY);
            }
            else {
                $.messager.alert("系统提示！", data.msg);
            }
        }
    })


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
      $.post(bgAdmin + "/UserInfo/Edit?r=" + Math.random(), postUpdate, function (data) {
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
            $("#txtNAMEDetail").val(RowDetailById.NAME);
            $("#txtSEXDetail").val(RowDetailById.SEX);
            $("#txtDATADetail").val(RowDetailById.DATA);
            $("#txtPLACEDetail").val(RowDetailById.PLACE);
            $("#txtNATIONDetail").val(RowDetailById.NATION);
            $("#txtHEIGHTDetail").val(RowDetailById.HEIGHT);
            $("#txtIMGDetail").val(RowDetailById.IMG);
            $("#txtHISTORYDetail").val(RowDetailById.HISTORY);
            $("#txtEDUCATIONDetail").val(RowDetailById.EDUCATION);
            $("#txtSCHOOLDetail").val(RowDetailById.SCHOOL);
            $("#txtADDRESSDetail").val(RowDetailById.ADDRESS);
            $("#txtWORKTDetail").val(RowDetailById.WORKT);
            $("#txtWORKPLACEDetail").val(RowDetailById.WORKPLACE);
            $("#txtPHONEDetail").val(RowDetailById.PHONE);
            $("#txtINTERESTDetail").val(RowDetailById.INTEREST);
            $("#txtOHEIGHTDetail").val(RowDetailById.OHEIGHT);
            $("#txtOWORKDetail").val(RowDetailById.OWORK);
            $("#txtOINTERESTDetail").val(RowDetailById.OINTEREST);
            $("#txtOSTRENGTHDetail").val(RowDetailById.OSTRENGTH);
            $("#txtMINDetail").val(RowDetailById.MIN);
            $("#txtMAXDetail").val(RowDetailById.MAX);
            $("#txtOWORKPLACEDetail").val(RowDetailById.OWORKPLACE);
            $("#txtFAMILYDetail").val(RowDetailById.FAMILY);
            $("#txtIMGDetail").attr("src", bgAdmin + RowDetailById.IMG);
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
   var filename = "/FileManager.ashx?action=exportexcel&Type=UserInfo&Query=" + name + "|" + value;
   location.href = filename;
}


function ShowDetail(uid) {

        $.ajax({
            url: bgAdmin + "/UserInfo/GetModel?r=" + Math.random(),
            data: { UID: uid },
            type: "post",
            dataType: 'json',
            success: function (data) {
                if (data.success) {
                 
                    var RowDetailById = data.data;
                    $("#txtNAMEDetail").val(RowDetailById.NAME);
                    $("#txtSEXDetail").val(RowDetailById.SEX);
                    $("#txtDATADetail").val(RowDetailById.DATA);
                    $("#txtPLACEDetail").val(RowDetailById.PLACE);
                    $("#txtNATIONDetail").val(RowDetailById.NATION);
                    $("#txtHEIGHTDetail").val(RowDetailById.HEIGHT);
                    $("#txtIMGDetail").val(RowDetailById.IMG);
                    $("#txtHISTORYDetail").val(RowDetailById.HISTORY);
                    $("#txtEDUCATIONDetail").val(RowDetailById.EDUCATION);
                    $("#txtSCHOOLDetail").val(RowDetailById.SCHOOL);
                    $("#txtADDRESSDetail").val(RowDetailById.ADDRESS);
                    $("#txtWORKTDetail").val(RowDetailById.WORKT);
                    $("#txtWORKPLACEDetail").val(RowDetailById.WORKPLACE);
                    $("#txtPHONEDetail").val(RowDetailById.PHONE);
                    $("#txtINTERESTDetail").val(RowDetailById.INTEREST);
                    $("#txtOHEIGHTDetail").val(RowDetailById.OHEIGHT);
                    $("#txtOWORKDetail").val(RowDetailById.OWORK);
                    $("#txtOINTERESTDetail").val(RowDetailById.OINTEREST);
                    $("#txtOSTRENGTHDetail").val(RowDetailById.OSTRENGTH);
                    $("#txtMINDetail").val(RowDetailById.MIN);
                    $("#txtMAXDetail").val(RowDetailById.MAX);
                    $("#txtOWORKPLACEDetail").val(RowDetailById.OWORKPLACE);
                    $("#txtFAMILYDetail").val(RowDetailById.FAMILY);
                    if (RowDetailById.IMG) {
                        $("#txtIMGDetail").attr("src", RowDetailById.IMG);
                    }
                    else {
                        $("#txtIMGDetail").attr("src", bgAdmin + "/Content/Images/nopic.gif");
                    }
                   
                }
                else {
                    $.messager.alert("系统提示！", data.msg);
                }
            }
        })
        //实现绑定数据显示

        $("#DetailDialog").dialog('open').dialog('setTitle', '详细信息');
  
}


function InitCropper() {

    'use strict';

    var console = window.console || { log: function () { } };
    var $image = $('#image');
    // var $download = $('#download');
    var $dataX = $('#dataX');
    var $dataY = $('#dataY');
    var $dataHeight = $('#dataHeight');
    var $dataWidth = $('#dataWidth');
    var $dataRotate = $('#dataRotate');
    var $dataScaleX = $('#dataScaleX');
    var $dataScaleY = $('#dataScaleY');
    var options = {
        aspectRatio: 5 / 6,
        preview: '.img-preview',
        crop: function (e) {
            $dataX.val(Math.round(e.x));
            $dataY.val(Math.round(e.y));
            $dataHeight.val(Math.round(e.height));
            $dataWidth.val(Math.round(e.width));
            $dataRotate.val(e.rotate);
            $dataScaleX.val(e.scaleX);
            $dataScaleY.val(e.scaleY);
        },
        dragMode: 'move',
        cropBoxResizable: true
    };


    // Tooltip
    $('[data-toggle="tooltip"]').tooltip();


    // Cropper
    //$image.on({
    //    'build.cropper': function (e) {
    //        console.log(e.type);
    //    },
    //    'built.cropper': function (e) {
    //        console.log(e.type);
    //    },
    //    'cropstart.cropper': function (e) {
    //        console.log(e.type, e.action);
    //    },
    //    'cropmove.cropper': function (e) {
    //        console.log(e.type, e.action);
    //    },
    //    'cropend.cropper': function (e) {
    //        console.log(e.type, e.action);
    //    },
    //    'crop.cropper': function (e) {
    //        console.log(e.type, e.x, e.y, e.width, e.height, e.rotate, e.scaleX, e.scaleY);
    //    },
    //    'zoom.cropper': function (e) {
    //        console.log(e.type, e.ratio);
    //    }
    //}).cropper(options);


    $image.on({
        'build.cropper': function (e) {
            console.log(e.type);
        },
        'built.cropper': function (e) {
            console.log(e.type);
        },
        'dragstart.cropper': function (e) {
            console.log(e.type, e.dragType);
        },
        'dragmove.cropper': function (e) {
            console.log(e.type, e.dragType);
        },
        'dragend.cropper': function (e) {
            console.log(e.type, e.dragType);
        },
        'zoomin.cropper': function (e) {
            console.log(e.type);
        },
        'zoomout.cropper': function (e) {
            console.log(e.type);
        }
    }).cropper(options);


    // Buttons
    if (!$.isFunction(document.createElement('canvas').getContext)) {
        $('button[data-method="getCroppedCanvas"]').prop('disabled', true);
    }

    if (typeof document.createElement('cropper').style.transition === 'undefined') {
        $('button[data-method="rotate"]').prop('disabled', true);
        $('button[data-method="scale"]').prop('disabled', true);
    }


    //$("#btnImageAdd").on("click", function () {
    //    var src = $image.eq(0).attr("src");
    //    var canvasdata = $image.cropper("getCanvasData");
    //    var cropBoxData = $image.cropper('getCropBoxData');
    //    var UID = $("#hidProID").val();


    //    if (src != "") {

    //        convertToData(src, canvasdata, cropBoxData, function (base64Str) {

    //            $.ajax({
    //                type: 'post',
    //                url: bgAdmin + "/UserInfo/SaveImage?r=" + Math.random(),
    //                data: { UID: UID, base64Str: base64Str },
    //                dataType: "text",
    //                async: false,
    //                success: function (data) {
    //                    var result = eval('(' + data + ')');

    //                    if (result.success) {
    //                        console.log("11");
    //                        $("#grid").datagrid("reload");
    //                        $.messager.alert("系统提示！", "保存成功");
    //                        $('#UpLoadPicDialog').dialog('close');
    //                    }
    //                    else {
    //                        $.messager.alert("系统提示！", result.msg);
    //                    }
    //                }
    //            });

    //        });
    //    }
    //    else {
    //        $.messager.alert("系统提示！", "请选择图片！");
    //    }
    //})









    // Download
    //if (typeof $download[0].download === 'undefined') {
    //    $download.addClass('disabled');
    //}


    // Options
    $('.docs-toggles').on('change', 'input', function () {
        var $this = $(this);
        var name = $this.attr('name');
        var type = $this.prop('type');
        var cropBoxData;
        var canvasData;

        if (!$image.data('cropper')) {
            return;
        }

        if (type === 'checkbox') {
            options[name] = $this.prop('checked');
            cropBoxData = $image.cropper('getCropBoxData');
            canvasData = $image.cropper('getCanvasData');

            options.built = function () {
                $image.cropper('setCropBoxData', cropBoxData);
                $image.cropper('setCanvasData', canvasData);
            };
        } else if (type === 'radio') {
            options[name] = $this.val();
        }

        $image.cropper('destroy').cropper(options);
    });


    // Methods
    $('.docs-buttons').on('click', '[data-method]', function () {
        var $this = $(this);
        var data = $this.data();
        var $target;
        var result;

        if ($this.prop('disabled') || $this.hasClass('disabled')) {
            return;
        }

        if ($image.data('cropper') && data.method) {
            data = $.extend({}, data); // Clone a new one

            if (typeof data.target !== 'undefined') {
                $target = $(data.target);

                if (typeof data.option === 'undefined') {
                    try {
                        data.option = JSON.parse($target.val());
                    } catch (e) {
                        console.log(e.message);
                    }
                }
            }

            if (data.method === 'rotate') {
                $image.cropper('clear');
            }

            result = $image.cropper(data.method, data.option, data.secondOption);

            if (data.method === 'rotate') {
                $image.cropper('crop');
            }

            switch (data.method) {
                case 'scaleX':
                case 'scaleY':
                    $(this).data('option', -data.option);
                    break;

                case 'getCroppedCanvas':
                    if (result) {

                        // Bootstrap's Modal
                        $('#getCroppedCanvasModal').modal().find('.modal-body').html(result);

                        if (!$download.hasClass('disabled')) {
                            $download.attr('href', result.toDataURL('image/jpeg'));
                        }
                    }

                    break;
            }

            if ($.isPlainObject(result) && $target) {
                try {
                    $target.val(JSON.stringify(result));
                } catch (e) {
                    console.log(e.message);
                }
            }

        }
    });


    // Keyboard
    $(document.body).on('keydown', function (e) {

        if (!$image.data('cropper') || this.scrollTop > 300) {
            return;
        }

        switch (e.which) {
            case 37:
                e.preventDefault();
                $image.cropper('move', -1, 0);
                break;

            case 38:
                e.preventDefault();
                $image.cropper('move', 0, -1);
                break;

            case 39:
                e.preventDefault();
                $image.cropper('move', 1, 0);
                break;

            case 40:
                e.preventDefault();
                $image.cropper('move', 0, 1);
                break;
        }

    });


    //// Import image
    var $inputImage = $('#inputImage');
    var URL = window.URL || window.webkitURL;
    var blobURL;


    if (URL) {
        $inputImage.change(function () {
            var files = this.files;
            var file;

            if (!$image.data('cropper')) {
                return;
            }

            if (files && files.length) {
                file = files[0];

                if (/^image\/\w+$/.test(file.type)) {
                    blobURL = URL.createObjectURL(file);
                    $image.one('built.cropper', function () {

                        // Revoke when load complete
                        URL.revokeObjectURL(blobURL);
                    }).cropper('reset').cropper('replace', blobURL);
                    $inputImage.val('');
                } else {
                    window.alert('Please choose an image file.');
                }
            }
        });
    } else {
        $inputImage.prop('disabled', true).parent().addClass('disabled');
    }

}

function convertToData(url, canvasdata, cropdata, callback) {
    var cropw = cropdata.width; // 剪切的宽
    var croph = cropdata.height; // 剪切的宽
    var imgw = canvasdata.width; // 图片缩放或则放大后的高
    var imgh = canvasdata.height; // 图片缩放或则放大后的高
    var poleft = canvasdata.left - cropdata.left; // canvas定位图片的左边位置
    var potop = canvasdata.top - cropdata.top; // canvas定位图片的上边位置
    var canvas = document.createElement("canvas");
    var ctx = canvas.getContext('2d');
    canvas.width = cropw;
    canvas.height = croph;
    var img = new Image();
    img.src = url;

    img.onload = function () {
        this.width = imgw;
        this.height = imgh;
        // 这里主要是懂得canvas与图片的裁剪之间的关系位置
        ctx.drawImage(this, poleft, potop, this.width, this.height);
        var base64 = canvas.toDataURL('image/jpg', 1);  // 这里的“1”是指的是处理图片的清晰度（0-1）之间，当然越小图片越模糊，处理后的图片大小也就越小
        callback && callback(base64)      // 回调base64字符串
    }
}



