<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sample002.aspx.cs" Inherits="GGFPortal.Sales.Sample002" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>樣品室處理狀況</title>
    <%--    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/style.css" rel="stylesheet" />
    <script src="../scripts/bootstrap.min.js"></script>
    <script src="../scripts/jquery-3.1.1.min.js"></script>
    <script src="../scripts/scripts.js"></script>--%>
    <link href="../scripts/bootstrap-4.3.1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../scripts/bootstrap-4.3.1/dist/js/bootstrap.min.js"></script>

    <script src="../scripts/jquery-3.4.1.min.js"></script>
    <style>


        .auto-style4 {
            width: 347px;
            text-align: left;
        }

        .auto-style8 {
            width: 100px;
            text-align: left;
        }

        .auto-style13 {
            color: #CC6600;
        }

        .auto-style15 {
            color:darkblue;
        }

        .auto-style16 {
            background-color: #FF9933;
            width: 106px;
            text-align:right;
        }

        .auto-style17 {
            align-content: center;
            text-align: left;
            vertical-align: middle;
            width: 347px;
        }

        .auto-style19 {
            width: 100px;
            text-align: right;
        }

        .auto-style20 {
            width: 120px;
        }

        .auto-style21 {
            text-align: right;
            width: 106px;
        }

        .auto-style22 {
            width: 347px;
        }
    </style>
</head>
<body class="bg-dark">
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg  text-body">

            <asp:Label ID="Label14" runat="server" Text="樣品室處理人員" CssClass="btn btn-warning navbar-brand  "></asp:Label>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <asp:Button ID="IndexBT" runat="server" Text="返回搜尋畫面" OnClick="IndexBT_Click" CssClass="btn btn-outline-success" />
            <%--        <div class="collapse navbar-collapse" id="navbarResponsive">
          <ul class="navbar-nav">
            <li class="nav-item active">
              <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#">Link</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#">Link</a>
            </li>
            <li class="nav-item dropdown">
              <a class="nav-link dropdown-toggle" href="#" id="dropdown" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Dropdown</a>
              <div class="dropdown-menu" aria-labelledby="dropdown">
                <a class="dropdown-item" href="#">Action</a>
                <a class="dropdown-item" href="#">Another action</a>
                <a class="dropdown-item" href="#">Something else here</a>
              </div>
            </li>
          </ul>
        </div>--%>
        </nav>

        <div>

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>



        </div>
        <div class="row">
            <div class="col-12">
                <table class=" table table-bordered table-striped table-dark">
                    <tr>
                        <th class="auto-style19">
                            <asp:Label ID="Label7" runat="server" Text="公司別："></asp:Label>
                        </th>
                        <td class="auto-style20 h3">
                            <asp:Label ID="SiteLB" runat="server" Text=""></asp:Label>
                        </td><th style="color: #003300; background-color: #00CCFF" class="auto-style21">
                            <asp:Label ID="Label6" runat="server" Text="打版完成日："></asp:Label>
                        </th>
                        <td class="auto-style22">
                            <div class="row  form-row">
                                <asp:TextBox ID="FinalDayTB" runat="server" Width="120px" AutoCompleteType="Disabled" Enabled="False" CssClass=" form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="FinalDayTB_CalendarExtender" runat="server" TargetControlID="FinalDayTB" Format="yyyy/MM/dd" CssClass=" table-dark"  />
                                <asp:Button ID="DayUpdateBT" runat="server" Text="打版完成日上傳" OnClick="DayUpdateBT_Click" CssClass="btn btn-outline-success" Visible="False" />
                            </div>
                        </td>
                        

                    </tr>
                    <tr>
                        <th class="auto-style19">
                            <asp:Label ID="SamNbrLB" runat="server" Text="樣品單號(款號)："></asp:Label>
                        </th>
                        <td class="auto-style20 h3 text-warning">
                            <asp:Label ID="SampleNbrLB" runat="server" Text=""></asp:Label>
                            <asp:Label ID="styleLB" runat="server" Text=""></asp:Label>
                        </td>
                        <th class="auto-style16" >
                            <asp:Label ID="Label11" runat="server" Text="打樣預計完成日：" CssClass="auto-style15"></asp:Label>
                        </th>
                        <td class="auto-style22">
                            <div class="row form-row">
                                <asp:TextBox ID="PlanDateTB" runat="server" Enabled="False" Width="120px" CssClass=" form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="PlanDateTB_CalendarExtender" runat="server" BehaviorID="PlanDateTB_CalendarExtender" TargetControlID="PlanDateTB" Format="yyyy/MM/dd"  CssClass=" table-dark" />
                                <asp:Button ID="PlanDateBT" runat="server" Text="打樣預計完成日上傳" CssClass="btn btn-outline-warning" Visible="False" OnClick="PlanDateBT_Click" />
                            </div>
                        </td>

                    </tr>
                    <tr>
                        <th class="auto-style19">
                            <asp:Label ID="Label3" runat="server" Text="處理人員：" CssClass="text-right "></asp:Label>
                        </th>
                        <td class="auto-style20">
                            <asp:DropDownList ID="UserDDL" runat="server" AppendDataBoundItems="True" DataTextField="Name" DataValueField="employee_no" CssClass=" dropdown form-control">
                            </asp:DropDownList>
                            <%--                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" 
                            SelectCommand="SELECT DISTINCT a.employee_no, b.dept_name + '-' + a.employee_name AS Name FROM bas_employee AS a LEFT OUTER JOIN bas_dept AS b ON a.site = b.site AND a.dept_no = b.dept_no WHERE (a.dept_no IN ('K01B','D01A','D010','E010','N01A','N01B','M01A','M01B','K01A','G010')) AND (a.employee_status &lt;&gt; 'IA') ORDER BY Name, a.employee_no" OnSelecting="SqlDataSource2_Selecting" OnSelected="SqlDataSource2_Selected">
                        </asp:SqlDataSource>--%>
                            <asp:Label ID="UserLB" runat="server" Text=""></asp:Label>
                        </td>
                        <th class="auto-style16" >
                            <asp:Label ID="Label13" runat="server" Text="上線日："  CssClass="auto-style15"></asp:Label>
                        </th>
                        <td style="" class="auto-style22">
                            <div class="row form-row">
                                <asp:TextBox ID="上線日上傳TB" runat="server" Enabled="False" Width="120px" CssClass=" form-control"></asp:TextBox>

                                <ajaxToolkit:CalendarExtender ID="上線日上傳TB_CalendarExtender" runat="server" BehaviorID="上線日上傳TB_CalendarExtender" TargetControlID="上線日上傳TB" Format="yyyy/MM/dd"  CssClass=" table-dark" />

                                <asp:Button ID="上線日上傳BT" runat="server" Text="上線日上傳" CssClass="btn btn-outline-warning" Visible="False" OnClick="上線日上傳BT_Click" />
                            </div>
                        </td>

                    </tr>
                    <tr>
                        <th class="auto-style19">
                            <asp:Label ID="Label4" runat="server" Text="處理方式："></asp:Label>
                        </th>
                        <td class="auto-style20">
                            <asp:DropDownList ID="TypeDDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource3" DataTextField="MappingData" DataValueField="Data" CssClass=" dropdown form-control">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="select Data,MappingData from Mapping where UsingDefine='GGFRequestSam'"></asp:SqlDataSource>
                        </td>
                        <th class="auto-style16" style="text-align: right">
                            <asp:Label ID="Label9" runat="server" Text="樣衣收單日：" CssClass="auto-style15"></asp:Label>
                        </th>
                        <td class="auto-style22 ">
                            <div class="row form-row">
                                <asp:TextBox ID="SamInTB" runat="server" Width="120px" AutoCompleteType="Disabled" Enabled="False" CssClass=" form-control"></asp:TextBox>

                                <ajaxToolkit:CalendarExtender ID="SamInTB_CalendarExtender" runat="server" BehaviorID="SamInTB_CalendarExtender" TargetControlID="SamInTB" Format="yyyy/MM/dd"  CssClass="table-dark" />

                                <asp:Button ID="SamInBT" runat="server" Text="樣衣收單日上傳" OnClick="SamInBT_Click" CssClass="btn btn-outline-warning" Visible="False" />
                            </div>
                        </td>

                    </tr>
                    <tr>
                        <th class="auto-style19">
                            <asp:Label ID="Label5" runat="server" Text="處理件數："></asp:Label>
                        </th>
                        <td class="auto-style20">
                            <asp:TextBox ID="QtyTB" runat="server" CssClass=" form-control"></asp:TextBox>
                        </td>
                        <th class="auto-style16" style="text-align: right">
                            <asp:Label ID="Label10" runat="server" Text="樣衣完成日：" CssClass="auto-style15"></asp:Label>
                        </th>
                        <td class="auto-style22">
                            <div class="row form-row">
                                <asp:TextBox ID="SamOutTB" runat="server" Width="120px" AutoCompleteType="Disabled" Enabled="False" CssClass=" form-control"></asp:TextBox>

                                <ajaxToolkit:CalendarExtender ID="SamOutTB_CalendarExtender" runat="server" BehaviorID="SamOutTB_CalendarExtender" TargetControlID="SamOutTB" Format="yyyy/MM/dd" CssClass=" table-dark" />

                                <asp:Button ID="SamOutBT" runat="server" Text="樣衣完成日上傳" OnClick="SamOutBT_Click" CssClass="btn btn-outline-warning" Visible="False" />
                            </div>
                        </td>

                    </tr>
                    <tr>
                        <th class="auto-style19">
                            <asp:Label ID="DateLB" runat="server" Text="處理日期：" Visible="false"></asp:Label>
                        </th>
                        <td class="auto-style8">
                            <div class="row form-row">
                                <asp:TextBox ID="DateTB" runat="server" Visible="false" CssClass=" form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="DateTB_CalendarExtender" runat="server" TargetControlID="DateTB" Format="yyyyMMdd"  CssClass=" table-dark" />
                            </div>
                        </td>
                        <th class="auto-style21">
                            <asp:Label ID="Label8" runat="server" Text="TD收單日：" Style="text-align: right"></asp:Label>
                        </th>
                        <td class="auto-style4">
                            <div class="row form-row">
                                <asp:TextBox ID="TDinDateTB" runat="server" Width="120px" AutoCompleteType="Disabled" Enabled="False" CssClass=" form-control"></asp:TextBox>
                                <asp:Button ID="TDinDateBT" runat="server" Text="TD收單日" CssClass="btn btn-outline-info text-break" Visible="False" OnClick="TDinDateBT_Click" />
                                <ajaxToolkit:CalendarExtender ID="TDinDateTB_CalendarExtender" runat="server" BehaviorID="TDinDateTB_CalendarExtender" TargetControlID="TDinDateTB" Format="yyyy/MM/dd"  CssClass=" table-dark" />
                            </div>


                        </td>

                    </tr>
                    <tr>
                        <th class="auto-style19">
                            <asp:Label ID="Label12" runat="server" Text="原因碼："></asp:Label>
                        </th>
                        <td class="auto-style8">
                            <div class="form-group">
                                <asp:DropDownList ID="原因碼DDL" runat="server" DataTextField="reason_name" DataValueField="reason" CssClass=" dropdown form-control">
                                </asp:DropDownList>
                                <asp:Label ID="原因LB" runat="server" Text="" Style="text-align: right"></asp:Label>
                            </div>
                        </td>

                        <th class="auto-style21">
                            <asp:Label ID="Label2" runat="server" Text="TD完成日：" Style="text-align: right"></asp:Label>
                        </th>
                        <td class="auto-style4">
                            <div class="row form-row">
                                <asp:TextBox ID="TDFinTB" runat="server" Width="120px" AutoCompleteType="Disabled" Enabled="False" CssClass=" form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="TDFinTB_CalendarExtender" runat="server" BehaviorID="TDFinTB_CalendarExtender" TargetControlID="TDFinTB" Format="yyyy/MM/dd"  CssClass=" table-dark" />
                                <asp:Button ID="TDFinBT" runat="server" Text="TD完成日上傳" OnClick="TDFinBT_Click" CssClass="btn btn-outline-info" Visible="False" />
                            </div>
                        </td>


                    </tr>
                    <tr>
                        <th class="auto-style19">
                            <asp:Label ID="DateLB0" runat="server" Text="備註："></asp:Label>
                        </th>
                        <td class="auto-style8">
                            <asp:TextBox ID="RemarkTB" runat="server" Height="58px" TextMode="MultiLine" Width="300px" CssClass=" form-control"></asp:TextBox>
                        </td>
                        <th class="auto-style21">&nbsp;</th>
                        <td class="auto-style17">
                            <div class="form-row row">
                                <asp:Button ID="AddBT" runat="server" OnClick="AddBT_Click" Text="新增" CssClass="btn btn-warning " />
                                <asp:Button ID="UpDateBT" runat="server" OnClick="UpDateBT_Click1" Text="更新" Visible="False" CssClass="btn btn-primary " />
                                <asp:Button ID="CancelBT" runat="server" OnClick="CancelBT_Click" Text="取消" Visible="False" CssClass="btn btn-danger  " />
                            </div>
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
            </div>

        </div>
        <div>



            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="uid,sam_nbr" DataSourceID="SqlDataSource1" CellPadding="4" GridLines="None" Style="background-color: #00CC00" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" CssClass="table table-condensed" ForeColor="#333333">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                            <asp:Button ID="修改馬克" runat="server" CausesValidation="False" CommandName="EditeDetail" Text="修改馬克" CssClass="btn btn-default" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="uid" HeaderText="uid" InsertVisible="False" ReadOnly="True" SortExpression="uid" />
                    <asp:BoundField DataField="sam_nbr" HeaderText="打樣單號" ReadOnly="True" SortExpression="sam_nbr" />
                    <asp:BoundField DataField="MappingData" HeaderText="處理類別" SortExpression="MappingData" />
                    <asp:BoundField DataField="SampleUser" HeaderText="處理人員" SortExpression="SampleUser" />
                    <asp:BoundField DataField="Qty" HeaderText="數量" SortExpression="Qty" />
                    <asp:BoundField DataField="SampleCreatDate" HeaderText="處理日期" SortExpression="SampleCreatDate" NullDisplayText="沒有資料" />
                    <asp:BoundField DataField="CreatDate" HeaderText="建立日期" SortExpression="CreatDate" NullDisplayText="沒有資料" DataFormatString="{0:yyyy/MM/dd}" />
                    <asp:BoundField DataField="馬克處理次數" HeaderText="馬克處理次數" SortExpression="馬克處理次數" NullDisplayText="沒有資料" />
                    <asp:BoundField DataField="Remark" HeaderText="備註" SortExpression="Remark" NullDisplayText="沒有資料" />
                    <%--                    <asp:BoundField DataField="修改馬克" HeaderText="修改馬克" SortExpression="修改馬克" NullDisplayText="沒有資料" />
                    <asp:BoundField DataField="馬克完成日" HeaderText="馬克完成日" SortExpression="馬克完成日" NullDisplayText="沒有資料" />--%>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <EmptyDataRowStyle BackColor="#00CC66" />
                <EmptyDataTemplate>
                    <h2>樣品單沒有資料
                        <br />
                        請新增資料</h2>
                </EmptyDataTemplate>
                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT *,(select count(*) from GGFRequestMark x where x.uid=[GGFRequestSam].uid and 狀態=0) as 馬克處理次數 FROM [GGFRequestSam]  left join Mapping on [GGFRequestSam].SampleType=Mapping.Data and Mapping.UsingDefine='GGFRequestSam' WHERE Flag = 0 and  ([sam_nbr] = @sam_nbr and site=@site)" DeleteCommand="DELETE FROM GGFRequestSam WHERE (1 = 2)">
                <SelectParameters>
                    <asp:SessionParameter Name="sam_nbr" SessionField="SampleNbr" Type="String" />
                    <asp:SessionParameter Name="site" SessionField="Site" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>

        </div>
 <div>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="show3" runat="server" Text="show3" Style="" OnClick="show3_Click" Visible="false" />
                                <%--<asp:Button ID="Button1" runat="server" Text="show3" Style="display: none" />--%>
                                <asp:Panel ID="AlertPanel" runat="server" align="center" Height="100px" Width="600px" Style="display: none" CssClass="bg-secondary">
                                    <div class=" text-center">
                                        <h3>
                                            <asp:Label ID="MessageLB" runat="server" Text="" CssClass="h3"></asp:Label>

                                        </h3>
                                        <asp:Button ID="AlertBT" runat="server" Text="確定" CssClass="btn btn-danger" />
                                    </div>
                                </asp:Panel>
                                <ajaxToolkit:ModalPopupExtender ID="AlertPanel_ModalPopupExtender" runat="server" BehaviorID="AlertPanel_ModalPopupExtender" TargetControlID="show3" PopupControlID="AlertPanel" CancelControlID="">
                                </ajaxToolkit:ModalPopupExtender>
                                
                            </ContentTemplate>
                        </asp:UpdatePanel>
            </div>
    </form>
    <script src="../scripts/bootstrap-4.3.1/js/dist/util.js"></script>
    <script src="../scripts/bootstrap-4.3.1/js/dist/dropdown.js"></script>
    <script src="../scripts/bootstrap-4.3.1/js/dist/collapse.js"></script>
</body>
</html>
