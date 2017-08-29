<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MGT002.aspx.cs" Inherits="GGFPortal.MGT.MGT002" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>快遞單明細</title>
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

        .hiddencol {
            display: none;
        }

        .viscol {
            display: block;
        }

        .置中 {
            margin: 0px auto;
        }
    </style>

    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="The description of my page" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-2">
                    <nav class="navbar navbar-default" role="navigation">
                        <h3 class="text-info text-center">快遞單明細
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
                                    <asp:Label ID="快遞日期LB" runat="server" Text="" CssClass=" control-label"></asp:Label>
                                </td>
                                <td class="text-center">
                                    <asp:Label ID="快遞廠商LB" runat="server" Text=""></asp:Label>
                                  </td>
                                <td class="text-center">
                                    <asp:Label ID="提單號碼LB" runat="server" Text="" CssClass=""></asp:Label>
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
                                    <asp:Label ID="送件地點LB" runat="server" Text=""></asp:Label>
                                </td>
                                <td class=" text-center">

                                    <asp:Literal ID="快遞單檔案Literal" runat="server"></asp:Literal>

                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <asp:GridView ID="ACRGV" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="uid" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" OnRowCommand="ACRGV_RowCommand">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="uid" HeaderText="uid" InsertVisible="False" ReadOnly="True" SortExpression="uid"  HeaderStyle-CssClass="hiddencol" ItemStyle-cssclass="hiddencol"  >
                            </asp:BoundField>
                            <asp:BoundField DataField="id" HeaderStyle-CssClass="hiddencol" HeaderText="id" ItemStyle-cssclass="hiddencol" SortExpression="id" />
                              <asp:TemplateField ShowHeader="False" ItemStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:Button ID="EditBT" runat="server" CausesValidation="false" CommandName="編輯" Text="編輯" />
                                    <asp:Button ID="DeleteBT" runat="server" CausesValidation="false" CommandName="刪除" Text="刪除"  OnClientClick="return confirm('是否刪除')" 9 />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="提單號碼" HeaderText="提單號碼" SortExpression="提單號碼" />
                            <asp:BoundField DataField="寄件人" HeaderText="寄件人" SortExpression="寄件人" />
                            <asp:BoundField DataField="寄件人分機" HeaderText="寄件人分機" SortExpression="寄件人分機" />
                            <asp:BoundField DataField="收件人" HeaderText="收件人" SortExpression="收件人" />
                            <asp:BoundField DataField="客戶名稱" HeaderText="客戶名稱" SortExpression="客戶名稱" />
                            <asp:BoundField DataField="明細" HeaderText="明細" SortExpression="明細" />
                            <asp:BoundField DataField="重量" HeaderText="重量" SortExpression="重量" />
                            <asp:BoundField DataField="付款方式" HeaderText="付款方式" SortExpression="付款方式" />
                            <asp:BoundField DataField="建立日期" HeaderText="建立日期" SortExpression="建立日期"  DataFormatString="{0:yyyy-MM-dd}"/>
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
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT * FROM [快遞單明細] WHERE ([id] = @id) and isDeleted =false">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="0" Name="id" SessionField="id" Type="Int32" />
                        </SelectParameters>
                        </asp:SqlDataSource>
                        </asp:Panel>
                    <div >
                        <asp:Button ID="show" runat="server" Text="show" Style="display:none" />
                        <asp:Panel ID="EditListPanel" runat="server" align="center" CssClass="modalPopup" Height="400px" Width="600px" ScrollBars="Horizontal" BackColor="#33CCFF" >
                            <div class=" text-center"><h3><b>新增明細</b></h3></div>
                            <div class="row">
                                <div class=" col-md-2 text-right">
                                    <asp:Label ID="寄件人LB" runat="server" Text="寄件人：" Font-Bold="True"></asp:Label>
                                </div>
                                <div class="col-md-4 text-left">
                                    <asp:TextBox ID="寄件人TB" runat="server"></asp:TextBox>
                                </div>
                                <div class=" col-md-2 text-right">
                                    <asp:Label ID="分機LB" runat="server"  Font-Bold="True" Text="分機："></asp:Label>
                                </div>
                                <div class="col-md-4 text-left">
                                    <asp:TextBox ID="分機TB" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class=" col-md-2  text-right">
                                    <asp:Label ID="客戶名稱LB" runat="server" Text="客戶名稱：" Font-Bold="True"></asp:Label>
                                </div>
                                <div class="col-md-4 text-left">
                                    <asp:TextBox ID="客戶名稱TB" runat="server"></asp:TextBox>
                                </div>
                                <div class=" col-md-2 text-right">
                                    <asp:Label ID="收件人LB" runat="server" Text="收件人：" Font-Bold="True"></asp:Label>
                                </div>
                                <div class="col-md-4 text-left">
                                    <asp:TextBox ID="收件人TB" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class=" col-md-2  text-right">
                                    <asp:Label ID="重量LB" runat="server" Text="重量：" Font-Bold="True"></asp:Label>
                                </div>
                                <div class="col-md-4 text-left">
                                    <asp:TextBox ID="重量TB" runat="server"></asp:TextBox>
                                </div>
                                <div class=" col-md-2 text-right">
                                    <asp:Label ID="責任歸屬LB" runat="server" Text="責任歸屬：" Font-Bold="True"></asp:Label>
                                </div>
                                <div class="col-md-4 text-left">
                                    <asp:TextBox ID="責任歸屬TB" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class=" col-md-2  text-right">
                                    <asp:Label ID="到付LB" runat="server" Text="到付：" Font-Bold="True"></asp:Label>
                                </div>
                                <div class="col-md-4 text-left">
                                    <asp:CheckBox ID="到付TB" runat="server" />
                                </div>
                                <div class=" col-md-2 text-right">
                                    <asp:Label ID="備註" runat="server" Text="備註：" Font-Bold="True"></asp:Label>
                                </div>
                                <div class="col-md-4 text-left">
                                    <asp:TextBox ID="備註TB" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row ">
                                <div class="col-md-2 text-right"><asp:Label ID="地址LB" runat="server" Text="地址：" Font-Bold="True"></asp:Label></div>
                                <div class="col-md-10 text-left"><asp:TextBox ID="地址TB" runat="server" Width="489px"></asp:TextBox></div>
                                </div>
                            <asp:Button ID="新增BT" runat="server" Text="新增" CssClass="btn btn-primary" Visible="false"/>
                            <asp:Button ID="更新BT" runat="server" Text="修改" CssClass="btn btn-primary" Visible="false"/>
                            <asp:Button ID="取消BT" runat="server" Text="取消" CssClass="btn btn-primary" OnClick="取消BT_Click"/>
                        </asp:Panel>
                        <ajaxToolkit:ModalPopupExtender ID="EditListPanel_ModalPopupExtender" runat="server" BehaviorID="EditListPanel_ModalPopupExtender"  TargetControlID="show" PopupControlID="EditListPanel" CancelControlID="取消BT">
                        </ajaxToolkit:ModalPopupExtender>

                        <asp:Panel ID="SelectPanel" runat="server" align="center" Height="400px" Width="600px" ScrollBars="Horizontal" BackColor="#33CCCC">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource2" CssClass=" form-control" OnRowCommand="GridView1_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderStyle-CssClass="hiddencol" HeaderText="id" InsertVisible="False" ReadOnly="True" ItemStyle-CssClass="hiddencol" SortExpression="id" />
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:Button ID="SelectBT" runat="server" CausesValidation="false" CommandName="Select" Text="選擇" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="提單號碼" HeaderText="提單號碼" SortExpression="提單號碼" />
                                    <asp:BoundField DataField="提單日期" HeaderText="提單日期" SortExpression="提單日期" DataFormatString="{0:yyyy-MM-dd}" />
                                    <asp:BoundField DataField="快遞廠商" HeaderText="快遞廠商" SortExpression="快遞廠商" />
                                    <asp:BoundField DataField="送件地點" HeaderText="送件地點" SortExpression="送件地點" />
                                    <asp:BoundField DataField="建立日期" HeaderText="建立日期" SortExpression="建立日期" DataFormatString="{0:yyyy-MM-dd}" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT * FROM [快遞單] WHERE ([提單日期] = @提單日期)">
                                <SelectParameters>
                                    <asp:SessionParameter DefaultValue="1991-01-01" Name="提單日期" SessionField="提單日期" Type="DateTime" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <div class=" text-center">
                                <asp:Button ID="取消選擇BT" runat="server" CssClass="btn btn-success" Text="取消" />
                            </div>
                            
                        </asp:Panel>
                        <asp:Button ID="show3" runat="server" Text="show3" style="display:none"/>
                         <asp:Panel ID="AlertPanel" runat="server" align="center" Height="100px" Width="600px" ScrollBars="Horizontal" BackColor="#0099FF">
                            <div class=" text-center">
                             <h3>
                                 <asp:Label ID="MessageLB" runat="server" Text=""></asp:Label>
                                 
                                </h3>
                                <asp:Button ID="AlertBT" runat="server" Text="確定" CssClass="btn btn-warning" />
                                </div>
                        </asp:Panel>
                        <ajaxToolkit:ModalPopupExtender ID="AlertPanel_ModalPopupExtender" runat="server" BehaviorID="AlertPanel_ModalPopupExtender" TargetControlID="show3" PopupControlID="AlertPanel" CancelControlID="">
                        </ajaxToolkit:ModalPopupExtender>
                        <asp:Button ID="show2" runat="server" Text="show2" style="display:none"/>
                        <ajaxToolkit:ModalPopupExtender ID="SelectPanel_ModalPopupExtender" runat="server" BehaviorID="SelectPanel_ModalPopupExtender" TargetControlID="show2" PopupControlID="SelectPanel" CancelControlID="取消選擇BT">
                        </ajaxToolkit:ModalPopupExtender>
                    </div>
                </div>
            </div>
        </div>

        <asp:HiddenField ID="idHF" runat="server" />
    </form>
</body>
</html>
