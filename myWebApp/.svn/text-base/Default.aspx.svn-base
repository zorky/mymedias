<%@ Page Language="C#" MasterPageFile="~/Themes/SiteDefault.Master" AutoEventWireup="true" 
    CodeFile="default.aspx.cs" Inherits="myWebApp.default_" Title="My Medias" MaintainScrollPositionOnPostback="true" %>
<%@ Import Namespace="MyConnector.Interfaces" %>
<%@ Import Namespace="MyConnector.Model" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH" runat="server">
    <div style="width: 650px">
        <div id="dmessage" runat="server" style="display: none;">
            <span id="smsg" runat="server"></span>
        </div>        
        <div style="text-align: right">
            <a title="ajouter un média" href="admin/medias.aspx?action=add" 
                style="color: red; font-size: 0.7em;">ajouter un média à la bibliothèque</a>          
        </div>
        <div id="lstMedias">
        <fieldset>
        <legend style="color: Gray">Ma bibliothèque</legend>                                
            <uc:listemedia id="media" runat="server" />
        </fieldset>
        </div>           
     </div> 
</asp:Content>
