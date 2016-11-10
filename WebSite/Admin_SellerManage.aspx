<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_SellerManage.aspx.cs" Inherits="Admin_SellerManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>经销商管理</title>
    <script src="http://libs.baidu.com/jquery/2.0.0/jquery.min.js"></script>
    <script src="SHA256.js"></script>
    <script type="text/javascript">
        var PassWordFiled, UserNameFiled;
        var FooterRowPassWordFiled, FooterRowUserNameFiled;
        var EmptyRowPassWordFiled, EmptyRowUserNameFiled;
        function GetPassWordFiled() {
            var temp = document.getElementById("TextBoxUserPassWordHash_Empty");
            if (temp != null)
                EmptyRowPassWordFiled = temp;
            var temp = document.getElementById("TextBoxUserName_Empty");
            if (temp != null)
                EmptyRowUserNameFiled = temp;

            var temp = document.getElementById("TextBoxUserPassWordHash");
            if (temp != null)
                PassWordFiled = temp;
            var temp = document.getElementById("LabelUserName");
            if (temp != null)
                UserNameFiled = temp;

            var temp = document.getElementById("TextBoxUserPassWordHash_Footer");
            if (temp != null)
                FooterRowPassWordFiled = temp;
            var temp = document.getElementById("TextBoxUserName_Footer");
            if (temp != null)
                FooterRowUserNameFiled = temp;
        }
        function GetPassWordHash_EmptyRow() {
            if (UserName == "" || PassWord == "")
                return false;
            var PassWord = EmptyRowPassWordFiled.value;
            var UserName = EmptyRowUserNameFiled.value;
            var PassWordWithSalt = PassWord + UserName + "dcLDJf8f8iHlS6LExCAj";
            var PassWordHash = SHA256(PassWordWithSalt).toUpperCase();
            EmptyRowPassWordFiled.value = PassWordHash;
            return true;
        }
        function GetPassWordHash_ButtonUpdate() {
            if (UserName == "" || PassWord == "")
                return false;
            var PassWord = PassWordFiled.value;
            var UserName = UserNameFiled.value;
            var PassWordWithSalt = PassWord + UserName + "dcLDJf8f8iHlS6LExCAj";
            var PassWordHash = SHA256(PassWordWithSalt).toUpperCase();
            PassWordFiled.value = PassWordHash;
            return true;
        }
        function GetPassWordHash_ButtonInsert() {
            if (UserName == "" || PassWord == "")
                return false;
            var PassWord = FooterRowPassWordFiled.value;
            var UserName = FooterRowUserNameFiled.value;
            var PassWordWithSalt = PassWord + UserName + "dcLDJf8f8iHlS6LExCAj";
            var PassWordHash = SHA256(PassWordWithSalt).toUpperCase();
            FooterRowPassWordFiled.value = PassWordHash;
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <script type="text/javascript">
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function (sender, e) {
                GetPassWordFiled();
            });
        </script>
        <div align="center">
            <asp:Label ID="LabelWelcome" runat="server" Text=""></asp:Label>
            &nbsp;<asp:Button ID="ButtonLogout" runat="server" Text="退出登录" OnClick="ButtonLogout_Click" UseSubmitBehavior="False" />
            &nbsp;<asp:Button ID="ButtonChangePage" runat="server" Text="管理手机型号" OnClick="ButtonChangePage_Click" UseSubmitBehavior="False" />
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

            <ContentTemplate>
                <div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Caption="经销商列表" CaptionAlign="Top" Width="100%" AllowPaging="True" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" Style="margin-bottom: 0px" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowCommand="GridView1_RowCommand" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" OnRowCreated="GridView1_RowCreated">
                        <Columns>
                            <asp:TemplateField HeaderText="经销商编号" InsertVisible="False">
                                <EditItemTemplate>
                                    <asp:Label ID="LabelSellerID" runat="server" Text='<%# Eval("SellerID") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelSellerID" runat="server" Text='<%# Bind("SellerID") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="LabelSellerID" runat="server" Text='自动生成'></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="经销商名称">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBoxName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="TextBoxName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="所在省份">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBoxProvience" runat="server" Text='<%# Bind("Provience") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelProvience" runat="server" Text='<%# Bind("Provience") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="TextBoxProvience" runat="server" Text='<%# Bind("Provience") %>'></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="所在城市">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBoxCity" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelCity" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="TextBoxCity" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="联系电话">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBoxPhone" runat="server" Text='<%# Bind("Phone") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelPhone" runat="server" Text='<%# Bind("Phone") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="TextBoxPhone" runat="server" Text='<%# Bind("Phone") %>'></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="详细地址">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBoxAddress" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="TextBoxAddress" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="经销商级别">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="DropDownListLevel" runat="server">
                                        <asp:ListItem>省级</asp:ListItem>
                                        <asp:ListItem>市级</asp:ListItem>
                                        <asp:ListItem>县级</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="TextBoxLevel" runat="server" Text='<%# Bind("Level") %>' Visible="false"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelLevel" runat="server" Text='<%# Bind("Level") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="DropDownListLevel" runat="server">
                                        <asp:ListItem>省级</asp:ListItem>
                                        <asp:ListItem>市级</asp:ListItem>
                                        <asp:ListItem>县级</asp:ListItem>
                                    </asp:DropDownList>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="上级经销商">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="DropDownListParentSellerID" runat="server"></asp:DropDownList>
                                    <asp:TextBox ID="TextBoxParentSellerID" runat="server" Text='<%# Bind("ParentSellerID") %>' Visible="false"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelParentSellerID" runat="server" Text='<%# Bind("ParentSellerID") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="DropDownListParentSellerID" runat="server"></asp:DropDownList>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <EditItemTemplate>
                                    <asp:Button ID="ButtonUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="更新" />
                                    &nbsp;<asp:Button ID="ButtonCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Button ID="ButtonEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="编辑" />
                                    &nbsp;<asp:Button ID="ButtonSelect" runat="server" CausesValidation="False" CommandName="Select" Text="选择" />
                                    &nbsp;<asp:Button ID="ButtonDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="删除" />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Button ID="ButtonInsert" runat="server" CausesValidation="True" CommandName="Insert" Text="新增" />
                                    &nbsp;<asp:Button ID="ButtonCancel" runat="server" CausesValidation="False" CommandName="InsertCancel" Text="取消" />
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="ButtonInsert" runat="server" Text="新增" OnClick="ButtonInsert_Click" />
                </div>
                <div>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Caption="经销商的用户" CaptionAlign="Top" Width="100%" AllowPaging="True" OnPageIndexChanged="GridView2_PageIndexChanged" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowDeleting="GridView2_RowDeleting" OnRowEditing="GridView2_RowEditing" Style="margin-bottom: 0px" OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowCommand="GridView2_RowCommand" OnRowUpdating="GridView2_RowUpdating" OnRowCreated="GridView2_RowCreated">

                        <EmptyDataTemplate>
                            <table width="100%" cellspacing="0" frame="border" rules="all">
                                <tr align="center">
                                    <th width="10%">用户编号</th>
                                    <th width="15%">用户名</th>
                                    <th width="20%">密码</th>
                                    <th width="20%">邮箱</th>
                                    <th width="15%">电话</th>
                                    <th width="20%">操作</th>
                                </tr>
                                <tr align="center">
                                    <td>自动生成</td>
                                    <td>
                                        <asp:TextBox ID="TextBoxUserName_Empty" runat="server" ClientIDMode="Static"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="TextBoxUserPassWordHash_Empty" runat="server" ClientIDMode="Static" TextMode="Password" CausesValidation="False"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="TextBoxEmail" runat="server" TextMode="Email"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="TextBoxPhone" runat="server" TextMode="Phone"></asp:TextBox></td>
                                    <td>
                                        <asp:Button ID="ButtonEmptyAdd" runat="server" CommandName="EmptyAdd" Text="新增" />
                                        <asp:Button ID="ButtonEmptyCancel" runat="server" CommandName="EmptyCancel" Text="取消" CausesValidation="false" />
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField HeaderText="用户编号" InsertVisible="False">
                                <EditItemTemplate>
                                    <asp:Label ID="LabelUserID" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelUserID" runat="server" Text='<%# Bind("UserID") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="LabelUserID" runat="server" Text='自动生成'></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="用户名">
                                <EditItemTemplate>
                                    <asp:Label ID="LabelUserName" runat="server" ClientIDMode="Static" Text='<%# Eval("UserName") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="TextBoxUserName_Footer" runat="server" ClientIDMode="Static" Text='<%# Bind("UserName") %>'></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="密码">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBoxUserPassWordHash" runat="server" ClientIDMode="Static" Text='' TextMode="Password"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="TextBoxUserPassWordHash" runat="server" Text='PROTECKETED'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="TextBoxUserPassWordHash_Footer" runat="server" ClientIDMode="Static" Text='' TextMode="Password"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="邮箱">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBoxEmail" runat="server" Text='<%# Bind("Email") %>' TextMode="Email"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="TextBoxEmail" runat="server" Text='<%# Bind("Email") %>' TextMode="Email"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="电话">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBoxPhone" runat="server" Text='<%# Bind("Phone") %>' TextMode="Phone"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelPhone" runat="server" Text='<%# Bind("Phone") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="TextBoxPhone" runat="server" Text='<%# Bind("Phone") %>' TextMode="Phone"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <EditItemTemplate>
                                    <asp:Button ID="ButtonUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="更新" />
                                    &nbsp;<asp:Button ID="ButtonCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Button ID="ButtonEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="编辑" />
                                    &nbsp;<asp:Button ID="ButtonDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="删除" />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Button ID="ButtonInsert" runat="server" CausesValidation="True" CommandName="Insert" Text="新增" />
                                    &nbsp;<asp:Button ID="ButtonCancel" runat="server" CausesValidation="False" CommandName="InsertCancel" Text="取消" />
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="ButtonInsert2" runat="server" Text="新增" OnClick="ButtonInsert2_Click" Visible="false" />
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
