<%@ Page Title="" Language="C#" MasterPageFile="~/TempCode/GGFSite.Master" AutoEventWireup="true" CodeBehind="Sample025.aspx.cs" Inherits="GGFPortal.Sales.Sample025" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                    var xxxx = $('input[id="ContentPlaceHolder1_HiddenField1"]').val();
                    console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' ~ ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + xxxx + ')');
            });
        });
        //postback後將資料塞回欄位
        $(document).ready(function () {
            //Assign the value from hidden field to textbox
            var xxxx = $('input[id="ContentPlaceHolder1_HiddenField1"]').val();
            console.log(xxxx.length);
            if (xxxx.length>0) {

                onLoad: $('input[id="ContentPlaceHolder1_DateRangeTB"]').val($('input[id="ContentPlaceHolder1_HiddenField1"]').val());
            }
            
        });
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav class="col-md-2 d-none d-md-block bg-light sidebar">
        <div class="sidebar-sticky">
            <%--<h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>日期</span>

            </h3>
            <div class="form-group">
                <asp:TextBox ID="DateRangeTB" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            
                        <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>說明2</span>

            </h3>
            <div class="form-group">
                <asp:TextBox ID="MutiTB" runat="server" CssClass="form-control h-50" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="form-group ">
                <div class=" text-right">
                    <asp:Button ID="SearchBT" runat="server" Text="Search" CssClass="btn btn-primary" />
                </div>
                
            </div>--%>
            
                        <div >
                            <h4>
                                <asp:Label ID="Label1" runat="server" Text="收單日期"></asp:Label></h4>
                            <asp:TextBox ID="收單起TB" runat="server" AutoPostBack="true" CssClass=" form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender runat="server" BehaviorID="收單起TB_CalendarExtender" TargetControlID="收單起TB" ID="收單起TB_CalendarExtender" Format="yyyy/MM/dd" ></ajaxToolkit:CalendarExtender>
                            <asp:TextBox ID="收單迄TB" runat="server" AutoPostBack="true" CssClass=" form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender runat="server" BehaviorID="收單迄TB_CalendarExtender" TargetControlID="收單迄TB" ID="收單迄TB_CalendarExtender" Format="yyyy/MM/dd" ></ajaxToolkit:CalendarExtender>
                            <h4>款號</h4>
                            <div class="form-group">
                                <asp:TextBox ID="款號TB" runat="server" CssClass=" form-control"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" BehaviorID="款號TB_AutoCompleteExtender" TargetControlID="款號TB" ID="款號TB_AutoCompleteExtender" ServiceMethod="SearchSampleStyleNo" MinimumPrefixLength="1" UseContextKey="True"></ajaxToolkit:AutoCompleteExtender>
                            </div>
                            <h4>品牌</h4>
                            <div class="form-group">
                                                        <asp:TextBox ID="BrandTB" runat="server" CssClass=" form-control"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="BrandTB_AutoCompleteExtender" runat="server" TargetControlID="BrandTB" CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" ServiceMethod="Search打樣單品牌"  ServicePath="~/ReferenceCode/AutoCompleteWCF.svc">
                        </ajaxToolkit:AutoCompleteExtender>

                            </div>
                            <h4>樣品種類</h4>
                            <div class=" ">
                                                        <asp:DropDownList ID="SamcTypeDDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSourceSamcType" DataTextField="type_desc" DataValueField="type_id"  CssClass=" form-control dropdown ">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSourceSamcType" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT DISTINCT [type_id], [type_desc] FROM [samc_type] ORDER BY [type_id]"></asp:SqlDataSource>
                            </div>
                            <h4>樣品單處理狀態</h4>
                            <div class="">
                                 <asp:DropDownList ID="NewOldDDL" runat="server" CssClass=" form-control dropdown ">
                            <asp:ListItem Value="2">業務完成</asp:ListItem>
                            <asp:ListItem Value="3">打樣完成</asp:ListItem>
                            <asp:ListItem Value="4">全部</asp:ListItem>
                        </asp:DropDownList>
                            </div>
                            <h4>打樣單狀態</h4>
                            <div class=" ">
                                <asp:DropDownList ID="StatusDDL" runat="server" AutoPostBack="True" OnSelectedIndexChanged="StatusDDL_SelectedIndexChanged" CssClass=" form-control dropdown ">
                            <asp:ListItem Value="A">新增</asp:ListItem>
                            <asp:ListItem Value="CL">結案</asp:ListItem>
                            <asp:ListItem Value="CA">刪除</asp:ListItem>
                            <asp:ListItem Value="ALL">全部</asp:ListItem>
                        </asp:DropDownList>
                            </div>
                            
                            
                           
                            
                            <div class="form-group">
                                <h4>是否收單</h4>
                                <asp:CheckBox ID="ReceiptCB" runat="server" Text="未收單資料" AutoPostBack="True"  />
                                <h4>地區</h4>
                                <asp:CheckBox ID="HanoiCB" runat="server" Text="河內打樣" />

                            </div>

                            <h4>結案日期</h4>
                            <div class=" form-group">
                                
                                <asp:TextBox runat="server" ID="結案起TB" Enabled="false"  CssClass=" form-control " />
                                <ajaxToolkit:CalendarExtender runat="server" BehaviorID="結案起TB_CalendarExtender" TargetControlID="結案起TB" ID="結案起TB_CalendarExtender"  Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>
                                <asp:TextBox runat="server" ID="結案迄TB" Enabled="false" CssClass=" form-control " />
                                <ajaxToolkit:CalendarExtender runat="server" BehaviorID="結案迄TB_CalendarExtender" TargetControlID="結案迄TB" ID="結案迄TB_CalendarExtender"  Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-dark" OnClick="SearchBT_Click" />
                                <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-danger" OnClick="ClearBT_Click" />
                            </div>
                        </div>
        </div>
    </nav>

    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" SizeToReportContent="True" Visible="False" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226">
            <LocalReport ReportPath="ReportSource\Sample\ReportSALEV7.rdlc"  DisplayName="樣品單資料" EnableExternalImages="True">
            </LocalReport>
    </rsweb:ReportViewer>
    </main>
    <!--日期暫存-->
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>
