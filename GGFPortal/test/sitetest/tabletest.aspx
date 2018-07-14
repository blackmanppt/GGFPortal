<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tabletest.aspx.cs" Inherits="GGFPortal.test.sitetest.tabletest" %>

<!DOCTYPE html>

<html xmlns:v="urn:schemas-microsoft-com:vml"
xmlns:o="urn:schemas-microsoft-com:office:office"
xmlns:x="urn:schemas-microsoft-com:office:excel"
xmlns="http://www.w3.org/TR/REC-html40">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="ProgId" content="Excel.Sheet">
    <meta name="Generator" content="Aspose.Cell ">
    <link rel="File-List" href="062911555236_files/filelist.xml">
    <link rel="Edit-Time-Data" href="062911555236_files/editdata.mso">
    <link rel="OLE-Object-Data" href="062911555236_files/oledata.mso">
    <title></title>
    <!--[if gte mso 9]><xml>
     <o:DocumentProperties>
      <o:Author>Stone.lee</o:Author>
      <o:Created>2018-06-29T11:55:14Z</o:Created>
      <o:LastSaved>2018-06-29T11:55:14Z</o:LastSaved>
    </o:DocumentProperties>
    </xml><![endif]-->
    <style>
        <!-- table {
            mso-displayed-decimal-separator: "\.";
            mso-displayed-thousand-separator: "\,";
        }

        @page {
            mso-header-data: "";
            mso-footer-data: "";
            margin: 0.15748031496063in 0.236220472440945in 0.15748031496063in 0.236220472440945in;
            mso-header-margin: 0in;
            mso-footer-margin: 0in;
            mso-page-orientation: Landscape;
            mso-horizontal-page-align: center;
            mso-vertical-page-align: center;
        }

        tr {
            mso-height-source: auto;
            mso-ruby-visibility: none;
        }

        col {
            mso-width-source: auto;
            mso-ruby-visibility: none;
        }

        br {
            mso-data-placement: same-cell;
        }

        ruby {
            ruby-align: left;
        }

        .style0 {
            mso-number-format: General;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            color: #000000;
            font-size: 10pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
            border: none;
            mso-protection: locked visible;
            mso-style-name: Normal;
            mso-style-id: 0;
        }

        .font0 {
            color: #000000;
            font-size: 10pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
        }

        .font1 {
            color: #000000;
            font-size: 9pt;
            font-weight: 400;
            font-style: normal;
            font-family: "細明體","monospace";
        }

        .font2 {
            color: #000000;
            font-size: 12pt;
            font-weight: 400;
            font-style: normal;
            font-family: "新細明體","serif";
        }

        .font3 {
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
        }

        .font4 {
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "細明體","monospace";
        }

        .font5 {
            color: #000000;
            font-size: 9pt;
            font-weight: 400;
            font-style: normal;
            font-family: "新細明體","serif";
        }

        .font6 {
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
        }

        .font7 {
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
        }

        .font8 {
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
        }

        .font9 {
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
        }

        .font10 {
            color: #0000CC;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
        }

        .font11 {
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri Light","sans-serif";
        }

        .font12 {
            color: #000000;
            font-size: 13pt;
            font-weight: 700;
            font-style: normal;
            font-family: "Calibri","sans-serif";
        }

        .font13 {
            color: #000000;
            font-size: 13pt;
            font-weight: 700;
            font-style: normal;
            font-family: "標楷體","cursive";
        }

        .font14 {
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
        }

        .font15 {
            color: #215968;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
        }

        .font16 {
            color: #215968;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
        }

        .font17 {
            color: #000000;
            font-size: 14pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
        }

        .font18 {
            color: #000000;
            font-size: 14pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
        }

        .font19 {
            color: #000000;
            font-size: 11pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
        }

        .font20 {
            color: #000000;
            font-size: 12pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
        }

        .font21 {
            color: #000000;
            font-size: 26pt;
            font-weight: 700;
            font-style: normal;
            font-family: "Calibri","sans-serif";
        }

        .font22 {
            color: #000000;
            font-size: 26pt;
            font-weight: 700;
            font-style: normal;
            font-family: "標楷體","cursive";
        }

        .font23 {
            color: #FFFFFF;
            font-size: 11pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
        }

        td {
            mso-style-parent: style0;
            mso-number-format: General;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            color: #000000;
            font-size: 10pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
            border: none;
            mso-protection: locked visible;
            mso-ignore: padding;
        }

        .style0 {
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 10pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
            border: none;
            mso-protection: locked visible;
            mso-style-name: "Normal";
        }

        .style1 {
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 10pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
            mso-protection: locked visible;
        }

        .style2 {
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 10pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
            mso-protection: locked visible;
        }

        .style3 {
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 10pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
            mso-protection: locked visible;
        }

        .style4 {
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 10pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
            mso-protection: locked visible;
        }

        .style5 {
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 10pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
            mso-protection: locked visible;
        }

        .style6 {
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 10pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
            mso-protection: locked visible;
        }

        .style7 {
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 10pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
            mso-protection: locked visible;
        }

        .style8 {
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 10pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
            mso-protection: locked visible;
        }

        .style9 {
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 10pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
            mso-protection: locked visible;
        }

        .style10 {
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 10pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
            mso-protection: locked visible;
        }

        .style11 {
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 10pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
            mso-protection: locked visible;
        }

        .style12 {
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 10pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
            mso-protection: locked visible;
        }

        .style13 {
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 10pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
            mso-protection: locked visible;
        }

        .style14 {
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 10pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
            mso-protection: locked visible;
        }

        .x15 {
            mso-style-parent: style0;
            mso-number-format: General;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 10pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .style16 {
            mso-number-format: "0%";
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 10pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
            mso-protection: locked visible;
            mso-style-name: "Percent";
        }

        .style17 {
            mso-number-format: "_ \0022¥\0022* \#\,\#\#0\.00_ \;_ \0022¥\0022* -\#\,\#\#0\.00_ \;_ \0022¥\0022* \0022-\0022??_ \;_ \@_ ";
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 10pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
            mso-protection: locked visible;
            mso-style-name: "Currency";
        }

        .style18 {
            mso-number-format: "_ \0022¥\0022* \#\,\#\#0_ \;_ \0022¥\0022* -\#\,\#\#0_ \;_ \0022¥\0022* \0022-\0022_ \;_ \@_ ";
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 10pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
            mso-protection: locked visible;
            mso-style-name: "Currency [0]";
        }

        .style19 {
            mso-number-format: "_ * \#\,\#\#0\.00_ \;_ * -\#\,\#\#0\.00_ \;_ * \0022-\0022??_ \;_ \@_ ";
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 10pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
            mso-protection: locked visible;
            mso-style-name: "Comma";
        }

        .style20 {
            mso-number-format: "_ * \#\,\#\#0_ \;_ * -\#\,\#\#0_ \;_ * \0022-\0022_ \;_ \@_ ";
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 10pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
            mso-protection: locked visible;
            mso-style-name: "Comma [0]";
        }

        .style21 {
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 12pt;
            font-weight: 400;
            font-style: normal;
            font-family: "新細明體","serif";
            border: none;
            mso-protection: locked visible;
            mso-style-name: "一般 2";
        }

        .x22 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x23 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "細明體","monospace";
            border: none;
            mso-protection: locked visible;
        }

        .x24 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 3px solid windowtext;
            border-right: 1px solid windowtext;
            border-bottom: none;
            border-left: 3px solid windowtext;
            mso-diagonal-down: 1px solid windowtext;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x25 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 3px solid windowtext;
            border-right: 1px solid windowtext;
            border-bottom: none;
            border-left: 1px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x26 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 3px solid windowtext;
            border-right: 1px solid windowtext;
            border-bottom: 1px solid windowtext;
            border-left: 1px solid windowtext;
            mso-diagonal-down: 1px solid windowtext;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x27 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 3px solid windowtext;
            border-right: none;
            border-bottom: 1px solid windowtext;
            border-left: 1px solid windowtext;
            mso-diagonal-down: 1px solid windowtext;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x28 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 3px solid windowtext;
            border-right: none;
            border-bottom: 1px solid windowtext;
            border-left: none;
            mso-diagonal-down: 1px solid windowtext;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x29 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 3px solid windowtext;
            border-right: 1px solid windowtext;
            border-bottom: 1px solid windowtext;
            border-left: none;
            mso-diagonal-down: 1px solid windowtext;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x30 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 3px solid windowtext;
            border-right: 3px solid windowtext;
            border-bottom: 1px solid windowtext;
            border-left: 1px solid windowtext;
            mso-diagonal-down: 1px solid windowtext;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x31 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 1px solid windowtext;
            border-bottom: 1px solid windowtext;
            border-left: 3px solid windowtext;
            mso-diagonal-down: 1px solid windowtext;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x32 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x33 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x34 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 3px solid windowtext;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x35 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 1px solid windowtext;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: 3px solid windowtext;
            mso-diagonal-down: 1px solid windowtext;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x36 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x37 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: none;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x38 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: none;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x39 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x40 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: none;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x41 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: none;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x42 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x43 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x44 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #CCFFFF;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x45 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x46 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: 1px solid windowtext;
            border-left: 3px solid windowtext;
            mso-diagonal-down: 1px solid windowtext;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x47 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border-top: none;
            border-right: none;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x48 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x49 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x50 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border-top: none;
            border-right: none;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x51 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border: none;
            mso-protection: locked visible;
        }

        .x52 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x53 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x54 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #CCFFFF;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x55 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #CCFFFF;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x56 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #CCFFFF;
            mso-pattern: auto none;
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x57 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x58 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: 2px solid windowtext;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x59 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: 2px solid windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x60 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: 2px solid windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x61 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: 2px solid windowtext;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x62 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #CCFFFF;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: 2px solid windowtext;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x63 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #CCFFFF;
            mso-pattern: auto none;
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: 2px solid windowtext;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x64 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x65 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x66 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x67 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x68 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 1px solid windowtext;
            border-right: none;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x69 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: none;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x70 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 3px solid windowtext;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x71 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x72 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x73 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x74 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border-top: none;
            border-right: none;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x75 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border: none;
            mso-protection: locked visible;
        }

        .x76 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x77 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border-top: none;
            border-right: none;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x78 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border: none;
            mso-protection: locked visible;
        }

        .x79 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x80 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 1px solid windowtext;
            border-bottom: none;
            border-left: 1px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x81 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border-top: none;
            border-right: none;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x82 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: 2px solid windowtext;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x83 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: 2px solid windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x84 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: 2px solid windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x85 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: 2px solid windowtext;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x86 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #CCFFFF;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Arial","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: 2px solid windowtext;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x87 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: none;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x88 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: none;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x89 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: none;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x90 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x91 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: none;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x92 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x93 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FFFFFF;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x94 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border-top: none;
            border-right: none;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x95 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FFFFFF;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 1px solid windowtext;
            border-bottom: none;
            border-left: 1px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x96 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FFFFFF;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x97 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 3px solid windowtext;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x98 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #000000;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 3px solid #00FF00;
            border-right: none;
            border-bottom: none;
            border-left: 3px solid #00FF00;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x99 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #000000;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 3px solid #00FF00;
            border-right: none;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x100 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #000000;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 3px solid #00FF00;
            border-right: 3px solid #00FF00;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x101 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FFFFFF;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border-top: 2px dot-dot-dash windowtext;
            border-right: none;
            border-bottom: 2px dot-dot-dash windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x102 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FFFFFF;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px dot-dot-dash windowtext;
            border-right: none;
            border-bottom: 2px dot-dot-dash windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x103 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FFFFFF;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px dot-dot-dash windowtext;
            border-right: 2px dot-dot-dash windowtext;
            border-bottom: 2px dot-dot-dash windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x104 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 1px solid windowtext;
            border-right: 1px solid windowtext;
            border-bottom: none;
            border-left: 1px solid windowtext;
            mso-diagonal-down: 1px solid windowtext;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x105 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 1px solid windowtext;
            border-right: 1px solid windowtext;
            border-bottom: none;
            border-left: 1px solid windowtext;
            mso-diagonal-down: 1px solid windowtext;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x106 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: none;
            border-left: 1px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x107 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 3px solid windowtext;
            border-bottom: 2px solid windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x108 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x109 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            color: #0000CC;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border-top: 2px solid windowtext;
            border-right: none;
            border-bottom: none;
            border-left: 3px solid #00FF00;
            mso-diagonal-down: 3px solid #FF0000;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x110 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: bottom;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri Light","sans-serif";
            border-top: 2px solid windowtext;
            border-right: none;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x111 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: bottom;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri Light","sans-serif";
            border-top: 2px solid windowtext;
            border-right: 3px solid #00FF00;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x112 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: bottom;
            white-space: normal;
            word-wrap: break-word;
            background: #CCFFFF;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px dot-dot-dash windowtext;
            border-right: none;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x113 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: bottom;
            white-space: normal;
            word-wrap: break-word;
            background: #CCFFFF;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px dot-dot-dash windowtext;
            border-right: 3px solid #FF0000;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x114 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 1px solid windowtext;
            border-bottom: none;
            border-left: 1px solid windowtext;
            mso-diagonal-down: 1px solid windowtext;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x115 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: none;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x116 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: none;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x117 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: 3px solid windowtext;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x118 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            color: #0000CC;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border-top: none;
            border-right: none;
            border-bottom: none;
            border-left: 3px solid #00FF00;
            mso-diagonal-down: 3px solid #FF0000;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x119 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri Light","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x120 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri Light","sans-serif";
            border-top: none;
            border-right: 3px solid #00FF00;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x121 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: bottom;
            white-space: normal;
            word-wrap: break-word;
            background: #CCFFFF;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x122 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: bottom;
            white-space: normal;
            word-wrap: break-word;
            background: #CCFFFF;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 3px solid #FF0000;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x123 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x124 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 3px solid windowtext;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x125 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x126 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: 1px solid windowtext;
            border-left: 3px solid #00FF00;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x127 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: top;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri Light","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x128 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: top;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri Light","sans-serif";
            border-top: none;
            border-right: 3px solid #00FF00;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x129 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 1px solid windowtext;
            border-right: 1px solid windowtext;
            border-bottom: none;
            border-left: 3px solid #00FF00;
            mso-diagonal-down: 1px solid windowtext;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x130 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #006600;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px dot-dot-dash windowtext;
            border-right: 2px dot-dot-dash windowtext;
            border-bottom: none;
            border-left: 2px dot-dot-dash windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x131 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 3px solid #00FF00;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x132 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #CCFFFF;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x133 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #CCFFFF;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x134 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: right;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 1px solid windowtext;
            border-right: 3px solid #FF0000;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x135 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 1px solid windowtext;
            border-bottom: 1px solid windowtext;
            border-left: 3px solid #00FF00;
            mso-diagonal-down: 1px solid windowtext;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x136 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x137 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #006600;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 2px dot-dot-dash windowtext;
            border-bottom: none;
            border-left: 2px dot-dot-dash windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x138 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 3px solid #00FF00;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x139 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: right;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 3px solid #FF0000;
            border-bottom: 1px solid windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x140 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: 2px solid windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x141 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 3px solid windowtext;
            border-bottom: 2px solid windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x142 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border-top: 1px solid windowtext;
            border-right: 1px solid windowtext;
            border-bottom: none;
            border-left: 3px solid #00FF00;
            mso-diagonal-down: 1px solid windowtext;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x143 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border: none;
            mso-protection: locked visible;
        }

        .x144 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 1px solid windowtext;
            border-right: none;
            border-bottom: none;
            border-left: 1px solid windowtext;
            mso-diagonal-down: 1px solid windowtext;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x145 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: none;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x146 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border-top: none;
            border-right: 1px solid windowtext;
            border-bottom: 3px solid #00FF00;
            border-left: 3px solid #00FF00;
            mso-diagonal-down: 1px solid windowtext;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x147 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: 3px solid #00FF00;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x148 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #006600;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 2px dot-dot-dash windowtext;
            border-bottom: 3px solid #00FF00;
            border-left: 2px dot-dot-dash windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x149 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 3px solid #00FF00;
            border-bottom: 3px solid #00FF00;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x150 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #CCFFFF;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: 2px solid windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x151 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #CCFFFF;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: 2px solid windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x152 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: 1px solid windowtext;
            border-left: 1px solid windowtext;
            mso-diagonal-down: 1px solid windowtext;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x153 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x154 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 700;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x155 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 700;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x156 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 700;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: none;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x157 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 700;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x158 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: none;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x159 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: none;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x160 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #000000;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x161 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 700;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: 2px solid windowtext;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x162 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 700;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: 2px solid windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x163 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 700;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: 2px solid windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x164 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 1px solid windowtext;
            border-bottom: 3px solid #FF0000;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x165 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #215968;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border-top: none;
            border-right: none;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x166 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #215968;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border: none;
            mso-protection: locked visible;
        }

        .x167 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #215968;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x168 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 3px solid #FF0000;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x169 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: left;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: none;
            border-bottom: none;
            border-left: 3px solid #FF0000;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x170 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: left;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x171 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: 2px solid windowtext;
            border-left: 3px solid windowtext;
            mso-diagonal-down: 1px solid windowtext;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x172 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: 2px solid windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x173 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #215968;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: 2px solid windowtext;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x174 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #215968;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: 2px solid windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x175 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF99CC;
            mso-pattern: auto none;
            color: #215968;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: 2px solid windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x176 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: left;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: none;
            border-left: 3px solid #FF0000;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x177 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: right;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 3px solid #FF0000;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x178 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: none;
            border-left: 3px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x179 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 1px solid windowtext;
            border-right: none;
            border-bottom: none;
            border-left: 3px solid windowtext;
            mso-diagonal-down: 1px solid windowtext;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x180 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 1px solid windowtext;
            border-right: 1px solid windowtext;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: 1px solid windowtext;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x181 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 1px solid windowtext;
            border-right: 1px solid windowtext;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: 1px solid windowtext;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x182 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 1px solid windowtext;
            border-right: 2px solid windowtext;
            border-bottom: 2px solid windowtext;
            border-left: 1px solid windowtext;
            mso-diagonal-down: 1px solid windowtext;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x183 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border-top: none;
            border-right: none;
            border-bottom: 3px solid #FF0000;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x184 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: 3px solid #FF0000;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x185 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 3px solid #FF0000;
            border-bottom: 3px solid #FF0000;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x186 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 14pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: none;
            border-bottom: none;
            border-left: 3px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x187 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: auto;
            mso-pattern: auto;
            font-size: 14pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: none;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x188 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 14pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px solid windowtext;
            border-right: none;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x189 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 14pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x190 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 14pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x191 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri Light","sans-serif";
            border-top: 3px solid #FF0000;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x192 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: right;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x193 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 3px solid windowtext;
            border-bottom: none;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x194 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 14pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: none;
            border-left: 3px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x195 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri Light","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x196 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 1px solid windowtext;
            border-right: 1px solid windowtext;
            border-bottom: 1px solid windowtext;
            border-left: 1px solid windowtext;
            mso-diagonal-down: 1px solid windowtext;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x197 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border: none;
            mso-protection: locked visible;
        }

        .x198 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FF8080;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x199 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri Light","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: 2px solid windowtext;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x200 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: #FFFFFF;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x201 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: right;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x202 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 1px solid windowtext;
            border-right: 1px solid windowtext;
            border-bottom: 1px solid windowtext;
            border-left: 1px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: 1px solid windowtext;
            mso-protection: locked visible;
        }

        .x203 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri Light","sans-serif";
            border-top: 2px solid windowtext;
            border-right: 2px solid windowtext;
            border-bottom: none;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x204 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: #000000;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x205 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #99CCFF;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }

        .x206 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FFFFFF;
            mso-pattern: auto none;
            font-size: 11pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 2px dot-dot-dash windowtext;
            border-right: 2px dot-dot-dash windowtext;
            border-bottom: 2px dot-dot-dash windowtext;
            border-left: 2px dot-dot-dash windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x207 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: left;
            vertical-align: middle;
            white-space: nowrap;
            background: #FFFFFF;
            mso-pattern: auto none;
            font-size: 12pt;
            font-weight: 400;
            font-style: normal;
            font-family: "標楷體","cursive";
            border: none;
            mso-protection: locked visible;
        }

        .x208 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 14pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: 3px solid windowtext;
            border-left: 3px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x209 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 14pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: 3px solid windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x210 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 14pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: 3px solid windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x211 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            word-wrap: break-word;
            background: #FF99CC;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri Light","sans-serif";
            border-top: none;
            border-right: 2px solid windowtext;
            border-bottom: 3px solid windowtext;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x212 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: 3px solid windowtext;
            border-left: 2px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x213 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: 3px solid windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x214 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: #FFFFFF;
            mso-pattern: auto none;
            font-size: 14pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: 1px solid windowtext;
            border-right: 1px solid windowtext;
            border-bottom: 3px solid windowtext;
            border-left: 1px solid windowtext;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x215 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: #FFFFFF;
            mso-pattern: auto none;
            font-size: 14pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: 3px solid windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x216 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: #FFFFFF;
            mso-pattern: auto none;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: 3px solid windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x217 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 26pt;
            font-weight: 700;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: none;
            border-bottom: 3px solid windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x218 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border-top: none;
            border-right: 3px solid windowtext;
            border-bottom: 3px solid windowtext;
            border-left: none;
            mso-diagonal-down: none;
            mso-diagonal-up: none;
            mso-protection: locked visible;
        }

        .x219 {
            mso-style-parent: style21;
            mso-number-format: General;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            background: auto;
            mso-pattern: auto;
            font-size: 13pt;
            font-weight: 400;
            font-style: normal;
            font-family: "Calibri","sans-serif";
            border: none;
            mso-protection: locked visible;
        }
        -->
    </style>
    <!--[if gte mso 9]><xml>
     <x:ExcelWorkbook>
      <x:ExcelWorksheets>
       <x:ExcelWorksheet>
        <x:Name>台北_5樓-業二+業四</x:Name>
    <x:WorksheetOptions>
     <x:StandardWidth>2048</x:StandardWidth>
     <x:Print>
      <x:ValidPrinterInfo/>
      <x:PaperSizeIndex>9</x:PaperSizeIndex>
      <x:Scale>70</x:Scale>
      <x:HorizontalResolution>600</x:HorizontalResolution>
      <x:VerticalResolution>600</x:VerticalResolution>
     </x:Print>
     <x:Zoom>85</x:Zoom>
     <x:Selected/>
     <x:DoNotDisplayGridlines/>
    </x:WorksheetOptions>
       </x:ExcelWorksheet>
      </x:ExcelWorksheets>
      <x:WindowHeight>9150</x:WindowHeight>
      <x:WindowWidth>14940</x:WindowWidth>
      <x:WindowTopX>360</x:WindowTopX>
      <x:WindowTopY>270</x:WindowTopY>
      <x:RefModeR1C1/>
      <x:TabRatio>600</x:TabRatio>
      <x:ActiveSheet>0</x:ActiveSheet>
     </x:ExcelWorkbook>
    </xml><![endif]-->
</head>
<body link="blue" vlink="purple" class="x22">
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" width="1549" style='border-collapse: collapse; table-layout: fixed; width: 1161pt'>
            <col class="x22" width="12" style='mso-width-source: userset; width: 9pt'>
            <col class="x22" width="22" style='mso-width-source: userset; width: 16pt'>
            <col class="x22" width="19" style='mso-width-source: userset; width: 14pt'>
            <col class="x22" width="35" span="12" style='mso-width-source: userset; width: 26pt'>
            <col class="x22" width="123" style='mso-width-source: userset; width: 92pt'>
            <col class="x22" width="31" span="4" style='mso-width-source: userset; width: 23pt'>
            <col class="x22" width="117" style='mso-width-source: userset; width: 87pt'>
            <col class="x22" width="31" style='mso-width-source: userset; width: 23pt'>
            <col class="x22" width="117" span="2" style='mso-width-source: userset; width: 87pt'>
            <col class="x22" width="31" style='mso-width-source: userset; width: 23pt'>
            <col class="x22" width="120" span="2" style='mso-width-source: userset; width: 90pt'>
            <col class="x22" width="34" style='mso-width-source: userset; width: 25pt'>
            <col class="x22" width="115" style='mso-width-source: userset; width: 86pt'>
            <col class="x22" width="27" style='mso-width-source: userset; width: 20pt'>
            <tr height="9" style='mso-height-source: userset; height: 6.75pt' id='r0'>
                <td height="9" class="x22" width="12" style='height: 6.75pt; width: 9pt;'></td>
                <td class="x22" width="22" style='width: 16.5pt;'></td>
                <td class="x22" width="19" style='width: 14.25pt;'></td>
                <td class="x22" width="35" style='width: 26.25pt;'></td>
                <td class="x22" width="35" style='width: 26.25pt;'></td>
                <td class="x22" width="35" style='width: 26.25pt;'></td>
                <td class="x22" width="35" style='width: 26.25pt;'></td>
                <td class="x22" width="35" style='width: 26.25pt;'></td>
                <td class="x22" width="35" style='width: 26.25pt;'></td>
                <td class="x22" width="35" style='width: 26.25pt;'></td>
                <td class="x22" width="35" style='width: 26.25pt;'></td>
                <td class="x22" width="35" style='width: 26.25pt;'></td>
                <td class="x22" width="35" style='width: 26.25pt;'></td>
                <td class="x22" width="35" style='width: 26.25pt;'></td>
                <td class="x22" width="35" style='width: 26.25pt;'></td>
                <td class="x22" width="123" style='width: 92.25pt;'></td>
                <td class="x22" width="31" style='width: 23.25pt;'></td>
                <td class="x23" width="31" style='width: 23.25pt; ></td>
                <td class="x22" width="31" style='width: 23.25pt;'></td>
                <td class="x22" width="31" style='width: 23.25pt;'></td>
                <td class="x22" width="117" style='width: 87.75pt;'></td>
                <td class="x22" width="31" style='width: 23.25pt;'></td>
                <td class="x22" width="117" style='width: 87.75pt;'></td>
                <td class="x22" width="117" style='width: 87.75pt;'></td>
                <td class="x22" width="31" style='width: 23.25pt;'></td>
                <td class="x22" width="120" style='width: 90pt;'></td>
                <td class="x22" width="120" style='width: 90pt;'></td>
                <td class="x22" width="34" style='width: 25.5pt;'></td>
                <td class="x22" width="115" style='width: 86.25pt;'></td>
                <td class="x22" width="27" style='width: 20.25pt;'></td>
            </tr>
            <tr height="23" style='mso-height-source: userset; height: 17.25pt' id='r1'>
                <td height="23" class="x22" style='height: 17.25pt;'></td>
                <td rowspan="2" height="59" class="x220" style='border-right: 1px solid windowtext; border-bottom: 1px solid windowtext; height: 44.25pt;'></td>
                <td class="x25"></td>
                <td class="x26"></td>
                <td class="x26"></td>
                <td class="x26"></td>
                <td class="x26"></td>
                <td class="x26"></td>
                <td class="x26"></td>
                <td class="x26"></td>
                <td class="x26"></td>
                <td class="x26"></td>
                <td class="x26"></td>
                <td class="x26"></td>
                <td class="x26"></td>
                <td class="x26"></td>
                <td colspan="4" id='tc0' class="x26" style='border-right: 1px solid windowtext; border-bottom: 1px solid windowtext;'></td>
                <td colspan="2" id='tc1' class="x26" style='border-right: 1px solid windowtext; border-bottom: 1px solid windowtext;'></td>
                <td class="x26"></td>
                <td class="x26"></td>
                <td class="x26"></td>
                <td class="x26"></td>
                <td class="x26"></td>
                <td class="x26"></td>
                <td class="x26"></td>
                <td class="x30"></td>
            </tr>
            <tr height="36" style='mso-height-source: userset; height: 27pt' id='r2'>
                <td height="36" class="x22" style='height: 27pt;'></td>
                <td class="x32"></td>
                <td class="x32"></td>
                <td class="x32"></td>
                <td class="x32"></td>
                <td class="x32"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x34"></td>
            </tr>
            <tr height="28" style='mso-height-source: userset; height: 21pt' id='r3'>
                <td height="28" class="x22" style='height: 21pt;'></td>
                <td rowspan="2" height="56" class="x221" style='border-right: 2px solid windowtext; border-bottom: 1px solid windowtext; height: 42pt;'></td>
                <td class="x36"></td>
                <td colspan="4" id='tc2' class="x43" style='border-right: 2px solid windowtext;'>#228</td>
                <td colspan="4" id='tc3' class="x43" style='border-right: 2px solid windowtext;'>#229</td>
                <td colspan="4" id='tc4' class="x43" style='border-right: 2px solid windowtext;'>#230</td>
                <td class="x33"></td>
                <td colspan="4" id='tc5' class="x43" style='border-right: 2px solid windowtext;'>#231</td>
                <td class="x43">#234</td>
                <td class="x33"></td>
                <td class="x44">#237</td>
                <td class="x44">#240</td>
                <td class="x33"></td>
                <td class="x44">#243</td>
                <td class="x44">#247</td>
                <td class="x45"></td>
                <td class="x44">#250</td>
                <td class="x34"></td>
            </tr>
            <tr height="28" style='mso-height-source: userset; height: 21pt' id='r4'>
                <td height="28" class="x22" style='height: 21pt;'></td>
                <td class="x36"></td>
                <td colspan="4" id='tc6' class="x222" style='border-right: 2px solid windowtext;'><asp:Label ID="CName228LB" runat="server" Text=""></asp:Label></td>
                <td colspan="4" id='tc7' class="x53" style='border-right: 2px solid windowtext;'><asp:Label ID="CName229LB" runat="server" Text=""></asp:Label></td>
                <td colspan="4" id='tc8' class="x53" style='border-right: 2px solid windowtext;'><asp:Label ID="CName230LB" runat="server" Text=""></asp:Label></td>
                <td class="x33"></td>
                <td colspan="4" id='tc9' class="x53" style='border-right: 2px solid windowtext;'><asp:Label ID="CName231LB" runat="server" Text=""></asp:Label></td>
                <td class="x53"><asp:Label ID="CName234LB" runat="server" Text=""></asp:Label></td>
                <td class="x33"></td>
                <td class="x54"><asp:Label ID="CName237LB" runat="server" Text=""></asp:Label></td>
                <td class="x55">
                    <font class="font6"><asp:Label ID="CName240LB" runat="server" Text=""></asp:Label></font>
                </td>
                <td class="x33"></td>
                <td class="x54"><asp:Label ID="CName243LB" runat="server" Text=""></asp:Label></td>
                <td class="x56"><asp:Label ID="CName247LB" runat="server" Text=""></asp:Label></td>
                <td class="x57"></td>
                <td class="x55">
                    <font class="font6"><asp:Label ID="CName250LB" runat="server" Text=""></asp:Label></font>
                </td>
                <td class="x34"></td>
            </tr>
            <tr height="28" style='mso-height-source: userset; height: 21pt' id='r5'>
                <td height="28" class="x22" style='height: 21pt;'></td>
                <td rowspan="2" height="56" class="x221" style='border-right: 2px solid windowtext; border-bottom: 1px solid windowtext; height: 42pt;'></td>
                <td class="x36"></td>
                <td colspan="4" id='tc10' class="x61" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name228LB" runat="server" Text=""></asp:Label></td>
                <td colspan="4" id='tc11' class="x61" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name229LB" runat="server" Text=""></asp:Label></td>
                <td colspan="4" id='tc12' class="x61" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name230LB" runat="server" Text=""></asp:Label></td>
                <td class="x33"></td>
                <td colspan="4" id='tc13' class="x61" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name231LB" runat="server" Text=""></asp:Label></td>
                <td class="x61"><asp:Label ID="Name234LB" runat="server" Text=""></asp:Label></td>
                <td class="x33"></td>
                <td class="x62"><asp:Label ID="Name237LB" runat="server" Text=""></asp:Label></td>
                <td class="x62"><asp:Label ID="Name240LB" runat="server" Text=""></asp:Label></td>
                <td class="x33"></td>
                <td class="x62"><asp:Label ID="Name243LB" runat="server" Text=""></asp:Label></td>
                <td class="x63"><asp:Label ID="Name247LB" runat="server" Text=""></asp:Label></td>
                <td class="x57"></td>
                <td class="x62"><asp:Label ID="Name250LB" runat="server" Text=""></asp:Label></td>
                <td class="x34"></td>
            </tr>
            <tr height="28" style='mso-height-source: userset; height: 21pt' id='r6'>
                <td height="28" class="x22" style='height: 21pt;'></td>
                <td class="x36"></td>
                <td colspan="4" id='tc14' class="x43" style='border-right: 2px solid windowtext;'>#225</td>
                <td colspan="4" id='tc15' class="x43" style='border-right: 2px solid windowtext;'>#226</td>
                <td colspan="4" id='tc16' class="x43" style='border-right: 2px solid windowtext;'>#227</td>
                <td class="x67"></td>
                <td colspan="4" id='tc17' class="x43" style='border-right: 2px solid windowtext;'>#232</td>
                <td class="x43">#235</td>
                <td class="x68"></td>
                <td class="x69">#238</td>
                <td class="x44">#241</td>
                <td class="x67"></td>
                <td class="x44">#245</td>
                <td class="x44">#248</td>
                <td class="x67"></td>
                <td class="x44">#251</td>
                <td class="x70"></td>
            </tr>
            <tr height="28" style='mso-height-source: userset; height: 21pt' id='r7'>
                <td height="28" class="x22" style='height: 21pt;'></td>
                <td rowspan="2" height="56" class="x221" style='border-right: 2px solid windowtext; border-bottom: 1px solid windowtext; height: 42pt;'></td>
                <td class="x71"></td>
                <td colspan="4" id='tc18' class="x53" style='border-right: 2px solid windowtext;'><asp:Label ID="CName225LB" runat="server" Text=""></asp:Label></td>
                <td colspan="4" id='tc19' class="x53" style='border-right: 2px solid windowtext;'><asp:Label ID="CName226LB" runat="server" Text=""></asp:Label></td>
                <td colspan="4" id='tc20' class="x223" style='border-right: 2px solid windowtext;'><asp:Label ID="CName227LB" runat="server" Text=""></asp:Label></td>
                <td class="x22"></td>
                <td colspan="4" id='tc21' class="x223" style='border-right: 2px solid windowtext;'><asp:Label ID="CName232LB" runat="server" Text=""></asp:Label></td>
                <td class="x53"><asp:Label ID="CName235LB" runat="server" Text=""></asp:Label></td>
                <td class="x80"></td>
                <td class="x81">
                    <asp:Label ID="CName238LB" runat="server" Text=""></asp:Label>
                </td>
                <td class="x54">
                    <asp:Label ID="CName241LB" runat="server" Text=""></asp:Label>
                </td>
                <td class="x67"></td>
                <td class="x55">
                    <font class="font6"><asp:Label ID="CName245LB" runat="server" Text=""></asp:Label></font>
                </td>
                <td class="x54"><asp:Label ID="CName248LB" runat="server" Text=""></asp:Label></td>
                <td class="x45"></td>
                <td class="x55">
                    <asp:Label ID="CName251LB" runat="server" Text=""></asp:Label>
                </td>
                <td class="x70"></td>
            </tr>
            <tr height="28" style='mso-height-source: userset; height: 21pt' id='r8'>
                <td height="28" class="x22" style='height: 21pt;'></td>
                <td class="x71"></td>
                <td colspan="4" id='tc22' class="x61" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name225LB" runat="server" Text=""></asp:Label></td>
                <td colspan="4" id='tc23' class="x61" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name226LB" runat="server" Text=""></asp:Label></td>
                <td colspan="4" id='tc24' class="x224" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name227LB" runat="server" Text=""></asp:Label></td>
                <td class="x22"></td>
                <td colspan="4" id='tc25' class="x224" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name232LB" runat="server" Text=""></asp:Label></td>
                <td class="x61"><asp:Label ID="Name235LB" runat="server" Text=""></asp:Label></td>
                <td class="x67"></td>
                <td class="x85">
                    <asp:Label ID="Name238LB" runat="server" Text=""></asp:Label>
                </td>
                <td class="x86">
                    <asp:Label ID="Name241LB" runat="server" Text=""></asp:Label>
                </td>
                <td class="x67"></td>
                <td class="x62"><asp:Label ID="Name245LB" runat="server" Text=""></asp:Label></td>
                <td class="x62"><asp:Label ID="Name248LB" runat="server" Text=""></asp:Label></td>
                <td class="x57"></td>
                <td class="x62">
                    <asp:Label ID="Name251LB" runat="server" Text=""></asp:Label>
                </td>
                <td class="x70"></td>
            </tr>
            <tr height="38" style='mso-height-source: userset; height: 28.5pt' id='r9'>
                <td height="38" class="x22" style='height: 28.5pt;'></td>
                <td rowspan="2" height="66" class="x221" style='border-right: 2px solid windowtext; border-bottom: 1px solid windowtext; height: 49.5pt;'></td>
                <td class="x32"></td>
                <td class="x32"></td>
                <td class="x32"></td>
                <td class="x32"></td>
                <td class="x32"></td>
                <td class="x87"></td>
                <td class="x87"></td>
                <td class="x87"></td>
                <td class="x87"></td>
                <td class="x32"></td>
                <td class="x32"></td>
                <td class="x32"></td>
                <td class="x32"></td>
                <td class="x67"></td>
                <td colspan="4" id='tc26' class="x225" style='border-right: 2px solid windowtext;'>#233</td>
                <td class="x43">#236</td>
                <td class="x67"></td>
                <td class="x91">#239</td>
                <td class="x44">#242</td>
                <td class="x67"></td>
                <td class="x44">#246</td>
                <td class="x44">#249</td>
                <td class="x57"></td>
                <td class="x44">#252</td>
                <td class="x70"></td>
            </tr>
            <tr height="28" style='mso-height-source: userset; height: 21pt' id='r10'>
                <td height="28" class="x22" style='height: 21pt;'></td>
                <td class="x36"></td>
                <td colspan="4" id='tc27' class="x43" style='border-right: 2px solid windowtext;'>#222</td>
                <td colspan="4" id='tc28' class="x43" style='border-right: 2px solid windowtext;'>#223</td>
                <td colspan="4" id='tc29' class="x43" style='border-right: 2px solid windowtext;'>#224</td>
                <td class="x92"></td>
                <td colspan="4" id='tc30' class="x223" style='border-right: 2px solid windowtext;'><asp:Label ID="CName233LB" runat="server" Text=""></asp:Label></td>
                <td class="x53"><asp:Label ID="CName236LB" runat="server" Text=""></asp:Label></td>
                <td class="x93"></td>
                <td class="x94">
                    <asp:Label ID="CName239LB" runat="server" Text=""></asp:Label>
                </td>
                <td class="x54"><asp:Label ID="CName242LB" runat="server" Text=""></asp:Label></td>
                <td class="x67"></td>
                <td class="x55">
                    <font class="font6"><asp:Label ID="CName246LB" runat="server" Text=""></asp:Label></font>
                </td>
                <td class="x56"><asp:Label ID="CName249LB" runat="server" Text=""></asp:Label></td>
                <td class="x67"></td>
                <td class="x55">
                    <font class="font6"><asp:Label ID="CName252LB" runat="server" Text=""></asp:Label></font>
                </td>
                <td class="x70"></td>
            </tr>
            <tr height="28" style='mso-height-source: userset; height: 21pt' id='r11'>
                <td height="28" class="x22" style='height: 21pt;'></td>
                <td rowspan="2" height="56" class="x221" style='border-right: 2px solid windowtext; border-bottom: 1px solid windowtext; height: 42pt;'></td>
                <td class="x36"></td>
                <td colspan="4" id='tc31' class="x53" style='border-right: 2px solid windowtext;'><asp:Label ID="CName222LB" runat="server" Text=""></asp:Label></td>
                <td colspan="4" id='tc32' class="x53" style='border-right: 2px solid windowtext;'><asp:Label ID="CName223LB" runat="server" Text=""></asp:Label></td>
                <td colspan="4" id='tc33' class="x53" style='border-right: 2px solid windowtext;'><asp:Label ID="CName224LB" runat="server" Text=""></asp:Label></td>
                <td class="x92"></td>
                <td colspan="4" id='tc34' class="x224" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name233LB" runat="server" Text=""></asp:Label></td>
                <td class="x61"><asp:Label ID="Name236LB" runat="server" Text=""></asp:Label></td>
                <td class="x95"></td>
                <td class="x85"></td>
                <td class="x62"><asp:Label ID="Name242LB" runat="server" Text=""></asp:Label></td>
                <td class="x67"></td>
                <td class="x62"><asp:Label ID="Name246LB" runat="server" Text=""></asp:Label></td>
                <td class="x63"><asp:Label ID="Name249LB" runat="server" Text=""></asp:Label></td>
                <td class="x45"></td>
                <td class="x62"><asp:Label ID="Name252LB" runat="server" Text=""></asp:Label></td>
                <td class="x70"></td>
            </tr>
            <tr height="28" style='mso-height-source: userset; height: 21pt' id='r12'>
                <td height="28" class="x22" style='height: 21pt;'></td>
                <td class="x36"></td>
                <td colspan="4" id='tc35' class="x61" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name222LB" runat="server" Text=""></asp:Label></td>
                <td colspan="4" id='tc36' class="x61" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name223LB" runat="server" Text=""></asp:Label></td>
                <td colspan="4" id='tc37' class="x61" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name224LB" runat="server" Text=""></asp:Label></td>
                <td class="x92"></td>
                <td class="x96"></td>
                <td class="x96"></td>
                <td class="x96"></td>
                <td class="x96"></td>
                <td class="x96"></td>
                <td class="x93"></td>
                <td class="x96"></td>
                <td class="x96"></td>
                <td class="x93"></td>
                <td class="x96"></td>
                <td class="x96"></td>
                <td class="x96"></td>
                <td class="x44">#253</td>
                <td class="x70"></td>
            </tr>
            <tr height="28" style='mso-height-source: userset; height: 21pt' id='r13'>
                <td height="28" class="x22" style='height: 21pt;'></td>
                <td rowspan="2" height="56" class="x221" style='border-right: 2px solid windowtext; border-bottom: 1px solid windowtext; height: 42pt;'></td>
                <td class="x36"></td>
                <td colspan="4" id='tc38' class="x43" style='border-right: 2px solid windowtext;'>#219</td>
                <td colspan="4" id='tc39' class="x43" style='border-right: 2px solid windowtext;'>#220</td>
                <td colspan="4" id='tc40' class="x43" style='border-right: 2px solid windowtext;'>#221</td>
                <td class="x22"></td>
                <td class="x96"></td>
                <td class="x96"></td>
                <td class="x96"></td>
                <td class="x96"></td>
                <td class="x96"></td>
                <td class="x93"></td>
                <td class="x96"></td>
                <td class="x96"></td>
                <td class="x93"></td>
                <td class="x96"></td>
                <td class="x96"></td>
                <td class="x96"></td>
                <td class="x54">
                    <asp:Label ID="CName253LB" runat="server" Text=""></asp:Label>
                </td>
                <td class="x70"></td>
            </tr>
            <tr height="28" style='mso-height-source: userset; height: 21pt' id='r14'>
                <td height="28" class="x22" style='height: 21pt;'></td>
                <td class="x36"></td>
                <td colspan="4" id='tc41' class="x53" style='border-right: 2px solid windowtext;'><asp:Label ID="CName219LB" runat="server" Text=""></asp:Label></td>
                <td colspan="4" id='tc42' class="x53" style='border-right: 2px solid windowtext;'><asp:Label ID="CName220LB" runat="server" Text=""></asp:Label></td>
                <td colspan="4" id='tc43' class="x53" style='border-right: 2px solid windowtext;'><asp:Label ID="Came221LB" runat="server" Text=""></asp:Label></td>
                <td class="x22"></td>
                <td class="x67"></td>
                <td class="x67"></td>
                <td class="x67"></td>
                <td class="x67"></td>
                <td class="x67"></td>
                <td class="x67"></td>
                <td class="x67"></td>
                <td class="x67"></td>
                <td class="x67"></td>
                <td class="x67"></td>
                <td class="x67"></td>
                <td class="x67"></td>
                <td class="x62">
                    <asp:Label ID="Name253LB" runat="server" Text=""></asp:Label>
                </td>
                <td class="x97"></td>
            </tr>
            <tr height="28" style='mso-height-source: userset; height: 21pt' id='r15'>
                <td height="28" class="x22" style='height: 21pt;'></td>
                <td rowspan="2" height="71" class="x221" style='border-right: 2px solid windowtext; border-bottom: 1px solid windowtext; height: 53.25pt;'></td>
                <td class="x71"></td>
                <td colspan="4" id='tc44' class="x61" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name219LB" runat="server" Text=""></asp:Label></td>
                <td colspan="4" id='tc45' class="x61" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name220LB" runat="server" Text=""></asp:Label></td>
                <td colspan="4" id='tc46' class="x61" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name221LB" runat="server" Text=""></asp:Label></td>
                <td class="x22"></td>
                <td class="x98"></td>
                <td class="x99"></td>
                <td class="x99"></td>
                <td class="x100"></td>
                <td colspan="3" id='tc47' class="x226" style='border-right: 2px dot-dot-dash windowtext; border-bottom: 2px dot-dot-dash windowtext;'>量桌</td>
                <td height="28" class="x67" width="117" style='height: 21pt; width: 87.75pt;' align="left" valign="top">
                    <span style='mso-ignore: vglayout; position: absolute; z-index: 1; margin-left: 3px; margin-top: -4px; width: 70px; height: 70px'>
                        <img width="70" height="70" src="062911555236_files\image001.jpeg" name='圖片 1'></span>
                    <span style='mso-ignore: vglayout2'>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="28" class="x67" width="117" style='height: 21pt; width: 87.75pt;'></td>
                            </tr>
                        </table>
                    </span>
                </td>
                <td rowspan="2" height="71" class="x105" style='border-right: 1px solid windowtext; height: 53.25pt;'></td>
                <td class="x105"></td>
                <td class="x105"></td>
                <td class="x105"></td>
                <td class="x106"></td>
                <td class="x107"></td>
            </tr>
            <tr height="43" style='mso-height-source: userset; height: 32.25pt' id='r16'>
                <td height="43" class="x22" style='height: 32.25pt;'></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x67"></td>
                <td class="x67"></td>
                <td class="x67"></td>
                <td class="x67"></td>
                <td class="x67"></td>
                <td class="x67"></td>
                <td class="x67"></td>
                <td class="x32"></td>
                <td class="x67"></td>
                <td rowspan="2" height="71" class="x109" style='height: 53.25pt;'></td>
                <td colspan="3" id='tc48' class="x111" style='border-right: 3px solid #00FF00;'>#286</td>
                <td colspan="3" id='tc49' rowspan="3" height="99" class="x227" style='border-right: 3px solid #FF0000; height: 74.25pt;'>#283
                <br>
                </td>
                <td class="x67"></td>
                <td colspan="5" id='tc50' rowspan="5" height="155" class="x228" style='border-right: 3px solid windowtext; border-bottom: 2px solid windowtext; height: 116.25pt;'>
                    <font class="font3">#190<br></font>
                    <font class="font6">機房</font>
                </td>
            </tr>
            <tr height="28" style='mso-height-source: userset; height: 21pt' id='r17'>
                <td height="28" class="x22" style='height: 21pt;'></td>
                <td rowspan="2" height="56" class="x221" style='border-right: 2px solid windowtext; border-bottom: 1px solid windowtext; height: 42pt;'></td>
                <td class="x36"></td>
                <td colspan="4" id='tc51' class="x43" style='border-right: 2px solid windowtext;'>#216</td>
                <td colspan="4" id='tc52' class="x43" style='border-right: 2px solid windowtext;'>#217</td>
                <td colspan="4" id='tc53' class="x43" style='border-right: 2px solid windowtext;'>#218</td>
                <td class="x33"></td>
                <td colspan="3" id='tc54' class="x120" style='border-right: 3px solid #00FF00;'>
                    <font class="font6">邱詩瑋</font>
                </td>
                <td class="x33"></td>
                <td rowspan="2" height="56" class="x229" style='border-right: 1px solid windowtext; height: 42pt;'></td>
            </tr>
            <tr height="28" style='mso-height-source: userset; height: 21pt' id='r18'>
                <td height="28" class="x22" style='height: 21pt;'></td>
                <td class="x36"></td>
                <td colspan="4" id='tc55' class="x230" style='border-right: 2px solid windowtext;'>
                    <font class="font6"><asp:Label ID="CName216LB" runat="server" Text=""></asp:Label></font>
                </td>
                <td colspan="4" id='tc56' class="x53" style='border-right: 2px solid windowtext;'><asp:Label ID="CName217LB" runat="server" Text=""></asp:Label></td>
                <td colspan="4" id='tc57' class="x53" style='border-right: 2px solid windowtext;'><asp:Label ID="CName218LB" runat="server" Text=""></asp:Label></td>
                <td class="x22"></td>
                <td class="x126"></td>
                <td colspan="3" id='tc58' class="x128" style='border-right: 3px solid #00FF00;'>Ellen</td>
                <td class="x33"></td>
            </tr>
            <tr height="28" style='mso-height-source: userset; height: 21pt' id='r19'>
                <td height="28" class="x22" style='height: 21pt;'></td>
                <td rowspan="2" height="56" class="x221" style='border-right: 2px solid windowtext; border-bottom: 1px solid windowtext; height: 42pt;'></td>
                <td class="x36"></td>
                <td colspan="4" id='tc59' class="x61" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name216LB" runat="server" Text=""></asp:Label></td>
                <td colspan="4" id='tc60' class="x61" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name217LB" runat="server" Text=""></asp:Label></td>
                <td colspan="4" id='tc61' class="x61" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name218LB" runat="server" Text=""></asp:Label></td>
                <td class="x22"></td>
                <td rowspan="2" height="56" class="x231" style='border-right: 1px solid windowtext; border-bottom: 1px solid windowtext; height: 42pt;'></td>
                <td class="x67"></td>
                <td rowspan="4" height="112" class="x232" style='border-right: 2px dot-dot-dash windowtext; border-bottom: 3px solid #00FF00; height: 84pt;'></td>
                <td class="x131"></td>
                <td colspan="3" id='tc62' rowspan="4" height="112" class="x233" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext; height: 84pt;'></td>
                <td class="x108"></td>
                <td rowspan="2" height="56" class="x234" style='border-right: 3px solid #FF0000; border-bottom: 1px solid windowtext; height: 42pt;'>
                    <font class="font6">門</font>
                </td>
            </tr>
            <tr height="28" style='mso-height-source: userset; height: 21pt' id='r20'>
                <td height="28" class="x22" style='height: 21pt;'></td>
                <td class="x36"></td>
                <td colspan="4" id='tc63' class="x43" style='border-right: 2px solid windowtext;'>#213</td>
                <td colspan="4" id='tc64' class="x43" style='border-right: 2px solid windowtext;'>#214</td>
                <td colspan="4" id='tc65' class="x43" style='border-right: 2px solid windowtext;'>#215</td>
                <td class="x108"></td>
                <td class="x136"></td>
                <td rowspan="2" height="56" class="x236" width="31" style='border-right: 3px solid #00FF00; height: 42pt; width: 23.25pt;' align="left" valign="top">
                    <span style='mso-ignore: vglayout; position: absolute; z-index: 2; margin-left: 0px; margin-top: 9px; width: 40px; height: 34px'>
                        <img width="40" height="34" src="062911555236_files\cellsDrawing.png" name='一般五邊形 3'></span>
                    <span style='mso-ignore: vglayout2'>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td rowspan="2" height="56" class="x136" width="31" style='height: 42pt; width: 23.25pt;'></td>
                            </tr>
                        </table>
                    </span>
                </td>
                <td class="x108"></td>
            </tr>
            <tr height="28" style='mso-height-source: userset; height: 21pt' id='r21'>
                <td height="28" class="x22" style='height: 21pt;'></td>
                <td rowspan="2" height="56" class="x221" style='border-right: 2px solid windowtext; border-bottom: 1px solid windowtext; height: 42pt;'></td>
                <td class="x36"></td>
                <td colspan="4" id='tc66' class="x53" style='border-right: 2px solid windowtext;'><asp:Label ID="CName213LB" runat="server" Text=""></asp:Label></td>
                <td colspan="4" id='tc67' class="x53" style='border-right: 2px solid windowtext;'><asp:Label ID="CName214LB" runat="server" Text=""></asp:Label></td>
                <td colspan="4" id='tc68' class="x223" style='border-right: 2px solid windowtext;'><asp:Label ID="CName215LB" runat="server" Text=""></asp:Label></td>
                <td class="x108"></td>
                <td rowspan="2" height="56" class="x237" style='border-right: 1px solid windowtext; border-bottom: 3px solid #00FF00; height: 42pt;'></td>
                <td class="x143"></td>
                <td class="x108"></td>
                <td rowspan="2" height="56" class="x238" style='border-bottom: 1px solid windowtext; height: 42pt;'></td>
                <td colspan="5" id='tc69' rowspan="8" height="247" class="x239" style='border-right: 3px solid windowtext; border-bottom: 2px solid windowtext; height: 185.25pt;'>
                    <font class="font6">員工休息室</font>
                </td>
            </tr>
            <tr height="28" style='mso-height-source: userset; height: 21pt' id='r22'>
                <td height="28" class="x22" style='height: 21pt;'></td>
                <td class="x36"></td>
                <td colspan="4" id='tc70' class="x61" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name213LB" runat="server" Text=""></asp:Label></td>
                <td colspan="4" id='tc71' class="x61" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name214LB" runat="server" Text=""></asp:Label></td>
                <td colspan="4" id='tc72' class="x224" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name215LB" runat="server" Text=""></asp:Label></td>
                <td class="x108"></td>
                <td class="x147"></td>
                <td class="x149"></td>
                <td class="x108"></td>
            </tr>
            <tr height="44" style='mso-height-source: userset; height: 33pt' id='r23'>
                <td height="44" class="x22" style='height: 33pt;'></td>
                <td rowspan="2" height="72" class="x221" style='border-right: 2px solid windowtext; border-bottom: 1px solid windowtext; height: 54pt;'></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td colspan="7" id='tc73' rowspan="2" height="72" class="x240" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext; height: 54pt;'>
                    <font class="font12">200 / 201<br></font>
                    <font class="font13">櫃台</font>
                    <font class="font12"><span style='mso-spacerun:yes'>&nbsp; </span></font>
                    <font class="font13"><asp:Label ID="CName200LB" runat="server" Text=""></asp:Label></font>
                    <font class="font12"><asp:Label ID="Name200LB" runat="server" Text=""></asp:Label> / <asp:Label ID="Name201LB" runat="server" Text=""></asp:Label></font>
                </td>
                <td class="x108"></td>
                <td rowspan="2" height="72" class="x238" style='border-bottom: 1px solid windowtext; height: 54pt;'></td>
            </tr>
            <tr height="28" style='mso-height-source: userset; height: 21pt' id='r24'>
                <td height="28" class="x22" style='height: 21pt;'></td>
                <td class="x71"></td>
                <td colspan="3" id='tc74' class="x241" style='border-right: 2px solid windowtext;'>#209</td>
                <td colspan="3" id='tc75' class="x241" style='border-right: 2px solid windowtext;'>#210</td>
                <td colspan="3" id='tc76' class="x241" style='border-right: 2px solid windowtext;'>#211</td>
                <td colspan="3" id='tc77' class="x241" style='border-right: 2px solid windowtext;'>#212</td>
                <td class="x108"></td>
                <td class="x164">
                    <font class="font6">門</font>
                </td>
            </tr>
            <tr height="28" style='mso-height-source: userset; height: 21pt' id='r25'>
                <td height="28" class="x22" style='height: 21pt;'></td>
                <td rowspan="2" height="56" class="x242" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext; height: 42pt;'></td>
                <td class="x36"></td>
                <td colspan="3" id='tc78' class="x53" style='border-right: 2px solid windowtext;'><asp:Label ID="CName209LB" runat="server" Text=""></asp:Label></td>
                <td colspan="3" id='tc79' class="x243" style='border-right: 2px solid windowtext;'><asp:Label ID="CName210LB" runat="server" Text=""></asp:Label></td>
                <td colspan="3" id='tc80' class="x53" style='border-right: 2px solid windowtext;'><asp:Label ID="CName211LB" runat="server" Text=""></asp:Label></td>
                <td colspan="3" id='tc81' class="x53" style='border-right: 2px solid windowtext;'><asp:Label ID="CName212LB" runat="server" Text=""></asp:Label></td>
                <td class="x168"></td>
                <td rowspan="4" height="119" class="x169" style='height: 89.25pt;'>
                    <font class="font6">門</font>
                </td>
                <td class="x170"></td>
                <td class="x170"></td>
                <td class="x170"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td rowspan="4" height="119" class="x134" style='border-right: 3px solid #FF0000; height: 89.25pt;'>
                    <font class="font6">門</font>
                </td>
            </tr>
            <tr height="28" style='mso-height-source: userset; height: 21pt' id='r26'>
                <td height="28" class="x22" style='height: 21pt;'></td>
                <td class="x172"></td>
                <td colspan="3" id='tc82' class="x61" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name209LB" runat="server" Text=""></asp:Label></td>
                <td colspan="3" id='tc83' class="x244" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name210LB" runat="server" Text=""></asp:Label></td>
                <td colspan="3" id='tc84' class="x61" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name211LB" runat="server" Text=""></asp:Label></td>
                <td colspan="3" id='tc85' class="x61" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext;'><asp:Label ID="Name212LB" runat="server" Text=""></asp:Label></td>
                <td class="x22"></td>
                <td class="x170"></td>
                <td class="x170"></td>
                <td class="x170"></td>
                <td class="x22"></td>
                <td class="x22"></td>
                <td class="x22"></td>
                <td class="x96"></td>
            </tr>
            <tr height="40" style='mso-height-source: userset; height: 30pt' id='r27'>
                <td height="40" class="x22" style='height: 30pt;'></td>
                <td class="x178"></td>
                <td class="x32"></td>
                <td class="x32"></td>
                <td class="x32"></td>
                <td class="x32"></td>
                <td class="x32"></td>
                <td class="x96"></td>
                <td class="x96"></td>
                <td class="x96"></td>
                <td class="x96"></td>
                <td class="x96"></td>
                <td class="x96"></td>
                <td class="x96"></td>
                <td class="x32"></td>
                <td class="x32"></td>
                <td class="x170"></td>
                <td class="x170"></td>
                <td class="x170"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x108"></td>
                <td class="x96"></td>
            </tr>
            <tr height="23" style='mso-height-source: userset; height: 17.25pt' id='r28'>
                <td height="23" class="x22" style='height: 17.25pt;'></td>
                <td colspan="2" id='tc86' class="x245" style='border-right: 1px solid windowtext;'></td>
                <td class="x181"></td>
                <td class="x181"></td>
                <td class="x181"></td>
                <td class="x181"></td>
                <td class="x105"></td>
                <td class="x105"></td>
                <td class="x105"></td>
                <td class="x105"></td>
                <td class="x182"></td>
                <td class="x183">門</td>
                <td class="x184"></td>
                <td class="x184"></td>
                <td class="x185">
                    <font class="font6">門</font>
                </td>
                <td class="x170"></td>
                <td class="x170"></td>
                <td class="x170"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x108"></td>
                <td class="x96"></td>
            </tr>
            <tr height="34" style='mso-height-source: userset; height: 25.5pt' id='r29'>
                <td height="34" class="x22" style='height: 25.5pt;'></td>
                <td colspan="14" id='tc87' rowspan="6" height="196" class="x246" style='border-right: 2px solid windowtext; border-bottom: 3px solid windowtext; height: 147pt;'>
                    <font class="font17">#288 / #289<br></font>
                    <font class="font18">李炤賢<br>總經理<br></font>
                    <font class="font17">Ivan</font>
                </td>
                <td rowspan="3" height="92" class="x247" style='border-right: 2px solid windowtext; border-bottom: 2px solid windowtext; height: 69pt; overflow: hidden;'>
                    <font class="font11">#291<br></font>
                    <font class="font6"><asp:Label ID="CName291LB" runat="server" Text=""></asp:Label><br></font>
                    <font class="font11"><asp:Label ID="Name291LB" runat="server" Text=""></asp:Label></font>
                </td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x22"></td>
                <td class="x22"></td>
                <td class="x108"></td>
                <td class="x96"></td>
                <td rowspan="2" height="63" class="x192" style='height: 47.25pt;'></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x193"></td>
            </tr>
            <tr height="29" style='mso-height-source: userset; height: 21.75pt' id='r30'>
                <td height="29" class="x22" style='height: 21.75pt;'></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x22"></td>
                <td class="x22"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x196"></td>
                <td class="x197">上下櫃</td>
                <td class="x108"></td>
                <td class="x198">
                    <font class="font6">業四</font>
                </td>
                <td class="x193"></td>
            </tr>
            <tr height="29" style='mso-height-source: userset; height: 21.75pt' id='r31'>
                <td height="29" class="x22" style='height: 21.75pt;'></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td height="29" class="x200" width="117" style='height: 21.75pt; width: 87.75pt;' align="left" valign="top">
                    <span style='mso-ignore: vglayout; position: absolute; z-index: 0; margin-left: 110px; margin-top: -28px; width: 55px; height: 112px'>
                        <img width="55" height="112" src="062911555236_files\image000.png" name='圖片 2'></span>
                    <span style='mso-ignore: vglayout2'>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="29" class="x200" width="117" style='height: 21.75pt; width: 87.75pt;'></td>
                            </tr>
                        </table>
                    </span>
                </td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x201"></td>
                <td class="x202"></td>
                <td class="x197">矮櫃</td>
                <td class="x32"></td>
                <td class="x32"></td>
                <td class="x193"></td>
            </tr>
            <tr height="29" style='mso-height-source: userset; height: 21.75pt' id='r32'>
                <td height="29" class="x22" style='height: 21.75pt;'></td>
                <td rowspan="3" height="104" class="x248" style='border-right: 2px solid windowtext; border-bottom: 3px solid windowtext; height: 78pt; overflow: hidden;'>
                    <font class="font11">#290<br></font>
                    <font class="font6"><asp:Label ID="CName290LB" runat="server" Text=""></asp:Label><br></font>
                    <font class="font11"><asp:Label ID="Name290LB" runat="server" Text=""></asp:Label></font>
                </td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x200"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x201"></td>
                <td class="x204"></td>
                <td class="x197">柱子</td>
                <td class="x32"></td>
                <td class="x205">
                    <font class="font6">業二</font>
                </td>
                <td class="x193"></td>
            </tr>
            <tr height="40" style='mso-height-source: userset; height: 30pt' id='r33'>
                <td height="40" class="x22" style='height: 30pt;'></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x200"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x201"></td>
                <td class="x206"></td>
                <td class="x207">量桌</td>
                <td class="x32"></td>
                <td class="x32"></td>
                <td class="x193"></td>
            </tr>
            <tr height="35" style='mso-height-source: userset; height: 26.25pt' id='r34'>
                <td height="35" class="x22" style='height: 26.25pt;'></td>
                <td class="x212"></td>
                <td class="x213"></td>
                <td class="x213"></td>
                <td class="x213"></td>
                <td class="x214">Elevator</td>
                <td class="x215"></td>
                <td class="x214">Elevator</td>
                <td class="x216"></td>
                <td class="x213"></td>
                <td colspan="4" id='tc88' class="x249" style='border-bottom: 3px solid windowtext;'>
                    <font class="font21">5F </font>
                    <font class="font22">業二</font>
                    <font class="font21"> / </font>
                    <font class="font22">業四</font>
                </td>
                <td class="x218"></td>
            </tr>
            <tr height="33" style='mso-height-source: userset; height: 24.95pt' id='r35'>
                <td height="33" class="x22" style='height: 24.95pt;'></td>
                <td class="x219"></td>
                <td class="x219"></td>
                <td class="x219"></td>
                <td class="x219"></td>
                <td class="x219"></td>
                <td class="x219"></td>
                <td class="x219"></td>
                <td class="x219"></td>
                <td class="x219"></td>
                <td class="x219"></td>
                <td class="x219"></td>
                <td class="x219"></td>
                <td class="x219"></td>
                <td class="x219"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x33"></td>
                <td class="x108"></td>
                <td class="x108"></td>
                <td class="x219"></td>
                <td class="x219"></td>
                <td class="x219"></td>
                <td class="x219"></td>
                <td class="x219"></td>
                <td class="x219"></td>
            </tr>
            <![if supportMisalignedColumns]>
        <tr height="0" style='display: none'>
            <td width="12" style='width: 9pt'></td>
            <td width="22" style='width: 16.5pt'></td>
            <td width="19" style='width: 14.25pt'></td>
            <td width="35" style='width: 26.25pt'></td>
            <td width="35" style='width: 26.25pt'></td>
            <td width="35" style='width: 26.25pt'></td>
            <td width="35" style='width: 26.25pt'></td>
            <td width="35" style='width: 26.25pt'></td>
            <td width="35" style='width: 26.25pt'></td>
            <td width="35" style='width: 26.25pt'></td>
            <td width="35" style='width: 26.25pt'></td>
            <td width="35" style='width: 26.25pt'></td>
            <td width="35" style='width: 26.25pt'></td>
            <td width="35" style='width: 26.25pt'></td>
            <td width="35" style='width: 26.25pt'></td>
            <td width="123" style='width: 92.25pt'></td>
            <td width="31" style='width: 23.25pt'></td>
            <td width="31" style='width: 23.25pt'></td>
            <td width="31" style='width: 23.25pt'></td>
            <td width="31" style='width: 23.25pt'></td>
            <td width="117" style='width: 87.75pt'></td>
            <td width="31" style='width: 23.25pt'></td>
            <td width="117" style='width: 87.75pt'></td>
            <td width="117" style='width: 87.75pt'></td>
            <td width="31" style='width: 23.25pt'></td>
            <td width="120" style='width: 90pt'></td>
            <td width="120" style='width: 90pt'></td>
            <td width="34" style='width: 25.5pt'></td>
            <td width="115" style='width: 86.25pt'></td>
            <td width="27" style='width: 20.25pt'></td>
        </tr>
            <![endif]>
        </table>

        <script language='javascript' type='text/javascript'>
            function ChangeColspanHiddenData() {
                var node;
                var ids = ["tc8", "tc52", "tc41", "tc47", "tc36", "tc25", "tc0", "tc65", "tc54", "tc53", "tc4", "tc88", "tc19", "tc23", "tc59", "tc48", "tc6", "tc82", "tc39", "tc28", "tc79", "tc68", "tc84", "tc42", "tc31", "tc20", "tc15", "tc71", "tc60", "tc86", "tc55", "tc44", "tc33", "tc22", "tc11", "tc17", "tc73", "tc9", "tc62", "tc51", "tc57", "tc40", "tc46", "tc35", "tc24", "tc1", "tc13", "tc75", "tc64", "tc5", "tc37", "tc26", "tc18", "tc77", "tc66", "tc76", "tc3", "tc67", "tc7", "tc80", "tc81", "tc49", "tc38", "tc78", "tc83", "tc30", "tc29", "tc14", "tc70", "tc69", "tc58", "tc85", "tc43", "tc32", "tc21", "tc27", "tc10", "tc16", "tc72", "tc61", "tc87", "tc50", "tc56", "tc45", "tc34", "tc2", "tc12", "tc74", "tc63"];
                var spans = ["4", "4", "4", "3", "4", "4", "4", "4", "3", "4", "4", "4", "4", "4", "4", "3", "4", "3", "4", "4", "3", "4", "3", "4", "4", "4", "4", "4", "4", "2", "4", "4", "4", "4", "4", "4", "7", "4", "3", "4", "4", "4", "4", "4", "4", "2", "4", "3", "4", "4", "4", "4", "4", "3", "4", "3", "4", "4", "4", "3", "3", "3", "4", "3", "3", "4", "4", "4", "4", "5", "3", "3", "4", "4", "4", "4", "4", "4", "4", "4", "14", "5", "4", "4", "4", "4", "4", "3", "4"];
                for (var i = 0; i < ids.length; i++) {
                    node = document.getElementById(ids[i]);
                    node.colSpan = spans[i];
                }
            }
            ChangeColspanHiddenData();
        </script>
        <script language='javascript' type='text/javascript'>
            function ChangeRowspanHiddenData() {
                var node;
                var params = ["r1", "r3", "r5", "r7", "r9", "r11", "r13", "r15", "r16", "r17", "r19", "r20", "r21", "r23", "r25", "r29", "r32"];
                for (var i = 0; i < params.length; i++) {
                    document.getElementById(params[i]).style.display = "";
                }
            }
            ChangeRowspanHiddenData();
        </script>
    </form>
</body>
<style>
    <!--
    .x220 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: nowrap;
        background: auto;
        mso-pattern: auto;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "Calibri","sans-serif";
        border-top: 3px solid windowtext;
        border-right: 1px solid windowtext;
        border-bottom: 1px solid windowtext;
        border-left: 3px solid windowtext;
        mso-diagonal-down: 1px solid windowtext;
        mso-diagonal-up: 1px solid windowtext;
        mso-protection: locked visible;
    }

    .x221 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: nowrap;
        background: auto;
        mso-pattern: auto;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "Calibri","sans-serif";
        border-top: 1px solid windowtext;
        border-right: 2px solid windowtext;
        border-bottom: 1px solid windowtext;
        border-left: 3px solid windowtext;
        mso-diagonal-down: 1px solid windowtext;
        mso-diagonal-up: 1px solid windowtext;
        mso-protection: locked visible;
    }

    .x222 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: normal;
        word-wrap: break-word;
        background: #FF99CC;
        mso-pattern: auto none;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "標楷體","cursive";
        border-top: none;
        border-right: 2px solid windowtext;
        border-bottom: none;
        border-left: 2px solid windowtext;
        mso-diagonal-down: none;
        mso-diagonal-up: none;
        mso-protection: locked visible;
    }

    .x223 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: nowrap;
        background: #FF99CC;
        mso-pattern: auto none;
        color: #000000;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "標楷體","cursive";
        border-top: none;
        border-right: 2px solid windowtext;
        border-bottom: none;
        border-left: 2px solid windowtext;
        mso-diagonal-down: none;
        mso-diagonal-up: none;
        mso-protection: locked visible;
    }

    .x224 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: nowrap;
        background: #FF99CC;
        mso-pattern: auto none;
        color: #000000;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "Calibri","sans-serif";
        border-top: none;
        border-right: 2px solid windowtext;
        border-bottom: 2px solid windowtext;
        border-left: 2px solid windowtext;
        mso-diagonal-down: none;
        mso-diagonal-up: none;
        mso-protection: locked visible;
    }

    .x225 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: normal;
        word-wrap: break-word;
        background: #FF99CC;
        mso-pattern: auto none;
        color: #000000;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "Calibri","sans-serif";
        border-top: 2px solid windowtext;
        border-right: 2px solid windowtext;
        border-bottom: none;
        border-left: 2px solid windowtext;
        mso-diagonal-down: none;
        mso-diagonal-up: none;
        mso-protection: locked visible;
    }

    .x226 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: normal;
        word-wrap: break-word;
        background: #FFFFFF;
        mso-pattern: auto none;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "標楷體","cursive";
        border-top: 2px dot-dot-dash windowtext;
        border-right: 2px dot-dot-dash windowtext;
        border-bottom: 2px dot-dot-dash windowtext;
        border-left: 3px solid #00FF00;
        mso-diagonal-down: none;
        mso-diagonal-up: none;
        mso-protection: locked visible;
    }

    .x227 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: bottom;
        white-space: normal;
        word-wrap: break-word;
        background: #CCFFFF;
        mso-pattern: auto none;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "Calibri","sans-serif";
        border-top: 2px dot-dot-dash windowtext;
        border-right: 3px solid #FF0000;
        border-bottom: none;
        border-left: 3px solid #00FF00;
        mso-diagonal-down: none;
        mso-diagonal-up: none;
        mso-protection: locked visible;
    }

    .x228 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: normal;
        word-wrap: break-word;
        background: auto;
        mso-pattern: auto;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "Calibri","sans-serif";
        border-top: 2px solid windowtext;
        border-right: 3px solid windowtext;
        border-bottom: 2px solid windowtext;
        border-left: 1px solid windowtext;
        mso-diagonal-down: none;
        mso-diagonal-up: none;
        mso-protection: locked visible;
    }

    .x229 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: nowrap;
        background: auto;
        mso-pattern: auto;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "Calibri","sans-serif";
        border-top: none;
        border-right: 1px solid windowtext;
        border-bottom: 1px solid windowtext;
        border-left: 1px solid windowtext;
        mso-diagonal-down: 1px solid windowtext;
        mso-diagonal-up: 1px solid windowtext;
        mso-protection: locked visible;
    }

    .x230 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: nowrap;
        background: #FF99CC;
        mso-pattern: auto none;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "Calibri","sans-serif";
        border-top: none;
        border-right: 2px solid windowtext;
        border-bottom: none;
        border-left: 2px solid windowtext;
        mso-diagonal-down: none;
        mso-diagonal-up: none;
        mso-protection: locked visible;
    }

    .x231 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: normal;
        word-wrap: break-word;
        background: auto;
        mso-pattern: auto;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "Calibri","sans-serif";
        border-top: 1px solid windowtext;
        border-right: 1px solid windowtext;
        border-bottom: 1px solid windowtext;
        border-left: 3px solid #00FF00;
        mso-diagonal-down: 1px solid windowtext;
        mso-diagonal-up: 1px solid windowtext;
        mso-protection: locked visible;
    }

    .x232 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: normal;
        word-wrap: break-word;
        background: #006600;
        mso-pattern: auto none;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "Calibri","sans-serif";
        border-top: 2px dot-dot-dash windowtext;
        border-right: 2px dot-dot-dash windowtext;
        border-bottom: 3px solid #00FF00;
        border-left: 2px dot-dot-dash windowtext;
        mso-diagonal-down: none;
        mso-diagonal-up: none;
        mso-protection: locked visible;
    }

    .x233 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: normal;
        word-wrap: break-word;
        background: #CCFFFF;
        mso-pattern: auto none;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "Calibri","sans-serif";
        border-top: none;
        border-right: 2px solid windowtext;
        border-bottom: 2px solid windowtext;
        border-left: 3px solid #00FF00;
        mso-diagonal-down: none;
        mso-diagonal-up: none;
        mso-protection: locked visible;
    }

    .x234 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: right;
        vertical-align: middle;
        white-space: nowrap;
        background: auto;
        mso-pattern: auto;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "Calibri","sans-serif";
        border-top: 1px solid windowtext;
        border-right: 3px solid #FF0000;
        border-bottom: 1px solid windowtext;
        border-left: none;
        mso-diagonal-down: none;
        mso-diagonal-up: none;
        mso-protection: locked visible;
    }

    .x235 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: normal;
        word-wrap: break-word;
        background: auto;
        mso-pattern: auto;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "Calibri","sans-serif";
        border-top: none;
        border-right: 3px solid #00FF00;
        border-bottom: none;
        border-left: 2px dot-dot-dash windowtext;
        mso-diagonal-down: none;
        mso-diagonal-up: none;
        mso-protection: locked visible;
    }

    .x236 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: general;
        vertical-align: middle;
        white-space: normal;
        word-wrap: break-word;
        background: auto;
        mso-pattern: auto;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "Calibri","sans-serif";
        border-top: none;
        border-right: 3px solid #00FF00;
        border-bottom: none;
        border-left: 2px dot-dot-dash windowtext;
        mso-diagonal-down: none;
        mso-diagonal-up: none;
        mso-protection: locked visible;
    }

    .x237 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: normal;
        word-wrap: break-word;
        background: auto;
        mso-pattern: auto;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "標楷體","cursive";
        border-top: 1px solid windowtext;
        border-right: 1px solid windowtext;
        border-bottom: 3px solid #00FF00;
        border-left: 3px solid #00FF00;
        mso-diagonal-down: 1px solid windowtext;
        mso-diagonal-up: 1px solid windowtext;
        mso-protection: locked visible;
    }

    .x238 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: nowrap;
        background: auto;
        mso-pattern: auto;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "Calibri","sans-serif";
        border-top: 1px solid windowtext;
        border-right: 2px solid windowtext;
        border-bottom: 1px solid windowtext;
        border-left: 1px solid windowtext;
        mso-diagonal-down: 1px solid windowtext;
        mso-diagonal-up: 1px solid windowtext;
        mso-protection: locked visible;
    }

    .x239 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: nowrap;
        background: auto;
        mso-pattern: auto;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "Calibri","sans-serif";
        border-top: 2px solid windowtext;
        border-right: 3px solid windowtext;
        border-bottom: 2px solid windowtext;
        border-left: 2px solid windowtext;
        mso-diagonal-down: none;
        mso-diagonal-up: none;
        mso-protection: locked visible;
    }

    .x240 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: normal;
        word-wrap: break-word;
        background: auto;
        mso-pattern: auto;
        font-size: 13pt;
        font-weight: 700;
        font-style: normal;
        font-family: "Calibri","sans-serif";
        border-top: 3px solid #00FF00;
        border-right: 2px solid windowtext;
        border-bottom: 2px solid windowtext;
        border-left: 2px solid windowtext;
        mso-diagonal-down: none;
        mso-diagonal-up: none;
        mso-protection: locked visible;
    }

    .x241 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: normal;
        word-wrap: break-word;
        background: #FF99CC;
        mso-pattern: auto none;
        color: #000000;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "Calibri","sans-serif";
        border-top: 2px solid windowtext;
        border-right: 2px solid windowtext;
        border-bottom: none;
        border-left: 2px solid windowtext;
        mso-diagonal-down: none;
        mso-diagonal-up: none;
        mso-protection: locked visible;
    }

    .x242 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: nowrap;
        background: auto;
        mso-pattern: auto;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "Calibri","sans-serif";
        border-top: 1px solid windowtext;
        border-right: 2px solid windowtext;
        border-bottom: 2px solid windowtext;
        border-left: 3px solid windowtext;
        mso-diagonal-down: 1px solid windowtext;
        mso-diagonal-up: 1px solid windowtext;
        mso-protection: locked visible;
    }

    .x243 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: nowrap;
        background: #FF99CC;
        mso-pattern: auto none;
        color: #215968;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "標楷體","cursive";
        border-top: none;
        border-right: 2px solid windowtext;
        border-bottom: none;
        border-left: 2px solid windowtext;
        mso-diagonal-down: none;
        mso-diagonal-up: none;
        mso-protection: locked visible;
    }

    .x244 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: nowrap;
        background: #FF99CC;
        mso-pattern: auto none;
        color: #215968;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "Calibri","sans-serif";
        border-top: none;
        border-right: 2px solid windowtext;
        border-bottom: 2px solid windowtext;
        border-left: 2px solid windowtext;
        mso-diagonal-down: none;
        mso-diagonal-up: none;
        mso-protection: locked visible;
    }

    .x245 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: nowrap;
        background: auto;
        mso-pattern: auto;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "Calibri","sans-serif";
        border-top: 1px solid windowtext;
        border-right: 1px solid windowtext;
        border-bottom: 2px solid windowtext;
        border-left: 3px solid windowtext;
        mso-diagonal-down: 1px solid windowtext;
        mso-diagonal-up: 1px solid windowtext;
        mso-protection: locked visible;
    }

    .x246 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: normal;
        word-wrap: break-word;
        background: auto;
        mso-pattern: auto;
        font-size: 14pt;
        font-weight: 400;
        font-style: normal;
        font-family: "Calibri","sans-serif";
        border-top: 2px solid windowtext;
        border-right: 2px solid windowtext;
        border-bottom: 3px solid windowtext;
        border-left: 3px solid windowtext;
        mso-diagonal-down: none;
        mso-diagonal-up: none;
        mso-protection: locked visible;
    }

    .x247 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: normal;
        word-wrap: break-word;
        background: #FF99CC;
        mso-pattern: auto none;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "Calibri Light","sans-serif";
        border-top: 3px solid #FF0000;
        border-right: 2px solid windowtext;
        border-bottom: 2px solid windowtext;
        border-left: 2px solid windowtext;
        mso-diagonal-down: none;
        mso-diagonal-up: none;
        mso-protection: locked visible;
    }

    .x248 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: normal;
        word-wrap: break-word;
        background: #FF99CC;
        mso-pattern: auto none;
        font-size: 13pt;
        font-weight: 400;
        font-style: normal;
        font-family: "Calibri Light","sans-serif";
        border-top: 2px solid windowtext;
        border-right: 2px solid windowtext;
        border-bottom: 3px solid windowtext;
        border-left: 2px solid windowtext;
        mso-diagonal-down: none;
        mso-diagonal-up: none;
        mso-protection: locked visible;
    }

    .x249 {
        mso-style-parent: style21;
        mso-number-format: General;
        text-align: center;
        vertical-align: middle;
        white-space: nowrap;
        background: auto;
        mso-pattern: auto;
        font-size: 26pt;
        font-weight: 700;
        font-style: normal;
        font-family: "Calibri","sans-serif";
        border-top: 2px dot-dot-dash windowtext;
        border-right: none;
        border-bottom: 3px solid windowtext;
        border-left: none;
        mso-diagonal-down: none;
        mso-diagonal-up: none;
        mso-protection: locked visible;
    }
    -->
</style>
</html>
