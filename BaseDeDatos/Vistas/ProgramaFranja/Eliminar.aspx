<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Eliminar.aspx.cs" Inherits="BaseDeDatos.Vistas.ProgramaFranja.Eliminar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
             <h2>Eliminar <small>Programa Franja</small></h2>

    <h4>¿Seguro que desea eliminar el registro?</h4>
     <table>
         <tr>
              <td>
                <asp:Label ID="lblTituloId" runat="server" Text="Codigo Programa Franja:  " Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblId" runat="server" Font-Bold="true"></asp:Label>
                

            </td>
         </tr>
         <tr>
             <td>
               <asp:Label ID="lblTituloPrograma" runat="server" Text="Programa:" Font-Bold="true"></asp:Label>
                 </td>
               <td>
               <asp:Label ID="lblPrograma" runat="server" Text="Programa" Font-Bold="true"></asp:Label>
                 </td>
         </tr>
           <tr>
             <td>
               <asp:Label ID="lblTituloFranjaHorario" runat="server" Text="Franja Horario:" Font-Bold="true"></asp:Label>
                 </td>
               <td>
               <asp:Label ID="lblFranjaHorario" runat="server" Text="Programa" Font-Bold="true"></asp:Label>
                 </td>
         </tr>
     
    </table>
    <br />
   <div class="form-actions">
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-default" CausesValidation="false" OnClick="btnRegresar_Click"/>
         <asp:Button ID="btnGuardar" runat="server" Text="Confirmar" CssClass="btn btn-danger" OnClick="btnGuardar_Click"   />
    </div>
</asp:Content>
