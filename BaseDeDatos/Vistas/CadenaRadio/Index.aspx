<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BaseDeDatos.Vistas.CadenaRadio.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h2>Index <small>Cadenas de Radio</small></h2>
   
    <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="btnCrear_Click"/><br /><br /><br />
        <asp:GridView ID="gvCadenas" runat="server" CssClass="table  table-bordered table-striped"  AutoGenerateColumns="False"  AllowSorting="True" DataSourceID="CadenasODS">
            <Columns>
             
                  <asp:BoundField DataField="IdCadena" HeaderText="Id" SortExpression="IdCadena" />
                  <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                   <asp:HyperLinkField DataNavigateUrlFields="IdCadena" DataNavigateUrlFormatString="Editar.aspx?IdCadena={0}" ControlStyle-CssClass="glyphicon glyphicon-edit" />
                   <asp:HyperLinkField DataNavigateUrlFields="IdCadena" DataNavigateUrlFormatString="Eliminar.aspx?IdCadena={0}" ControlStyle-CssClass="glyphicon glyphicon-remove" />
            </Columns>
        </asp:GridView>
     <asp:ObjectDataSource ID="CadenasODS" runat="server" SelectMethod="ObtenerTodas" TypeName="BaseDeDatos.Servicios.CadenaRadioServicio" SortParameterName="sortBy">
     </asp:ObjectDataSource>
</asp:Content>
