<%@ Page Language="C#" AutoEventWireup="true" CodeFile="role_edit.aspx.cs" Inherits="Admin_manager_role_edit" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑管理角色</title>
<script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
//        //是否启用权限
//        if ($("#ddlRoleType").find("option:selected").attr("value") == 1) {
//            $(".border-table").find("input[type='checkbox']").prop("disabled", true);
//        }
//        $("#ddlRoleType").change(function () {
//            if ($(this).find("option:selected").attr("value") == 1) {
//                $(".border-table").find("input[type='checkbox']").prop("checked", false);
//                $(".border-table").find("input[type='checkbox']").prop("disabled", true);
//            } else {
//                $(".border-table").find("input[type='checkbox']").prop("disabled", false);
//            }
//        });
        //权限全选
        $("input[name='checkAll']").click(function () {
            if ($(this).prop("checked") == true) {
                $(this).parent().siblings("td").find("input[type='checkbox']").prop("checked", true);
            } else {
                $(this).parent().siblings("td").find("input[type='checkbox']").prop("checked", false);
            }
        });

        //权限全选
        $("input[name='checkAllone']").click(function () {
            if ($(this).prop("checked") == true) {
                $("#cloumn").find("input[type='checkbox']").prop("checked", true);
            } else {
                $("#cloumn").find("input[type='checkbox']").prop("checked", false);
            }
        });

    });

    $(function () {

        $(":checkbox[group]")   //选择所有成组的复选框 
        .click(function () {  //绑定 click 事件 

            var blnStat = this.checked; //复选框状态 

            var blnEqual = true;    //该组成员状态是否相同 

            var pid = this.getAttribute('pid');

            var gname = this.getAttribute('group');

            var id = this.getAttribute('cid');

           // $(":checkbox[group='" + gname + "'][pid='" + pid + "']").attr("checked", this.checked);
           

            if (true == this.checked) {
                next(id, pid, gname);
            } else {
                if (pid == 0) {
                    nextall(id, pid, gname);
                } else {
                    if (Child(id, pid, gname) == false) {
                        //this.checked = false;
                    } else {
                        nexts(id, pid, gname, id);
                    } 
                }
            }
        });
    });


</script>




<script type="text/jscript">
    function next(id, pid, gname) {
        $(":checkbox[group='" + gname + "']")
                .each(function () {
                    var pids = this.getAttribute('pid');
                    var ids = this.getAttribute('cid');


                    if (pid == ids) {
                        this.checked = true;
                        pret(ids, pid, gname);
                    }
                   
                    if (pids == id) {
                        this.checked = true;
                        next(ids, pids, gname);
                    }

                });
            }


            function pret(id, pid, gname) {
                $(":checkbox[group='" + gname + "']")
                .each(function () {
                    var pids = this.getAttribute('pid');
                    var ids = this.getAttribute('cid');


                    if (pid == ids) {
                        this.checked = true;
                        pret(ids, pids, gname);
                    }
                });
            }

    function nexts(id, pid, gname,tid) {
        $(":checkbox[group='" + gname + "']")
        .each(function () {
            var pids = this.getAttribute('pid');
            var ids = this.getAttribute('cid');

            if (pid == ids) {
                if (pids == 0) {
                    if (!Childs(ids, pids, gname)) {

                        this.checked = false;
                       
                    }
                } else {
                    this.checked = false;
                }
                prets(ids, pid, gname, tid);
            }


            if (pids == id) {


                this.checked = false;
                nexts(ids, pids, gname, tid);
            }

        });
    }

    function prets(id, pid, gname,tid) {
        $(":checkbox[group='" + gname + "']")
                .each(function () {
                    var pids = this.getAttribute('pid');
                    var ids = this.getAttribute('cid');

                    if (pid == ids) {
                      
                        if (pids == 0) {
                           
                            if (!Childs(ids, pids, gname)) {
                                if (ids != tid) {
                                    this.checked = false;
                                }
                            }
                        } else {
                           
                            this.checked = false;
                        }
                        prets(ids, pids, gname, tid);
                    }

                });
            }


            function sibling(id, pid, gname) {
                var bl = false;
                $(":checkbox[group='" + gname + "']")
                .each(function () {
                    var pids = this.getAttribute('pid');
                    var ids = this.getAttribute('cid');

                    
                    if (pid == pids) {
                        if (Child(ids, pid, gname)) {
                            bl = true;
                        }
                    }

                });
                return bl;
            }

            function Child(id, pid, gname) {
                var bl = false;
                $(":checkbox[group='" + gname + "']")
                .each(function () {
                    var pids = this.getAttribute('pid');
                    var ids = this.getAttribute('cid');
                  
                    if (pids == id) {
                        bl = true;
                    }
                });
                return bl;
            }

            function Childs(id, pid, gname) {
                var bl = false;
                $(":checkbox[group='" + gname + "']")
                .each(function () {
                    var pids = this.getAttribute('pid');
                    var ids = this.getAttribute('cid');

                    if (pids == id) {

                        if (this.checked == true) {
                            bl = true;
                        }
                        Childs(ids, pids, gname)
                    }
                });
                return bl;
            }


            function nextall(id, pid, gname) {
                $(":checkbox[group='" + gname + "']")
        .each(function () {
            var pids = this.getAttribute('pid');
            var ids = this.getAttribute('cid');

            if (pid == ids) {
                
                this.checked = false;

                pretall(ids, pid, gname);
            }


            if (pids == id) {


                this.checked = false;
                nextall(ids, pids, gname);
            }

        });
            }

            function pretall(id, pid, gname) {
                $(":checkbox[group='" + gname + "']")
                .each(function () {
                    var pids = this.getAttribute('pid');
                    var ids = this.getAttribute('cid');

                    if (pid == ids) {
                        this.checked = false;

                        pretall(ids, pids, gname);
                    }

                });
            }
</script>

</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="role_list.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="manager_list.aspx"><span>管理员</span></a>
  <i class="arrow"></i>
  <a href="role_list.aspx"><span>管理角色</span></a>
  <i class="arrow"></i>
  <span>编辑角色</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑角色信息</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>角色类型</dt>
    <dd>
      <div class="rule-single-select">
        <asp:DropDownList id="ddlRoleType" runat="server" datatype="*" errormsg="请选择角色类型！" sucmsg=" "></asp:DropDownList>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>角色名称</dt>
    <dd><asp:TextBox ID="txtRoleName" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*角色中文名称，100字符内</span></dd>
  </dl>   
  <dl>
    <dt>管理权限</dt>
    <dd>
      <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="98%" id="cloumn">
        <thead>
          <tr>
            <th width="30%">导航名称</th>
            <th>权限分配</th>
            <th width="10%" style=" display:none;"><input name="checkAllone" type="checkbox" />全选</th>
          </tr>
        </thead>
        <tbody>
          <asp:Repeater ID="rptList" runat="server" onitemdatabound="rptList_ItemDataBound">
          <ItemTemplate>
           <tr>
            <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
              <asp:HiddenField ID="hidName" Value='<%#Eval("className") %>' runat="server" />
              <asp:HiddenField ID="hidActionType" Value='<%#Eval("action_type") %>' runat="server" />
              <asp:HiddenField ID="hidLayer" Value='<%#Eval("class_layer") %>' runat="server" />
              <asp:Literal ID="LitFirst" runat="server"></asp:Literal>
              <%#Eval("className")%>
            </td>
             <%--<%#((DataRowView)Container.DataItem)["Colum"]%>--%>
            <td>
             <%-- <asp:CheckBoxList ID="cblActionType"  runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="cbllist"></asp:CheckBoxList>--%>
                <input id="checkbox1" name="checkbox"  pid='<%#Eval("parentId") %>' cid='<%#Eval("classid") %>' group="groupname" type="checkbox" value=""   runat="server"  />&nbsp;<asp:Label ID="lbshow" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
              <input id="checkbox2" name="checkbox"  pid='<%#Eval("parentId") %>' cid='<%#Eval("classid") %>' group="groupname2" type="checkbox" value=""   runat="server"  />&nbsp;<asp:Label ID="lbshow2" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
               <input id="checkbox3" name="checkbox"  pid='<%#Eval("parentId") %>' cid='<%#Eval("classid") %>' group="groupname3" type="checkbox" value=""   runat="server"  />&nbsp;<asp:Label ID="lbshow3" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                <input id="checkbox4" name="checkbox"  pid='<%#Eval("parentId") %>' cid='<%#Eval("classid") %>' group="groupname4" type="checkbox" value=""   runat="server"  />&nbsp;<asp:Label ID="lbshow4" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                 <input id="checkbox5" name="checkbox"  pid='<%#Eval("parentId") %>' cid='<%#Eval("classid") %>' group="groupname5" type="checkbox" value=""   runat="server"  />&nbsp;<asp:Label ID="lbshow5" runat="server" Text=""></asp:Label>   
            </td>
            <td align="center"  style=" display:none;"><input name="checkAll" type="checkbox" /></td>
          </tr>

          </ItemTemplate>
          </asp:Repeater>
        </tbody>
      </table>
    </dd>
  </dl>
</div>
<!--/内容-->

<!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->

</form>
</body>
</html>