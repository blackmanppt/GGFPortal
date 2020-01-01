<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MGT005.aspx.cs" Inherits="GGFPortal.MGT.MGT005" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>快遞單列印</title>
    <script src="../scripts/jquery-3.1.1.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../scripts/scripts.js"></script>
    <script src="../scripts/jQuery.print.min.js"></script>
    <style>
        table {
    border-collapse: collapse;
}

table, td, th {
    border: 2px solid black;
}
        .auto-style1 {
            background-color: #00FFFF;
        }
    </style>
    <script type='text/javascript'>
<!--// 自動列印: 會彈出印表機交談視窗
        //-->
function printPage() {
   //window.alert('測試');
   window.print();  
}

</script>
</head>
<body>
    <form id="form1" runat="server" style="width:600px">
    <div id="printarea">
    <div class="container-fluid" >
	<div class="row">
		<div class="col-md-12">
			<table class="table table-bordered" style="width:600px;height:400px;">
					<tr>
						<th class="auto-style1">
							快遞廠商</th>
						<th>
							<asp:Label ID="快遞廠商LB" runat="server" Text=""></asp:Label>
						</th>
						<th class="auto-style1">
							快遞日期</th>
						<th>
							<asp:Label ID="快遞日期LB" runat="server" Text=""></asp:Label>
                        </th>
					</tr>
				<tr>
						<th class="auto-style1">
							提單號碼</th>
						<th>
							<asp:Label ID="提單號碼LB" runat="server" Text="" style="font-size: x-large"></asp:Label>
						</th>
						<th class="auto-style1">
							快遞編號</th>
						<th>
							<asp:Label ID="快遞編號LB" runat="server" Text=""></asp:Label>
                        </th>
					</tr>
                					<tr>
						<th class="auto-style1">寄件人
							</th>
						<th>
							<asp:Label ID="寄件人LB" runat="server" Text=""></asp:Label>
                                        </th>
						<th class="auto-style1">
							name</th>
						<th>
							<asp:Label ID="英文名LB" runat="server" Text=""></asp:Label>
                                        </th>
					</tr>
                <tr>
						<th class="auto-style1">送件目的地
							</th>
						<th>
							<asp:Label ID="送件地點LB" runat="server" Text=""></asp:Label>
                                        </th>
						<th class="auto-style1">
							收件人</th>
						<th>
							<asp:Label ID="收件人LB" runat="server" Text="" style="font-size: x-large"></asp:Label>
                                        </th>
					</tr>
					<tr class="active">
						<th class="auto-style1">
							明細</th>
						<th colspan="3">
                            <asp:Label ID="明細LB" runat="server" Text=""></asp:Label></th>

					</tr>
					<tr class="active">
						<th class="auto-style1">
							備註</th>
						<th colspan="3">
                            <asp:Label ID="備註LB" runat="server" Text=""></asp:Label></th>

					</tr>
                <tr>
                    <th >

                        公斤數</th>
                    <th >

                        <asp:Label ID="公斤LB" runat="server" ></asp:Label>

                    </th>
                    <th >

                        &nbsp;</th>
                    <th >

                        &nbsp;</th>
                </tr>
                <tr>

                    <td colspan="4">
                        <asp:Literal ID="快遞單檔案Literal" runat="server" Visible="false"></asp:Literal>
                    </td>
                </tr>
				

			</table>
		</div>
	</div>
</div>
    </div>
<%--        <div>
                        <button class="print-link" onclick="jQuery('#printarea').print()">
            列印</button>
        </div>--%>
        <div>
                        <asp:Label ID="過重LB" runat="server" Text="" CssClass="alert-danger"></asp:Label>
                    <br />
            <asp:Button ID="Button1" runat="server" Text="列印部門快遞核准單" OnClick="Button1_Click" CssClass="btn btn-primary" />
        </div>

    </form>
</body>
</html>
