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
    <form id="form1" runat="server" defaultfocus="TextBoxUserName" defaultbutton="ButtonAdminLogin">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <span style="width: 55px; display: inline-block;">账号</span><span><asp:TextBox ID="TextBoxUserName" runat="server" ClientIDMode="Static" TabIndex="1"></asp:TextBox></span>
                    <asp:CheckBox ID="CheckBoxRememberUserName" runat="server" Text="记住账号" TabIndex="6" />
                </div>
                <div>
                    <span style="width: 55px; display: inline-block;">密码</span><span><asp:TextBox ID="TextBoxPassWord" runat="server" ClientIDMode="Static" TextMode="Password" TabIndex="2"></asp:TextBox></span>
                </div>
                <div>
                    <span style="width: 50px; display: inline-block;">验证码</span>
                    <span>
                        <asp:TextBox ID="TextBoxCAPTCHA" runat="server" TabIndex="3"></asp:TextBox></span>
                </div>

                <div>
                    <asp:ImageButton ID="ImageButtonCAPTCHA" runat="server" ImageUrl="./CAPTCHAPage.aspx" OnClick="ImageButtonCAPTCHA_Click" TabIndex="8" />
                </div>

                <div>
                    <asp:Label ID="LabelWrongPassWordSign" runat="server" Text="" TabIndex="100"></asp:Label>
                    <asp:HiddenField ID="HiddenFieldTimeStamp" runat="server" />
                </div>
                <div>
                    <asp:Button ID="ButtonAdminLogin" runat="server" Text="管理员登录" OnClientClick="OnLogin()" OnClick="ButtonAdminLogin_Click" TabIndex="4" />
                    <asp:Button ID="ButtonSellerLogin" runat="server" Text="经销商登录" OnClientClick="OnLogin()" OnClick="ButtonSellerLogin_Click" TabIndex="5" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
