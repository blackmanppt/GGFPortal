<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Findex.aspx.cs" Inherits="GGFPortal.FactoryMG.Findex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/style.css" rel="stylesheet" />
    <script src="../scripts/jquery-3.1.1.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
    <script src="../scripts/scripts.js"></script>
    <style type="text/css">
        .auto-style2 {
            width: 85px;
            background-color: #00CCFF;
        }
table, td, th {
    border: 1px solid black;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-light navbar-dark bg-dark">
				 
				<button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
					<span class="navbar-toggler-icon"></span>
				</button> <a class="navbar-brand" href="#">Brand</a>
				<div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
					<ul class="navbar-nav">
						<li class="nav-item active">
							 <a class="nav-link" href="#">Link <span class="sr-only">(current)</span></a>
						</li>
						<li class="nav-item">
							 <a class="nav-link" href="#">Link</a>
						</li>
						<li class="nav-item dropdown">
							 <a class="nav-link dropdown-toggle" href="http://example.com" id="navbarDropdownMenuLink" data-toggle="dropdown">Dropdown link</a>
							<div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
								 <a class="dropdown-item" href="#">Action</a> <a class="dropdown-item" href="#">Another action</a> <a class="dropdown-item" href="#">Something else here</a>
								<div class="dropdown-divider">
								</div> <a class="dropdown-item" href="#">Separated link</a>
							</div>
						</li>
					</ul>
					<form class="form-inline">
						<input class="form-control mr-sm-2" type="text"> 
						<button class="btn btn-primary my-2 my-sm-0" type="submit">
							Search
						</button>
					</form>
					<ul class="navbar-nav ml-md-auto">
						<li class="nav-item active">
							 <a class="nav-link" href="#">Link <span class="sr-only">(current)</span></a>
						</li>
						<li class="nav-item dropdown">
							 <a class="nav-link dropdown-toggle" href="http://example.com" id="navbarDropdownMenuLink" data-toggle="dropdown">Dropdown link</a>
							<div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdownMenuLink">
								 <a class="dropdown-item" href="#">Action</a> <a class="dropdown-item" href="#">Another action</a> <a class="dropdown-item" href="#">Something else here</a>
								<div class="dropdown-divider">
								</div> <a class="dropdown-item" href="#">Separated link</a>
							</div>
						</li>
					</ul>
				</div>
			</nav>
        <div class="row text-center">
            <div class=" col-lg-12">
                <div class="h2">test</div>
            </div>
        </div>
        <div class="row">
            <div class=" col-md-2"></div>
            <div class=" col-md-10"></div>
        </div>
        <div class=" row table table-bordered">
            <div class=" col-md-3 "><asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/VN/VN002.aspx?AREA=VGG&TYPE=Cut" CssClass="btn btn-primary btn-lg active">裁剪</asp:LinkButton><br/></div>
            <div class=" col-md-3">2</div>
            <div class=" col-md-3">3</div>
            <div class=" col-md-3">4</div>
        </div>
    <div>
   
        <table style="width:400px;">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="資料查詢："></asp:Label>
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton6" runat="server" PostBackUrl="~/VN/VN001.aspx">Style No 查詢</asp:LinkButton>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="資料匯入："></asp:Label>
                </td>
                <td>
                    
                    <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/VN/VN002.aspx?AREA=VGG&TYPE=Stitch">車縫</asp:LinkButton><br/>
                    <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/VN/VN002.aspx?AREA=VGG&TYPE=QC">品檢</asp:LinkButton><br/>
                    <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/VN/VN002.aspx?AREA=VGG&TYPE=Iron">整燙</asp:LinkButton><br/>
                    <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="~/VN/VN002.aspx?AREA=VGG&TYPE=Package">包裝</asp:LinkButton>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
            <td class="auto-style2">
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
   
    </div>
    </form>
</body>
</html>
