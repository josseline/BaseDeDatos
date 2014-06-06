<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BaseDeDatos.Vistas.FranjaHorario.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h2>Index <small>Franjas Horario</small></h2>
   
    <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="btnCrear_Click" /><br /><br /><br />
        <asp:GridView ID="gvFranjas" runat="server" CssClass="table  table-bordered table-striped"  AutoGenerateColumns="False" AllowSorting="True" DataSourceID="FranjasODS">
            <Columns>
             
                <asp:BoundField DataField="IdFranjaHorario" HeaderText="Id" SortExpression="IdFranjaHorario" />
                <asp:BoundField DataField="HoraInicio" HeaderText="Hora Inicio" />
                <asp:BoundField DataField="HoraFin" HeaderText="Hora Fin" />
                <asp:BoundField DataField="DiaSemana" HeaderText="Dia de la Semana" SortExpression="DiaSemana" />
              <asp:HyperLinkField DataNavigateUrlFields="IdFranjaHorario" DataNavigateUrlFormatString="Editar.aspx?IdFranjaHorario={0}" ControlStyle-CssClass="glyphicon glyphicon-edit" />
                   <asp:HyperLinkField DataNavigateUrlFields="IdFranjaHorario" DataNavigateUrlFormatString="Eliminar.aspx?IdFranjaHorario={0}" ControlStyle-CssClass="glyphicon glyphicon-remove" />
            </Columns>
        </asp:GridView>
     <asp:ObjectDataSource ID="FranjasODS" runat="server" SelectMethod="ObtenerTodas" TypeName="BaseDeDatos.Servicios.FranjaHorarioServicio" SortParameterName="sortBy">
      
     </asp:ObjectDataSource>
</asp:Content>
