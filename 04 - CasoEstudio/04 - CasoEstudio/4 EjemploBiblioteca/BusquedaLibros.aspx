<%@ Page Title="" Language="C#" MasterPageFile="~/MP.master" AutoEventWireup="true" CodeFile="BusquedaLibros.aspx.cs" Inherits="BusquedaLibros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <table style="width: 773px" >
            <tr>
                <td colspan="2" class="style2" style="text-align: center"> Busqueda de Libros</td>
            </tr>
            <tr>
                <td class="style4">Tipo de Busqueda:</td>
                <td><asp:DropDownList ID="DdlTipo" runat="server" Height="24px" Width="126px">
                    <asp:ListItem>ISBN</asp:ListItem>
                    <asp:ListItem>Titulo</asp:ListItem>
                    <asp:ListItem>Categoria</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="style4">Introduzca dato</td>
                <td><asp:TextBox ID="txtDato" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2"><asp:Button ID="BtnBuscar" runat="server" Text="Buscar" 
                        onclick="BtnBuscar_Click" />
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                        Text="Cantidad de libros por categoris" />
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2"><asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="style4" colspan="2">Resultado:</td>
            </tr>
            <tr>
                <td class="style4" colspan="2">
                    <asp:GridView ID="GvResultado" runat="server" Width="708px">
                    </asp:GridView>
                </td>
            </tr>
        </table>
</asp:Content>

