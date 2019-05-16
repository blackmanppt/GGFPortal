<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MGT008.aspx.cs" Inherits="GGFPortal.MGT.MGT008" %>

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
                        <h3 class="text-info text-left">快遞單明細表-查詢
			 

                        </h3>

                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">


                            <h4>快遞日期</h4>
                            <div class="form-group">
                                <asp:TextBox ID="StartDay" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="StartDay_CalendarExtender" runat="server" BehaviorID="StartDay_CalendarExtender" TargetControlID="StartDay" Format="yyyy-MM-dd" />
                            </div>
                            <h4>快遞廠商</h4>
                            <div class="form-group">                                
                                    <asp:DropDownList ID="快遞廠商DDL" runat="server" CssClass="form-control" >
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>譽得</asp:ListItem>
                                        <asp:ListItem>峻越</asp:ListItem>
                                        <asp:ListItem>捷麟</asp:ListItem>
                                        <asp:ListItem>順豐</asp:ListItem>
                                        <asp:ListItem>船務-馬島-DHL</asp:ListItem>
                                        <asp:ListItem>DHL</asp:ListItem>
                                        <asp:ListItem>FedEx</asp:ListItem>
                                        <asp:ListItem>VGG</asp:ListItem>
                                        <asp:ListItem>越新</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            <h4>快遞單號</h4>
                            <div class="form-group">
                                <asp:TextBox ID="提單TB" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />
                                <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-default" OnClick="ClearBT_Click"  />

                            </div>
                            <div class="form-group">
                                <asp:Button ID="全部結案BT" runat="server" Text="全部結案" class="btn btn-default" OnClick="全部結案BT_Click" />
                                <asp:Button ID="全部撿貨BT" runat="server" Text="全部檢貨" class="btn btn-default" OnClick="全部撿貨BT_Click"/>
                            </div>
                        </div>

                    </nav>
                </div>
                <div class="col-md-10">
                    <asp:GridView ID="確認GV" runat="server" CssClass="table table-hover table-striped" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" OnRowCommand="確認GV_RowCommand">
                        <Columns>
                            
<%--                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id"/>--%>
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
                            <%--<asp:BoundField DataField="快遞單檔案" HeaderText="快遞單檔案" SortExpression="快遞單檔案" />--%>
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
                    </asp:SqlDataSource>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
