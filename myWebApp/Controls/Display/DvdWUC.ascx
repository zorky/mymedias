<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DvdWUC.ascx.cs" Inherits="myWebApp.Controls.Display.DvdWUC" %>
<%@ Import Namespace="MyConnector.Interfaces" %>

<div id="dvd">
<span>Région : <%= ((IDvd)Media).Region == null || ((IDvd)Media).Region == 0 ? "/" : ((IDvd)Media).Region.ToString()%></span>
</div>