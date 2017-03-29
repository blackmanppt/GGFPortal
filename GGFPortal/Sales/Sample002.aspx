<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sample002.aspx.cs" Inherits="GGFPortal.Sales.Sample002" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>樣品室處理狀況</title>

    <style>
        #titletable {
            border-collapse: collapse;
            border: 1px solid black;
        }

        .auto-style1 {
            width: 90px;
            border: 1px solid black;
        }

        .auto-style2 {
            width: 270px;
            border: 1px solid black;
        }

        .auto-style3 {
            width: 239px;
            border: 1px solid black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="Label1" runat="server" Text="樣品室處理人員" style="font-size: xx-large; font-weight: 700; background-color: #66CCFF;"></asp:Label>

        </div>
        <div>

            <table style="width: 600px;" id="titletable">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="SamNbrLB" runat="server" Text="樣品單號："></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:Label ID="SampleNbrLB" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label3" runat="server" Text="處理人員："></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="UserDDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="employee_no">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="select distinct employee_no,dept_no+dept_name+'-'+employee_name_c as Name
  FROM [GGF].[dbo].[view_empl_name_id_dept_name]
  where dept_no in ('17','18','40','41','42','43','44') order by Name,employee_no "></asp:SqlDataSource>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label4" runat="server" Text="處理方式："></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="TypeDDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource3" DataTextField="MappingData" DataValueField="Data">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="select Data,MappingData from Mapping where UsingDefine='GGFRequestSam'"></asp:SqlDataSource>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label5" runat="server" Text="處理件數："></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="QtyTB" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="AddBT" runat="server" Text="新增" OnClick="AddBT_Click" />
                        <asp:Button ID="UpDateBT" runat="server" Text="更新" OnClick="UpDateBT_Click1" Visible="False" />
                        <asp:Button ID="CancelBT" runat="server" Text="取消" OnClick="CancelBT_Click" Visible="False" />
                    </td>
                </tr>
            </table>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="uid,sam_nbr" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" Style="background-color: #00CC00" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:CommandField ButtonType="Button" SelectText="編輯" ShowSelectButton="True" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除" OnClientClick="return confirm('是否刪除')" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="uid" HeaderText="uid" InsertVisible="False" ReadOnly="True" SortExpression="uid" />
                    <asp:BoundField DataField="sam_nbr" HeaderText="打樣單號" ReadOnly="True" SortExpression="sam_nbr" />
                    <asp:BoundField DataField="MappingData" HeaderText="處理類別" SortExpression="MappingData" />
                    <asp:BoundField DataField="SampleUser" HeaderText="處理人員" SortExpression="SampleUser" />
                    <asp:BoundField DataField="Qty" HeaderText="數量" SortExpression="Qty" />
                </Columns>
                <EmptyDataRowStyle BackColor="#00CC66" />
                <EmptyDataTemplate>
                    樣品單沒有資料<br />
                    請新增資料
                </EmptyDataTemplate>
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#594B9C" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#33276A" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT * FROM [GGFRequestSam]  left join Mapping on [GGFRequestSam].SampleType=Mapping.Data and Mapping.UsingDefine='GGFRequestSam' WHERE Flag = 0 and  ([sam_nbr] = @sam_nbr)" DeleteCommand="DELETE FROM GGFRequestSam WHERE (1 = 2)">
                <SelectParameters>
                    <asp:SessionParameter Name="sam_nbr" SessionField="SampleNbr" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>

        </div>
        <div>
        </div>
    </form>
</body>
</html>
