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
        <div class="box box-element ui-draggable" style="">
  	<a href="#close" class="remove badge badge-danger"><svg class="svg-inline--fa fa-times fa-w-12" aria-hidden="true" data-prefix="fas" data-icon="times" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 384 512" data-fa-i2svg=""><path fill="currentColor" d="M323.1 441l53.9-53.9c9.4-9.4 9.4-24.5 0-33.9L279.8 256l97.2-97.2c9.4-9.4 9.4-24.5 0-33.9L323.1 71c-9.4-9.4-24.5-9.4-33.9 0L192 168.2 94.8 71c-9.4-9.4-24.5-9.4-33.9 0L7 124.9c-9.4 9.4-9.4 24.5 0 33.9l97.2 97.2L7 353.2c-9.4 9.4-9.4 24.5 0 33.9L60.9 441c9.4 9.4 24.5 9.4 33.9 0l97.2-97.2 97.2 97.2c9.3 9.3 24.5 9.3 33.9 0z"></path></svg><!-- <i class="fas fa-times"></i> --> remove</a>
	<span class="drag badge badge-default ui-draggable-handle ui-sortable-handle"><svg class="svg-inline--fa fa-arrows-alt fa-w-16" aria-hidden="true" data-prefix="fas" data-icon="arrows-alt" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" data-fa-i2svg=""><path fill="currentColor" d="M352.201 425.775l-79.196 79.196c-9.373 9.373-24.568 9.373-33.941 0l-79.196-79.196c-15.119-15.119-4.411-40.971 16.971-40.97h51.162L228 284H127.196v51.162c0 21.382-25.851 32.09-40.971 16.971L7.029 272.937c-9.373-9.373-9.373-24.569 0-33.941L86.225 159.8c15.119-15.119 40.971-4.411 40.971 16.971V228H228V127.196h-51.23c-21.382 0-32.09-25.851-16.971-40.971l79.196-79.196c9.373-9.373 24.568-9.373 33.941 0l79.196 79.196c15.119 15.119 4.411 40.971-16.971 40.971h-51.162V228h100.804v-51.162c0-21.382 25.851-32.09 40.97-16.971l79.196 79.196c9.373 9.373 9.373 24.569 0 33.941L425.773 352.2c-15.119 15.119-40.971 4.411-40.97-16.971V284H284v100.804h51.23c21.382 0 32.09 25.851 16.971 40.971z"></path></svg><!-- <i class="fas fa-arrows-alt"></i> --> drag</span>
	<span class="configuration">
  <span class="btn-group btn-group-sm">
	<a class="btn btn-default dropdown-toggle" data-toggle="dropdown" href="#">Position <span class="caret"></span></a>
	<div class="dropdown-menu">
				<a href="#" class="dropdown-item" rel="">Default</a>
				<a href="#" class="dropdown-item" rel="static-top">Static top</a>
				<a href="#" class="dropdown-item" rel="fixed-top">Navbar fixed top</a>
				<a href="#" class="dropdown-item" rel="fixed-bottom">Navbar fixed bottom</a>
			</div>
</span>
		<a class="btn btn-sm btn-secondary active" href="#" rel="navbar-dark bg-dark">Navbar Dark</a>
		<!--a class="btn btn-xs btn-default" href="#" rel="navbar-static-top">Static top</a>
		<a class="btn btn-mini" href="#" rel="navbar-fixed-top">Navbar fixed top</a>
		<a class="btn btn-mini" href="#" rel="navbar-fixed-bottom">Navbar fixed bottom</a-->
	</span>
	<div class="preview">Navbar</div>
	<div class="view">
    <nav class="navbar navbar-expand-lg navbar-light bg-light navbar-dark bg-dark">
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-controls="bs-example-navbar-collapse-1" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <a class="navbar-brand" href="#">Brand</a>
      <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
        <ul class="navbar-nav">
          <li class="nav-item active">
            <a class="nav-link" href="#">Link <span class="sr-only">(current)</span></a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#">Link</a>
          </li>
          <li class="nav-item dropdown">
            <a class="nav-link dropdown-toggle" href="http://example.com" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
              Dropdown link
            </a>
            <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
              <a class="dropdown-item" href="#">Action</a>
              <a class="dropdown-item" href="#">Another action</a>
              <a class="dropdown-item" href="#">Something else here</a>
              <div class="dropdown-divider"></div>
              <a class="dropdown-item" href="#">Separated link</a>
            </div>
          </li>
        </ul>
        <form class="form-inline">
          <input class="form-control mr-sm-2" type="text" placeholder="Search">
          <button class="btn btn-primary my-2 my-sm-0" type="submit">Search</button>
        </form>
        <ul class="navbar-nav ml-md-auto">
          <li class="nav-item active">
            <a class="nav-link" href="#">Link <span class="sr-only">(current)</span></a>
          </li>
          <li class="nav-item dropdown">
            <a class="nav-link dropdown-toggle" href="http://example.com" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
              Dropdown link
            </a>
            <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdownMenuLink">
              <a class="dropdown-item" href="#">Action</a>
              <a class="dropdown-item" href="#">Another action</a>
              <a class="dropdown-item" href="#">Something else here</a>
              <div class="dropdown-divider"></div>
              <a class="dropdown-item" href="#">Separated link</a>
            </div>
          </li>
        </ul>
      </div>
    </nav>
	</div>
</div>
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
