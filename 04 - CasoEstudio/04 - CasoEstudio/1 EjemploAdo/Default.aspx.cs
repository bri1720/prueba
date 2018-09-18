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

using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    //objeto donde se guarda la info
    private DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            //es un posttback, obtengo la info de la memoria 
            ds = (DataSet)ViewState["ds"];
        }
        else {
            //es el primmero ingreso a la pagina - genero objeto para guardar info
            ds = new DataSet("Ventas");
            ViewState["ds"] = ds;
        }
    }

    protected void BtnAccion1_Click(object sender, EventArgs e)
    {
        //creo la conexion a bd 
        SqlConnection con = new SqlConnection("data source =.; initial catalog = Ventas; integrated security =true");
        
        //creo adaptadores
        SqlDataAdapter daFam = new SqlDataAdapter("select * from Familias", con);
        SqlDataAdapter daArt = new SqlDataAdapter("select * from Articulos", con);

        //cargo de los datos 
        daFam.Fill(ds,"Familias");
        daArt.Fill(ds, "Articulos");
        ViewState["ds"]=ds;

        //cargo lass grillas 
        GVFamilias.DataSource = ds.Tables["Familias"];
        GVFamilias.DataBind();
        GVArticulos.DataSource = ds.Tables["Articulos"];
        GVArticulos.DataBind();
    }

    protected void BtnAccion2_Click(object sender, EventArgs e)
    {
        //CREO DATASET PARA CARGAR EL ARCHIVO XML 
        DataSet dsaux = new DataSet();
        dsaux.ReadXml(Server.MapPath("~/XML/DatosXML.XML"));

        //combino la info que viene de db (y que ya esta en el dataset en memoria)
        //y la info del archivo xml, en un solo dataset
        ds.Merge(dsaux,true,MissingSchemaAction.Ignore);
        ViewState["ds"] = ds;

        //catrgo las grilla
        GVFamilias.DataSource = ds.Tables["Familias"];
        GVFamilias.DataBind();
        GVArticulos.DataSource = ds.Tables["Articulos"];
        GVArticulos.DataBind();
    }

    protected void BtnAccion3_Click(object sender, EventArgs e)
    {
        ds.WriteXmlSchema(Server.MapPath("~/XML/EsquemaXML.XML"));
        ds.WriteXml(Server.MapPath("~/XML/DatosEsqemaXML.XML"));
        ds.WriteXml(Server.MapPath("~/XML/DatosEsquemaXML.XML"), XmlWriteMode.WriteSchema);
    }
 
}
