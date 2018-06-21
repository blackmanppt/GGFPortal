<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sales009.aspx.cs" Inherits="GGFPortal.Sales.Sales009" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>LF檔案轉檔</title>
    <script src="../scripts/jquery-3.1.1.min.js"></script>
    <script src="../scripts/scripts.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-2">
                </div>
                <div class="col-md-8">
                    <h2>XML轉檔程式</h2>
                    <div>
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control-file" />
                        

                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="card mb-4 box-shadow">
                                <img class="card-img-top" src="IMG/Screenshot_9.png" />
                                <div class="card-body">
                                    <p class="card-text">尺寸表格式</p>
                                    <div class="d-flex justify-content-between align-items-center">
                                        <div class="btn-group">
                                            <asp:Button ID="Button1" runat="server" Text="轉檔" CssClass="btn btn-group" OnClick="Button1_Click" />
                                        </div>
                                        <small class="text-muted">9 mins</small>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="card mb-4 box-shadow">
                                <img class="card-img-top" src="IMG/Screenshot_9.png"  />
                                <div class="card-body">
                                    <p class="card-text">明細格式</p>
                                    <div class="d-flex justify-content-between align-items-center">
                                        <div class="btn-group">
                                            <asp:Button ID="Button2" runat="server" Text="轉檔二" class="btn btn-sm btn-outline-secondary" OnClick="Button2_Click" />
                                        </div>
                                        <small class="text-muted">9 mins</small>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="show3" runat="server" Text="show3" Style="display: none" />
                                <asp:Panel ID="AlertPanel" runat="server" align="center" Height="100px" Width="600px" BackColor="#0099FF" Style="display: none">
                                    <div class=" text-center">
                                        <h3>
                                            <asp:Label ID="MessageLB" runat="server" Text=""></asp:Label>

                                        </h3>
                                        <asp:Button ID="AlertBT" runat="server" Text="確定" CssClass="btn btn-warning" />
                                    </div>
                                </asp:Panel>
                                <ajaxToolkit:ModalPopupExtender ID="AlertPanel_ModalPopupExtender" runat="server" BehaviorID="AlertPanel_ModalPopupExtender" TargetControlID="show3" PopupControlID="AlertPanel" CancelControlID="">
                                </ajaxToolkit:ModalPopupExtender>

                            </ContentTemplate>

                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="col-md-2">
                </div>
            </div>
        </div>
    </form>
</body>
</html>
