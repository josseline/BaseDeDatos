<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Eliminar.aspx.cs" Inherits="BaseDeDatos.Vistas.CadenaEmisora.Eliminar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h2>Eliminar <small>Cadena - Emisora</small></h2>

    <h4>¿Seguro que desea eliminar Cadena - Emisora?</h4>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Id: " Font-Bold="true"></asp:Label>
                <asp:Label ID="lblCadenaId" runat="server" Text="Id cadena: "></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="NombreCadena: " Font-Bold="true"></asp:Label>
                <asp:Label ID="lblNombreCadena" runat="server" Text="Nombre Cadena: "></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Nif emisora: " Font-Bold="true"></asp:Label>
                <asp:Label ID="lblNifEmisora" runat="server" Text="Nif emisora: "></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Nombre emisora: " Font-Bold="true"></asp:Label>
                <asp:Label ID="lblNombreEmisora" runat="server" Text="Nombre emisora: "></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Nif director: " Font-Bold="true"></asp:Label>
                <asp:Label ID="lblNifRepresentante" runat="server" Text="Nif director: "></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Nombre director: " Font-Bold="true"></asp:Label>
                <asp:Label ID="lblNombreRepresentante" runat="server" Text="Nombre director: "></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Es central: " Font-Bold="true"></asp:Label>
                <asp:Label ID="lblEsCentral" runat="server" Text="Es central: "></asp:Label>
            </td>
        </tr>
    </table>

    <div class="form-actions">
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-default" CausesValidation="false" OnClick="btnRegresar_Click"/>
         <asp:Button ID="btnGuardar" runat="server" Text="Confirmar" CssClass="btn btn-danger" OnClick="btnGuardar_Click"   />
    </div>
</asp:Content>
