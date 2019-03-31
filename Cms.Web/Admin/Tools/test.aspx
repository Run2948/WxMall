<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="Tools_test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    .InforTab
      { 
          border: 1px #6FAADB solid;
          border-collapse: collapse;
          float: left;
          white-space:nowrap; 
        overflow:hidden; 
        text-overflow:ellipsis;
          }
     .InforTab tr
     {
         border: 1px #6FAADB solid;
         border-collapse: collapse;
         }
    .InforTab tr td
     {
         border: 1px #6FAADB solid;
         border-collapse: collapse;
         }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="InforTab">
            <tr>
                <td>
                    <input id="InputAffixFile" runat="server" name="InputPictureFile" size="33" 
                        style="WIDTH: 150px; HEIGHT: 22px" type="file" />
                    <asp:Button ID="Button2" runat="server" Height="21px" onclick="Button2_Click" 
                        Text="先上传" />
                </td>
            </tr>
            
            <tr style="background-color:#EDF6FC;">
                <td align="center">
    <asp:Button ID="Button1" runat="server" Text="再导入" onclick="Button1_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
