<%@ Page Title="" Language="C#" MasterPageFile="~/TempCode/GGFSite.Master" AutoEventWireup="true" CodeBehind="MGT011.aspx.cs" Inherits="GGFPortal.MGT.MGT011" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--    <script type="text/javascript">
        $(function () {
            var start = moment().subtract(29, 'days');
            var end = moment();
            $('input[id="ContentPlaceHolder1_DateRangeTB"]').daterangepicker({
                singleDatePicker: true,
                showDropdowns: true,
                "locale": {
                    "format": "YYYY-MM-DD",
                    "applyLabel": "Apply",
                    cancelLabel: "Cancel",
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
                    "firstDay": 0
                }
            });
        });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <nav class="col-md-2 d-none d-md-block bg-light sidebar">
        <div class="sidebar-sticky">
            <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>日期</span>

            </h3>
            
            <asp:TextBox ID="DateRangeTB" runat="server" CssClass="form-control"></asp:TextBox>
            <ajaxToolkit:CalendarExtender runat="server" BehaviorID="DateRangeTB_CalendarExtender" TargetControlID="DateRangeTB" ID="DateRangeTB_CalendarExtender" Format="yyyy-MM-dd"></ajaxToolkit:CalendarExtender>
            <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>快遞單號</span>

            </h3>
            <%--<asp:TextBox ID="MutiTB" runat="server" CssClass="form-control h-50" TextMode="MultiLine"></asp:TextBox>--%>
            <asp:TextBox ID="提單TB" runat="server" class="form-control"></asp:TextBox>
            <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>寄件部門</span>

            </h3>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                                <asp:DropDownList ID="寄件人DDL" runat="server" DataSourceID="SqlDataSource4" DataTextField="dept" DataValueField="Dept_ID" AppendDataBoundItems="true" CssClass="form-control">
<%--                                        <asp:ListItem Text="河內快遞" Value="C180100" />
                                        <asp:ListItem Text="寧平快遞" Value="B180100" />--%>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString='<%$ ConnectionStrings:EIPConnectionString %>' SelectCommand="SELECT distinct dept,Dept_ID
                                            FROM [dbo].[Dept] where Dept_ID not in ( 'test')"></asp:SqlDataSource>
                </ContentTemplate>
            </asp:UpdatePanel>
                        <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>寄件人工號</span>

            </h3>
            <asp:TextBox ID="工號TB" runat="server" class="form-control"></asp:TextBox>
            <div class="form-group m-3">
                                            <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-outline-primary" OnClick="SearchBT_Click" />
                            <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-outline-dark" OnClick="ClearBT_Click" />
            </div>
        </div>
    </nav>

    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="100%" Visible="false" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="ReportSource\MGT\ReportMGT011V2.rdlc" DisplayName="快遞核准單"></LocalReport>
        </rsweb:ReportViewer>
    </main>
                                                    <asp:Panel ID="SelectPanel" runat="server" Style="display:none"   ScrollBars="Auto" CssClass="w-50 h-50 bg-info text-center" >
                                    <div><h3>選擇快遞單</h3></div>
                                    
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource2" OnRowCommand="GridView1_RowCommand"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="table table-dark">
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
                                        
                              
                                        <div class=" align-items-center"><asp:Button ID="取消選擇BT" runat="server" CssClass="btn btn-success" Text="取消" /></div>
                                        
                              

                                </asp:Panel>
                                <ajaxToolkit:ModalPopupExtender ID="SelectPanel_ModalPopupExtender" runat="server" BehaviorID="SelectPanel_ModalPopupExtender" TargetControlID="show2" PopupControlID="SelectPanel" CancelControlID="取消選擇BT">
                                </ajaxToolkit:ModalPopupExtender>
                                <asp:Button ID="show2" runat="server" Text="show2" Style="display: none" />
</asp:Content>
