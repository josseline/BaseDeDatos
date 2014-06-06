<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BaseDeDatos.Vistas.Anuncio.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h2>Index <small>Anuncios</small></h2>
   
    <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="btnCrear_Click"/><br /><br /><br />
        <asp:GridView ID="gvCadenas" runat="server" CssClass="table  table-bordered table-striped"  AutoGenerateColumns="False"  AllowSorting="True" DataSourceID="CadenasODS">
            <Columns>
                  <asp:BoundField DataField="IdAnuncio" HeaderText="Id" SortExpression="IdAnuncio" />
                  <asp:BoundField DataField="NombrePrograma" HeaderText="Programa" SortExpression="NombrePrograma" />
                  <asp:BoundField DataField="NombrePatrocinador" HeaderText="Patrocinador" SortExpression="NombrePatrocinador" />
                   <asp:HyperLinkField DataNavigateUrlFields="IdAnuncio" DataNavigateUrlFormatString="Editar.aspx?IdAnuncio={0}" ControlStyle-CssClass="glyphicon glyphicon-edit" />
                   <asp:HyperLinkField DataNavigateUrlFields="IdAnuncio" DataNavigateUrlFormatString="Eliminar.aspx?IdAnuncio={0}" ControlStyle-CssClass="glyphicon glyphicon-remove" />
            </Columns>
        </asp:GridView>
     <asp:ObjectDataSource ID="CadenasODS" runat="server" SelectMethod="ObtenerTodas" TypeName="BaseDeDatos.Servicios.AnuncioServicio" SortParameterName="sortBy">
     </asp:ObjectDataSource>
</asp:Content>
