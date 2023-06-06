<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SampleASPNetDbSession.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Hello world <asp:Label ID="lblCounter" runat="server" Text=""></asp:Label>
            <asp:Button ID="btnCounter" runat="server" Text="Couter" OnClick="btnCounter_Click" />

        </div>
    </form>
</body>
</html>
