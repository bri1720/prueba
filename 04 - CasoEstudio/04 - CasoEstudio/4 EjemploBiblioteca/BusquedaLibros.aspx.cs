using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Xml;
using System.Xml.Linq;


public partial class BusquedaLibros : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {

        //limpia el resutado anterior
        GvResultado.DataSource = null;
        GvResultado.DataBind();
        //origen de datos
        XElement doc = System.Xml.Linq.XElement.Load(Server.MapPath("~/XML/Libros.xml"));

        //linq busqueda ISBN
        if (DdlTipo.SelectedIndex == 0)
        {
            var r = (from unNodo in doc.Elements("Libro")
                     where (int)unNodo.Element("ISBN") == Convert.ToInt32(txtDato.Text)
                     select new
                     {
                         Titulo = unNodo.Element("Titulo").Value,
                         Categoria = unNodo.Attribute("Categoria").Value
                     }).ToList<object>();
            GvResultado.DataSource = r;
            GvResultado.DataBind();
        }


        //linq busqueda titulo
        if (DdlTipo.SelectedIndex == 1)
        {
            var r = (from unNodo in doc.Elements("Libro")
                     where (string)unNodo.Element("Titulo") == txtDato.Text.Trim()
                     select new
                     {
                         ISBN = unNodo.Element("ISBN").Value,
                         Titulo = unNodo.Element("Titulo").Value,
                         Categoria = unNodo.Attribute("Categoria").Value
                     }).ToList<object>();
            GvResultado.DataSource = r;
            GvResultado.DataBind();
        }
        //linq busqueda categoria
        if (DdlTipo.SelectedIndex == 2)
        {
            var r = (from unNodo in doc.Elements("Libro")
                     where (string)unNodo.Attribute("Categoria") == txtDato.Text.Trim()
                     select new
                     {
                         ISBN = unNodo.Element("ISBN").Value,
                         Titulo = unNodo.Element("Titulo").Value,
                         Categoria = unNodo.Attribute("Categoria").Value
                     }).ToList<object>();
            GvResultado.DataSource = r;
            GvResultado.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //limpia el resutado anterior
        GvResultado.DataSource = null;
        GvResultado.DataBind();
        //origen de datos
        XElement doc = System.Xml.Linq.XElement.Load(Server.MapPath("~/XML/Libros.xml"));
        var r = (from unNodo in doc.Elements("Libro")
                
                 group unNodo by unNodo.Attribute("Categoria").Value into g
                 select new
                 {
                    Categoria=g.Key,
                     Cantidad=g.Count()
                    
                 }).ToList<object>();
        GvResultado.DataSource = r;
        GvResultado.DataBind();
    }
}