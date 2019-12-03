<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MGT004.aspx.cs" Inherits="GGFPortal.MGT.MGT004" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>快遞單明細表-每日查詢</title>
    <script src="../scripts/jquery-3.1.1.min.js"></script>
    <script src="../scripts/scripts.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
    <script src="../scripts/jQuery.print.min.js"></script>
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
                        <h3 class="text-info text-left">快遞單明細表-每日查詢
			 

                        </h3>

                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">


                            <div class="form-group">
                                <h4>快遞時間</h4>
                                <asp:TextBox ID="快遞時間TB" CssClass="form-control" runat="server" />
                                <ajaxToolkit:CalendarExtender ID="快遞時間TB_CalendarExtender" runat="server" BehaviorID="快遞時間TB_CalendarExtender" TargetControlID="快遞時間TB" Format="yyyy-MM-dd" />
                            </div>
                            <h4>快遞單號</h4>
                            <div class="form-group">
                                <asp:TextBox ID="提單TB" runat="server" class="form-control"></asp:TextBox>
<%--                                <ajaxToolkit:AutoCompleteExtender ID="StyleTB_AutoCompleteExtender" runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" TargetControlID="StyleTB"  ServiceMethod="快遞單號" MinimumPrefixLength="1" UseContextKey="True" >
                                </ajaxToolkit:AutoCompleteExtender>--%>
                            </div>
                            <div class="form-group">
                            <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />
                            <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-default" OnClick="ClearBT_Click" />

                            </div>


                        </div>

                    </nav>
                </div>
                <div class="col-md-10">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="768px" Width="1024px" Visible="False" >
                        <LocalReport ReportPath="ReportSource\MGT\ReportMGT004V2.rdlc" DisplayName="快遞單明細">
                        </LocalReport>
                    </rsweb:ReportViewer>
                </div>
                                                <asp:Panel ID="SelectPanel" runat="server" align="center" Height="400px" Width="600px" BackColor="#0099FF" Style="display:none"   ScrollBars="Vertical">
                                    <div><h3>選擇快遞單</h3></div>
                                    
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource2" OnRowCommand="GridView1_RowCommand"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
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
                                            <asp:BoundField DataField="送件地點" HeaderText="送件目的地" SortExpression="送件地點" />
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
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT * FROM [快遞單] WHERE ([提單日期] = @提單日期) and [IsDeleted]= 0">
                                        <SelectParameters>
                                            <asp:SessionParameter DefaultValue="2000/1/1" Name="提單日期" SessionField="提單日期" Type="DateTime" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                        
                                    <div class="row text-center">
                                        <asp:Button ID="取消選擇BT" runat="server" CssClass="btn btn-success" Text="取消" />
                                    </div>

                                </asp:Panel>
                                <ajaxToolkit:ModalPopupExtender ID="SelectPanel_ModalPopupExtender" runat="server" BehaviorID="SelectPanel_ModalPopupExtender" TargetControlID="show2" PopupControlID="SelectPanel" CancelControlID="取消選擇BT">
                                </ajaxToolkit:ModalPopupExtender>
                                <asp:Button ID="show2" runat="server" Text="show2" Style="display: none" />
            </div>
        </div>
    </form>
</body>
</html>
