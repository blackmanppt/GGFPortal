<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TAX008.aspx.cs" Inherits="GGFPortal.Finance.TAX.TAX008" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>樣品室產量月總表-款式</title>
    <link href="~/Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/style.css" rel="stylesheet" />
    <script src="~/scripts/bootstrap.min.js"></script>
    <script src="~/scripts/jquery-3.1.1.min.js"></script>
    <script src="~/scripts/scripts.js"></script>
    
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            color: #333300;
            background-color: #0099FF;
        }
        .auto-style2 {
            font-size: large;
            color: #006600;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-2">
                    <nav class="navbar navbar-default" role="navigation">
                        <h3 class="text-info text-center">應收資料結轉
                        </h3>
                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">
                            <div class="form-group">
                            <h4>結轉時間</h4>
<asp:DropDownList ID="YearDDL" runat="server" class="form-control"></asp:DropDownList>
						</div> 
                    <%--<h4>月</h4>
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
                            <h4>地區</h4>
                            <div class="form-group">
                                <asp:DropDownList ID="AreaDDL" runat="server" class="form-control">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>台北</asp:ListItem>
                                    <asp:ListItem>宜蘭</asp:ListItem>
                                    <asp:ListItem>上海</asp:ListItem>
                                    <asp:ListItem>廣州</asp:ListItem>
                                </asp:DropDownList>
                            </div>--%>
                            <div class="form-group">
                            <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />


                            </div>


                        </div>

                    </nav>
                </div>
                <div class="col-md-10">
                    <table class="table table-bordered">
            <thead>
                <tr>
                    <th colspan="4"> <h3 class="text-center">應收結轉資料</h3></th>
                </tr>
              <tr class="auto-style2">
                <th class="auto-style1">結轉月份</th>
                <th class="auto-style1">結轉款號數量</th>
                <th class="auto-style1">結轉時間</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td class="text-center">
                    <asp:Label ID="MonthLB" runat="server" Text="" ></asp:Label></td>
                <td class="text-center">
                    <asp:Label ID="StyleCountLB" runat="server" Text=""></asp:Label>
                  </td>
                <td class="text-center">
                    <asp:Label ID="CloseDateLB" runat="server" Text=""></asp:Label>
                  </td>
              </tr>
              <tr>
                <td colspan="3" class="text-center">
                                        <asp:Button ID="DeleteBT" runat="server" Text="刪除" CssClass="btn btn-default" Visible="false" />
                    <asp:Button ID="CloseBT" runat="server" Text="結轉" CssClass="btn btn-default" Visible="false" OnClick="CloseBT_Click" />
                  </td>
 
              </tr>
            <%--  <tr>
                <td>2</td>
                <td>Jacob</td>
                <td>Thornton</td>
                <td>@fat</td>
              </tr>
              <tr>
                <td>3</td>
                <td colspan="2">Larry the Bird</td>
                <td>@twitter</td>
              </tr>--%>
            </tbody>
          </table>
                    <asp:GridView ID="ACRGV" runat="server" CssClass="table table-bordered"></asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
