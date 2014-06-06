<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Eliminar.aspx.cs" Inherits="BaseDeDatos.Vistas.Patrocinador.Eliminar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Eliminar <small>Patrocinador</small></h2>

    <h4>¿Seguro que desea eliminar el registro?</h4>
     <table>
         <tr>
              <td>
                <asp:Label ID="lblTituloNif" runat="server" Text="NIF:" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblNif" runat="server"></asp:Label>
                

            </td>
         </tr>
        <tr>
            <td>
                <asp:Label ID="lblTituloNombre" runat="server" Text="Nombre:" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblNombre" runat="server"></asp:Label>
                

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTituloDireccion" runat="server" Text="Direccion:" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblDireccion" runat="server"  ></asp:Label>
            </td>
        </tr>
    </table>
    <br />
   <div class="form-actions">
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-default" CausesValidation="false" OnClick="btnRegresar_Click"/>
         <asp:Button ID="btnGuardar" runat="server" Text="Confirmar" CssClass="btn btn-danger" OnClick="btnGuardar_Click"   />
    </div>
</asp:Content>
