<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">        
            <asp:Button ID="btnLoad" runat="server" Text="Load Data" OnClick="btnLoad_Click" />
            <asp:Button ID="btnProcess" runat="server" Text="Process Data" OnClick="btnProcess_Click" />
            <br />
        <div id="divPDF" runat="server">
            Hello
        </div>
        <asp:GridView ID="gvInvoice" runat="server" AutoGenerateColumns="true"></asp:GridView>
    </form>
</body>
</html>
