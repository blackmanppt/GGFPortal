<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="F001.aspx.cs" Inherits="GGFPortal.FactoryMG.F001" MasterPageFile="FactorySite.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>

        <div  >
            <table class="table table-dark w-50" >
                <tr class="">
                    <th class=" text-right">
                        <asp:Label ID="Label2" runat="server" Text="預計出貨日："></asp:Label>
                    </th>
                    <td class="">
                    <asp:TextBox ID="StartDayTB" runat="server" CssClass="form-row form-control-sm" AutoPostBack="True"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="StartDayTB_CalendarExtender" runat="server" TargetControlID="StartDayTB" Format="yyyy-MM-dd" CssClass="table table-dark" />
                    ~
                    <asp:TextBox ID="EndDayTB" runat="server" CssClass="form-row form-control-sm" AutoPostBack="True"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="EndDayTB_CalendarExtender" runat="server" TargetControlID="EndDayTB" Format="yyyy-MM-dd"  CssClass="table table-dark" />
                    </td>
                    <td class="">
                       
                    </td>
                </tr>
                <tr class="">
                    <th class="text-right">
                        <asp:Label ID="Label3" runat="server" Text="Style No："></asp:Label>
                    </th>
                    <td>
 <asp:TextBox ID="StyleNoTB" runat="server" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender ID="StyleNoTB_AutoCompleteExtender" runat="server" CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" ServiceMethod="SearchStyleNo"  TargetControlID="StyleNoTB">
                    </ajaxToolkit:AutoCompleteExtender>
                    </td>
                    <td> 
                        <div class="btn-group">
                            <asp:Button ID="Search" runat="server" Text="Search" CssClass="btn btn-primary" />
                            <asp:Button ID="Export" runat="server" OnClick="Export_Click" Text="Export" CssClass="btn btn-secondary" />
                        </div>
                    </td>
                </tr>
               
            </table>
        </div>
        <div >

            <asp:GridView ID="GridView1" runat="server" CssClass="table" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" AllowPaging="True" PageSize="50" BorderStyle="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="cus_item_no" HeaderText="style_no" SortExpression="style_no" />
                    <asp:BoundField DataField="agents" HeaderText="客戶" SortExpression="客戶" />
                    <asp:BoundField DataField="brand" HeaderText="品牌" SortExpression="品牌" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" ForeColor="White" Font-Bold="True" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>

<%--            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" 
                SelectCommand="select distinct a.agents,b.cus_name,brand,cus_item_no from ordc_bat x left join ordc_bah1 a on x.site=a.site and x.ord_nbr=a.ord_nbr left join bas_cus_master b on a.agents=b.cus_id where  bah_status<>'CA'">

            </asp:SqlDataSource>--%>



        </div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:Button ID="show3" runat="server" Text="show3" Style="" />
                <asp:Panel ID="AlertPanel" runat="server" align="center"  CssClass="alert-danger w-75" Style="display: none">
                    <div class=" text-center">
                        <h3>
                            <asp:Label ID="MessageLB" runat="server" Text="" CssClass="h3"></asp:Label>

                        </h3>
                        <asp:Button ID="AlertBT" runat="server" Text="確定" CssClass="btn btn-danger" />
                    </div>
                </asp:Panel>
                <ajaxToolkit:ModalPopupExtender ID="AlertPanel_ModalPopupExtender" runat="server" BehaviorID="AlertPanel_ModalPopupExtender" TargetControlID="show3" PopupControlID="AlertPanel" CancelControlID="">
                </ajaxToolkit:ModalPopupExtender>

                <asp:ScriptManager ID="ScriptManager2" runat="server">
                </asp:ScriptManager>

            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>






