<%@ Page Language="C#" MasterPageFile="~/Themes/SiteDefault.Master" AutoEventWireup="true" 
 CodeFile="medias.aspx.cs" Inherits="myWebApp.admin.medias" Title="Gestion des médias" %>
<%@ Import Namespace="MyConnector.Interfaces" %>
<%@ Import Namespace="MyConnector.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH" runat="server">
<div>
        <div id="dmessage" runat="server" style="display: none;">
            <span id="smsg" runat="server"></span>
        </div>
        <span>
                <a href="../" style="font-size: 0.7em">accueil</a>
        </span>
        <div id="dsaisie">            
            <div id="dform" style="width: 650px">            
                <div id="typemedia" style="text-align: right">
                <span style="color: Gray">Type de média <em>*</em> : </span> 
                <asp:DropDownList ID="ddlTypeMedia" runat="server" AutoPostBack="true"/>
                </div>
                <div id="fform">
                <fieldset>		
		        <ol>
			        <li>			        
			        <img src="../Themes/images/info.png" id="titreinfo" alt="aide titre" />
			        <label for="<%=txtTitre.ClientID %>" style="display: -moz-inline-box;">
			        <span style="display: block; width: 120px;">Titre <em>*</em></span></label> 
			        <asp:TextBox ID="txtTitre" runat="server" Columns="80"></asp:TextBox>
			        <asp:CustomValidator ID="csVal" runat="server"
			            ValidateEmptyText="true" 			           
			            EnableClientScript="false" 
			            ControlToValidate="txtTitre" ErrorMessage="Titre obligatoire" />
			        </li>
			        <li>
			            <img src="../Themes/images/info.png" id="resumeinfo" alt="aide résumé" />
			            <label for="<%=txtResume.ClientID %>" style="display: -moz-inline-box;">
			            <span style="display: block; width: 120px;">Résumé</span></label> 
			            <asp:TextBox ID="txtResume" runat="server" Rows="5" Columns="80" TextMode="MultiLine"></asp:TextBox>
			        </li>	
			        <li>
			            <label for="<%=ddlAuteur.ClientID %>" style="display: -moz-inline-box;">
			            <span style="display: block; width: 120px;">Auteur</span></label> 
			            <asp:DropDownList ID="ddlAuteur" runat="server">
			            </asp:DropDownList>
			        </li>
			        <!-- affichage du contrôle chargé de gérer le type spécifique (Livre, Cd, ...)-->
			        <asp:Label ID="lbDetail" runat="server"/>		
		        </ol>
	            </fieldset>
	            </div>
	        </div>
	        <div id="dBtn" style="text-align: right">	
	            <asp:Button ID="btnValider" runat="server" Text="Valider" />
	        </div>
	    </div>	    
</div>
<script language="javascript" type="text/javascript">
                
		        function initialize() {		            
		            if($('<%=dmessage.ClientID %>').visible())
		            {
		                new Effect.Highlight('<%=dmessage.ClientID %>');
		            }		            
		                                              
                    new Tip('titreinfo', 'Le titre est obligatoire', {
                      title: 'Titre de l\'ouvrage',
                      style: 'protogrey',
                      stem: 'topLeft',
                      hook: { tip: 'topLeft', mouse: true },
                      offset: { x: 14, y: 14 }
                    });
                    
                    new Tip('resumeinfo', 'Une brève description du livre', {
                      title: 'Le résumé (optionnel)',
                      style: 'protogrey',
                      stem: 'topLeft',
                      hook: { tip: 'topLeft', mouse: true },
                      offset: { x: 14, y: 14 }
                    });
        
		        } // init événements
		        
		        Event.observe(window, 'load', initialize, false);
            </script>
</asp:Content>
