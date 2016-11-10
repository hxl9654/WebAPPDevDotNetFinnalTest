<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Seller.aspx.cs" Inherits="Seller" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>经销商操作页面</title>
    <style type="text/css">
        .auto-style1 {
            width: 104px;
        }
        .auto-style2 {
            margin-left: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div align="center">
            <asp:Label ID="LabelWelcome" runat="server" Text=""></asp:Label>
            &nbsp;<asp:Button ID="ButtonLogout" runat="server" Text="退出登录" OnClick="ButtonLogout_Click" UseSubmitBehavior="False" />
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <table align="center">
                        <tr>
                            <th>手机品牌</th>
                            <th>手机型号</th>
                            <th>操作类型</th>
                            <th>库存</th>
                            <th class="auto-style1">操作数量</th>
                            <th>下级经销商</th>
                            <th>确认按钮</th>
                        </tr>
                        <tr align="center">
                            <td>
                                <asp:DropDownList ID="DropDownListBrand" runat="server" Width="105px" OnSelectedIndexChanged="DropDownListBrand_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="DropDownListModel" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="DropDownListModel_SelectedIndexChanged"></asp:DropDownList></td>
                            <td align="left">
                                <asp:RadioButtonList ID="RadioButtonListOption" runat="server" OnSelectedIndexChanged="RadioButtonListOption_SelectedIndexChanged" AutoPostBack="True">
                                    <asp:ListItem Value="Init">初始化库存</asp:ListItem>
                                    <asp:ListItem Value="Sell">发货</asp:ListItem>
                                    <asp:ListItem Value="Return">退货</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td>
                                <asp:Label ID="LabelStock" runat="server" MaxLength="5" TextMode="Number" Width="61px" CssClass="auto-style2"></asp:Label></td>
                            <td class="auto-style1">
                                <br /><asp:TextBox ID="TextBoxQuantity" runat="server" MaxLength="5" TextMode="Number" Width="71px" AutoPostBack="True"></asp:TextBox>
                                <br /><asp:Label ID="LabelSign" runat="server" MaxLength="5" TextMode="Number" Width="72px" CssClass="auto-style2"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListSunSeller" runat="server" Width="102px" AutoPostBack="True" Enabled="False"></asp:DropDownList></td>
                            <td>
                                <asp:Button ID="ButtonOK" runat="server" Text="确认" OnClick="ButtonOK_Click" /></td>
                        </tr>
                    </table>
                </div>
                <div align="center">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="日志编号" />
                            <asp:BoundField DataField="UserID" HeaderText="操作用户" />
                            <asp:BoundField HeaderText="品牌" />
                            <asp:BoundField DataField="ModelID" HeaderText="型号" />
                            <asp:BoundField DataField="Opreate" HeaderText="操作" />
                            <asp:BoundField DataField="Quantity" HeaderText="数量" />
                            <asp:BoundField DataField="Object" HeaderText="下级经销商" />
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
