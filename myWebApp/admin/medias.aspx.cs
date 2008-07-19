using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

using MyConnector;
using MyConnector.Model;
using MyConnector.Interfaces;

namespace myWebApp.admin
{
    public partial class medias :  MyWebAppBasePage
    {
        AbstractMediaDetailWrite mycontrol = null;

        protected int MediaId
        {
            get
            {
                if (ViewState["mediaid"] == null )
                    if(!string.IsNullOrEmpty(Request.QueryString["id"]))
                        ViewState["mediaid"] = Convert.ToInt32(Request.QueryString["id"]);
                    else
                        throw new ArgumentNullException("id", "il manque l'identifiant du média");
                return (int) ViewState["mediaid"];
            }
            set
            {
                ViewState["mediaid"] = value;
            }
        }

        private Media _media = null;
        protected Media Media
        {
            get
            {
                if(_media==null)
                    _media = mediaManager.getMedia(MediaId);
                return _media;
            }            
        }

        protected string Action
        {
            get
            {
                return ViewState["Action"] as string ?? "add";
            }
            set
            {
                ViewState["Action"] = value;
            }
        }

        void bindAuteurs()
        {
            ddlAuteur.Items.Clear();
            ddlAuteur.Items.Add(new ListItem("<< Sélectionner un auteur >>", "-1"));
            List<Auteur> myauteurs = auteurManager.getAuteurs();
            foreach (IAuteur auteur in myauteurs)
                ddlAuteur.Items.Add(new ListItem(string.Format("{0} {1}",
                    auteur.Prenom, auteur.Nom), auteur.Id.ToString()));
        }

        /// <summary>
        ///     Remplissage des champs dans le case d'une mise à jour
        /// </summary>
        void dataToform()
        {
            bindAuteurs();
            if (Action == "upd")
            {
                ddlTypeMedia.SelectedIndex = (int) Media.MediaType;
                ddlTypeMedia.Enabled = false;

                txtTitre.Text = Media.Titre;
                txtResume.Text = Media.Resume;

                if (Media.Auteur != null)
                {
                    ddlAuteur.ClearSelection();
                    ddlAuteur.Items.FindByValue(Media.Auteur.Id.ToString()).Selected = true;
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // init de l'action en cours : add ou upd
            Action = Request.QueryString["action"];

            // init des types de médias
            foreach (string typemedia in Enum.GetNames(typeof(MediaType)))
                ddlTypeMedia.Items.Add(typemedia);
        }

        /// <summary>
        ///     Charge le contrôle suivant le type de média à gérer : Livre, Cd, ...
        /// </summary>
        void chargeMediaWUC()
        {
            mycontrol = LoadControl(string.Format("~/Controls/Update/{0}WUC.ascx", 
                ddlTypeMedia.SelectedValue)) as AbstractMediaDetailWrite;

            if(Action=="upd")
                mycontrol.LoadFormMedia(Media);
            
            lbDetail.Controls.Add(mycontrol);
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {                             
            btnValider.Click += new EventHandler(btnValider_Click);
            csVal.ServerValidate += new ServerValidateEventHandler(csVal_ServerValidate);
                        
            dmessage.Style.Clear();
            dmessage.Style.Add("display", "none");

            if (!IsPostBack)            
                dataToform();                
            
            chargeMediaWUC();
        }

        /// <summary>
        ///     Vérification titre
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        void csVal_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = !string.IsNullOrEmpty(txtTitre.Text);
        }

        /// <summary>
        ///     Enregistre les champs saisis dans le media
        /// </summary>
        /// <param name="media"></param>
        void SaveMedia(Media media)
        {
            media.Titre = txtTitre.Text;
            media.Resume = txtResume.Text;

            if (int.Parse(ddlAuteur.SelectedValue) != -1)
            {
                Auteur auteur = auteurManager.getAuteur(int.Parse(ddlAuteur.SelectedValue));
                media.Auteur = auteur;
            }

            mycontrol.SaveValuesToMedia(media);
            mediaManager.saveMedia(media);

            // passage au mode mise à jour
            ddlTypeMedia.Enabled = false;
            Action = "upd";
            MediaId = media.Id;
        }

        /// <summary>
        ///     Ajout/Màj média
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnValider_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Media media = null;
                switch(Action)
                {
                    case "upd" :
                        media = mediaManager.getMedia(MediaId);
                        break;
                    case "add":
                        //media = System.Reflection.Assembly.GetAssembly(typeof(MyConnector)).CreateInstance(ddlTypeMedia.SelectedValue) as Media; 
                        //media = System.Reflection.Assembly.GetEntryAssembly().CreateInstance(ddlTypeMedia.SelectedValue) as Media;                     
                        
                        // pas convainquant...
                        switch (ddlTypeMedia.SelectedValue)
                        {
                            case "Cd":
                                media = new Cd();
                                break;
                            case "Dvd":
                                media = new Dvd();
                                break;
                            case "Livre":
                                media = new Livre();
                                break;
                            case "Divx":
                                media = new Divx();
                                break;
                            case "Jeu" :
                                media = new Jeu();
                                break;
                            default:
                                throw new ArgumentException("Impossible de déterminer le type de média à sauvegarder");
                        }
                        break;
                    default:
                        throw new ArgumentNullException("type d'opération inconnue");
                }
                SaveMedia(media);                

                displayMessage("success", "Le média a bien été enregistré !");                
            }
            else
                displayMessage("error", csVal.ErrorMessage);
        }

        /// <summary>
        ///     bloc message succés ou erreur
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        void displayMessage(string type, string message)
        {
            dmessage.Attributes.Add("class", string.Format("section {0}", type));
            dmessage.Style.Add("display", "block");
            dmessage.InnerHtml = message;
        }
    }
}
