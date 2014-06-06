<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Eliminar.aspx.cs" Inherits="BaseDeDatos.Vistas.Contrato.Eliminar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
             <h2>Eliminar <small>Contrato</small></h2>

    <h4>¿Seguro que desea eliminar Contrato?</h4>
     <table>
         <tr>
              <td>
                <asp:Label ID="lblTituloId" runat="server" Text="Id: " Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblContrato" runat="server"></asp:Label>
                

            </td>
         </tr>
            <tr>
              <td>
                <asp:Label ID="lblTituloDuracion" runat="server" Text="Duración: :" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblDuracion" runat="server"></asp:Label>
                

            </td>
         </tr>

            <tr>
              <td>
                <asp:Label ID="lblTituloPatrocinador" runat="server" Text="Id:" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPatrocinador" runat="server"></asp:Label>
                

            </td>
         </tr>
     
    </table>
    <br />
   <div class="form-actions">
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-default" CausesValidation="false" OnClick="btnRegresar_Click"/>
         <asp:Button ID="btnGuardar" runat="server" Text="Confirmar" CssClass="btn btn-danger" OnClick="btnGuardar_Click"   />
    </div>
</asp:Content>
