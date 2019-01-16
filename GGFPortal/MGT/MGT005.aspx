<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MGT005.aspx.cs" Inherits="GGFPortal.MGT.MGT005" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>快遞單列印</title>
    <script src="../scripts/jquery-3.1.1.min.js"></script>
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

                        簽名欄</th>
                    <th >

                        <asp:Label ID="Label1" runat="server" ></asp:Label>

                    </th>
                </tr>

                <tr>
                    <th colspan="4">
                        寄包裹超過2kg以上，需經理級批核<br />
                        寄包裹超過5kg以上，需副總級批核<br />
                        寄包裹超過10kg以上，需總經理批核<br />
                        寄包裹超過20kg以上，需董事長批核
                    </th>
                </tr>
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
<%--        <div>
                        <button class="print-link" onclick="jQuery('#printarea').print()">
            列印</button>
        </div>--%>
        <div>
            <asp:Button ID="Button1" runat="server" Text="列印" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
