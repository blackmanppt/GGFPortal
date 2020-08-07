<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="GGFPortal.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
        <script src="scripts/jquery-3.1.1.min.js"></script>
    <script src="scripts/scripts.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/style.css" rel="stylesheet" />
    
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

            <table style="width: 100%;" class="table table-hover">
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
                        <asp:HyperLink ID="HyperLink57" runat="server" NavigateUrl="~/MIS/MIS006.aspx">訂單簽核查詢(新版)</asp:HyperLink>
                                                <br />
                        <asp:HyperLink ID="HyperLink76" runat="server" NavigateUrl="~/MIS/MIS007.aspx">採購單核准</asp:HyperLink>
                                                                        <br />
                        <asp:HyperLink ID="HyperLink81" runat="server" NavigateUrl="~/MIS/MIS009.aspx">廠商交易資料查詢</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink85" runat="server" NavigateUrl="~/MIS/site/site4F.aspx">4F座位表</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink86" runat="server" NavigateUrl="~/MIS/site/site5F.aspx">5F座位表</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink87" runat="server" NavigateUrl="~/MIS/site/site6F.aspx">6F座位表</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink88" runat="server" NavigateUrl="~/MIS/site/site9F.aspx">9F座位表</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink89" runat="server" NavigateUrl="~/MIS/site/site10.aspx">10F座位表</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink90" runat="server" NavigateUrl="~/MIS/site/site12F.aspx">12F座位表</asp:HyperLink>
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
                        <asp:HyperLink ID="HyperLink40" runat="server" NavigateUrl="~/Finance/Finance011.aspx">出口大表(BY Carrie)(客戶查詢)</asp:HyperLink>
                                                <br />
                        <asp:HyperLink ID="HyperLink49" runat="server" NavigateUrl="~/Finance/Finance012.aspx">銷貨資料(BY Carrie)</asp:HyperLink>
                                                                        <br />
                        <asp:HyperLink ID="HyperLink56" runat="server" NavigateUrl="~/Finance/Finance013.aspx">出貨短出資料對照</asp:HyperLink>
                         <br />
                        <asp:HyperLink ID="HyperLink68" runat="server" NavigateUrl="~/Finance/Finance014.aspx">預計到貨毛利-查詢</asp:HyperLink>
                                                 <br />
                        <asp:HyperLink ID="HyperLink74" runat="server" NavigateUrl="~/Finance/Finance015.aspx">文件實際上傳日-查詢</asp:HyperLink>
                                                 <br />
                        <asp:HyperLink ID="HyperLink102" runat="server" NavigateUrl="~/Finance/Finance016.aspx">匯率上傳</asp:HyperLink>
                                                                         <br />
                        <asp:HyperLink ID="HyperLink120" runat="server" NavigateUrl="~/Finance/Finance019.aspx">越南成品入庫查詢</asp:HyperLink>
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
                                                <asp:HyperLink ID="HyperLink69" runat="server" NavigateUrl="~/Secretary/Secretary001V2.aspx">產區表(新版)</asp:HyperLink>
                        <br />
                                                                        <asp:HyperLink ID="HyperLink71" runat="server" NavigateUrl="~/Secretary/Secretary001V3.aspx">產區表(多資料組合版)</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink72" runat="server" NavigateUrl="~/Secretary/Secretary001V4.aspx">產區表(多資料組合版無產量月份顯示)</asp:HyperLink>
                                                <br />
                        <asp:HyperLink ID="HyperLink99" runat="server" NavigateUrl="~/Secretary/Secretary001V5.aspx">產區表(多資料組合版無產量月份含出貨單資料)</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/Secretary/Secretary004.aspx">產區表(資料查詢)</asp:HyperLink>
                        <br />
<%--                        <asp:HyperLink ID="HyperLink63" runat="server" NavigateUrl="~/Secretary/Secretary006.aspx">產區表資料</asp:HyperLink>
                                                <br />--%>
                        <asp:HyperLink ID="HyperLink73" runat="server" NavigateUrl="~/Secretary/Secretary007.aspx">工時IE對應表</asp:HyperLink>
                                                                        <br />
                        <asp:HyperLink ID="HyperLink80" runat="server" NavigateUrl="~/Secretary/Secretary008.aspx">訂單明細</asp:HyperLink>
                                                                                                <br />
                        <asp:HyperLink ID="HyperLink117" runat="server" NavigateUrl="~/Secretary/Secretary009.aspx">產區表含明細</asp:HyperLink>
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
                        <br />
                        <asp:HyperLink ID="HyperLink51" runat="server" NavigateUrl="~/Ship/Ship001.aspx">採購單狀況查詢</asp:HyperLink>
                                                <br />
                        <asp:HyperLink ID="HyperLink58" runat="server" NavigateUrl="~/Ship/Ship002.aspx">客戶訂單轉Excel查詢(查詢多單價) </asp:HyperLink>
                         <br />
                        <asp:HyperLink ID="HyperLink61" runat="server" NavigateUrl="~/Ship/Ship003.aspx">客戶訂單轉Excel查詢(多條件查詢) </asp:HyperLink>
                         <br />
                        <asp:HyperLink ID="HyperLink75" runat="server" NavigateUrl="~/Ship/Ship004.aspx">櫃號相關資料-查詢 </asp:HyperLink>
                                                 <br />
                        <asp:HyperLink ID="HyperLink79" runat="server" NavigateUrl="~/Ship/Ship005.aspx">出口大表(BOSS/設計師) </asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink100" runat="server" NavigateUrl="~/Ship/Ship006.aspx">入庫暫估應付比較表 </asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink101" runat="server" NavigateUrl="~/Ship/Ship007.aspx">採購入庫狀況V2 </asp:HyperLink>
                                                <br />
                        <asp:HyperLink ID="HyperLink119" runat="server" NavigateUrl="~/Ship/Ship008.aspx">訂單多單價 </asp:HyperLink>
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
                                                                                                                        <br />
                        <asp:HyperLink ID="HyperLink50" runat="server" NavigateUrl="~/Sales/Sales005.aspx">銷貨資料(BOSS)</asp:HyperLink>
                                                                                                                        <br />
                        <asp:HyperLink ID="HyperLink70" runat="server" NavigateUrl="~/Sales/Sales006.aspx">出口統計表</asp:HyperLink>
                                                                                                                                                <br />
                        <asp:HyperLink ID="HyperLink77" runat="server" NavigateUrl="~/Sales/Sales007.aspx">訂單預估毛利成本(Sales)</asp:HyperLink>
                                                                                                                                                <br />
                        <asp:HyperLink ID="HyperLink78" runat="server" NavigateUrl="~/Sales/Sales008.aspx">訂單小圖</asp:HyperLink>                        
                                                                                                                                                                        <br />
                        <asp:HyperLink ID="HyperLink82" runat="server" NavigateUrl="~/Sales/Sales010.aspx">採購料號查詢</asp:HyperLink>                        
                                                                                                                                                                                                <br />
                        <asp:HyperLink ID="HyperLink92" runat="server" NavigateUrl="~/Sales/Sales011.aspx">AMZ Forecast匯入</asp:HyperLink>                        
                        <br />
                        <asp:HyperLink ID="HyperLink93" runat="server" NavigateUrl="~/Sales/Sales012.aspx">AMZ Forecast報表</asp:HyperLink>                        
                        <br />
                        <asp:HyperLink ID="HyperLink95" runat="server" NavigateUrl="~/Sales/Sales013.aspx">CRP排程表</asp:HyperLink>                        
                        <br />
                        <asp:HyperLink ID="HyperLink97" runat="server" NavigateUrl="~/Sales/Sales014V2.aspx">訂單工廠樣品單產區表</asp:HyperLink>                        

                        <br />
                        <asp:HyperLink ID="HyperLink96" runat="server" NavigateUrl="~/Sales/Sales014.aspx">訂單工廠樣品單產區表(三旬版)</asp:HyperLink>                        
                                                <br />
                        <asp:HyperLink ID="HyperLink98" runat="server" NavigateUrl="~/Sales/Sales015.aspx">訂單工廠樣品單產區表(明細)</asp:HyperLink>                        
                                                <br />
                        <asp:HyperLink ID="HyperLink63" runat="server" NavigateUrl="~/Sales/Sales017.aspx">訂單樣衣到料上傳</asp:HyperLink> 
                                                                        <br />
                        <asp:HyperLink ID="HyperLink106" runat="server" NavigateUrl="~/Sales/Sales018.aspx">訂單樣衣完工上傳</asp:HyperLink> 
                        <br />
                        <asp:HyperLink ID="HyperLink107" runat="server" NavigateUrl="~/Sales/Sales016.aspx">布價歷史資料查詢</asp:HyperLink> 
                                                                                                <br />
                        <asp:HyperLink ID="HyperLink118" runat="server" NavigateUrl="~/Sales/Sales019.aspx">DDP費用</asp:HyperLink> 
                         <br />
                        <asp:HyperLink ID="HyperLink121" runat="server" NavigateUrl="~/Sales/Sales020.aspx">品牌產量表</asp:HyperLink> 
                                                 <br />
                        <asp:HyperLink ID="HyperLink122" runat="server" NavigateUrl="~/Sales/Sales021.aspx">德永佳採購單匯出</asp:HyperLink> 
                                                                         <br />
                        <asp:HyperLink ID="HyperLink123" runat="server" NavigateUrl="~/Sales/Sales022.aspx">採購單入庫量查詢</asp:HyperLink> 
                         <br />
                        <asp:HyperLink ID="HyperLink124" runat="server" NavigateUrl="~/Sales/Sales023.aspx">庫存調撥單查詢</asp:HyperLink> 
                                                 <br />
                        <asp:HyperLink ID="HyperLink125" runat="server" NavigateUrl="~/Sales/Sales024.aspx">AMZ資料上傳</asp:HyperLink> 
                        <br />
                        <asp:HyperLink ID="HyperLink127" runat="server" NavigateUrl="~/Sales/Sales025.aspx">AMZ資料匯出</asp:HyperLink> 
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
                                                                                                                        <br />
                                                <asp:HyperLink ID="HyperLink55" runat="server" NavigateUrl="~/Sales/Sample009.aspx">樣品室產量月總表-馬克處理人員</asp:HyperLink>
                         <br />
                                                <asp:HyperLink ID="HyperLink62" runat="server" NavigateUrl="~/Sales/Sample010.aspx">打樣收單查詢(BY 款號)</asp:HyperLink>
                        <br />
                                                <asp:HyperLink ID="HyperLink83" runat="server" NavigateUrl="~/Sales/Sample011.aspx">樣品室產量月總表-處理人員(打版日期)</asp:HyperLink>
                        <br />
                                                <asp:HyperLink ID="HyperLink103" runat="server" NavigateUrl="~/Sales/Sample012.aspx">打版完成資料查詢</asp:HyperLink>
                                                <br />
                                                <asp:HyperLink ID="HyperLink104" runat="server" NavigateUrl="~/Sales/Sample013.aspx">打版資料查詢</asp:HyperLink>
                                                <br />
                                                <asp:HyperLink ID="HyperLink105" runat="server" NavigateUrl="~/Sales/Sample014.aspx">打版資料明細查詢</asp:HyperLink>
                                                                        <br />
                                                <asp:HyperLink ID="HyperLink108" runat="server" NavigateUrl="~/Sales/Sample015.aspx">打版完成日快速上傳</asp:HyperLink>
                                                                        <br />
                                                <asp:HyperLink ID="HyperLink109" runat="server" NavigateUrl="~/Sales/Sample016.aspx">打樣收單(河內)</asp:HyperLink>

                                                <br />
                        <asp:HyperLink ID="HyperLink111" runat="server" NavigateUrl="~/Sales/Sample018.aspx">樣品單主副料收單</asp:HyperLink>
                                                                        <br />
                        <asp:HyperLink ID="HyperLink112" runat="server" NavigateUrl="~/Sales/Sample017.aspx">版師借出</asp:HyperLink>
                                                                                                <br />
                        <asp:HyperLink ID="HyperLink113" runat="server" NavigateUrl="~/Sales/Sample019.aspx">打樣室接收</asp:HyperLink>
                                                                                                <br />
                        <asp:HyperLink ID="HyperLink114" runat="server" NavigateUrl="~/Sales/Sample020.aspx">打樣室歸還</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink115" runat="server" NavigateUrl="~/Sales/Sample021.aspx">版房收回</asp:HyperLink>
                                                <br />
                        <asp:HyperLink ID="HyperLink116" runat="server" NavigateUrl="~/Sales/Sample022.aspx">租借報表</asp:HyperLink>
                                                <br />
                        <asp:HyperLink ID="HyperLink126" runat="server" NavigateUrl="~/Sales/Sample023.aspx">樣品作業進度上傳</asp:HyperLink>

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
                                                <br />
                        <asp:HyperLink ID="HyperLink52" runat="server" NavigateUrl="~/VN/VN011.aspx">越南明細表(含訂單工繳)</asp:HyperLink>
                                                                        <br />
                        <asp:HyperLink ID="HyperLink53" runat="server" NavigateUrl="~/VN/VN012.aspx">越南明細表(秒數)</asp:HyperLink>
                                                                                                <br />
                        <asp:HyperLink ID="HyperLink54" runat="server" NavigateUrl="~/VN/VN013.aspx">越南明細表(各組秒數)</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink84" runat="server" NavigateUrl="~/VN/VN014.aspx">訂單主料到廠日(有小圖)</asp:HyperLink>
                    </td>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td>
                        <asp:HyperLink ID="HyperLink110" runat="server" NavigateUrl="~/FactoryMG/Findex.aspx">工廠多語首頁</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">管理部</td>
                    <td>
                        <asp:HyperLink ID="HyperLink59" runat="server" NavigateUrl="~/MGT/MGT001.aspx">新增快遞單</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink60" runat="server" NavigateUrl="~/MGT/MGT002.aspx">新增快遞單明細</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink64" runat="server" NavigateUrl="~/MGT/MGT004.aspx">快遞單資料查詢</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink65" runat="server" NavigateUrl="~/MGT/MGT006.aspx">快遞單成立資料查詢</asp:HyperLink>
                        <br />
                                                <asp:HyperLink ID="HyperLink66" runat="server" NavigateUrl="~/MGT/MGT007.aspx">快遞單成立資料查詢</asp:HyperLink>
                        <br />
                          <asp:HyperLink ID="HyperLink67" runat="server" NavigateUrl="~/MGT/MGT008.aspx">快遞單撿貨結案</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink91" runat="server" NavigateUrl="~/MGT/MGT009.aspx">快遞單INVOICE</asp:HyperLink>
                                                <br />
                        <asp:HyperLink ID="HyperLink94" runat="server" NavigateUrl="~/MGT/MGT010.aspx">快遞單原因歸屬管理</asp:HyperLink>
                         <br />
<%--                        <asp:HyperLink ID="HyperLink112" runat="server" NavigateUrl="~/MGT/MGT002Print.aspx">快遞單重量列印</asp:HyperLink>--%>
                        
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
