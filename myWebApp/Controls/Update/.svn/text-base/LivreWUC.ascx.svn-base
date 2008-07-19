<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LivreWUC.ascx.cs" Inherits="myWebApp.Controls.Update.LivreWUC" %>

<div>
<ol>
    <li>
    <label for="<%=txtNbPages.ClientID %>" style="display: -moz-inline-box;">
			        <span style="display: block; width: 120px;">Nb. pages</span></label> 
    <asp:TextBox ID="txtNbPages" runat="server" Columns="10"></asp:TextBox>
    <asp:RegularExpressionValidator ID="rgPages" runat="server" 
        ValidationExpression="\d+" 
        ControlToValidate="txtNbPages" ErrorMessage="Nombre de page invalide" />    
    </li>
    <li>
    <label for="<%=txtIsbn.ClientID %>" style="display: -moz-inline-box;">
			        <span style="display: block; width: 120px;">Isbn</span></label> 
			        <asp:TextBox ID="txtIsbn" runat="server" Width="250"></asp:TextBox>
    </li>
</ol>
</div>
