<%@ Page Title="" Language="C#" MasterPageFile="~/TempCode/GGFSite.Master" AutoEventWireup="true" CodeBehind="Sample024.aspx.cs" Inherits="GGFPortal.Sales.Sample024" %>

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
<%--        <div class="sidebar-sticky">
            <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>日期</span>

            </h3>
            <asp:TextBox ID="DateRangeTB" runat="server" CssClass="form-control"></asp:TextBox>
                        <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>說明2</span>

            </h3>
            <asp:TextBox ID="MutiTB" runat="server" CssClass="form-control h-50" TextMode="MultiLine"></asp:TextBox>
        </div>--%>
    </nav>

    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
        <div class="table-responsive">

            <asp:GridView ID="ToDayGV" runat="server" CssClass="table table-striped table-sm table-dark" AutoGenerateColumns="False" OnRowDataBound="ToDayGV_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="款號" HeaderText="款號" SortExpression="款號" />
                    <asp:BoundField DataField="打樣單號" HeaderText="打樣單號" SortExpression="打樣單號" />
                    <asp:TemplateField HeaderText="路徑" SortExpression="路徑">

                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("路徑") %>' Visible="false"></asp:Label>
                            <asp:Label ID="LinkLB" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="文件名稱" HeaderText="文件名稱" SortExpression="文件名稱" />
                    <asp:BoundField DataField="開單人員" HeaderText="開單人員" SortExpression="開單人員" />
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="客來版" HeaderText="客來版" SortExpression="客來版" />
                    <asp:BoundField DataField="參考版" HeaderText="參考版" SortExpression="參考版" />
                    <asp:BoundField DataField="上傳日期" HeaderText="上傳日期" ReadOnly="True" SortExpression="上傳日期" />
                </Columns>
            </asp:GridView>
            <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionString %>" SelectCommand="SELECT top 100 * FROM [View打樣單客來參考版]"></asp:SqlDataSource>--%>
            <asp:GridView ID="OldGV" runat="server" CssClass="table table-striped table-sm table-info"  AutoGenerateColumns="False" OnRowDataBound="OldGV_RowDataBound">
                 <Columns>
                    <asp:BoundField DataField="款號" HeaderText="款號" SortExpression="款號" />
                    <asp:BoundField DataField="打樣單號" HeaderText="打樣單號" SortExpression="打樣單號" />
                    <asp:TemplateField HeaderText="路徑" SortExpression="路徑">

                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("路徑") %>' Visible="false"></asp:Label>
                            <asp:Label ID="LinkLB" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="文件名稱" HeaderText="文件名稱" SortExpression="文件名稱" />
                    <asp:BoundField DataField="開單人員" HeaderText="開單人員" SortExpression="開單人員" />
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="客來版" HeaderText="客來版" SortExpression="客來版" />
                    <asp:BoundField DataField="參考版" HeaderText="參考版" SortExpression="參考版" />
                    <asp:BoundField DataField="上傳日期" HeaderText="上傳日期" ReadOnly="True" SortExpression="上傳日期" />
                </Columns>
            </asp:GridView>
        </div>
    </main>
    <!--日期暫存-->
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>
