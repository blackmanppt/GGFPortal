<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sample002.aspx.cs" Inherits="GGFPortal.Sales.Sample002" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>樣品室處理狀況</title>
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/style.css" rel="stylesheet" />
    <script src="../scripts/bootstrap.min.js"></script>
    <script src="../scripts/jquery-3.1.1.min.js"></script>
    <script src="../scripts/scripts.js"></script>
    <style>
        #titletable {
            border-collapse: collapse;
            border: 1px solid black;
        }

        .auto-style3 {
            width: 239px;
            border: 1px solid black;
        }
        .auto-style4 {
            width: 146px;
            border: 1px solid black;
            text-align: left;
        }
        .auto-style7 {
            width: 41px;
            border: 1px solid black;
        }
        .auto-style8 {
            width: 41px;
            border: 1px solid black;
            text-align: left;
        }
        .auto-style10 {
            width: 105px;
            border: 1px solid black;
            text-align: right;
        }
        .auto-style11 {
            width: 105px;
            border: 1px solid black;
            text-align: right;
            background-color: #FFFFFF;
        }
        .auto-style13 {
            color: #CC6600;
        }
        .auto-style15 {
            color: #00FF00;
        }
        .auto-style16 {
            background-color: #FF9933;
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

            <table style="width: 800px;" id="titletable" class=" table">
                <tr>
                    <th style="border: 1px solid #000000; text-align: right">
                        <asp:Label ID="Label7" runat="server" Text="公司別："></asp:Label>
                    </th>
                    <td style="border: 1px solid #000000; "">
                        <asp:Label ID="SiteLB" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="2" style="border: 1px solid #000000;text-align: right ">
                        <asp:Button ID="IndexBT" runat="server" Text="返回搜尋畫面" OnClick="IndexBT_Click" CssClass="btn btn-block btn-primary" />
                    </td>
                </tr>
                <tr>
                    <th style="border: 1px solid #000000; text-align: right">
                        <asp:Label ID="SamNbrLB" runat="server" Text="樣品單號(款號)："></asp:Label>
                    </th>
                    <td class="auto-style7">
                        <asp:Label ID="SampleNbrLB" runat="server" Text=""></asp:Label>
                        <asp:Label ID="styleLB" runat="server" Text="" style="font-weight: 700; color: #FF3300"></asp:Label>
                    </td>
                    <th class="auto-style10">
                        <asp:Label ID="Label11" runat="server" Text="打樣預計完成日："></asp:Label>
                    </th>
                    <td class="auto-style3">
                        <asp:TextBox ID="PlanDateTB" runat="server" Enabled="False" Width="90px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="PlanDateTB_CalendarExtender" runat="server" BehaviorID="PlanDateTB_CalendarExtender" TargetControlID="PlanDateTB" Format="yyyy/MM/dd" />
                        <asp:Button ID="PlanDateBT" runat="server" Text="打樣預計完成日上傳"  CssClass="btn btn-primary" Visible="False" OnClick="PlanDateBT_Click"  />
                    </td>
                </tr>
                <tr>
                    <th style="border: 1px solid #000000; text-align: right">
                        <asp:Label ID="Label3" runat="server" Text="處理人員："></asp:Label>
                    </th>
                    <td class="auto-style7">
                        <asp:DropDownList ID="UserDDL" runat="server" AppendDataBoundItems="True"  DataTextField="Name" DataValueField="employee_no" CssClass=" dropdown dropdown-toggle">
                        </asp:DropDownList>
<%--                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" 
                            SelectCommand="SELECT DISTINCT a.employee_no, b.dept_name + '-' + a.employee_name AS Name FROM bas_employee AS a LEFT OUTER JOIN bas_dept AS b ON a.site = b.site AND a.dept_no = b.dept_no WHERE (a.dept_no IN ('K01B','D01A','D010','E010','N01A','N01B','M01A','M01B','K01A','G010')) AND (a.employee_status &lt;&gt; 'IA') ORDER BY Name, a.employee_no" OnSelecting="SqlDataSource2_Selecting" OnSelected="SqlDataSource2_Selected">
                        </asp:SqlDataSource>--%>
                        <asp:Label ID="UserLB" runat="server" Text=""></asp:Label>
                    </td>
                    <th style="border: 1px solid #000000;text-align: right; color: #003300; background-color: #00CCFF" >
                        <asp:Label ID="Label6" runat="server" Text="打版完成日：" CssClass="auto-style13"></asp:Label>
                    </th>
                    <td class="auto-style3">
                        <asp:TextBox ID="FinalDayTB" runat="server"  Width="90px" AutoCompleteType="Disabled" Enabled="False"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="FinalDayTB_CalendarExtender" runat="server" TargetControlID="FinalDayTB" Format="yyyy/MM/dd" />
                        <asp:Button ID="DayUpdateBT" runat="server" Text="打版完成日上傳" OnClick="DayUpdateBT_Click" CssClass="btn btn-primary" Visible="False" />
                    </td>
                </tr>
                <tr>
                    <th style="border: 1px solid #000000; text-align: right">
                        <asp:Label ID="Label4" runat="server" Text="處理方式："></asp:Label>
                    </th>
                    <td class="auto-style7">
                        <asp:DropDownList ID="TypeDDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource3" DataTextField="MappingData" DataValueField="Data">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="select Data,MappingData from Mapping where UsingDefine='GGFRequestSam'"></asp:SqlDataSource>
                    </td>
                    <th class="auto-style16" style="border: 1px solid #000000;text-align: right">
                        <asp:Label ID="Label9" runat="server" Text="樣衣收單日：" CssClass="auto-style15"></asp:Label>
                    </th>
                    <td class="auto-style3">
                        <asp:TextBox ID="SamInTB" runat="server"  Width="90px" AutoCompleteType="Disabled" Enabled="False"></asp:TextBox>
                        
                        <ajaxToolkit:CalendarExtender ID="SamInTB_CalendarExtender" runat="server" BehaviorID="SamInTB_CalendarExtender" TargetControlID="SamInTB"  Format="yyyy/MM/dd" />
                        
                        <asp:Button ID="SamInBT" runat="server" Text="樣衣收單日上傳" OnClick="SamInBT_Click"  CssClass="btn btn-primary" Visible="False"/>
                    </td>
                </tr>
                <tr>
                    <th style="border: 1px solid #000000;text-align: right" >
                        <asp:Label ID="Label5" runat="server" Text="處理件數："></asp:Label>
                    </th>
                    <td class="auto-style7">
                        <asp:TextBox ID="QtyTB" runat="server"></asp:TextBox>
                    </td>
                    <th class="auto-style16" style="border: 1px solid #000000;text-align: right" >
                        <asp:Label ID="Label10" runat="server" Text="樣衣完成日：" CssClass="auto-style15"></asp:Label>
                    </th>
                    <td class="auto-style3">
                        <asp:TextBox ID="SamOutTB" runat="server" Width="90px" AutoCompleteType="Disabled" Enabled="False"></asp:TextBox>
                        
                        <ajaxToolkit:CalendarExtender ID="SamOutTB_CalendarExtender" runat="server" BehaviorID="SamOutTB_CalendarExtender" TargetControlID="SamOutTB" Format="yyyy/MM/dd"  />
                        
                        <asp:Button ID="SamOutBT" runat="server" Text="樣衣完成日上傳" OnClick="SamOutBT_Click" CssClass="btn btn-primary" Visible="False"/>
                    </td>
                </tr>
                <tr>
                    <th style="border: 1px solid #000000;text-align: right"  >
                        <asp:Label ID="DateLB" runat="server" Text="處理日期：" Visible="false" ></asp:Label>
                    </th>
                    <td class="auto-style8">
                        <asp:TextBox ID="DateTB" runat="server" Visible="false"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="DateTB_CalendarExtender" runat="server" TargetControlID="DateTB" Format="yyyyMMdd" />
                    </td>
                    <th class="" style="text-align: right; color: #FFFFFF; background-color: #000000">
                        <asp:Label ID="Label8" runat="server" Text="TD完成日：" style="text-align: right" ></asp:Label>
                    </th>
                    <td class="auto-style4">
                        <asp:TextBox ID="TDFinTB" runat="server" Width="90px" AutoCompleteType="Disabled" Enabled="False"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="TDFinTB_CalendarExtender" runat="server" BehaviorID="TDFinTB_CalendarExtender" TargetControlID="TDFinTB"  Format="yyyy/MM/dd" />
                        <asp:Button ID="TDFinBT" runat="server" Text="TD完成日上傳" OnClick="TDFinBT_Click" CssClass="btn btn-primary" Visible="False"/>
                    </td>
                </tr>
                 <tr>
                    <th style="border: 1px solid #000000;text-align: right" >
                        <asp:Label ID="DateLB0" runat="server" Text="備註：" ></asp:Label>
                     </th>
                    <td class="auto-style8">
                        <asp:TextBox ID="RemarkTB" runat="server" Height="58px" TextMode="MultiLine" Width="257px" CssClass=""></asp:TextBox>
                     </td>
                    <th class="auto-style11"></th>
                    <td class="auto-style4">
                        <asp:Button ID="AddBT" runat="server" OnClick="AddBT_Click" Text="新增" CssClass="btn btn-warning"/>
                        <asp:Button ID="UpDateBT" runat="server" OnClick="UpDateBT_Click1" Text="更新" Visible="False" CssClass="btn btn-primary"/>
                        <asp:Button ID="CancelBT" runat="server" OnClick="CancelBT_Click" Text="取消" Visible="False" CssClass="btn btn-danger"/>
                     </td>
                </tr>
                <%--<tr>
                    <th class="auto-style1">
                        <asp:Label ID="Label8" runat="server" Text="放縮馬克："></asp:Label>
                    </th>
                    <td class="auto-style2">
                        <asp:DropDownList ID="MarkDDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource4" DataTextField="Name" DataValueField="employee_no">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand=
  " select distinct a.employee_no,b.dept_name+'-'+a.employee_name  as Name from bas_employee a left join bas_dept b on a.site=b.site and a.dept_no=b.dept_no where a.dept_no in ('E010','M01B','N01B') and a.employee_status<>'IA'  order by Name,employee_no "></asp:SqlDataSource>
                    </td>
                                        <th class="auto-style4">
                        <asp:Label ID="Label9" runat="server" Text="修改放縮馬克："></asp:Label>
                    </th>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ReMarkDDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource5" DataTextField="Name" DataValueField="employee_no">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand=
  " select distinct a.employee_no,b.dept_name+'-'+a.employee_name  as Name from bas_employee a left join bas_dept b on a.site=b.site and a.dept_no=b.dept_no where a.dept_no in ('E010','M01B','N01B') and a.employee_status<>'IA'  order by Name,employee_no "></asp:SqlDataSource>
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

                    </td>
                </tr>--%>
            </table>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="uid,sam_nbr" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" Style="background-color: #00CC00" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" CssClass="table table-condensed">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="EditData" Text="編輯" />
                        </ItemTemplate>
                        <ControlStyle CssClass="btn btn-primary" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除" OnClientClick="return confirm('是否刪除')" CssClass="btn btn-danger " />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="修改馬克" runat="server" CausesValidation="False" CommandName="EditeDetail" Text="修改馬克"  CssClass="btn btn-default" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="uid" HeaderText="uid" InsertVisible="False" ReadOnly="True" SortExpression="uid" />
                    <asp:BoundField DataField="sam_nbr" HeaderText="打樣單號" ReadOnly="True" SortExpression="sam_nbr" />
                    <asp:BoundField DataField="MappingData" HeaderText="處理類別" SortExpression="MappingData" />
                    <asp:BoundField DataField="SampleUser" HeaderText="處理人員" SortExpression="SampleUser" />
                    <asp:BoundField DataField="Qty" HeaderText="數量" SortExpression="Qty" />
                    <asp:BoundField DataField="SampleCreatDate" HeaderText="處理日期" SortExpression="SampleCreatDate" NullDisplayText="沒有資料" />
                    <asp:BoundField DataField="CreatDate" HeaderText="建立日期" SortExpression="CreatDate" NullDisplayText="沒有資料" DataFormatString="{0:yyyy/MM/dd}"/>
                    <asp:BoundField DataField="馬克處理次數" HeaderText="馬克處理次數" SortExpression="馬克處理次數" NullDisplayText="沒有資料" />
                    <asp:BoundField DataField="Remark" HeaderText="備註" SortExpression="Remark" NullDisplayText="沒有資料" />
<%--                    <asp:BoundField DataField="修改馬克" HeaderText="修改馬克" SortExpression="修改馬克" NullDisplayText="沒有資料" />
                    <asp:BoundField DataField="馬克完成日" HeaderText="馬克完成日" SortExpression="馬克完成日" NullDisplayText="沒有資料" />--%>
                </Columns>
                <EmptyDataRowStyle BackColor="#00CC66" />
                <EmptyDataTemplate>
                   <h2> 樣品單沒有資料 <br />
                    請新增資料</h2>
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT *,(select count(*) from GGFRequestMark x where x.uid=[GGFRequestSam].uid and 狀態=0) as 馬克處理次數 FROM [GGFRequestSam]  left join Mapping on [GGFRequestSam].SampleType=Mapping.Data and Mapping.UsingDefine='GGFRequestSam' WHERE Flag = 0 and  ([sam_nbr] = @sam_nbr and site=@site)" DeleteCommand="DELETE FROM GGFRequestSam WHERE (1 = 2)">
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
