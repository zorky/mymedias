<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LivreWUC.ascx.cs" Inherits="myWebApp.Controls.Display.LivreWUC" %>
<%@ Import Namespace="MyConnector.Interfaces" %>

<div id="livre" style="margin-top: 10px">
<span>Nombre de pages : <%=((ILivre)Media).NbPages == 0 ? "/" : ((ILivre)Media).NbPages.ToString()%> </span><br />
<span>Isbn : <%= string.IsNullOrEmpty(((ILivre)Media).Isbn) ? "/" : ((ILivre)Media).Isbn%></span>
</div>
