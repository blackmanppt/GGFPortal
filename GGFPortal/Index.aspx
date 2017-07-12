<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="GGFPortal.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
table {
    border-collapse: collapse;
}

table, td, th {
    border: 2px solid black;
}
        .auto-style1 {
            text-align: right;
            background-color: #00CCFF;
        }
        .auto-style2 {
            color: #00CC66;
            font-weight: bold;
            text-align: right;
            background-color: #3333FF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table style="width: 100%;">
                <tr>
                    <td class="auto-style1">
                        MIS</td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/MIS/MIS001.aspx">訂單未簽核查詢</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/MIS/MIS002.aspx">採購單未簽核查詢</asp:HyperLink>
                        <br />
                 <%--       <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/MIS/MIS004.aspx">分機表(維護)</asp:HyperLink>--%>
                        <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/MIS/MIS005.aspx">分機表</asp:HyperLink>
                                                <br />
                    </td>
                    <td class="auto-style2">
                        測試區：</td>
                    <td>
                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/test/test.aspx">test</asp:HyperLink>
                        <br />
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                        <br />
                        <asp:HyperLink ID="HyperLink24" runat="server" NavigateUrl="~/test/ExcelUpload.aspx">Excel上傳</asp:HyperLink>
                        <br />
                        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/test/WebForm1.aspx">CrystalReporttest</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">財務</td>
                    <td>
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Finance/Finace001.aspx">出貨大表</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/Finance/Finance004.aspx">出貨大表(By客戶)</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Finance/Finance002.aspx">應付檢查表</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="~/Finance/Finance005.aspx">AP1查詢程式</asp:HyperLink>
                                                <br />
                        <asp:HyperLink ID="HyperLink22" runat="server" NavigateUrl="~/Finance/Finance007.aspx">出口大表(BY CATHY)</asp:HyperLink>
                                                <br />
                        <asp:HyperLink ID="HyperLink26" runat="server" NavigateUrl="~/Finance/Finance009.aspx">出口大表(BY Ariel)</asp:HyperLink>
                                                <br />
                        <asp:HyperLink ID="HyperLink40" runat="server" NavigateUrl="~/Finance/Finance011.aspx">出口大表(BY Carrie)</asp:HyperLink>
                    </td>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td>
                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Finance/TAX/TAX001.aspx">進項稅額應收結轉</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/Finance/TAX/TAX003.aspx">進項稅額應收發票</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="~/Finance/TAX/TAX004.aspx">進項稅額結轉</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink20" runat="server" NavigateUrl="~/Finance/TAX/TAX005.aspx">進項稅額批次結轉</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink21" runat="server" NavigateUrl="~/Finance/TAX/TAX006.aspx">進項稅額調整</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Finance/TAX/TAX007.aspx">進項稅額報表</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Finance/TAX/TAX002.aspx">包裝底稿結轉</asp:HyperLink>
                        <br />
                        </td>
                </tr>
                <tr>
                    <td class="auto-style1">秘書</td>
                    <td>
                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Secretary/Secretary001.aspx">產區表</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/Secretary/Secretary004.aspx">產區表(資料查詢)</asp:HyperLink>
                    </td>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">船務</td>
                    <td>
                        <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/Ship/Search/Search001.aspx">應付資料搜尋</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/Ship/Search/Search002.aspx">應付資料搜尋(含已應付)</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink25" runat="server" NavigateUrl="~/Finance/Finance008.aspx">出口大表(BY CATHY2)</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink29" runat="server" NavigateUrl="~/Ship/Search/Search003.aspx">採購入庫狀況</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink30" runat="server" NavigateUrl="~/Ship/Search/Search004.aspx">包裝底稿狀況查詢</asp:HyperLink>
                    </td>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                
                <tr>
                    <td class="auto-style1">業務</td>
                    <td><asp:HyperLink ID="HyperLink18" runat="server" NavigateUrl="~/Sales/Sales001.aspx">訂單資料查詢</asp:HyperLink>
                                                <br />
                        <asp:HyperLink ID="HyperLink23" runat="server" NavigateUrl="~/Sales/Sales002.aspx">業績表</asp:HyperLink>
                                                                        <br />
                        <asp:HyperLink ID="HyperLink46" runat="server" NavigateUrl="~/Sales/Sales003.aspx">實際訂單查詢表(部門群組)</asp:HyperLink>
                                                                                                <br />
                        <asp:HyperLink ID="HyperLink47" runat="server" NavigateUrl="~/Sales/Sales004.aspx">實際訂單查詢表(明細)</asp:HyperLink>
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <th class="auto-style1">

                        <asp:Label ID="Label1" runat="server" Text="打樣室"></asp:Label>

                    </th>
                    <td>
                        <asp:HyperLink ID="HyperLink19" runat="server" NavigateUrl="~/Sales/SALE.aspx">樣品</asp:HyperLink>
                                                <br />
                                                <asp:HyperLink ID="HyperLink28" runat="server" NavigateUrl="~/Sales/SALE_V2.aspx">樣品_2</asp:HyperLink>
                                                <br />
                        <asp:HyperLink ID="HyperLink31" runat="server" NavigateUrl="~/Sales/SALE_V3.aspx">樣品_3</asp:HyperLink>
                                                <br />
                                                <asp:HyperLink ID="HyperLink32" runat="server" NavigateUrl="~/Sales/SALE_V4.aspx">樣品_4</asp:HyperLink>
                        <br />
                                                <asp:HyperLink ID="HyperLink37" runat="server" NavigateUrl="~/Sales/SALE_V5.aspx">打樣收單</asp:HyperLink>
                                                <br />
                                                <asp:HyperLink ID="HyperLink35" runat="server" NavigateUrl="~/Sales/Sample001.aspx">打樣打版資料上傳</asp:HyperLink>
                                                                        <br />
                                                <asp:HyperLink ID="HyperLink38" runat="server" NavigateUrl="~/Sales/Sample003.aspx">打版資料查詢</asp:HyperLink>
                                                                                                <br />
                                                <asp:HyperLink ID="HyperLink41" runat="server" NavigateUrl="~/Sales/Sample004.aspx">樣品室產量月總表</asp:HyperLink>
                                                                                                <br />
                                                <asp:HyperLink ID="HyperLink42" runat="server" NavigateUrl="~/Sales/Sample005.aspx">樣品室產量月總表-客戶</asp:HyperLink>
                                                                                                <br />
                                                <asp:HyperLink ID="HyperLink43" runat="server" NavigateUrl="~/Sales/Sample006.aspx">樣品室產量月總表-款式</asp:HyperLink>
                                                                                                <br />
                                                <asp:HyperLink ID="HyperLink44" runat="server" NavigateUrl="~/Sales/Sample007.aspx">樣品室產量月總表-處理人員</asp:HyperLink>
                                                </td>
                    <th  class="auto-style2">

                        &nbsp;</th>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">越南</td>
                    <td>
                        <asp:HyperLink ID="HyperLink27" runat="server" NavigateUrl="~/VN/VNindex.aspx">越南首頁</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink33" runat="server" NavigateUrl="~/VN/VN005.aspx">越南工時匯入紀錄(越文版)</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink34" runat="server" NavigateUrl="~/VN/VN006.aspx">越南工時匯入紀錄(中文版含刪除資料功能)</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink36" runat="server" NavigateUrl="~/VN/VN007.aspx">越南工時匯入明細</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink45" runat="server" NavigateUrl="~/VN/VN008.aspx">越南工時成本</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink39" runat="server" NavigateUrl="~/VN/VNProductivityManagement.aspx">越南工時匯入鎖定</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink48" runat="server" NavigateUrl="~/VN/VN010.aspx">越南款號各組數量</asp:HyperLink>
                    </td>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
