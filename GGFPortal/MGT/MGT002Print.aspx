<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MGT002Print.aspx.cs" Inherits="GGFPortal.MGT.MGT002Print" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>快遞單明細</title>
    <script src="../scripts/jquery-3.1.1.min.js"></script>
    <script src="../scripts/scripts.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
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

        .置中 {
            margin: 0px auto;
        }
    </style>
    <script type='text/javascript'>
        //<![CDATA[
        jQuery(function($) { 'use strict';
            $("#ele2").find('.print-link').on('click', function() {
                //Print ele2 with default options
                $.print("#ele2");
            });
        });
        //]]>
        </script>
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


                    <asp:Panel ID="ADDPanel" runat="server" Visible="false" >
                    <table class="table table-bordered">
                        <thead>
                            <tr>
                                <th colspan="3">
                                    <h3 class="text-center">快遞單資料</h3>
                                    
                                </th>
                            </tr>
                            <tr class="auto-style2">
                                <th class="auto-style1">快遞日期(Thời gian chuyển phát nhanh)</th>
                                <th class="auto-style1">快遞廠商(Nhà cung cấp chuyển phát nhanh)</th>
                                <th class="auto-style1">提單號碼(Đặt hàng nhanh)</th>
                                
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
                                    <asp:Label ID="部門LB" runat="server" Text="" CssClass=""></asp:Label>
                                    <asp:Label ID="提單號碼LB" runat="server" Text="" CssClass=""></asp:Label>
                                </td>

                            </tr>
                            <tr class="auto-style2">
                                                                <th class="auto-style1">送件目的地(<span lang="EN-US">Địa điểm giao hàng</span>)</th>
                                <th class="auto-style1">快遞單檔案(<span lang="EN-US">Tập tin chuyển phát nhanh</span>)</th>
                                                                <th class=" text-right" style="vertical-align:bottom;"rowspan="2" >                                    
                                    <%--<asp:Button ID="SaveBT" runat="server" Text="新增明細" CssClass="btn btn-default" OnClick="SaveBT_Click"/>--%>
                                                                    <%--<button class="print-link" onclick="jQuery.print()">Print page - jQuery.print()
            </button> <asp:Button ID="Button1" runat="server" Text="列印圖片" class=" btn btn-default"  OnClientClick="jQuery('#picture').print();"/>--%>
                         
                                    </th>
                            </tr>
                            <tr>
                                <td class=" text-center">
                                    <asp:Label ID="送件地點LB" runat="server" Text=""></asp:Label>
                                </td>
                                <td class=" text-center">
                                    <div  id="picture">
                                    <asp:Literal ID="快遞單檔案Literal" runat="server"></asp:Literal>
                                        </div>
                                </td>
                            </tr>
                        </tbody>
                        <tr><th class=" text-center" colspan="3" style="background-color:#bec494"><asp:Label ID="MsgLB" runat="server" Text=""></asp:Label></th>
                            </tr>
                    </table>
                    <asp:GridView ID="ACRGV" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="uid" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" OnRowCommand="ACRGV_RowCommand">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="uid" HeaderText="uid" InsertVisible="False" ReadOnly="True" SortExpression="uid"  HeaderStyle-CssClass="hiddencol" ItemStyle-cssclass="hiddencol"  >
                            </asp:BoundField>
                            <asp:BoundField DataField="id" HeaderStyle-CssClass="hiddencol" HeaderText="id" ItemStyle-cssclass="hiddencol" SortExpression="id" />
                              <asp:TemplateField ShowHeader="False" ItemStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:Button ID="PrintBT" runat="server" CausesValidation="false" CommandName="列印" Text="Print" CssClass="btn btn-primary" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="寄件人" HeaderText="寄件人" SortExpression="寄件人" />
                            <asp:BoundField DataField="寄件人分機" HeaderText="寄件人分機(Gia hạn)" SortExpression="寄件人分機" />
                            <asp:BoundField DataField="收件人" HeaderText="收件人(Người nhận)" SortExpression="收件人" />
                            <asp:BoundField DataField="客戶名稱" HeaderText="客戶名稱(Khách hàng)" SortExpression="客戶名稱" />
                            <asp:BoundField DataField="明細" HeaderText="明細(Chi tiết)" SortExpression="明細" />
                            <asp:BoundField DataField="重量" HeaderText="重量(Cân nặng)" SortExpression="重量" />
                            <asp:BoundField DataField="付款方式" HeaderText="到付" SortExpression="付款方式" />
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
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT * FROM [快遞單明細] WHERE ([id] = @id) and IsDeleted =0">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="0" Name="id" SessionField="id" Type="Int32" />
                        </SelectParameters>
                        </asp:SqlDataSource>
                        </asp:Panel>


                    <div >



                                <asp:Button ID="show" runat="server" Text="show" Style="display: none" />
                                <asp:Panel ID="EditListPanel" runat="server" align="center" CssClass="modalPopup form-control" Height="430px" Width="800px" BackColor="#33CCFF" Style="display: none"  >
                                    <div class=" text-center text-danger">
                                        <h3><b>Detail</b></h3>
                                    </div>
                                    <div class="row">
                                        <div class=" col-md-3 text-right">
                                            <asp:Label ID="寄件人LB" runat="server" Text="ID：" Font-Bold="True"></asp:Label>
                                        </div>
                                        <div class="col-md-3 text-left">

                                            <asp:TextBox ID="寄件人工號TB" runat="server"></asp:TextBox>
                                        </div>
                                        <div class=" col-md-3 text-right">
                                            <asp:Label ID="分機LB" runat="server" Font-Bold="True" Text="Telephone："></asp:Label>
                                        </div>
                                        <div class="col-md-3 text-left">
                                            <asp:TextBox ID="分機TB" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class=" col-md-3  text-right">
                                            <asp:Label ID="客戶名稱LB" runat="server" Text="Receive company：" Font-Bold="True"></asp:Label>
                                        </div>
                                        <div class="col-md-3 text-left">
                                            <!--
                                                pup裡面包auto
                                                1.欄位前要多加
                                                <div id="chromeUse"></div>
                                                2.
                                                <ajaxToolkit:AutoCompleteExtender CompletionListElementID="chromeUse"
                                                -->
                                            <div id="chromeUse"></div>
                                            <asp:TextBox ID="客戶名稱TB" runat="server"></asp:TextBox>
                                             <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" TargetControlID="客戶名稱TB" ID="客戶名稱TB_AutoCompleteExtender" ServiceMethod="Search供應商代號"  MinimumPrefixLength="1"
        CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" OnClientPopulated="Employees_Populated" FirstRowSelected="false" CompletionListElementID="chromeUse"></ajaxToolkit:AutoCompleteExtender>
                            <div>
                                    <script type="text/javascript">
                                        function Employees_Populated(sender, e) {
                                            var employees = sender.get_completionList().childNodes;
                                            var div = "<table>";
                                            div += "<tr><th>客戶代號</th><th>&nbsp;</th><th>客戶簡稱</th></tr>";
                                            for (var i = 0; i < employees.length; i++) {
 
                                                div += "<tr><td>" + employees[i].innerHTML.split(',')[0] + "</td><td>&nbsp;</td><td>" + employees[i].innerHTML.split(',')[1] + "</td></tr>";
                                            }
                                            div += "</table>";
                                            sender._completionListElement.innerHTML = div;
                                        }
                                    </script>
                                </div>
                                        </div>
                                        <div class=" col-md-3 text-right">
                                            <asp:Label ID="收件人LB" runat="server" Text="receiver：" Font-Bold="True"></asp:Label>
                                        </div>
                                        <div class="col-md-3 text-left">
                                            <asp:TextBox ID="收件人TB" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class=" col-md-3  text-right">
                                            <asp:Label ID="重量LB" runat="server" Text="weight(kg)：" Font-Bold="True"></asp:Label>
                                        </div>
                                        <div class="col-md-3 text-left">
                                            <asp:TextBox ID="重量TB" runat="server"></asp:TextBox>
                                            </div>
                                        <div class=" col-md-3 text-right">
                                            <asp:Label ID="責任歸屬LB" runat="server" Text="Responsibility：" Font-Bold="True"></asp:Label>
                                        </div>
                                        <div class="col-md-3 text-left">
                                            <asp:TextBox ID="責任歸屬TB" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class=" col-md-3  text-right">
                                            <asp:Label ID="到付LB" runat="server" Text="Cash on delivery：" Font-Bold="True"></asp:Label>
                                        </div>
                                        <div class="col-md-3 text-left">
                                            <asp:CheckBox ID="到付CB" runat="server" />
                                        </div>
                                        <div class=" col-md-3 text-right">
                                            <asp:Label ID="Label1" runat="server" Text="Reason：" Font-Bold="True"></asp:Label>
                                        </div>
                                        <div class="col-md-3 text-left">
                                            <asp:DropDownList ID="原因歸屬DDL" runat="server" DataSourceID="SqlDataSource3" DataTextField="Data" DataValueField="MappingData" AppendDataBoundItems="True">
                                            <asp:ListItem></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionString %>" SelectCommand="SELECT * FROM [Mapping] WHERE ([UsingDefine] = @UsingDefine)">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="原因歸屬" Name="UsingDefine" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </div>
                                    </div>
                                    <div id="DHLrow2" runat="server" class="row" visible="false">
                                        <div class=" col-md-3 text-right">
                                            <asp:Label ID="款號LB" runat="server" Text="Style：" Font-Bold="True" ></asp:Label>
                                        </div>
                                        <div class=" col-md-9 text-left">
                                            <div id="showauto"></div>
                                            <asp:TextBox ID="款號TB" runat="server"></asp:TextBox>
                                            <ajaxToolkit:AutoCompleteExtender ID="款號TB_AutoCompleteExtender" runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" TargetControlID="款號TB" ServiceMethod="SearchOrdStyle" MinimumPrefixLength="1" UseContextKey="True" CompletionListElementID="showauto">
                                            </ajaxToolkit:AutoCompleteExtender>
                                        </div>
                                    </div>

                                    <div id="DHLrow" runat="server" class="row" visible="false">
                                        <div class=" col-md-3 text-right">
                                            <asp:Label ID="數量LB" runat="server" Text="Qty：" Font-Bold="True" ></asp:Label>
                                        </div>
                                        <div class=" col-md-3 text-left">
                                            <asp:TextBox ID="數量TB" runat="server" TextMode="Number"></asp:TextBox>
                                        </div>
                                        <div class=" col-md-3 text-right">
                                            <asp:Label ID="單位LB" runat="server" Text="Unit：" Font-Bold="True"></asp:Label>
                                        </div>
                                        <div class=" col-md-3 text-left">
                                            <asp:DropDownList ID="單位DDL" runat="server">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem>PSC</asp:ListItem>
                                                <asp:ListItem>SET</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row ">
                                        <div class="col-md-3 text-right">
                                            <asp:Label ID="明細LB" runat="server" Text="Detail：" Font-Bold="True"></asp:Label></div>
                                        <div class="col-md-9 text-left">
                                            <asp:TextBox ID="明細TB" runat="server" Width="489px"></asp:TextBox></div>
                                    </div>
                                    <div class="row">
                                                                                <div class=" col-md-3 text-right">
                                            <asp:Label ID="備註" runat="server" Text="remark：" Font-Bold="True"></asp:Label>
                                        </div>
                                        <div class="col-md-3 text-left">
                                            <asp:TextBox ID="備註TB" runat="server" Width="489px" TextMode="MultiLine" Height="84px"></asp:TextBox>
                                        </div>                                        
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                                                               <h3>
                                            <asp:Label ID="EditMessageLB" runat="server" Text=""></asp:Label>

                                        </h3>
                                        </div>
                                    </div>
                                    <%--<asp:Literal ID="EditMessageLiteral" runat="server"></asp:Literal>--%>
                                    <asp:Button ID="新增BT" runat="server" Text="ADD" CssClass="btn btn-primary" Visible="false" OnClick="新增BT_Click" />
                                    <asp:Button ID="更新BT" runat="server" Text="Update" CssClass="btn btn-primary" Visible="false" OnClick="更新BT_Click" />
                                    <asp:Button ID="取消BT" runat="server" Text="Cancel" CssClass="btn btn-primary" OnClick="取消BT_Click" />
                                </asp:Panel>
                                <ajaxToolkit:ModalPopupExtender ID="EditListPanel_ModalPopupExtender" runat="server" BehaviorID="EditListPanel_ModalPopupExtender" TargetControlID="show" PopupControlID="EditListPanel" >
                                </ajaxToolkit:ModalPopupExtender>
                        

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
        </div>

        <asp:HiddenField ID="uidHF" runat="server" />
        <asp:HiddenField ID="idHF" runat="server" />
    </form>
</body>
</html>
