<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BaseDeDatos.Vistas.Patrocinador.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h2>Index <small>Patrocinadores</small></h2>
   
    <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="btnCrear_Click" /><br /><br /><br />
        <asp:GridView ID="gvPatrocinadores" runat="server" CssClass="table  table-bordered table-striped"  AutoGenerateColumns="False" AllowSorting="True" DataSourceID="PatrocinadoresODS">
            <Columns>
                <asp:BoundField DataField="NifPatrocinador" HeaderText="NIF" SortExpression="NifPatrocinador" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
                <asp:HyperLinkField DataNavigateUrlFields="NifPatrocinador" DataNavigateUrlFormatString="Editar.aspx?nif={0}" ControlStyle-CssClass="glyphicon glyphicon-edit" />
                   <asp:HyperLinkField DataNavigateUrlFields="NifPatrocinador" DataNavigateUrlFormatString="Eliminar.aspx?nif={0}" ControlStyle-CssClass="glyphicon glyphicon-remove" />
            </Columns>
          
        </asp:GridView>
     <asp:ObjectDataSource ID="PatrocinadoresODS" runat="server" SelectMethod="ObtenerTodas" TypeName="BaseDeDatos.Servicios.PatrocinadoresServicio" SortParameterName="sortBy">
      
     </asp:ObjectDataSource>
</asp:Content>
