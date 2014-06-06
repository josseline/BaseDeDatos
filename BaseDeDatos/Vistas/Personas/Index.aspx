<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BaseDeDatos.Vistas.Personas.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h2>Index <small>Personas</small></h2>
   
    <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="btnCrear_Click" /><br /><br /><br />
        <asp:GridView ID="gvPersonas" runat="server" CssClass="table  table-bordered table-striped"  AutoGenerateColumns="False" AllowSorting="True" DataSourceID="PersonasODS" >
            <Columns>
                <asp:BoundField DataField="NifPersona" HeaderText="NIF" SortExpression="NifPersona" />
                <asp:BoundField DataField="Nombres" HeaderText="Nombres" SortExpression="Nombres" />
                <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" SortExpression="Apellidos" />
                <asp:BoundField DataField="Direccion" HeaderText="Direccion"  />
                 <asp:HyperLinkField DataNavigateUrlFields="NifPersona" DataNavigateUrlFormatString="Editar.aspx?nif={0}" ControlStyle-CssClass="glyphicon glyphicon-edit" />
                   <asp:HyperLinkField DataNavigateUrlFields="NifPersona" DataNavigateUrlFormatString="Eliminar.aspx?nif={0}" ControlStyle-CssClass="glyphicon glyphicon-remove" />
            </Columns>
            
          
        </asp:GridView>
      <asp:ObjectDataSource ID="PersonasODS" runat="server" SelectMethod="ObtenerTodas" TypeName="BaseDeDatos.Servicios.PersonasServicio" SortParameterName="sortBy">
         
      </asp:ObjectDataSource>
</asp:Content>
