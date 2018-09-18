using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Configuration;
using System.Data;

public partial class AbmAutos : System.Web.UI.Page
{
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
            //this.BotonesPorDefecto();

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
            string camino = Server.MapPath(ConfigurationManager.AppSettings["XmlAutos"]);

            //leo archivo
            DataSet ds = new DataSet();
            ds.ReadXml(camino);

            //cargo en grilla
            gvAutos.DataSource = ds;
            gvAutos.DataBind();







        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void gvAutos_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
          {


            string camino = Server.MapPath(ConfigurationManager.AppSettings["XmlAutos"]);
            //recupero el xml para agregar un nodo de libro
            XmlDocument DocumentoXml = new XmlDocument();
            DocumentoXml.Load(camino);

            //obtengo el nodo seleccionado en el primer nivel del archivo
            XmlNode nodoA = DocumentoXml.DocumentElement.ChildNodes[gvAutos.SelectedIndex];

            //determino que hay un nodo seleccionado
            ViewState["haySeleccion"] = gvAutos.SelectedIndex;

            //cargo datos en pantalla
            txtMatricula.Text = nodoA["Matricula"].InnerText;
            txtMarca.Text = nodoA["Marca"].InnerText;
            txtModelo.Text = nodoA["Modelo"].InnerText;
            txtPrecio.Text = nodoA["Precio"].InnerText;
            txtDci.Text = nodoA["Dueño"].InnerText;

            //determino el autpr recordar que solo puede haber un elemento seleccionado
            //foreach (ListItem unItem in DdlAutor.Items)
            //{
            //    if (unItem.Value == nodoL["Autor"].InnerText)
            //    {
            //        unItem.Selected = true;
            //    }
            //    else
            //    {
            //        unItem.Selected = false;
            //    }
            //    //determino acciones
            //    this.BotonesBM();
            //}
        }
        catch (Exception ex)
        {

            lblerror.Text = ex.Message;
        }
    }
}