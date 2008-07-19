<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CdWUC.ascx.cs" Inherits="myWebApp.Controls.Update.CdWUC" %>
<div>
<ol>
    <li>
    <label for="<%=txtDureeMn.ClientID %>" style="display: -moz-inline-box;">
			        <span style="display: block; width: 120px; ">Durée (mn)</span></label> 
    <asp:TextBox ID="txtDureeMn" runat="server" Columns="10"></asp:TextBox>
    <asp:RegularExpressionValidator ID="rgDuree" runat="server" 
        ValidationExpression="\d+" 
        ControlToValidate="txtDureeMn" ErrorMessage="Durée en minutes invalide" />
    </li>    
</ol>
</div>