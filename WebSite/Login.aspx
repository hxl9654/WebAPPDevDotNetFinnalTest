<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>手机分销管理系统登录页面</title>
    <script src="http://libs.baidu.com/jquery/2.0.0/jquery.min.js"></script>
    <script src="SHA256.js"></script>
    <script type="text/javascript">
        function OnLogin() {
            var PassWord = document.getElementById("TextBoxPassWord").value;
            var UserName = document.getElementById("TextBoxUserName").value;
            var PassWordWithSalt = PassWord + UserName + "dcLDJf8f8iHlS6LExCAj";
            var PassWordHash = SHA256(PassWordWithSalt).toUpperCase();
            var TimeStamp = new Date().getTime();
            var PassWordWithTimeStamp = PassWordHash + ":" + TimeStamp;
            var PassWordHashWithTimeStamp = SHA256(PassWordWithTimeStamp).toUpperCase();
            document.getElementById("TextBoxPassWord").value = PassWordHashWithTimeStamp;
            document.getElementById("HiddenFieldTimeStamp").value = TimeStamp;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    账号<asp:TextBox ID="TextBoxUserName" runat="server" ClientIDMode="Static"></asp:TextBox>
                    <asp:CheckBox ID="CheckBoxRememberUserName" runat="server" Text="记住账号" />
                </div>
                <div>
                    密码<asp:TextBox ID="TextBoxPassWord" runat="server" ClientIDMode="Static" TextMode="Password"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="LabelWrongPassWordSign" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="HiddenFieldTimeStamp" runat="server" />
                </div>
                <div>
                    <asp:Button ID="ButtonAdminLogin" runat="server" Text="管理员登录" OnClientClick="OnLogin()" OnClick="ButtonAdminLogin_Click" />
                    <asp:Button ID="ButtonSellerLogin" runat="server" Text="经销商登录" OnClientClick="OnLogin()" OnClick="ButtonSellerLogin_Click" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
