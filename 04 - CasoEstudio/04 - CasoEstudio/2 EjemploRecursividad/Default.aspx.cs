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

//agrego uso de XML
using System.Xml;

public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void BtnProcesar_Click(object sender, EventArgs e)
    {
        // limpio la caja de despligue
        TxtMostrar.Text = "";

        //levanto el atributo xml que voy a mostrar en la pagina
        XmlDocument _xmlAlumnos = new XmlDocument();
        _xmlAlumnos.Load(Server.MapPath("~/XML/Alumnos.xml"));
        //OBTENGO EL NODO RAIZ
        XmlNode _NodoRaiz = _xmlAlumnos.DocumentElement;

        //Muestro el nodo raiz en el listbox
        TxtMostrar.Text += "Nombre Nodo raiz: " + _NodoRaiz.Name + "\n";

        //invoco al metodo recursivo para mostrar todo el contenido
        MostrarNodoRecursivo(_NodoRaiz);
    }

    private void MostrarNodoRecursivo(XmlNode pNodo)
    {
        //recorro todos losnodos hijos directos del nodo que viene por parametro
        for (int indice = 0; indice < pNodo.ChildNodes.Count; indice++)
        {
            //preginto por el tipo de xmlNode por que solo me interesan etiquetas no textos contenidos
            if (pNodo.ChildNodes[indice].NodeType == XmlNodeType.Element)
            {
                //agrego el nombre de la etiqueta si estoy ante un elemento del tipo <elementos> pregunto si tiene elementos hijos, asi no indento (por eso pregunto por la cantidad de hijos mayor a 1 ya que el texto contenido se considera un hijo mas)
                if (pNodo.ChildNodes[indice].ChildNodes.Count > 1)
                {
                    TxtMostrar.Text += pNodo.ChildNodes[indice].Name + "\n";

                }
                else
                {
                    TxtMostrar.Text += "\t" + pNodo.ChildNodes[indice].Name;
                }
            }
            else
            {
                //agrego texto si estoy ante el contenido de un elemento <elemento> contenido </elemento>
                TxtMostrar.Text += ": " + pNodo.ChildNodes[indice].InnerText + "\n";
            }


            // si hay hijos mando a cada uno a mostrarse
            if (pNodo.ChildNodes.Count > 0)
            {
                MostrarNodoRecursivo(pNodo.ChildNodes[indice]);
            }
        }// fin recorrido nodos hijos


    }//fin recursividad

    protected void BtnAlReves_Click(object sender, EventArgs e)
    { // limpio la caja de despligue
        TxtMostrar.Text = "";

        //levanto el atributo xml que voy a mostrar en la pagina
        XmlDocument _xmlAlumnos = new XmlDocument();
        _xmlAlumnos.Load(Server.MapPath("~/XML/Alumnos.xml"));
        //OBTENGO EL NODO RAIZ
        XmlNode _NodoRaiz = _xmlAlumnos.DocumentElement;

        

        //invoco al metodo recursivo para mostrar todo el contenido
        MostrarNodoRecursivoReves(_NodoRaiz);
        //Muestro el nodo raiz en el listbox
        TxtMostrar.Text += "Nombre Nodo raiz: " + _NodoRaiz.Name + "\n";
    }
    private void MostrarNodoRecursivoReves(XmlNode pNodo)
    {
        //recorro todos losnodos hijos directos del nodo que viene por parametro
        for (int indice = pNodo.ChildNodes.Count-1; indice > -1; indice--)
        {
            //preginto por el tipo de xmlNode por que solo me interesan etiquetas no textos contenidos
            if (pNodo.ChildNodes[indice].NodeType == XmlNodeType.Element)
            {
                //agrego el nombre de la etiqueta si estoy ante un elemento del tipo <elementos> pregunto si tiene elementos hijos, asi no indento (por eso pregunto por la cantidad de hijos mayor a 1 ya que el texto contenido se considera un hijo mas)
                if (pNodo.ChildNodes[indice].ChildNodes.Count > 1)
                {
                    TxtMostrar.Text += pNodo.ChildNodes[indice].Name + "\n";

                }
                else
                {
                    TxtMostrar.Text += "\t" + pNodo.ChildNodes[indice].Name;
                }
            }
            else
            {
                //agrego texto si estoy ante el contenido de un elemento <elemento> contenido </elemento>
                TxtMostrar.Text += ": " + pNodo.ChildNodes[indice].InnerText + "\n";
            }
            // si hay hijos mando a cada uno a mostrarse
            if (pNodo.ChildNodes.Count > 0)
            {
                MostrarNodoRecursivoReves(pNodo.ChildNodes[indice]);
            }

        }
    }
}