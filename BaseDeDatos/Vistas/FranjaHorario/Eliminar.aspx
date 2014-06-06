<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Eliminar.aspx.cs" Inherits="BaseDeDatos.Vistas.FranjaHorario.Eliminar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <h2>Eliminar <small>Franja Horario</small></h2>

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
                <asp:Label ID="lblTituloHoraInicio" runat="server" Text="HoraInicio:" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblHoraInicio" runat="server"></asp:Label>
                

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTituloHoraFin" runat="server" Text="Hora Fin:" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblHoraFin" runat="server"  ></asp:Label>
            </td>
        </tr>
          <tr>
            <td>
                <asp:Label ID="lblTituloDiaSemana" runat="server" Text="Dia de la Semana:" Font-Bold="true"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblDiaSemana" runat="server"  ></asp:Label>
            </td>
        </tr>
    </table>
    <br />
   <div class="form-actions">
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-default" CausesValidation="false" OnClick="btnRegresar_Click"/>
         <asp:Button ID="btnGuardar" runat="server" Text="Confirmar" CssClass="btn btn-danger" OnClick="btnGuardar_Click"   />
    </div>
</asp:Content>
