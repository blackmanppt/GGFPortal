<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VNProductivityManagement.aspx.cs" Inherits="GGFPortal.VN.VNProductivityManagement" %>

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
</head>
<body>
    <form id="form1" runat="server">
<div class="container-fluid">
	<div class="row">
		<div class="col-md-2">
			<nav class="navbar navbar-default" role="navigation">
			<h3 class="text-info text-left">
				工時資料參數設定
			</h3>
				
				<div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">

                        <div class="form-group">
                            <h4>年</h4>
<%--<asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>--%>
<asp:DropDownList ID="DropDownList2" runat="server" class="form-control"></asp:DropDownList>
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
                    <h4>工廠</h4>
                    <div class="form-group">
							<asp:DropDownList ID="VendorDDL" runat="server" class="form-control"></asp:DropDownList>
						</div> 
<%--                    <h4>工廠</h4>
                    <div class="form-group">
    <asp:DropDownList ID="DropDownList1" runat="server" class="form-control "  ></asp:DropDownList>
						</div> --%>
<asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" />
					
				</div>
				
			</nav>
		</div>
		<div class="col-md-10">
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover" AutoGenerateColumns="False" DataKeyNames="uid" DataSourceID="SqlDataSource1" AllowPaging="True" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" PageSize="25">
        <Columns>
            <asp:BoundField DataField="uid" HeaderText="uid" InsertVisible="False" ReadOnly="True" SortExpression="uid" />
            <asp:BoundField DataField="VendorId" HeaderText="VendorId" SortExpression="VendorId" />
            <asp:BoundField DataField="Year" HeaderText="Year" SortExpression="Year" />
            <asp:BoundField DataField="Month" HeaderText="Month" SortExpression="Month" />
            <asp:BoundField DataField="Currency" HeaderText="Currency" SortExpression="Currency" />
            <asp:BoundField DataField="Cost" HeaderText="Cost" SortExpression="Cost" />
            <asp:BoundField DataField="Day" HeaderText="Day" SortExpression="Day" />
            <asp:BoundField DataField="Hour" HeaderText="Hour" SortExpression="Hour" />
            <asp:BoundField DataField="CREATOR" HeaderText="CREATOR" SortExpression="CREATOR" />
            <asp:BoundField DataField="CREATEDATE" HeaderText="CREATEDATE" SortExpression="CREATEDATE" />
            <asp:BoundField DataField="ModifyUser" HeaderText="ModifyUser" SortExpression="ModifyUser" />
            <asp:BoundField DataField="ModifyDate" HeaderText="ModifyDate" SortExpression="ModifyDate" />
            <asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag" />
        </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#487575" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
			
		    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT * FROM [ProductivityCost]"></asp:SqlDataSource>
			
		</div>

</div>
    </div>
    </form>
</body>
</html>
