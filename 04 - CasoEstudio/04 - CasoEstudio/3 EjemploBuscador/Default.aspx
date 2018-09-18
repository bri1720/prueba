<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <style type="text/css">
        .style2
        {
            color: #CC0066;
            font-weight: bold;
            text-decoration: underline;
        }
        .style3
        {
            width: 401px;
        }
        .style4
        {
            color: #CC0066;
            font-weight: bold;
            text-decoration: underline;
            width: 401px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:50%;">
            <tr>
                <td class="style2" colspan="3" style="text-align: center">
                    Ejemplo de Buscador de Datos Sobre un Archivo XML bien Formado</td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td class="style3" >
                    &nbsp;</td>
                <td >
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style3" >
                    Alumnos que han aprobado</td>
                <td >
        <asp:Button ID="btnConsulta1" runat="server"  
            Text="Consultar" onclick="btnbtnConsulta1_Click" />
                </td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td  >
                    Alumnos que No han aprobado</td>
                <td >
        <asp:Button ID="btnConsulta2" runat="server"  
            Text="Consultar" onclick="btnbtnConsulta2_Click" />
                </td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td class="style3" >
                    &nbsp;</td>
                <td >
                    &nbsp;</td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td class="style3" >
                    Cantidad de Alumnos que aprobaron&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td >
        <asp:Button ID="btnConsulta3" runat="server"  
            Text="Consultar" onclick="btnbtnConsulta3_Click" />
                </td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td class="style3" >
                    &nbsp;</td>
                <td >
                    &nbsp;</td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td class="style3" >
                    Cantidad de Alumnos por Materia</td>
                <td >
        <asp:Button ID="btnConsulta4" runat="server"  
            Text="Consultar" onclick="btnbtnConsulta4_Click" />
                </td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td class="style3" >
                    &nbsp;</td>
                <td >
                    &nbsp;</td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td class="style4" >
                    Resultados</td>
                <td >
                    &nbsp;</td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td class="style3"  >
                    &nbsp;</td>
                <td >
                    &nbsp;</td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td class="style3"  >
                    <asp:TextBox ID="TxtResultado" runat="server" BackColor="#CCFFCC" 
                        BorderStyle="None" Width="283px"></asp:TextBox>
                </td>
                <td >
                    &nbsp;</td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td class="style3"  >
                    &nbsp;</td>
                <td >
                    &nbsp;</td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td class="style3"  >
                    <asp:GridView ID="GvResultado" runat="server" Width="393px">
                    </asp:GridView>
                </td>
                <td >
                    &nbsp;</td>
            </tr>
        </table>

    
    </div>
    </form>
</body>
</html>
