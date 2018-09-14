<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MGT009.aspx.cs" Inherits="GGFPortal.MGT.MGT009" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>快遞單INVOICE</title>
    <script src="../scripts/jquery-3.1.1.min.js"></script>
    <script src="../scripts/scripts.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-2">
                    <nav class="navbar navbar-default" role="navigation">
                        <h3 class="text-info text-left">快遞單INVOICE</h3>
                        
                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">
                            <h4>快遞單日期</h4>
                            <div class="form-group">
                                <asp:TextBox ID="StartDay" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="StartDay_CalendarExtender" runat="server" BehaviorID="StartDay_CalendarExtender" TargetControlID="StartDay" Format="yyyy-MM-dd" />
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="EndDay" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="EndDay_CalendarExtender" runat="server" BehaviorID="EndDay_CalendarExtender" TargetControlID="EndDay"  Format="yyyy-MM-dd" />
                            </div>
                            <h4>提單號碼</h4>
                            <div class="form-group">
                                <asp:TextBox ID="提單TB" runat="server" CssClass="form-control" ></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc"  BehaviorID="提單TB_AutoCompleteExtender" TargetControlID="提單TB" ID="提單TB_AutoCompleteExtender" ServiceMethod="Search提單號碼" MinimumPrefixLength="1" UseContextKey="True"></ajaxToolkit:AutoCompleteExtender>
                            </div>
 <%--                           <h4>款號</h4>
                            <div class="form-group">
                                <asp:TextBox ID="款號TB" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <h4>年度</h4>
                                <div class="form-group">
                                <asp:DropDownList ID="年度DDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource2" DataTextField="season_y" DataValueField="season_y"  CssClass="form-control">
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>

                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT DISTINCT [season_y] FROM [ordc_bah1] ORDER BY [season_y] DESC"></asp:SqlDataSource>
                                    </div>
                            <h4>季節</h4>
                            <div class="form-group">
                                <asp:DropDownList ID="季節DDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="season" DataValueField="season"  CssClass="form-control">
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT DISTINCT [season] FROM [ordc_bah1] ORDER BY [season]"></asp:SqlDataSource>
                            </div>
                            <h4>代理商</h4>
                            <div class="form-group">
                                <asp:TextBox ID="代理商TB" runat="server"  CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" BehaviorID="代理商TB_AutoCompleteExtender" TargetControlID="代理商TB" ID="代理商TB_AutoCompleteExtender" ServiceMethod="Search訂單客戶品牌" MinimumPrefixLength="1" UseContextKey="True"></ajaxToolkit:AutoCompleteExtender>

 多欄位autocomp                               <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" TargetControlID="供應商TB" ID="供應商TB_AutoCompleteExtender" ServiceMethod="Search供應商代號"  MinimumPrefixLength="1"
        CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" OnClientPopulated="Employees_Populated" FirstRowSelected="false"></ajaxToolkit:AutoCompleteExtender>
                            <div>
                                    <script type="text/javascript">
                                        function Employees_Populated(sender, e) {
                                            var employees = sender.get_completionList().childNodes;
                                            var div = "<table>";
                                            div += "<tr><th>Search</th><th>SearchName</th></tr>";
                                            for (var i = 0; i < employees.length; i++) {
 
                                                div += "<tr><td>" + employees[i].innerHTML.split('-')[0] + "</td><td>" + employees[i].innerHTML.split('-')[1]  + "</td></tr>";
                                            }
                                            div += "</table>";
                                            sender._completionListElement.innerHTML = div;
                                        }
                                    </script>
                                </div>

                            </div>
                            <h4>品牌</h4>
                            <div class="form-group">
                                <asp:TextBox ID="品牌TB" runat="server" CssClass="form-control" ></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc"  BehaviorID="品牌TB_AutoCompleteExtender" TargetControlID="品牌TB" ID="品牌TB_AutoCompleteExtender" ServiceMethod="Search訂單品牌" MinimumPrefixLength="1" UseContextKey="True"></ajaxToolkit:AutoCompleteExtender>
                            </div>
                            <h4>狀態</h4>
                            <div class="form-group">
                                <asp:CheckBox ID="主料CB" runat="server" Checked="true"  CssClass="form-control" Text="顯示主料資料"/>
                                <asp:CheckBox ID="入庫CB" runat="server" Checked="true"   CssClass="form-control" Text="顯示入庫資料"/>
                            </div>--%>
                            <div class="form-group">
                            <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />
                            <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-default" OnClick="ClearBT_Click" />
                            </div>


                        </div>

                    </nav>
                </div>
                <div class="col-md-10">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="768px" Width="1024px" Visible="False" >
                        <LocalReport ReportPath="ReportSource\MGT\ReportMGT009.rdlc" DisplayName="INVOICE" EnableExternalImages="True">
                        </LocalReport>
                    </rsweb:ReportViewer>
                      <asp:Panel ID="SelectPanel" runat="server" align="center" Height="400px" Width="650px" BackColor="#0099FF" Style="display:none"   ScrollBars="Vertical">
                                    <div><h3>選擇快遞單</h3></div>
                                    
                                    <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource2" OnRowCommand="GridView1_RowCommand"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">--%>
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id"  OnRowCommand="GridView1_RowCommand"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass=" table table-bordered">
                                        <Columns>
                                            <asp:BoundField DataField="id" HeaderStyle-CssClass="hiddencol" HeaderText="id" InsertVisible="False" ReadOnly="True" ItemStyle-CssClass="hiddencol" SortExpression="id" >
                                            <HeaderStyle CssClass="hiddencol" />
                                            <ItemStyle CssClass="hiddencol" />
                                            </asp:BoundField>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:Button ID="SelectBT" runat="server" CausesValidation="false" CommandName="Select" Text="選擇" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="提單號碼" HeaderText="提單號碼" SortExpression="提單號碼" />
                                            <asp:BoundField DataField="提單日期" HeaderText="提單日期" SortExpression="提單日期" DataFormatString="{0:yyyy-MM-dd}" />
                                            <asp:BoundField DataField="快遞廠商" HeaderText="快遞廠商" SortExpression="快遞廠商" />
                                            <asp:BoundField DataField="送件地點" HeaderText="送件地點" SortExpression="送件地點" />
                                            <asp:BoundField DataField="地點備註" HeaderText="地點備註" SortExpression="地點備註" />
                                            <asp:BoundField DataField="建立日期" HeaderText="建立日期" SortExpression="建立日期" DataFormatString="{0:yyyy-MM-dd}" />
                                        </Columns>
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                        <RowStyle ForeColor="#000066" />
                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                    </asp:GridView>
                                    <%--<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT top 20 * FROM [快遞單] WHERE ([提單日期] between @提單日期1 and @提單日期2) and [IsDeleted]= 0 and 快遞廠商 in ('DHL','FedEx') and id like @id order by 提單日期 desc ">
                                        <SelectParameters>
                                            <asp:SessionParameter DefaultValue="2000/1/1" Name="提單日期1" SessionField="提單日期1" Type="DateTime" />
                                            <asp:SessionParameter DefaultValue="2099/1/1" Name="提單日期2" SessionField="提單日期2" Type="DateTime" />
                                            <asp:SessionParameter DefaultValue="%" Name="id" SessionField="id" Type="int16" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>--%>
                                        
                                    <div class="row text-center">
                                        <asp:Button ID="取消選擇BT" runat="server" CssClass="btn btn-success" Text="取消" />
                                    </div>

                                </asp:Panel>
                                <ajaxToolkit:ModalPopupExtender ID="SelectPanel_ModalPopupExtender" runat="server" BehaviorID="SelectPanel_ModalPopupExtender" TargetControlID="show2" PopupControlID="SelectPanel" CancelControlID="取消選擇BT">
                                </ajaxToolkit:ModalPopupExtender>
                    <asp:Button ID="show2" runat="server" Text="show2" Style="display: none" />
                </div>
            </div>
        </div>
         <div>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="show3" runat="server" Text="show3" Style="display: none" />
                                <%--<asp:Button ID="Button1" runat="server" Text="show3" Style="display: none" />--%>
                                <asp:Panel ID="AlertPanel" runat="server" align="center" Height="100px" Width="600px" BackColor="#009999" Style="display: none">
                                    <div class=" text-center">
                                        <h3>
                                            <asp:Label ID="MessageLB" runat="server" Text=""></asp:Label>
                                           
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
</body>
</html>
