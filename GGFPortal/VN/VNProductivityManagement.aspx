<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VNProductivityManagement.aspx.cs" Inherits="GGFPortal.VN.VNProductivityManagement" %>

<%--<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/style.css" rel="stylesheet" />
    <script src="../scripts/bootstrap.min.js"></script>
    <script src="../scripts/jquery-3.1.1.min.js"></script>
    <script src="../scripts/scripts.js"></script>
    <style type="text/css">
        .modalPopup {}
        .auto-style1 {
            height: 39px;
        }
    </style>
    

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<div class="container-fluid">
	<div class="row">
		<div class="col-md-2">
			<nav class="navbar navbar-default" role="navigation">
			<h3 class="text-info text-center">
				工時資料參數設定
			</h3>
				
				<div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">

                        <div class="form-group">
                            <h4>年</h4>
<%--<asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>--%>
<asp:DropDownList ID="YearDDL" runat="server" class="form-control"></asp:DropDownList>
						</div> 
                    <h4>月</h4>
                    <div class="form-group">
							<asp:DropDownList ID="MonthDDL" runat="server" class="form-control">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                            </asp:DropDownList>
						</div> 
  <%--                   <h4>工廠</h4>
                    <div class="form-group">
							<asp:DropDownList ID="VendorDDL" runat="server" class="form-control"></asp:DropDownList>
						</div> 
                   <h4>工廠</h4>
                    <div class="form-group">
    <asp:DropDownList ID="DropDownList1" runat="server" class="form-control "  ></asp:DropDownList>
						</div> --%>
                    <div class="form-group">
						</div>
<asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />
                    <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-default" OnClick="ClearBT_Click" />
					
				</div>
				
			</nav>
		</div>
		<div class="col-md-10">
    <asp:GridView ID="GridView1" runat="server"  CssClass="table table-bordered" AutoGenerateColumns="False" DataKeyNames="uid" DataSourceID="SqlDataSource1" AllowPaging="True" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" PageSize="25" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
        <Columns>
            <asp:CommandField ButtonType="Button" SelectText="修改" ShowSelectButton="True" />
            <asp:BoundField DataField="uid" HeaderText="" InsertVisible="False" ReadOnly="True" SortExpression="uid" />
            <asp:BoundField DataField="Flag" HeaderText="鎖定" SortExpression="Flag"  />
            <asp:BoundField DataField="VendorId" HeaderText="工廠代號" SortExpression="VendorId" />
            <asp:BoundField DataField="Year" HeaderText="年" SortExpression="Year" />
            <asp:BoundField DataField="Month" HeaderText="月" SortExpression="Month" />
            <asp:BoundField DataField="Currency" HeaderText="幣別" SortExpression="Currency" />
            <asp:BoundField DataField="Cost" HeaderText="成本" SortExpression="Cost" />
            <asp:BoundField DataField="Day" HeaderText="天數" SortExpression="Day" />
            <asp:BoundField DataField="Hour" HeaderText="日工時" SortExpression="Hour" />
            <%--<asp:BoundField DataField="CREATOR" HeaderText="建立者" SortExpression="CREATOR" />--%>
            <asp:BoundField DataField="CREATEDATE" HeaderText="建立時間" SortExpression="CREATEDATE"  DataFormatString="{0:d}"/>
            <%--<asp:BoundField DataField="ModifyUser" HeaderText="修改者" SortExpression="ModifyUser" NullDisplayText="未修改" />--%>
            <asp:BoundField DataField="ModifyDate" HeaderText="修改時間" SortExpression="ModifyDate"  DataFormatString="{0:d}" NullDisplayText="未修改"/>
        </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
        <PagerSettings Position="Top" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#487575" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
			
		    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT * FROM [ProductivityCost] WHERE ([Year] = @Year and ([Month] = @Month or 1=@SearchFlag2) ) or 1=@SearchFlag">
                <SelectParameters>
                    <asp:ControlParameter ControlID="YearDDL" DefaultValue="2017" Name="Year" PropertyName="SelectedValue" Type="Int32" />
                    <asp:ControlParameter ControlID="MonthDDL" DefaultValue="1" Name="Month" PropertyName="SelectedValue" Type="Int32" />
                    <asp:SessionParameter DefaultValue="1" Name="SearchFlag" SessionField="SearchFlag" Type="Int32" />
                    <asp:SessionParameter DefaultValue="2" Name="SearchFlag2" SessionField="SearchFlag2" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            
		
        <asp:Button ID="Show" runat="server" Text="Button"   Style="display: none" />
                <ajaxToolkit:modalpopupextender ID="ModalPopupExtender1" runat="server" PopupControlID="UpDatePanel" CancelControlID="ExitBT" TargetControlID="Show" ></ajaxToolkit:modalpopupextender>
            <asp:Panel ID="UpDatePanel" runat="server"  
                 align="center" CssClass="modalPopup" Height="300px" Width="600px" ScrollBars="Horizontal" BackColor="#33CCFF">

                <table style="width: 100%;"  class="table table-bordered">
                    <tr>
                        <th class="" colspan="2">
                            <h3 class=" text-center">工時基本資料設定</h3><asp:HiddenField ID="UidHF" runat="server" />
                            <asp:HiddenField ID="FlagHF" runat="server" />
                        </th>

                    </tr>
                    <tr>
                        <th class="auto-style4">
                            <asp:Label ID="BlockLB" runat="server" Text="鎖定"></asp:Label>
                        </th>
                        <td class="text-left">
                            <asp:CheckBox ID="BlockCB" runat="server"  Text="是否鎖定"/>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                        <th class="auto-style4">
                            <asp:Label ID="CostLB" runat="server" Text="成本:"></asp:Label>
                        </th>
                        <td class="text-left">
                            <asp:TextBox ID="CostTB" runat="server" ></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^[0-9]+(.[0-9]{0,4})?$" ControlToValidate="CostTB"></asp:RegularExpressionValidator>
                        </td>


                        
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="AddTypeLB" runat="server" Text="Type:"></asp:Label>
                        </td>
                        <td class="auto-style1">
                            </td>
                        
                    </tr>
                   
                    <tr>
                        
                        <td colspan="2" class="">
                            <asp:Button ID="SaveBT" runat="server" Text="Save" OnClick="SaveBT_Click" />
                            <asp:Button ID="ExitBT" runat="server" Text="Exit" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            </div>
</div>
    </div>
    </form>
</body>
</html>
