<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mydoc.aspx.cs" Inherits="myWebApp.mydoc" %>
<%@ Import Namespace="MyConnector.Interfaces" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>My Documents</title>   
    <link href="styles.css" rel="stylesheet" />
    <script src="http://ajax.googleapis.com/ajax/libs/prototype/1.6.0.2/prototype.js" 
        type="text/javascript" defer="defer"></script>    
    <script src="http://ajax.googleapis.com/ajax/libs/scriptaculous/1.8.1/scriptaculous.js" 
        type="text/javascript" defer="defer"></script>                    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="dmessage" runat="server" style="display: none;">
            <span id="smsg" runat="server"></span>
        </div>
        <a href="javascript:void(0);" title="Ajout d'un livre" class="plus" id="abook">Ajouter un livre >></a>
        <div id="dsaisie" style="display:none;">
            <div id="dform">
                <fieldset>		
		        <ol>
			        <li><label for="<%=txtTitre.ClientID %>" style="display: -moz-inline-box;">
			        <span style="display: block; width: 120px;">Titre <em>*</em></span></label> 
			        <asp:TextBox ID="txtTitre" runat="server" Width="250"></asp:TextBox>
			        <asp:CustomValidator ID="csVal" runat="server" Enabled="false"
			            ValidateEmptyText="true" 			           
			            EnableClientScript="false" 
			            ControlToValidate="txtTitre" ErrorMessage="Titre obligatoire" />
			        </li>
			        <li><label for="<%=txtResume.ClientID %>" style="display: -moz-inline-box;">
			        <span style="display: block; width: 120px;">Description</span></label> 
			        <asp:TextBox ID="txtResume" runat="server" Rows="5" Columns="80" TextMode="MultiLine"></asp:TextBox>
			        </li>			
		        </ol>
	            </fieldset>
	        </div>
	        <div id="dBtn" style="text-align: right">	
	            <asp:Button ID="btnValider" runat="server" Text="Valider" />
	        </div>
	    </div>
        </div>        
        <div id="lstDocs" style="width: 600px">
        <fieldset>
        <legend>Liste des livres</legend>
            <asp:Repeater id="rpBooks" runat="server">
                <HeaderTemplate><ol></HeaderTemplate>
                <ItemTemplate>
                    <li>
                    <asp:LinkButton ID="lnkDelete" runat="server"
                        OnClientClick="return confirm('Supprimer ce livre ?');"
                        CommandArgument="<%# ((ILivre)Container.DataItem).Id %>"       
                        CommandName="deleteBook"><img src="images/trash.gif" style="border: none;" alt="supprimer" title="Supprimer le livre"/></asp:LinkButton>
                    
                    <%# ((ILivre) Container.DataItem).Titre %>
                    <ul>
                        <li style="color: #777; font-size: 0.8em"><%# ((ILivre) Container.DataItem).Resume %></li>
                    </ul>
                    </li>
                </ItemTemplate>
                <FooterTemplate></ol></FooterTemplate>
            </asp:Repeater>
        </fieldset>
        </div>    
    </form>
    <script language="javascript" type="text/javascript">
                function setPlusMoins(elt,ahref) {		                            
		            if( $(elt).visible() )
		            {		        		            		                
		                Element.removeClassName(ahref,'plus');
		                Element.addClassName(ahref,'moins');
                    }
                    else
                    {                    
		                Element.removeClassName(ahref,'moins');
		                Element.addClassName(ahref,'plus');
                    }
		        } // bascule images + et -
		        
		        function initialize() {
		            Event.observe('abook','click',function() 
	                { 	                
	                    setPlusMoins(Element.toggle($('dsaisie')),'abook');	                
	                });		                
	                
		            setPlusMoins($('dsaisie'),$('abook'));		            		            
		            
		            if($('<%=dmessage.ClientID %>').visible())
		            {
		                new Effect.Highlight('<%=dmessage.ClientID %>');
		            }
		        } // init événements
		        
		        Event.observe(window, 'load', initialize, false);
            </script>
</body>
</html>
