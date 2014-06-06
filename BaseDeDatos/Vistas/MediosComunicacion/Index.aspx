<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BaseDeDatos.Vistas.MediosComunicacion.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <h2>Index <small>Medios Comunicacion</small></h2>
   
    <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="btnCrear_Click"/><br /><br /><br />
        <asp:GridView ID="gvCadenas" runat="server" CssClass="table  table-bordered table-striped"  AutoGenerateColumns="False"  AllowSorting="True" DataSourceID="CadenasODS">
            <Columns>
                  <asp:BoundField DataField="Nif" HeaderText="Nif" SortExpression="Nif" />
                  <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                  <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
                  <asp:BoundField DataField="NombrePersona" HeaderText="Director" />
                   <asp:HyperLinkField DataNavigateUrlFields="Nif" DataNavigateUrlFormatString="Editar.aspx?Nif={0}" ControlStyle-CssClass="glyphicon glyphicon-edit" />
                   <asp:HyperLinkField DataNavigateUrlFields="Nif" DataNavigateUrlFormatString="Eliminar.aspx?Nif={0}" ControlStyle-CssClass="glyphicon glyphicon-remove" />
            </Columns>
        </asp:GridView>
     <asp:ObjectDataSource ID="CadenasODS" runat="server" SelectMethod="ObtenerTodas" TypeName="BaseDeDatos.Servicios.MediosComunicacionServicio" SortParameterName="sortBy">
     </asp:ObjectDataSource>
</asp:Content>
