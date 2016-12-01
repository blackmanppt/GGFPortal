<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="GGFPortal.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table style="width: 100%;">
                <tr>
                    <td>
                        MIS</td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/MIS/MIS001.aspx">訂單未簽核查詢</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/MIS/MIS002.aspx">採購單未簽核查詢</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/MIS/MIS004.aspx">分機表(維護)</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/MIS/MIS005.aspx">分機表</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/test/test.aspx">test</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>財務</td>
                    <td>
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Finance/Finace001.aspx">出貨大表</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/Finance/Finance004.aspx">出貨大表(By客戶)</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Finance/TAX/TAX001.aspx">進項稅額應收結轉</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/Finance/TAX/TAX003.aspx">進項稅額應收發票</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="~/Finance/TAX/TAX004.aspx">進項稅額結轉</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink20" runat="server" NavigateUrl="~/Finance/TAX/TAX005.aspx">進項稅額批次結轉</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink21" runat="server" NavigateUrl="~/Finance/TAX/TAX005.aspx">進項稅額報表</asp:HyperLink>
                        <br />
                        
                        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Finance/TAX/TAX002.aspx">包裝底稿結轉</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Finance/Finance002.aspx">應付檢查表</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="~/Finance/Finance005.aspx">AP1查詢程式</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>秘書</td>
                    <td>
                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Secretary/Secretary001.aspx">產區表</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/Secretary/Secretary004.aspx">產區表(資料查詢)</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>船務</td>
                    <td>
                        <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/Ship/Search/Search001.aspx">應付資料搜尋</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/Ship/Search/Search002.aspx">應付資料搜尋(含已應付)</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                
                <tr>
                    <td>業務</td>
                    <td><asp:HyperLink ID="HyperLink18" runat="server" NavigateUrl="~/Sales/Sales001.aspx">訂單資料查詢</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink19" runat="server" NavigateUrl="~/Sales/SALE.aspx">樣品</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
