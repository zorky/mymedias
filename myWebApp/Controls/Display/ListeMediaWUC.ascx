<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListeMediaWUC.ascx.cs" Inherits="myWebApp.Controls.Display.ListeMediaWUC" %>
<%@ Import Namespace="MyConnector.Interfaces" %>

<div id="dliste">
    <asp:Repeater id="rpBooks" runat="server">
        <HeaderTemplate><ol></HeaderTemplate>
        <ItemTemplate>            
            <li>
            <span id="sdel" style="float: right;">
                <asp:LinkButton ID="lnkDelete" runat="server"
                    OnClientClick="return confirm('Supprimer cet élément ?');"
                    CommandArgument="<%# ((IMedia)Container.DataItem).Id %>"       
                    CommandName="deleteMedia">
                    <img src="Themes/images/trash.gif" style="border: none;" alt="supprimer" title="Supprimer l'élément"/></asp:LinkButton>
                    
                <a title="éditer le média" href="admin/medias.aspx?id=<%# ((IMedia)Container.DataItem).Id %>&action=upd" style="color: red; font-size: 0.7em">edit</a>                            
            </span>
            <div id="dDisplay" style="clear: both;">
                <span id="sIcon"><%# afficheIcon((IMedia)Container.DataItem, null)%></span>
                <span id="sTitre" style="color: #640000">
                    <%# ((IMedia)Container.DataItem).Titre %> 
                </span>
                <span id="sAuteur" style="color: #777; font-size: 0.9em;">                        
                        <%# ((IMedia)Container.DataItem).Auteur != null ? string.Format("({0} {1})", 
                                ((IMedia)Container.DataItem).Auteur.Prenom, ((IMedia)Container.DataItem).Auteur.Nom) : string.Empty%>                        
                </span>
                <%# afficheDetails((IMedia)Container.DataItem, null) %>                     
                <ul>
                    <li style="color: #777; font-size: 0.8em; text-align: justify"><%# ((IMedia)Container.DataItem).Resume%></li>
                </ul>
            </div>                                                  
            <div class="rating" style="display: none">
                <ul>
                    <li><a class="one-star">1</a></li>
                    <li><a class="two-stars">2</a></li>
                    <li><a class="three-stars">3</a></li>
                    <li><a class="four-stars">4</a></li>
                    <li><a class="five-stars">5</a></li>
                </ul>
            </div>
            </li>
            <li><hr style="color: #A17777; text-decoration: underline; text-align: center; width: 500px" /></li>
        </ItemTemplate>
        <FooterTemplate></ol></FooterTemplate>
    </asp:Repeater>
</div>
