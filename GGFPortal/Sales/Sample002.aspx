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
            width: 211px;
            border: 1px solid black;
            text-align: right;
        }

        .auto-style2 {
            width: 255px;
            border: 1px solid black;
        }

        .auto-style3 {
            width: 239px;
            border: 1px solid black;
        }
        .auto-style4 {
            width: 146px;
            border: 1px solid black;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="Label1" runat="server" Text="樣品室處理人員" style="font-size: xx-large; font-weight: 700; background-color: #66CCFF;"></asp:Label>

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>

        </div>
        <div>

            <table style="width: 600px;" id="titletable">
                <tr>
                    <th class="auto-style1">
                        <asp:Label ID="Label7" runat="server" Text="公司別："></asp:Label>
                    </th>
                    <td class="auto-style2">
                        <asp:Label ID="SiteLB" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="2" style="text-align: right">
                        <asp:Button ID="IndexBT" runat="server" Text="返回搜尋畫面" OnClick="IndexBT_Click" />
                    </td>
                </tr>
                <tr>
                    <th class="auto-style1">
                        <asp:Label ID="SamNbrLB" runat="server" Text="樣品單號："></asp:Label>
                    </th>
                    <td class="auto-style2">
                        <asp:Label ID="SampleNbrLB" runat="server" Text=""></asp:Label>
                    </td>
                    <th class="auto-style4">
                        &nbsp;</th>
                    <td class="auto-style3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <th class="auto-style1">
                        <asp:Label ID="Label3" runat="server" Text="處理人員："></asp:Label>
                    </th>
                    <td class="auto-style2">
                        <asp:DropDownList ID="UserDDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="employee_no">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" 
                            SelectCommand="select distinct a.employee_no,b.dept_name+'-'+a.employee_name  as Name from bas_employee a left join bas_dept b on a.site=b.site and a.dept_no=b.dept_no where a.dept_no in ('K01B','D01A','D010','E010','N01A','N01B','M01A','M01B','K01A')  and a.employee_status<>'IA'  order by Name,employee_no"></asp:SqlDataSource>
                    </td>
                    <th class="auto-style4">
                        <asp:Label ID="DateLB" runat="server" Text="處理日期：" Visible="false"></asp:Label>
                    </th>
                    <td class="auto-style3">
                        <asp:TextBox ID="DateTB" runat="server" Visible="false"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="DateTB_CalendarExtender" runat="server" TargetControlID="DateTB" Format="yyyyMMdd" />
                    </td>
                </tr>
                <tr>
                    <th class="auto-style1">
                        <asp:Label ID="Label4" runat="server" Text="處理方式："></asp:Label>
                    </th>
                    <td class="auto-style2">
                        <asp:DropDownList ID="TypeDDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource3" DataTextField="MappingData" DataValueField="Data">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="select Data,MappingData from Mapping where UsingDefine='GGFRequestSam'"></asp:SqlDataSource>
                    </td>
                    <th class="auto-style4">
                        <asp:Label ID="Label6" runat="server" Text="打版完成日："></asp:Label>
                    </th>
                    <td class="auto-style3">
                        <asp:TextBox ID="FinalDayTB" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="FinalDayTB_CalendarExtender" runat="server" TargetControlID="FinalDayTB" Format="yyyy/MM/dd" />
                        <asp:Button ID="DayUpdateBT" runat="server" Text="日期上傳" OnClick="DayUpdateBT_Click" />
                    </td>
                </tr>
                <tr>
                    <th class="auto-style1">
                        <asp:Label ID="Label5" runat="server" Text="處理件數："></asp:Label>
                    </th>
                    <td class="auto-style2">
                        <asp:TextBox ID="QtyTB" runat="server"></asp:TextBox>
                    </td>
                    <th class="auto-style4"></th>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <th class="auto-style1">
                        <asp:Label ID="Label8" runat="server" Text="放縮馬克："></asp:Label>
                    </th>
                    <td class="auto-style2">
                        <asp:DropDownList ID="MarkDDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource4" DataTextField="Name" DataValueField="employee_no">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand=
  " select distinct a.employee_no,b.dept_name+'-'+a.employee_name  as Name from bas_employee a left join bas_dept b on a.site=b.site and a.dept_no=b.dept_no where a.dept_no in ('E01A') and a.employee_status<>'IA'  order by Name,employee_no "></asp:SqlDataSource>
                    </td>
                                        <th class="auto-style4">
                        <asp:Label ID="Label9" runat="server" Text="修改放縮馬克："></asp:Label>
                    </th>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ReMarkDDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource5" DataTextField="Name" DataValueField="employee_no">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand=
  " select distinct a.employee_no,b.dept_name+'-'+a.employee_name  as Name from bas_employee a left join bas_dept b on a.site=b.site and a.dept_no=b.dept_no where a.dept_no in ('E01A') and a.employee_status<>'IA'  order by Name,employee_no "></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <th class="auto-style1">
                        <asp:Label ID="Label10" runat="server" Text="馬克完成日："></asp:Label>
                    </th>
                    <td class="auto-style2">
                        <asp:TextBox ID="MarkDateTB" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="MarkDateTB_CalendarExtender" runat="server" TargetControlID="MarkDateTB" Format="yyyyMMdd" />
                    </td>

                                        <td class="auto-style3" colspan="2">
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
                    <asp:BoundField DataField="SampleCreatDate" HeaderText="建立日期" SortExpression="SampleCreatDate" NullDisplayText="沒有資料" />
                    <asp:BoundField DataField="馬克" HeaderText="馬克" SortExpression="馬克" NullDisplayText="沒有資料" />
                    <asp:BoundField DataField="修改馬克" HeaderText="修改馬克" SortExpression="修改馬克" NullDisplayText="沒有資料" />
                    <asp:BoundField DataField="馬克完成日" HeaderText="馬克完成日" SortExpression="馬克完成日" NullDisplayText="沒有資料" />
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT * FROM [GGFRequestSam]  left join Mapping on [GGFRequestSam].SampleType=Mapping.Data and Mapping.UsingDefine='GGFRequestSam' WHERE Flag = 0 and  ([sam_nbr] = @sam_nbr and site=@site)" DeleteCommand="DELETE FROM GGFRequestSam WHERE (1 = 2)">
                <SelectParameters>
                    <asp:SessionParameter Name="sam_nbr" SessionField="SampleNbr" Type="String" />
                    <asp:SessionParameter Name="site" SessionField="Site" Type="String"  />
                </SelectParameters>
            </asp:SqlDataSource>

        </div>
        <div>
        </div>
    </form>
</body>
</html>
