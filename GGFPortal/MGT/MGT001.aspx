<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MGT001.aspx.cs" Inherits="GGFPortal.MGT.MGT001" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>快遞單</title>
    <link href="~/Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/style.css" rel="stylesheet" />
    <script src="~/scripts/bootstrap.min.js"></script>
    <script src="~/scripts/jquery-3.1.1.min.js"></script>
    <script src="~/scripts/scripts.js"></script>

    <style type="text/css">
        .auto-style1 {
            text-align: center;
            color: #000000;
            background-color: #808080;
        }

        .auto-style2 {
            font-size: large;
            color: #006600;
        }
            .hiddencol
    {
        display:none;
    }
    .viscol
    {
        display:block;
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
                        <h3 class="text-info text-center">快遞單
                        </h3>
                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">
                            <div class="form-group">
                                <h4>快遞時間</h4>
                                <asp:TextBox ID="快遞時間TB" CssClass="form-control" runat="server" />
                                <ajaxToolkit:CalendarExtender ID="快遞時間TB_CalendarExtender" runat="server" BehaviorID="快遞時間TB_CalendarExtender" TargetControlID="快遞時間TB" Format="yyyy-MM-dd" />
                            </div>
                            <div class="from-group">
                                <h4>快遞單號</h4>
                                <asp:TextBox ID="快遞單號TB" CssClass="form-control" runat="server" />
                            </div>

                            <div class="form-group">
                                <asp:Button ID="SearchBT" runat="server" Text="搜尋" class="btn btn-default" OnClick="SearchBT_Click" />
                                <asp:Button ID="ClearBT" runat="server" Text="清除搜尋資料" class="btn btn-default" OnClick="ClearBT_Click1"  />
                               <%-- <asp:Button ID="AddBT" runat="server" Text="新增快遞單" class="btn btn-default"  />--%>


                            </div>


                        </div>

                    </nav>
                </div>
                <div class="col-md-10">
                    <asp:Panel ID="ADDPanel" runat="server" Visible="false">
                    <table class="table table-bordered">
                        <thead>
                            <tr>
                                <th colspan="3">
                                    <h3 class="text-center">快遞單資料</h3>
                                    
                                </th>
                            </tr>
                            <tr class="auto-style2">
                                <th class="auto-style1">快遞日期</th>
                                <th class="auto-style1">快遞廠商</th>
                                <th class="auto-style1">提單號碼</th>
                                
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td class="text-center">
                                    <asp:TextBox ID="快遞日期TB" runat="server" CssClass="form-control"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="快遞日期TB_CalendarExtender" runat="server" BehaviorID="快遞日期TB_CalendarExtender" TargetControlID="快遞日期TB" Format="yyyy-MM-dd" />
                                </td>
                                <td class="text-center">
                                    <asp:DropDownList ID="快遞廠商DDL" runat="server" CssClass="form-control" DataSourceID="SqlDataSource2" DataTextField="MappingData" DataValueField="MappingData">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT [MappingData] FROM [Mapping] WHERE ([UsingDefine] = @UsingDefine) ORDER BY [Data]">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="快遞廠商" Name="UsingDefine" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                                <td class="text-center">
                                    <asp:TextBox ID="提單號碼TB" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>

                            </tr>
                            <tr class="auto-style2">
                                                                <th class="auto-style1">送件地點</th>
                                <th class="auto-style1">快遞單檔案</th>
                                                                <th class=" text-right" style="vertical-align:bottom;"rowspan="2" >                                    
                                    <asp:Button ID="SaveBT" runat="server" Text="儲存" CssClass="btn btn-default" Visible="false" OnClick="SaveBT_Click"/>                                    
                                    <asp:Button ID="DeleteBT" runat="server" Text="刪除" CssClass="btn btn-default" Visible="false" OnClick="DeleteBT_Click"  />
                                    </th>
                            </tr>
                            <tr>
                                <td class=" text-center">
                                    <asp:TextBox ID="送件地點TB" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td class=" text-center">

                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control"  />

                                </td>
                            </tr>

                         
                        </tbody>
                    </table>
                        </asp:Panel>
                    <asp:Panel ID="GridPanel" runat="server" Visible="true">
                    <asp:GridView ID="ACRGV" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" OnRowCommand="ACRGV_RowCommand">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id"  ItemStyle-cssclass="hiddencol" HeaderStyle-CssClass="hiddencol"  >
                            <HeaderStyle CssClass="hiddencol" />
                            <ItemStyle CssClass="hiddencol" />
                            </asp:BoundField>
                            <asp:TemplateField ShowHeader="False" ItemStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:Button ID="EditBT" runat="server" CausesValidation="false" CommandName="編輯" Text="編輯" />
                                    <asp:Button ID="NewBT" runat="server" CausesValidation="false" CommandName="新增明細" Text="新增明細" />
                                    <asp:Button ID="DeleteBT" runat="server" CausesValidation="false" CommandName="刪除" Text="刪除"  OnClientClick="return confirm('是否刪除')" 9 />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="提單號碼" HeaderText="提單號碼" SortExpression="提單號碼" />
                            <asp:BoundField DataField="提單日期" DataFormatString="{0:yyyy-MM-dd}" HeaderText="提單日期" SortExpression="提單日期" />
                            <asp:BoundField DataField="快遞廠商" HeaderText="快遞廠商" SortExpression="快遞廠商" />
                            <asp:BoundField DataField="快遞單檔案" HeaderText="快遞單檔案" SortExpression="快遞單檔案" />
                            <asp:BoundField DataField="送件地點" HeaderText="送件地點" SortExpression="送件地點" />
                        </Columns>
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
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT [id], [提單號碼], [提單日期], [快遞廠商], [快遞單檔案], [送件地點] FROM [快遞單] WHERE ([IsDeleted] = @IsDeleted) and convert(varchar(10), 提單日期,111) like @提單日期 and 提單號碼 like @提單號碼">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="false" Name="IsDeleted" Type="Boolean" />
                            <asp:SessionParameter DefaultValue="%" Name="提單日期" SessionField="提單日期" />
                            <asp:SessionParameter DefaultValue="%" Name="提單號碼" SessionField="提單號碼" />
                        </SelectParameters>
                        </asp:SqlDataSource>
                        </asp:Panel>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="idHF" runat="server" />
    </form>
</body>
</html>
