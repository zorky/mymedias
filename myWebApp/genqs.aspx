<%@ Page Language="C#" AutoEventWireup="true" CodeFile="genqs.aspx.cs" Inherits="myWebApp._genqs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>cr�ation URL</title>
    <style type="text/css">
    .gras
    {
        font-weight: bold;
        color: brown
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Querystring g�n�r�e : <asp:Label ID="lbKey" runat="server" CssClass="gras"></asp:Label>
        <br />
        URL cliente avec la querystring : <asp:HyperLink ID="hpHref" runat="server"></asp:HyperLink><br />
        modifier une des valeurs d'un des param�tres.
    </div>
    </form>
</body>
</html>
