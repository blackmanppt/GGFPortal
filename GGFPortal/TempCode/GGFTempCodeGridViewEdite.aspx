<%@ Page Title="" Language="C#" MasterPageFile="~/TempCode/GGFSite.Master" AutoEventWireup="true" CodeBehind="GGFTempCodeGridViewEdite.aspx.cs" Inherits="GGFPortal.TempCode.GGFTempCodeGridViewEdite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="//github.com/fyneworks/multifile/blob/master/jQuery.MultiFile.min.js" type="text/javascript"></script>
        <style type="text/css">
    .hiddencol
    {
        display:none;
    }
    .viscol
    {
        display:block;
    }
</style>
    <script type="text/javascript">
        $(function () {
            var start = moment().subtract(29, 'days');
            var end = moment();
            $('input[id="ContentPlaceHolder1_DateRangeTB"]').daterangepicker({
                "startDate": start,
                "endDate": end,
                "showDropdowns": true,
                "autoApply": true,
                "locale": {
                    "format": "YYYY-MM-DD",
                    "separator": " ~ ",
                    "applyLabel": "Apply",
                    "cancelLabel": "Cancel",
                    "fromLabel": "From",
                    "toLabel": "To",
                    "customRangeLabel": "Custom",
                    "weekLabel": "W",
                    "daysOfWeek": [
                        "Su",
                        "Mo",
                        "Tu",
                        "We",
                        "Th",
                        "Fr",
                        "Sa"
                    ],
                    "monthNames": [
                        "January",
                        "February",
                        "March",
                        "April",
                        "May",
                        "June",
                        "July",
                        "August",
                        "September",
                        "October",
                        "November",
                        "December"
                    ],
                    "firstDay": 1
                },
                "showCustomRangeLabel": false,
                "alwaysShowCalendars": true,
                "autoUpdateInput": true

            }, function (start, end, label) {
                //Updates value of date
                $('input[id="ContentPlaceHolder1_DateRangeTB"]').val(start.format('YYYY-MM-DD') + ' ~ ' + end.format('YYYY-MM-DD'));
                //Add the value to hidden field
                $('input[id="ContentPlaceHolder1_HiddenField1"]').val(start.format('YYYY-MM-DD') + ' ~ ' + end.format('YYYY-MM-DD'));
                $('input[id="ContentPlaceHolder1_DateRangeTB"]').trigger('change');
                //確認資料
                var KeepDate = $('input[id="ContentPlaceHolder1_HiddenField1"]').val();
                console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' ~ ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + KeepDate + ')');
            });
        });
        //postback後將資料塞回欄位
        $(document).ready(function () {
            //Assign the value from hidden field to textbox
            var xxxx = $('input[id="ContentPlaceHolder1_HiddenField1"]').val();
            console.log(xxxx.length);
            if (xxxx.length > 0) {

                onLoad: $('input[id="ContentPlaceHolder1_DateRangeTB"]').val($('input[id="ContentPlaceHolder1_HiddenField1"]').val());
            }

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav class="col-md-2 d-none d-md-block bg-light sidebar">
        <div class="sidebar-sticky">
<%--            <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>日期</span>

            </h3>
            <asp:TextBox ID="DateRangeTB" runat="server" CssClass="form-control"></asp:TextBox>--%>
            <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>款號</span>

            </h3>
            <asp:TextBox ID="MutiTB" runat="server" CssClass="form-control h-50" TextMode="MultiLine"></asp:TextBox>
            <div class="form-group btn-group align-content-end">
                <asp:Button ID="SearchBT" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="SearchBT_Click" />
                <asp:Button ID="ClearBT" runat="server" Text="Clear" CssClass="btn btn-info" OnClick="ClearBT_Click" />
            </div>

        </div>
    </nav>

    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
        <h3>
            <asp:Label ID="副標LB" runat="server" Text=""></asp:Label></h3>

        <div class="table-responsive">
            <asp:GridView ID="GV" runat="server" CssClass="table table-striped table-sm table-dark" OnRowCommand="GV_RowCommand" AutoGenerateColumns="False" AllowPaging="True" OnRowDataBound="GV_RowDataBound" PageSize="15" DataKeyNames="id" OnPageIndexChanging="GV_PageIndexChanging">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <div class="btn-group">
                                <asp:Button ID="GVEditBT" runat="server" CausesValidation="False" CommandName="EditData" Text="編輯" CssClass=" btn btn-primary" />
                                <%--<asp:Button ID="GVDeleteBT" runat="server" CausesValidation="False" CommandName="DeleteData" Text="刪除" OnClientClick="return confirm('是否刪除')" CssClass="btn btn-danger " />--%>
                            </div>

                        </ItemTemplate>
                        <ItemStyle Width="10px" />
                    </asp:TemplateField>

                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                                    <HeaderStyle CssClass="hiddencol" />
                                    <ItemStyle CssClass="hiddencol" />
                                </asp:BoundField>
                    <asp:BoundField DataField="DataModifyDate" HeaderText="收料日期" SortExpression="DataModifyDate" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="款號" HeaderText="款號" SortExpression="款號" />
                    <asp:BoundField DataField="料號" HeaderText="料號" SortExpression="料號" />
                    <asp:BoundField DataField="Qty" HeaderText="Qty" SortExpression="Qty" />
                    <asp:BoundField DataField="file_name" HeaderText="file_name" SortExpression="file_name" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                                    <HeaderStyle CssClass="hiddencol" />
                                    <ItemStyle CssClass="hiddencol" />
                                </asp:BoundField>
<%--                    <asp:BoundField DataField="Reason" HeaderText="Reason" SortExpression="Reason" />
                    <asp:BoundField DataField="ReasonCode" HeaderText="ReasonCode" SortExpression="ReasonCode" />--%>
                    <asp:TemplateField HeaderText="File">
                        <ItemTemplate>
                            <asp:Label ID="LinkLB" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT [id], [DataModifyDate], [款號], [料號], [Qty], [file_name], [Reason], [ReasonCode] FROM [GGF收料報告]"></asp:SqlDataSource>
            <asp:Button ID="show3" runat="server" Text="show3" Style="display: none" />
            <asp:Panel ID="EditPanel" runat="server" align="center" CssClass="alert-danger w-50" Style="display: none" Height="600px">
                <div class=" container-fluid">
                    <div class="row">
                        <div class="col-md-12 col-lg-12 text-center p-3">
                            <h3>
                                <asp:Label ID="EditLB" runat="server" Text="編輯資料" CssClass="text-danger"></asp:Label>

                            </h3>
                        </div>

                        <table class=" table" style="">
                            <tr>
                                <th>
                                    <div class="text-lg-right text-primary h4">收料日期:</div>
                                </th>
                                <td>
                                    <asp:Label ID="收料日期LB" runat="server" Text="" CssClass="text-black-50 text-info"></asp:Label>
                                </td>
                                <th>
                                    <div class="text-lg-right text-primary h4">款號:</div>
                                </th>
                                <td>
                                    <asp:Label ID="StyleLB" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <div class="text-lg-right text-primary h4">收料人員:</div>
                                </th>
                                <td>
                                    <asp:TextBox ID="收料人員TB" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                                <th>
                                    <div class="text-lg-right text-primary h4">錯誤原因:</div>
                                </th>
                                <td >

                                                                            <asp:DropDownList ID="錯誤原因DDL" runat="server" CssClass="form-control form-control-dark dropdown" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="錯誤原因DDL_SelectedIndexChanged" DataSourceID="SqlDataSource2" DataTextField="reason_name" DataValueField="reason">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem Text="其他" Value="OTHER" />
                                        </asp:DropDownList>



                                                                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionString %>" SelectCommand="SELECT [reason], [reason_name] FROM [bas_reason] WHERE ([sys_id] = @sys_id) ORDER BY [reason]">
                                                                                <SelectParameters>
                                                                                    <asp:Parameter DefaultValue="MPSC" Name="sys_id" Type="String" />
                                                                                </SelectParameters>
                                                                            </asp:SqlDataSource>



                                </td>
                            </tr>
                            <tr class="h-50">
                                <th>
                                    <div class="text-lg-right text-primary h4">文件上傳:</div>
                                </th>
                                <td colspan="2">
                                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                    <%--<ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload1" runat="server" CssClass="" Height="300px" Width="350px" OnUploadComplete="AjaxFileUpload1_UploadComplete" />--%>
                                    <label class="btn btn-info">

                                        <img src="../Pic/Icon/svg/file.svg" />
                                        <input id="upload_file" style="display: none;" type="file" runat="server" multiple name="FileUpload">
                                        <i class="fa fa-photo"></i>上傳檔案
                                    </label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="備註TB" runat="server" TextMode="MultiLine" CssClass="form-control" Height="200px" Visible="false"></asp:TextBox>
                                </td>
                            </tr>
                        </table>


                        <div class="col-md-12 col-lg-12 text-center p-3">
                            <h3>
                                <asp:Button ID="SaveBT" runat="server" Text="Save" CssClass="btn btn-danger" OnClick="SaveBT_Click" />
                                <asp:Button ID="CancelBT" runat="server" Text="Cancel" CssClass="btn btn-info" />
                            </h3>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <ajaxToolkit:ModalPopupExtender ID="EditPanel_ModalPopupExtender" runat="server" BehaviorID="EditPanel_ModalPopupExtender" TargetControlID="show3" PopupControlID="EditPanel" CancelControlID="CancelBT">
            </ajaxToolkit:ModalPopupExtender>

        </div>
    </main>
    <!--日期暫存-->
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>
