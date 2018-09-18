using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;




public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnbtnConsulta1_Click(object sender, EventArgs e)
    {
        GvResultado.DataSource = null;
        GvResultado.DataBind();
        TxtResultado.Text = "";

        XElement doc = System.Xml.Linq.XElement.Load(Server.MapPath("~/XML/Alumnos.XML"));

        var resultado = (from unNodo in doc.Elements("Alumno")
                         where (int)unNodo.Element("Nota") >= 70
                         select new
                         {
                             Nombre = unNodo.Element("Nombre").Value,
                             Apellido = unNodo.Element("Apellido").Value,
                             Nota = unNodo.Element("Nota").Value

                         }
                            ).ToList();
        GvResultado.DataSource = resultado;
        GvResultado.DataBind();
    }

    protected void btnbtnConsulta2_Click(object sender, EventArgs e)
    {
        GvResultado.DataSource = null;
        GvResultado.DataBind();
        TxtResultado.Text = "";

        XElement doc = System.Xml.Linq.XElement.Load(Server.MapPath("~/XML/Alumnos.XML"));

        var resultado = (from unNodo in doc.Elements("Alumno")
                         where (int)unNodo.Element("Nota") < 70
                         select new
                         {
                             Nombre = unNodo.Element("Nombre").Value,
                             Apellido = unNodo.Element("Apellido").Value,
                             Nota = unNodo.Element("Nota").Value

                         }
                            ).ToList();
        GvResultado.DataSource = resultado;
        GvResultado.DataBind();
    }

    protected void btnbtnConsulta3_Click(object sender, EventArgs e)
    {
        GvResultado.DataSource = null;
        GvResultado.DataBind();
        TxtResultado.Text = "";

        XElement doc = System.Xml.Linq.XElement.Load(Server.MapPath("~/XML/Alumnos.XML"));

        var resultado = (from unNodo in doc.Elements("Alumno")
                         where (int)unNodo.Element("Nota") >= 70
                         select unNodo).Count();


        TxtResultado.Text = "Cantidad de alumnos aprobados " + resultado; 
    }

    protected void btnbtnConsulta4_Click(object sender, EventArgs e)
    {
        GvResultado.DataSource = null;
        GvResultado.DataBind();
        TxtResultado.Text = "";

        XElement doc = System.Xml.Linq.XElement.Load(Server.MapPath("~/XML/Alumnos.XML"));

        var resultado = (from unNodo in doc.Elements("Alumno")
                       group unNodo by unNodo.Element("Materia").Value into tabla
                         select new
                         {
                             Materia = tabla.Key,
                             CantidadAlumno = tabla.Count()
                           

                         }
                            ).ToList();
        GvResultado.DataSource = resultado;
        GvResultado.DataBind();
    }
}