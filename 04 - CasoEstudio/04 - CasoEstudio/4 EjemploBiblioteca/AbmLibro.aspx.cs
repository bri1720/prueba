using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Xml;
using System.Configuration;
using System.Data;


public partial class AbmLibro : System.Web.UI.Page
{
    //atributos del formulario
    private int haySeleccion = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //mando a cargar la grilla con datos que ya contenga dicho archivo
            CargarDatos();

            //por defecto no tenemos nada seleccionado
            haySeleccion = 0;
            ViewState["haySeleccion"] = haySeleccion;

            //determino botones por defecto
            this.BotonesPorDefecto();

        }
        else
        {
            //mantengo el estado de si hubo haySeleccion o No para modificar y eliminar
            haySeleccion = (int)ViewState["haySeleccion"];
        }
    }

    private void CargarDatos()
    {
        try
        {

            //determino el comino completo de la hubicacion del archivo xml para abm
            string camino = Server.MapPath(ConfigurationManager.AppSettings["XmlLibros"]);

            //leo archivo
            DataSet ds = new DataSet();
            ds.ReadXml(camino);

            //cargo en grilla
            GVLibros.DataSource = ds;
            GVLibros.DataBind();

            //catgo datos autoress
            ds.ReadXml(Server.MapPath("~/XML/Autores.xml"), XmlReadMode.InferSchema);
            DdlAutor.DataSource = ds.Tables["Autor"];
            DdlAutor.DataTextField = "Nombre";
            DdlAutor.DataValueField = "codigo";
            DdlAutor.DataBind();


        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    private void BotonesPorDefecto()
    {
        BtnAlta.Enabled = true;
        BtnBaja.Enabled = false;
        BtnModificar.Enabled = false;
    }
    private void BotonesBM()
    {
        BtnAlta.Enabled = false;
        BtnBaja.Enabled = true;
        BtnModificar.Enabled = true;
    }
    private void LimpiarControles()
    {
        TxtIsbn.Text = "";
        TxtTitulo.Text = "";
        TxtCategoria.Text = "";
        DdlAutor.SelectedIndex = 0;
    }
    protected void GVLibros_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {


            string camino = Server.MapPath(ConfigurationManager.AppSettings["XmlLibros"]);
            //recupero el xml para agregar un nodo de libro
            XmlDocument DocumentoXml = new XmlDocument();
            DocumentoXml.Load(camino);

            //obtengo el nodo seleccionado en el primer nivel del archivo
            XmlNode nodoL = DocumentoXml.DocumentElement.ChildNodes[GVLibros.SelectedIndex];

            //determino que hay un nodo seleccionado
            ViewState["haySeleccion"] = GVLibros.SelectedIndex;

            //cargo datos en pantalla
            TxtIsbn.Text = nodoL["ISBN"].InnerText;
            TxtTitulo.Text = nodoL["Titulo"].InnerText;
            TxtCategoria.Text = nodoL.Attributes["Categoria"].InnerText;

            //determino el autpr recordar que solo puede haber un elemento seleccionado
            foreach (ListItem unItem in DdlAutor.Items)
            {
                if (unItem.Value == nodoL["Autor"].InnerText)
                {
                    unItem.Selected = true;
                }
                else
                {
                    unItem.Selected = false;
                }
                //determino acciones
                this.BotonesBM();
            }
        }
        catch (Exception ex)
        {

            LblError.Text = ex.Message;
        }
    }

    protected void BtnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            //archivo de origen de datos
            string camino = Server.MapPath(ConfigurationManager.AppSettings["XmlLibros"]);

            //recupero el xml para agregar un nodo de libro
            XmlDocument DocumentoXml = new XmlDocument();
            DocumentoXml.Load(camino);

            //creo el nodo libro con su atributo
            XmlNode NodoL = DocumentoXml.CreateNode(XmlNodeType.Element, "Libro", "");
            XmlAttribute AtributoCategoria = DocumentoXml.CreateAttribute("Categoria");
            AtributoCategoria.InnerText = TxtCategoria.Text.Trim();
            NodoL.Attributes.Append(AtributoCategoria);

            //creo el nodo ISBN
            XmlNode NodoI = DocumentoXml.CreateNode(XmlNodeType.Element, "ISBN", "");
            NodoI.InnerXml = TxtIsbn.Text.Trim();
            NodoL.AppendChild(NodoI);

            //creo el nodo titulo
            XmlNode NodoT = DocumentoXml.CreateNode(XmlNodeType.Element, "Titulo", "");
            NodoT.InnerXml = TxtTitulo.Text.Trim();
            NodoL.AppendChild(NodoT);

            //creo el nodo autor
            XmlNode NodoA = DocumentoXml.CreateNode(XmlNodeType.Element, "Autor", "");
            NodoA.InnerXml = DdlAutor.SelectedValue;
            NodoL.AppendChild(NodoA);

            //agrego el nodo libro al documento
            DocumentoXml.DocumentElement.AppendChild(NodoL);
            //grabo el archivo con la nueva informacion
            DocumentoXml.Save(camino);
            //actualzo la pantalla
            this.CargarDatos();
            this.LimpiarControles();
            this.BotonesPorDefecto();

            //se llege hasta aca todo ok
            LblError.Text = "Alta con exito";

        }
        catch (Exception ex)
        {

            LblError.Text = ex.Message;
        }
    }

    protected void BtnBaja_Click(object sender, EventArgs e)
    {
        try
        {
            //archivo de origen de datos
            string camino = Server.MapPath(ConfigurationManager.AppSettings["XmlLibros"]);

            //recupero el xml para eliminar un nodo de libro
            XmlDocument DocumentoXml = new XmlDocument();
            DocumentoXml.Load(camino);

            //verifica si hay algun libro seleccionado
            XmlNode nodoL = DocumentoXml.DocumentElement.ChildNodes[(int)ViewState["haySeleccion"]];

            if (nodoL == null)
            {
                LblError.Text = "no se puede eliminar por que no selecciono nada";
                return;
            }
            else
            {
                //elimino el nodo seleccionado
                DocumentoXml.DocumentElement.RemoveChild(nodoL);
                //guado los cambios
                DocumentoXml.Save(camino);
                //saco la seleccion
                ViewState["haySeleccion"] = 0;
                //actualio la pantalla
                this.CargarDatos();
                this.LimpiarControles();
                this.BotonesPorDefecto();

                LblError.Text = "Baja con exito";

            }

        }
        catch (Exception ex)
        {

            LblError.Text = ex.Message;
        }

    }

    protected void BtnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            //archivo de origen
            string camino = Server.MapPath(ConfigurationManager.AppSettings["XmlLibros"]);
            //recupero el documento
            XmlDocument documento = new XmlDataDocument();
            documento.Load(camino);

            //verifico si selecciono algun libro
            XmlNode nodoL = documento.DocumentElement.ChildNodes[(int)ViewState["haySeleccion"]];
            if (nodoL == null)
            {
                LblError.Text = "No se puede eliminar";
                return;
            }
            //modifico el nodo seleccionado
            nodoL["ISBN"].InnerText = TxtIsbn.Text.Trim();
            nodoL["Titulo"].InnerText = TxtTitulo.Text.Trim();
            nodoL.Attributes["Categoria"].InnerText = TxtCategoria.Text.Trim();
            nodoL["Autor"].InnerText = DdlAutor.SelectedValue;

            //salvo los cambops
            documento.Save(camino);
            //saco la seleccion
            ViewState["haySeleccion"] = 0;
            //actualizo pantalla
            this.CargarDatos();
            this.LimpiarControles();
            this.BotonesPorDefecto();
            LblError.Text = "modificacion con exito";


        }
        catch (Exception ex)
        {

            LblError.Text = ex.Message;
        }
    }

}