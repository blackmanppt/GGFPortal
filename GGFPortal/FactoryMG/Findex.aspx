<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Findex.aspx.cs" Inherits="GGFPortal.FactoryMG.Findex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../scripts/jquery-3.4.1.min.js"></script>
    <script src="../scripts/bootstrap-4.3.1/site/docs/4.3/examples/dashboard/dashboard.js"></script>
    <link href="../scripts/bootstrap-4.3.1/site/docs/4.3/examples/dashboard/dashboard.css" rel="stylesheet" />
    <script src="../scripts/bootstrap-4.3.1/dist/js/bootstrap.min.js"></script>
    <link href="../scripts/bootstrap-4.3.1/dist/css/bootstrap.min.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server" class="container ">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>

        <table class="table table-secondary m-2">
            <tr>
                <th class="h3 text-center" colspan="2">
                    
                    <asp:Label ID="TitleLB" runat="server" Text="Program" CssClass=""></asp:Label>
                </th>
            </tr>
            <tr class="row m-1">
                <th class=" text-right col-3">
                    <asp:Label ID="Label3" runat="server" Text="Area："></asp:Label>
                </th>
                <td class="  col-9">
                    <asp:DropDownList ID="FactoryDDL" runat="server" CssClass="dropdown dropdown-toggle-split bg-light form-control-sm" AutoPostBack="True" OnSelectedIndexChanged="FactoryDDL_SelectedIndexChanged">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem >VGG</asp:ListItem>
                        <asp:ListItem>GAMA</asp:ListItem>
                        <asp:ListItem>TW</asp:ListItem>

                    </asp:DropDownList>

                </td>

            </tr>
            <tr class="row m-1 ">
                <th class=" text-right col-3">
                    <asp:Label ID="Label2" runat="server" Text="Style Search："></asp:Label>
                </th>
                <td class="  col-9">
                    <asp:Button ID="StyleBT" runat="server" Text="Style Search" CssClass="btn btn-primary" OnClick="StyleBT_Click" />
                </td>

            </tr>
            <tr class="row  m-1">
                <th class="text-right col-3">
                    <asp:Label ID="Label1" runat="server" Text="Data Import："></asp:Label>
                </th>
                <td class="col-9">
                    <div class="btn-group">
                        <asp:Button ID="StitchBT" runat="server" Text="" CssClass="btn btn-primary" Visible="false" OnClick="StitchBT_Click" />
                        <asp:Button ID="PackageBT" runat="server" Text="" CssClass="btn btn-secondary" Visible="false" OnClick="PackageBT_Click" />
                        <asp:Button ID="CutBT" runat="server" Text="" CssClass="btn btn-primary" Visible="false" OnClick="CutBT_Click"/>
                        <asp:Button ID="IronBT" runat="server" Text="" CssClass="btn  btn-secondary" Visible="false" OnClick="IronBT_Click"/>
                        <asp:Button ID="QCBT" runat="server" Text="" CssClass="btn btn-primary" Visible="false" OnClick="QCBT_Click"/>
                    </div>
                </td>

            </tr>
            <tr class=" m-1">
                <th class="text-right col-3 " rowspan="6">
                    <asp:Label ID="Label4" runat="server" Text="Report:"></asp:Label>
                </th>
                <td class="col-9">
                    005
                    <asp:Button ID="ImportLogSearchBT" runat="server"  CssClass="btn btn-primary" OnClick="ImportLogSearchBT_Click" />
                    <br />
                    007
                    <asp:Button ID="ImportDataSearchBT" runat="server"  CssClass="btn btn-primary" OnClick="ImportDataSearchBT_Click" />
                    <br />
                    008
                    <asp:Button ID="MonthTimeSumBT" runat="server"  CssClass="btn btn-primary" OnClick="MonthTimeSumBT_Click" />
                    <br />
                    010
                    <asp:Button ID="TeamQtyBT" runat="server"  CssClass="btn btn-primary" OnClick="TeamQtyBT_Click" />
                    <br />
                    011
                    <asp:Button ID="TeamCMBT" runat="server"  CssClass="btn btn-primary" OnClick="TeamCMBT_Click" />
                    <br />
                    012越南明細表(秒數)
                    <asp:Button ID="TimeSecBT" runat="server"  CssClass="btn btn-primary" OnClick="TimeSecBT_Click" />
                    <br />
                    013越南明細表(各組秒數)
                    <asp:Button ID="TimeSecTeamBT" runat="server"  CssClass="btn btn-primary" OnClick="TimeSecTeamBT_Click" />
                    </td>

            </tr>
            <tr class="m-1">

                <td class="col-9">
                    006
                    <asp:Button ID="ImportLogSearchDeleteBT" runat="server"  CssClass="btn btn-primary" />
                    <br />
                    VNProductivityManagement
                    <asp:Button ID="ImportLock" runat="server"  CssClass="btn btn-primary" />
                    </td>

            </tr>
            <tr class="m-1">

                <td class="col-9">
                    <asp:Button ID="Button3" runat="server" Text="Button" />
                    </td>

            </tr>

        </table>

                <div>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:Button ID="show3" runat="server" Text="show3" Style="display: none" />
                    <asp:Panel ID="AlertPanel" runat="server" align="center" Height="100px" Width="600px" BackColor="#009999" Style="display: none">
                        <div class=" text-center">
                            <h3>
                                <asp:Label ID="MessageLB" runat="server" Text=""></asp:Label>

                            </h3>
                            <asp:Button ID="AlertBT" runat="server" Text="OK" CssClass="btn btn-danger" />
                        </div>
                    </asp:Panel>
                    <ajaxToolkit:ModalPopupExtender ID="AlertPanel_ModalPopupExtender" runat="server" BehaviorID="AlertPanel_ModalPopupExtender" TargetControlID="show3" PopupControlID="AlertPanel" CancelControlID="">
                    </ajaxToolkit:ModalPopupExtender>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </form>
</body>
</html>
