<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MGT003.aspx.cs" Inherits="GGFPortal.MGT.MGT003" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>快遞單列印</title>
    <script src="../scripts/jquery-3.1.1.min.js"></script>
    <script src="../scripts/scripts.js"></script>
    <script src="../scripts/jQuery.print.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" style="width:600px">
    <div id="printarea">
    <div class="container-fluid" >
	<div class="row">
		<div class="col-md-12">
			<table class="table table-bordered">
					<tr>
						<th>
							快遞廠商</th>
						<th>
							<asp:Label ID="快遞廠商LB" runat="server" Text=""></asp:Label>
						</th>
						<th>
							快遞日期</th>
						<th>
							<asp:Label ID="快遞日期LB" runat="server" Text=""></asp:Label>
                        </th>
					</tr>
				<tr>
						<th>
							提單號碼</th>
						<th>
							<asp:Label ID="提單號碼LB" runat="server" Text=""></asp:Label>
						</th>
						<th>
							快遞編號</th>
						<th>
							<asp:Label ID="快遞編號LB" runat="server" Text=""></asp:Label>
                        </th>
					</tr>
                					<tr>
						<th>寄件人
							</th>
						<th>
							<asp:Label ID="寄件人LB" runat="server" Text=""></asp:Label>
                                        </th>
						<th>
							name</th>
						<th>
							<asp:Label ID="英文名LB" runat="server" Text=""></asp:Label>
                                        </th>
					</tr>
                <tr>
						<th>送件目的地
							</th>
						<th>
							<asp:Label ID="送件地點LB" runat="server" Text=""></asp:Label>
                                        </th>
						<th>
							收件人</th>
						<th>
							<asp:Label ID="收件人LB" runat="server" Text=""></asp:Label>
                                        </th>
					</tr>
					<tr class="active">
						<th>
							明細</th>
						<th colspan="3">
                            <asp:Label ID="明細LB" runat="server" Text=""></asp:Label></th>

					</tr>
<%--					<tr class="success">
						<td>
							&nbsp;</td>
						<td>
							&nbsp;</td>
						<td>
							&nbsp;</td>
						<td>
							&nbsp;</td>
					</tr>
					<tr class="warning">
						<td>
							&nbsp;</td>
						<td>
							&nbsp;</td>
						<td>
							&nbsp;</td>
						<td>
							&nbsp;</td>
					</tr>
					<tr class="danger">
						<td>
							&nbsp;</td>
						<td>
							&nbsp;</td>
						<td>
							&nbsp;</td>
						<td>
							&nbsp;</td>
					</tr>--%>
                <tr>
                    <td colspan="4">
                        <asp:Literal ID="快遞單檔案Literal" runat="server"></asp:Literal>
                    </td>
                </tr>
				

			</table>
		</div>
	</div>
</div>
    </div>
        <div>
                        <button class="print-link" onclick="jQuery('#printarea').print()">
            列印</button>
        </div>
    </form>
</body>
</html>
