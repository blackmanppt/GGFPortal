<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="GGFPortal.test.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    
        <asp:Button ID="Button2" runat="server" Text="test" OnClick="Button2_Click" />
    
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button3_Click" />
    </div>
        <div>
            test gridview select
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" AutoGenerateSelectButton="True" DataSourceID="SqlDataSource1" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" ViewStateMode="Enabled">
                <Columns>
                    <asp:BoundField DataField="style_no" HeaderText="style_no" SortExpression="style_no" />
                    <asp:BoundField DataField="數量" HeaderText="數量" SortExpression="數量" />
                    <asp:BoundField DataField="單價" HeaderText="單價" SortExpression="單價" />
                    <asp:BoundField DataField="明細金額" HeaderText="明細金額" SortExpression="明細金額" />
                    <asp:BoundField DataField="pur_nbr" HeaderText="pur_nbr" ReadOnly="True" SortExpression="pur_nbr" />
                    <asp:BoundField DataField="acp_nbr" HeaderText="acp_nbr" SortExpression="acp_nbr" />
                    <asp:BoundField DataField="acp_seq" HeaderText="acp_seq" SortExpression="acp_seq" />
                    <asp:BoundField DataField="料品代號" HeaderText="料品代號" SortExpression="料品代號" />
                    <asp:BoundField DataField="立帳幣別" HeaderText="立帳幣別" SortExpression="立帳幣別" />
                    <asp:BoundField DataField="remark40" HeaderText="remark40" SortExpression="remark40" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT * FROM [ViewACP]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
