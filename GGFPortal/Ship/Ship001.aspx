<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ship001.aspx.cs" Inherits="GGFPortal.Ship.Ship001" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>採購單資料查詢</title>
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/style.css" rel="stylesheet" />
    <script src="../scripts/bootstrap.min.js"></script>
    <script src="../scripts/jquery-3.1.1.min.js"></script>
    <script src="../scripts/scripts.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="container-fluid ">
            <div class="row ">
                <div class="col-md-2 container-fluid ">
                    <nav class="navbar navbar-default text-success" role="navigation">
                        
                        <h3 class="text-info text-center ">採購單資料查詢
                        </h3>
                        <div class="collapse navbar-collapse bg-info text-white" id="bs-example-navbar-collapse-1">

                            <div class="form-group center-block ">
                                <h4>採購單</h4>
                                <asp:TextBox ID="PurTB" runat="server" TextMode="MultiLine"  class="form-control col-lg-5" Height="200px"></asp:TextBox>

                            </div>
                            <div class="form-group center-block">
                                <h4>款號</h4>
                                <asp:TextBox ID="款號TB" runat="server" TextMode="MultiLine"  class="form-control col-lg-5" Height="200px"></asp:TextBox>

                            </div>
                            <h4>款號模糊查詢</h4>
                            <div class="form-group">
                                <asp:TextBox ID="StyleTB" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender ID="StyleTB_AutoCompleteExtender" runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" TargetControlID="StyleTB"  ServiceMethod="SearchOrdStyle" MinimumPrefixLength="1" UseContextKey="True" >
                                </ajaxToolkit:AutoCompleteExtender>
                            </div>
                            <h4>供應商</h4>
                                <asp:TextBox ID="供應商TB" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" TargetControlID="供應商TB" ID="供應商TB_AutoCompleteExtender" ServiceMethod="Search供應商代號"  MinimumPrefixLength="1"
        CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" OnClientPopulated="Employees_Populated" FirstRowSelected="false"></ajaxToolkit:AutoCompleteExtender>
                            <div>
                                    <script type="text/javascript">
                                        function Employees_Populated(sender, e) {
                                            var employees = sender.get_completionList().childNodes;
                                            var div = "<table>";
                                            div += "<tr><th>Search</th><th>SearchName</th></tr>";
                                            for (var i = 0; i < employees.length; i++) {
 
                                                div += "<tr><td>" + employees[i].innerHTML.split(',')[0] + "</td><td>" + employees[i].innerHTML.split(',')[1]  + "</td></tr>";
                                            }
                                            div += "</table>";
                                            sender._completionListElement.innerHTML = div;
                                        }
                                    </script>
                                </div>
                            <div class="form-group">
                                <asp:CheckBox ID="主料CB" runat="server" Checked="true"  CssClass="form-control" Text="顯示主料資料"/>
                                <asp:CheckBox ID="副料CB" runat="server" Checked="true"   CssClass="form-control" Text="顯示副料資料"/>
                            </div>

                            <div class="form-group">
                            <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />
                            <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-default" OnClick="ClearBT_Click" />

                            </div>


                        </div>

                    </nav>
                </div>
                <div class="col-md-10">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Visible="False"  AsyncRendering="False" SizeToReportContent="True">
                        <LocalReport ReportPath="ReportSource\Ship\ReportShip001.rdlc" DisplayName="採購單">
                        </LocalReport>
                    </rsweb:ReportViewer>
                </div>
                <div>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="show3" runat="server" Text="show3" Style="display: none" />
                                <%--<asp:Button ID="Button1" runat="server" Text="show3" Style="display: none" />--%>
                                <asp:Panel ID="AlertPanel" runat="server" align="center" Height="100px" Width="600px" BackColor="#009999" Style="display: none">
                                    <div class=" text-center">
                                        <h3>
                                            <asp:Label ID="MessageLB" runat="server" Text=""></asp:Label>
                                           
                                        </h3>
                                        <asp:Button ID="AlertBT" runat="server" Text="確定" CssClass="btn btn-danger" />
                                    </div>
                                </asp:Panel>
                                <ajaxToolkit:ModalPopupExtender ID="AlertPanel_ModalPopupExtender" runat="server" BehaviorID="AlertPanel_ModalPopupExtender" TargetControlID="show3" PopupControlID="AlertPanel" CancelControlID="">
                                </ajaxToolkit:ModalPopupExtender>
                                
                            </ContentTemplate>
                        </asp:UpdatePanel>
            </div>
            </div>
        </div>
    </form>
</body>
</html>
