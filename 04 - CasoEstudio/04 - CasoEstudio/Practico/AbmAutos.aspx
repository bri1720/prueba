<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AbmAutos.aspx.cs" Inherits="AbmAutos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: center;
        }
        .style3
        {
            width: 74px;
        }
        .style4
        {
            width: 473px;
        }
        .style5
        {
            width: 74px;
            height: 46px;
        }
        .style6
        {
            width: 473px;
            height: 46px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style2" colspan="3">
                    <strong>ABM Autos</strong></td>
            </tr>
            <tr>
                <td class="style3">
                    Matricula</td>
                <td class="style4">
                    <asp:TextBox ID="txtMatricula" runat="server"></asp:TextBox>
                </td>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    Marca</td>
                <td class="style4">
                    <asp:TextBox ID="txtMarca" runat="server"></asp:TextBox>
                </td>
                <td rowspan="4">
                    .</td>
            </tr>
            <tr>
                <td class="style5">
                    Modelo</td>
                <td class="style6">
                    <asp:TextBox ID="txtModelo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    Dueño CI</td>
                <td class="style6">
                    <asp:TextBox ID="txtDci" runat="server"></asp:TextBox>
                    Nombre<asp:TextBox ID="txtDn" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Precio</td>
                <td class="style4">
                    <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Button ID="Button1" runat="server" Text="Alta" />
                    <asp:Button ID="Button2" runat="server" Text="Modificar" />
                    <asp:Button ID="Button3" runat="server" Text="Eliminar" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="lblerror" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
