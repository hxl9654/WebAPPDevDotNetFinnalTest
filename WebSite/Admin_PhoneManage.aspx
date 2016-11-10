<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_PhoneManage.aspx.cs" Inherits="Admin_PhoneManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>手机品牌型号管理</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div align="center">
                <asp:Label ID="LabelWelcome" runat="server" Text=""></asp:Label>
                &nbsp;<asp:Button ID="ButtonLogout" runat="server" Text="退出登录" OnClick="ButtonLogout_Click" UseSubmitBehavior="False" />
                &nbsp;<asp:Button ID="ButtonChangePage" runat="server" Text="管理经销商" OnClick="ButtonChangePage_Click" UseSubmitBehavior="False" />
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                <ContentTemplate>
                    <div>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Caption="手机品牌列表" CaptionAlign="Top" Width="100%" AllowPaging="True" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" Style="margin-bottom: 0px" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowCommand="GridView1_RowCommand" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCreated="GridView1_RowCreated">
                            <EmptyDataTemplate>
                                <table width="100%" cellspacing="0" frame="border" rules="all">
                                    <tr align="center">
                                        <th width="20%">品牌编号</th>
                                        <th width="20%">品牌名称</th>
                                        <th width="40%">生产地址</th>
                                        <th width="20%">操作</th>
                                    </tr>
                                    <tr align="center">
                                        <td>自动生成</td>
                                        <td>
                                            <asp:TextBox ID="TextBoxBrandName" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="TextBoxProductAddress" runat="server" CausesValidation="False"></asp:TextBox></td>
                                        <td>
                                            <asp:Button ID="ButtonEmptyAdd" runat="server" CommandName="EmptyAdd" Text="新增" />
                                            <asp:Button ID="ButtonEmptyCancel" runat="server" CommandName="EmptyCancel" Text="取消" CausesValidation="false" />
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="品牌编号" InsertVisible="False">
                                    <EditItemTemplate>
                                        <asp:Label ID="LabelBrandID" runat="server" Text='<%# Eval("BrandID") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelBrandID" runat="server" Text='<%# Bind("BrandID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="LabelBrandID" runat="server" Text='自动生成'></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="品牌名称">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxBrandName" runat="server" Text='<%# Bind("BrandName") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelBrandName" runat="server" Text='<%# Bind("BrandName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="TextBoxBrandName" runat="server" Text='<%# Bind("BrandName") %>'></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="生产地址">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxProductAddress" runat="server" Text='<%# Bind("ProductAddress") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelProductAddress" runat="server" Text='<%# Bind("ProductAddress") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="TextBoxProductAddress" runat="server" Text='<%# Bind("ProductAddress") %>'></asp:TextBox>
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
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Caption="手机品牌列表" CaptionAlign="Top" Width="100%" AllowPaging="True" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowDeleting="GridView2_RowDeleting" OnRowEditing="GridView2_RowEditing" Style="margin-bottom: 0px" OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowCommand="GridView2_RowCommand" OnRowUpdating="GridView2_RowUpdating" OnRowCreated="GridView2_RowCreated">
                            <EmptyDataTemplate>
                                <table width="100%" cellspacing="0" frame="border" rules="all">
                                    <tr align="center">
                                        <th width="10%">型号编号</th>
                                        <th width="10%">手机型号</th>
                                        <th width="30%">手机配置</th>
                                        <th width="10%">颜色</th>
                                        <th width="20%">图片</th>
                                        <th width="20%">操作</th>
                                    </tr>
                                    <tr align="center">
                                        <td>自动生成</td>
                                        <td>
                                            <asp:TextBox ID="TextBoxModelName" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="TextBoxInfo" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="TextBoxColor" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="TextBoxPicture" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:Button ID="ButtonEmptyAdd" runat="server" CommandName="EmptyAdd" Text="新增" />
                                            <asp:Button ID="ButtonEmptyCancel" runat="server" CommandName="EmptyCancel" Text="取消" CausesValidation="false" />
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="型号编号" InsertVisible="False">
                                    <EditItemTemplate>
                                        <asp:Label ID="LabelModelID" runat="server" Text='<%# Eval("ModelID") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelModelID" runat="server" Text='<%# Bind("ModelID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="LabelModelID" runat="server" Text='自动生成'></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="型号名称">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxModelName" runat="server" Text='<%# Bind("ModelName") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelModelName" runat="server" Text='<%# Bind("ModelName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="TextBoxModelName" runat="server" Text='<%# Bind("ModelName") %>'></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="手机配置">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxInfo" runat="server" Text='<%# Bind("Info") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelInfo" runat="server" Text='<%# Bind("Info") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="TextBoxInfo" runat="server" Text='<%# Bind("Info") %>'></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="颜色">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxColor" runat="server" Text='<%# Bind("Color") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelColor" runat="server" Text='<%# Bind("Color") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="TextBoxColor" runat="server" Text='<%# Bind("Color") %>'></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="图片">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxPicture" runat="server" Text='<%# Bind("Picture") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LabelPicture" runat="server" Text='<%# Bind("Picture") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="TextBoxPicture" runat="server" Text='<%# Bind("Picture") %>'></asp:TextBox>
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
        </div>
    </form>
</body>
</html>
