<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Eliminar.aspx.cs" Inherits="BaseDeDatos.Vistas.BandaHertziana.Eliminar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h2>Eliminar <small>Banda Hertziana</small></h2>

    <h4>¿Seguro que desea eliminar el registro?</h4>
     <table>
         <tr>
              <td>
                <asp:Label ID="lblTituloId" runat="server" Text="Id:" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblId" runat="server"></asp:Label>
                

            </td>
         </tr>
        <tr>
            <td>
                <asp:Label ID="lblTituloDescripcion" runat="server" Text="Descripcion:" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTituloDel" runat="server" Text="Del:" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblDel" runat="server"  ></asp:Label> 
            </td>
        </tr>
          <tr>
            <td>
                <asp:Label ID="lblTituloAl" runat="server" Text="Al:" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblAl" runat="server"  ></asp:Label>
            </td>
        </tr>
    </table>
    <br />
   <div class="form-actions">
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-default" CausesValidation="false" OnClick="btnRegresar_Click" />
         <asp:Button ID="btnGuardar" runat="server" Text="Confirmar" CssClass="btn btn-danger" OnClick="btnGuardar_Click"   />
    </div>
</asp:Content>
