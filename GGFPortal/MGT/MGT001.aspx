<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MGT001.aspx.cs" Inherits="GGFPortal.MGT.MGT001" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>快遞單</title>
    <script src="../scripts/jquery-3.1.1.min.js"></script>
    <script src="../scripts/scripts.js"></script>
    <script src="../scripts/jQuery.print.min.js"></script>
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/style.css" rel="stylesheet" />
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

        .hiddencol {
            display: none;
        }

        .viscol {
            display: block;
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
                                <asp:Button ID="ClearBT" runat="server" Text="清除搜尋資料" class="btn btn-default" OnClick="ClearBT_Click1" />
                                <asp:Button ID="AddBT" runat="server" Text="新增快遞單" class="btn btn-default" OnClick="AddBT_Click" />
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
                                    <th class="auto-style1">快遞日期(<span lang="EN-US">Thời gian chuyển phát nhanh</span>)</th>
                                    <th class="auto-style1">快遞廠商(<span lang="EN-US">Nhà cung cấp chuyển phát nhanh</span>)</th>
                                    <th class="auto-style1">提單號碼(<span lang="EN-US">Vận đơn</span>)</th>

                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td class="text-center">
                                        <asp:TextBox ID="快遞日期TB" runat="server" CssClass="form-control"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="快遞日期TB_CalendarExtender" runat="server" BehaviorID="快遞日期TB_CalendarExtender" TargetControlID="快遞日期TB" Format="yyyy-MM-dd" />
                                    </td>
                                    <td class="text-center">
                                        <asp:DropDownList ID="快遞廠商DDL" runat="server" CssClass="form-control">
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
                                        <%--                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT [MappingData] FROM [Mapping] WHERE ([UsingDefine] = @UsingDefine) ORDER BY [Data]">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="快遞廠商" Name="UsingDefine" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>--%>
                                    </td>
                                    <td class="text-center">
                                        <asp:TextBox ID="提單號碼TB" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>

                                </tr>
                                <tr class="auto-style2">
                                    <th class="auto-style1">送件目的地(<span lang="EN-US">Địa điểm giao hàng</span>)</th>
                                    <th class="auto-style1">快遞單檔案(<span lang="EN-US">Tập tin chuyển phát nhanh</span>)</th>
                                    <th class="auto-style1">寄件部門(<span lang="EN-US">Bộ phận vận chuyển</span>)</th>

                                </tr>
                                <tr>
                                    <td class=" text-center">
                                        <%--<asp:TextBox ID="送件地點TB" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                        <asp:DropDownList ID="送件地點DDL" runat="server" CssClass=" form-control" DataSourceID="SqlDataSource3" DataTextField="Data" DataValueField="Data" OnDataBound="送件地點DDL_DataBound"></asp:DropDownList>
                                        <asp:TextBox ID="地點備註TB" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT * FROM [Mapping] WHERE ([UsingDefine] = @UsingDefine)">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="寄送地點" Name="UsingDefine" Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                    <td class=" text-center">
                                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="部門DDL" runat="server" CssClass=" form-control" DataSourceID="SqlDataSource2" DataTextField="Data" DataValueField="Data">
                                        </asp:DropDownList>

                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionString %>" SelectCommand="SELECT * FROM [Mapping] WHERE ([UsingDefine] = @UsingDefine)">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="寄件部門" Name="UsingDefine" Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>

                                </tr>
                                <tr class="auto-style2">
  
                                    <th class="auto-style1" colspan="1">寄件地點</th>

                                    <td class="text-center">
                                        <asp:DropDownList ID="寄件地點DDL" runat="server" CssClass=" form-control">
                                            <asp:ListItem>振大</asp:ListItem>
                                            <asp:ListItem>第三地</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                                                        <td class=" text-right" style="vertical-align: bottom;">
                                        <%--                                    <th class=" text-right" style="vertical-align:bottom;" >                                    
                                        </th>--%>
                                        <asp:Button ID="SaveBT" runat="server" Text="Save" CssClass="btn btn-default" Visible="false" OnClick="SaveBT_Click" />
                                        <asp:Button ID="DeleteBT" runat="server" Text="Delete" CssClass="btn btn-danger" Visible="false" OnClick="DeleteBT_Click" OnClientClick="return confirm('是否刪除')" />
                                        <asp:Button ID="CancelBT" runat="server" Text="Cancel" CssClass="btn btn-primary" OnClick="CancelBT_Click" />

                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="GridPanel" runat="server" Visible="true">
                        <asp:GridView ID="ACRGV" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" OnRowCommand="ACRGV_RowCommand">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                                    <HeaderStyle CssClass="hiddencol" />
                                    <ItemStyle CssClass="hiddencol" />
                                </asp:BoundField>
                                <asp:TemplateField ShowHeader="False" ItemStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Button ID="EditBT" runat="server" CausesValidation="false" CommandName="編輯" Text="Edit" CssClass="btn btn-default btn-block" />
                                        <asp:Button ID="NewBT" runat="server" CausesValidation="false" CommandName="新增明細" Text="ADD Detail" CssClass="btn btn-primary btn-block" />
                                        <asp:Button ID="DeleteBT" runat="server" CausesValidation="false" CommandName="刪除" Text="Delete" OnClientClick="return confirm('是否刪除')" CssClass="btn btn-danger btn-block" />
                                    </ItemTemplate>
                                    <ItemStyle Width="200px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="提單號碼(Vận đơn)" SortExpression="提單號碼">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("提單號碼") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderTemplate>
                                        提單號碼<br /> (Vận đơn)
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("提單號碼") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="送件部門(Bộ phận giao hàng)" SortExpression="送件部門">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("送件部門") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderTemplate>
                                        送件部門<br /> (Bộ phận giao hàng)
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("送件部門") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="提單日期(Ngày vận đơn)" SortExpression="提單日期">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("提單日期") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderTemplate>
                                        提單日期<br /> (Ngày vận đơn)
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("提單日期", "{0:yyyy-MM-dd}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="快遞廠商(Nhà sản xuất nhanh)" SortExpression="快遞廠商">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("快遞廠商") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderTemplate>
                                        快遞廠商<br /> (Nhà sản xuất nhanh)
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("快遞廠商") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="快遞單檔案(Tập tin chuyển phát nhanh)" SortExpression="快遞單檔案">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("快遞單檔案") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderTemplate>
                                        快遞單檔案<br /> (Tập tin chuyển phát nhanh)
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("快遞單檔案") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" SortExpression="送件地點">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("送件地點") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderTemplate>
                                        送件地點<br /> (Địa điểm giao hàng)
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("送件地點") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" SortExpression="地點備註">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("地點備註") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderTemplate>
                                        地點備註<br /> (Ghi chú vị trí)
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("地點備註") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

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
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT top 50 [id], [提單號碼], [提單日期], [快遞廠商], [快遞單檔案], [送件地點],送件部門,地點備註 FROM [快遞單] WHERE ([IsDeleted] = @IsDeleted) and convert(varchar(10), 提單日期,121) like @提單日期 and 提單號碼 like @提單號碼 order by 提單日期 desc">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="false" Name="IsDeleted" Type="Boolean" />
                                <asp:SessionParameter DefaultValue="%" Name="提單日期" SessionField="提單日期" />
                                <asp:SessionParameter DefaultValue="%" Name="提單號碼" SessionField="提單號碼" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </asp:Panel>
                </div>
            </div>
            <div>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="show3" runat="server" Text="show3" Style="display: none" />
                        <asp:Panel ID="AlertPanel" runat="server" align="center" Height="100px" Width="600px" BackColor="#0099FF" Style="display: none">
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
        <asp:HiddenField ID="idHF" runat="server" />
    </form>
</body>
</html>
