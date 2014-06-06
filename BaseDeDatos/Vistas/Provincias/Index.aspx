<%@ Page Title="Listado de Provincias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BaseDeDatos.Vistas.Provincias.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Index <small>Provincias</small></h2>
   
    <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="btnCrear_Click" /><br /><br /><br />
        <asp:GridView ID="gvProvincias" runat="server" CssClass="table  table-bordered table-striped"  AutoGenerateColumns="False" DataSourceID="ProvinciasODS" AllowSorting="true">
            <Columns>
                <asp:BoundField DataField="IdProvincia" HeaderText="Id" SortExpression="IdProvincia" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" SortExpression="Descripcion" />
                <asp:BoundField DataField="Ubicacion" HeaderText="Ubicación" SortExpression="Ubicacion" />
                  <asp:HyperLinkField DataNavigateUrlFields="IdProvincia" DataNavigateUrlFormatString="Editar.aspx?IdProvincia={0}" ControlStyle-CssClass="glyphicon glyphicon-edit" />
                   <asp:HyperLinkField DataNavigateUrlFields="IdProvincia" DataNavigateUrlFormatString="Eliminar.aspx?IdProvincia={0}" ControlStyle-CssClass="glyphicon glyphicon-remove" />
            </Columns>
        </asp:GridView>
   



    <asp:ObjectDataSource ID="ProvinciasODS" runat="server" SelectMethod="ObtenerTodas" TypeName="BaseDeDatos.Servicios.ProvinciaServicio" SortParameterName="sortBy"></asp:ObjectDataSource>
   



</asp:Content>
