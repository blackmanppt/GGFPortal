<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AutoComplete.aspx.cs" Inherits="GGFPortal.test.AutoComplete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <ajaxToolkit:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server"  ServiceMethod="SearchCustomers"
            MinimumPrefixLength="2" CompletionInterval="100" 
            EnableCaching="false" CompletionSetCount="10" TargetControlID="TextBox1" FirstRowSelected = "false">
        </ajaxToolkit:AutoCompleteExtender>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
