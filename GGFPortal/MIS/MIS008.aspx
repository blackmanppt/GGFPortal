<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MIS008.aspx.cs" Inherits="GGFPortal.MIS.MIS008" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>佣金重算</title>
    <script src="../scripts/jquery-3.1.1.min.js"></script>
    <script src="../scripts/scripts.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
    <script src="../scripts/jQuery.print.min.js"></script>
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/style.css" rel="stylesheet" />
    <style type="text/css">
        .checkbox
        {
            padding-left: 20px;
        }
        .checkbox label
        {
            display: inline-block;
            vertical-align: middle;
            position: relative;
            padding-left: 5px;
        }
        .checkbox label::before
        {
            content: "";
            display: inline-block;
            position: absolute;
            width: 17px;
            height: 17px;
            left: 0;
            margin-left: -20px;
            border: 1px solid #cccccc;
            border-radius: 3px;
            background-color: #fff;
            -webkit-transition: border 0.15s ease-in-out, color 0.15s ease-in-out;
            -o-transition: border 0.15s ease-in-out, color 0.15s ease-in-out;
            transition: border 0.15s ease-in-out, color 0.15s ease-in-out;
        }
        .checkbox label::after
        {
            display: inline-block;
            position: absolute;
            width: 16px;
            height: 16px;
            left: 0;
            top: 0;
            margin-left: -20px;
            padding-left: 3px;
            padding-top: 1px;
            font-size: 11px;
            color: #555555;
        }
        .checkbox input[type="checkbox"]
        {
            opacity: 0;
            z-index: 1;
        }
        .checkbox input[type="checkbox"]:checked + label::after
        {
            font-family: "FontAwesome";
            content: "\f00c";
        }
         
        .checkbox-primary input[type="checkbox"]:checked + label::before
        {
            background-color: #337ab7;
            border-color: #337ab7;
        }
        .checkbox-primary input[type="checkbox"]:checked + label::after
        {
            color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-2">
                    <nav class="navbar navbar-default" role="navigation">
                        <h3 class="text-info text-left">採購單核准
			 

                        </h3>

                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">


                            <h4>採購單號</h4>
                            <div class="form-group">
                                <asp:TextBox ID="採購單TB" runat="server" CssClass="form-control" Height="100px" TextMode="MultiLine" ></asp:TextBox>
                            </div>
                            <h4>款號</h4>
                            <div class="form-group">
                                <asp:TextBox ID="款號TB" runat="server" class="form-control"  Height="100px" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />
                                <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-default" OnClick="ClearBT_Click"  />

                            </div>
                        </div>

                    </nav>
                </div>
                <div class="col-md-10">
                    <%--<asp:Label ID="MessageLB" runat="server" Text=""></asp:Label>--%>
                    <asp:GridView ID="確認GV" runat="server" CssClass="table table-hover table-striped" AutoGenerateColumns="False"  BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            
<%--                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id"/>--%>
                            <asp:TemplateField ShowHeader="False" ItemStyle-Width="145px" >
                                <HeaderTemplate>
                                    <asp:CheckBox ID="全部更新CB" runat="server" CssClass=" glyphicon " Text="全部核准" />
                                    <asp:Button ID="UpDateBT" runat="server" Text="採購單核准" ForeColor="#003300" OnClick="UpDateBT_Click" CssClass="btn btn-group-sm" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="UpdateCB" runat="server" CssClass="styled" />
                                </ItemTemplate>

<ItemStyle Width="145px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="採購單號碼" HeaderText="採購單號碼" SortExpression="採購單號碼" />
                            <asp:BoundField DataField="主副料" HeaderText="主副料" SortExpression="主副料" />
                            <asp:BoundField DataField="訂單號碼" HeaderText="訂單號碼" SortExpression="訂單號碼" />
                            <asp:BoundField DataField="款號" HeaderText="款號" SortExpression="款號" />
                            <asp:BoundField DataField="採購單狀態" HeaderText="採購單狀態" SortExpression="採購單狀態" />
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" Font-Size="Medium" ForeColor="White" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#F7F7DE" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                        <SortedAscendingHeaderStyle BackColor="#848384" />
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>
<%--                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT top 40 case when 結案狀態=1 then 'V'else'' end as 已結案,case when 檢貨狀態 = 1 then 'V' else '' end as '已檢貨', * FROM [快遞單] WHERE (([IsDeleted] = @IsDeleted) AND ([提單日期] = @提單日期 ) and 提單號碼 like @提單號碼 and 快遞廠商 like @快遞廠商 )">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="false" Name="IsDeleted" Type="Boolean" />
                            <asp:SessionParameter Name="提單日期" SessionField="Today" Type="DateTime" />
                            <asp:SessionParameter Name="提單號碼" SessionField="Nbr" Type="String" DefaultValue="%" />
                            <asp:SessionParameter Name="快遞廠商" SessionField="快遞商" Type="String" DefaultValue="%" />
                            
                        </SelectParameters>
                    </asp:SqlDataSource>--%>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server"  ChildrenAsTriggers="True">
                            <ContentTemplate>
                                <asp:Button ID="show3" runat="server" Text="show3" Style="display: none" />
                                <asp:Panel ID="AlertPanel" runat="server" align="center" Height="100px" Width="600px" BackColor="#0099FF" style="display:none" >
                                    <div class=" text-center">
                                        <h3>
                                            <asp:Label ID="MessageLB" runat="server" Text=""></asp:Label>

                                        </h3>
                                        <asp:Button ID="AlertBT" runat="server" Text="確定" CssClass="btn btn-warning" />
                                    </div>
                                </asp:Panel>
                                <ajaxToolkit:ModalPopupExtender ID="AlertPanel_ModalPopupExtender" runat="server" BehaviorID="AlertPanel_ModalPopupExtender" TargetControlID="show3" PopupControlID="AlertPanel" CancelControlID="">
                                </ajaxToolkit:ModalPopupExtender>
                                
                            </ContentTemplate>
                        </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
