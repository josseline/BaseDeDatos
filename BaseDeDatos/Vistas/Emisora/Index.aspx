<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BaseDeDatos.Vistas.Emisora.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <h2>Index <small>Emisoras</small></h2>
   
    <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="btnCrear_Click"/><br /><br /><br />
        <asp:GridView ID="gvEmisoras" runat="server" CssClass="table  table-bordered table-striped"  AutoGenerateColumns="False"  AllowSorting="True" DataSourceID="CadenasODS">
            <Columns>
                  <asp:BoundField DataField="NIF" HeaderText="NIF" SortExpression="NIF" />
                  <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                  <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
                  <asp:BoundField DataField="Descripcion" HeaderText="Provincia"/>
                   <asp:HyperLinkField DataNavigateUrlFields="NIF" DataNavigateUrlFormatString="Editar.aspx?NIF={0}" ControlStyle-CssClass="glyphicon glyphicon-edit" />
                   <asp:HyperLinkField DataNavigateUrlFields="NIF" DataNavigateUrlFormatString="Eliminar.aspx?NIF={0}" ControlStyle-CssClass="glyphicon glyphicon-remove" />
            </Columns>
        </asp:GridView>
     <asp:ObjectDataSource ID="CadenasODS" runat="server" SelectMethod="ObtenerTodas" TypeName="BaseDeDatos.Servicios.EmisoraServicio" SortParameterName="sortBy">
     </asp:ObjectDataSource>
</asp:Content>
