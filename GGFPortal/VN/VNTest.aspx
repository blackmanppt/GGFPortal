<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VNTest.aspx.cs" Inherits="GGFPortal.VN.VNTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="uid" DataSourceID="SqlDataSource1" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="uid" HeaderText="uid" InsertVisible="False" ReadOnly="True" SortExpression="uid" />
                    <asp:BoundField DataField="Team" HeaderText="Team" SortExpression="Team" />
                    <asp:BoundField DataField="FileName" HeaderText="FileName" SortExpression="FileName" />
                    <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                    <asp:BoundField DataField="Area" HeaderText="Area" SortExpression="Area" />
                    <asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag" />
                    <asp:BoundField DataField="CreateDate" HeaderText="CreateDate" SortExpression="CreateDate" />
                    <asp:BoundField DataField="Creator" HeaderText="Creator" SortExpression="Creator" />
                    <asp:BoundField DataField="ModifyDate" HeaderText="ModifyDate" SortExpression="ModifyDate" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" DeleteCommand="UPDATE Productivity_Head SET Flag = 2 WHERE (1 = 2)" SelectCommand="SELECT * FROM [Productivity_Head]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
