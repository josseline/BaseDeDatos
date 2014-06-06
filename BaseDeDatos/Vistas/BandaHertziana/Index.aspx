<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BaseDeDatos.Vistas.BandaHertziana.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <h2>Index <small>Bandas Hertzianas </small></h2>
   
    <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="btnCrear_Click" /><br /><br /><br />
        <asp:GridView ID="gvBandaHertziana" runat="server" CssClass="table  table-bordered table-striped"  AutoGenerateColumns="False" AllowSorting="True" DataSourceID="BandaODS">
            <Columns>
                <asp:BoundField DataField="IdBandaHertziana" HeaderText="Id" SortExpression="IdBandaHertziana" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                <asp:BoundField DataField="Del" HeaderText="Del"  />
                  <asp:BoundField DataField="Al" HeaderText="Al" />
                 <asp:HyperLinkField DataNavigateUrlFields="IdBandaHertziana" DataNavigateUrlFormatString="Editar.aspx?IdBanda={0}" ControlStyle-CssClass="glyphicon glyphicon-edit" />
                   <asp:HyperLinkField DataNavigateUrlFields="IdBandaHertziana" DataNavigateUrlFormatString="Eliminar.aspx?IdBanda={0}" ControlStyle-CssClass="glyphicon glyphicon-remove" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="BandaODS" runat="server" SelectMethod="ObtenerTodas" TypeName="BaseDeDatos.Servicios.BandaHertzianaServicio" SortParameterName="sortBy">
            
        </asp:ObjectDataSource>
</asp:Content>
