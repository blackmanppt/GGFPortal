<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sales011.aspx.cs" Inherits="GGFPortal.Sales.Sales011" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Excel匯入</title>
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
                        <h3 class="text-info text-left">Excel匯入</h3>

                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">


                            <h4>匯入檔案</h4>
                                <asp:FileUpload ID="文件上傳FU" runat="server" CssClass=""/>
                            <h4>匯入起始日</h4>
                            <asp:TextBox ID="StartDayTB" runat="server" CssClass="form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender runat="server" BehaviorID="StartDayTB_CalendarExtender" TargetControlID="StartDayTB" ID="StartDayTB_CalendarExtender" Format="yyyy-MM-dd"></ajaxToolkit:CalendarExtender>
                            <div class="form-group">
                                <%--<asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />--%>
                                <asp:Button ID="DataCheckBT" runat="server" Text="CheckData" CssClass="btn btn-danger" OnClick="DataCheckBT_Click" />
                                <asp:Button ID="UpLoadBT" runat="server" Text="UpLoadData" CssClass="btn btn-group" OnClick="UpLoadBT_Click" />
                            </div>
                        </div>

                    </nav>
                </div>
                <div class="col-md-10">
<%--                    <asp:GridView ID="確認GV" runat="server" CssClass="table table-hover table-striped" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" OnRowCommand="確認GV_RowCommand">
                        <Columns>
                            <asp:TemplateField ShowHeader="False" ItemStyle-Width="145px" >
                                <ItemTemplate>
                                    <asp:Button ID="檢貨BT" runat="server" CausesValidation="false" CommandName="檢貨" Text="檢貨" CssClass="btn btn-default"/>
                                    <asp:Button ID="結案BT" runat="server" CausesValidation="false" CommandName="結案" Text="結案" CssClass="btn btn-danger"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="已結案" HeaderText="已結案" SortExpression="已結案" />
                            <asp:BoundField DataField="已檢貨" HeaderText="已檢貨" SortExpression="已檢貨" />
                            <asp:BoundField DataField="提單號碼" HeaderText="提單號碼" SortExpression="提單號碼" />
                            <asp:BoundField DataField="提單日期" HeaderText="提單日期" SortExpression="提單日期" DataFormatString="{0:yyyy/MM/dd}" />
                            <asp:BoundField DataField="快遞廠商" HeaderText="快遞廠商" SortExpression="快遞廠商" />
                            <asp:BoundField DataField="地點備註" HeaderText="地點備註" SortExpression="地點備註" />
                            <asp:BoundField DataField="送件地點" HeaderText="送件地點" SortExpression="送件地點" />
                            <asp:BoundField DataField="送件部門" HeaderText="送件部門" SortExpression="送件部門" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT top 40 case when 結案狀態=1 then 'V'else'' end as 已結案,case when 檢貨狀態 = 1 then 'V' else '' end as '已檢貨', * FROM [快遞單] WHERE (([IsDeleted] = @IsDeleted) AND ([提單日期] = @提單日期 ) and 提單號碼 like @提單號碼 and 快遞廠商 like @快遞廠商 )">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="false" Name="IsDeleted" Type="Boolean" />
                            <asp:SessionParameter Name="提單日期" SessionField="Today" Type="DateTime" />
                            <asp:SessionParameter Name="提單號碼" SessionField="Nbr" Type="String" DefaultValue="%" />
                            <asp:SessionParameter Name="快遞廠商" SessionField="快遞商" Type="String" DefaultValue="%" />
                            
                        </SelectParameters>
                    </asp:SqlDataSource>--%>
                    <asp:GridView ID="ErrorGV" CssClass="table table-hover table-condensed" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#FFFFCC" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
<asp:GridView ID="DataGV" CssClass="table table-hover table-striped" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
    <AlternatingRowStyle BackColor="White" />
    <EditRowStyle BackColor="#7C6F57" />
    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#E3EAEB" />
    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F8FAFA" />
    <SortedAscendingHeaderStyle BackColor="#246B61" />
    <SortedDescendingCellStyle BackColor="#D4DFE1" />
    <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                </div>
            </div>
        </div>
                    <div>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="show3" runat="server" Text="show3" Style="display: none" OnClick="show3_Click" />
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
