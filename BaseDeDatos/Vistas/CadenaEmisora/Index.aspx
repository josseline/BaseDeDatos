<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BaseDeDatos.Vistas.CadenaEmisora.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <h2>Index <small>Cadena Emisora</small></h2>
   
    <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="btnCrear_Click"/><br /><br /><br />
        <asp:GridView ID="gvCadenasEmisora" runat="server" CssClass="table  table-bordered table-striped"  AutoGenerateColumns="False"  AllowSorting="True" DataSourceID="CadenaEmisoraODS" >
            <Columns>
                <asp:BoundField DataField="IdCadena" Visible="false" />
                <asp:BoundField DataField="NifEmisora" Visible="false" />
                  
                  <asp:BoundField DataField="Cadena" HeaderText="Cadena" SortExpression="Cadena" />
                  <asp:BoundField DataField="Emisora" HeaderText="Emisora" SortExpression="Emisora" />
                  <asp:BoundField DataField="Director" HeaderText="Director"  />
                  <asp:BoundField DataField="EsCentral" HeaderText="¿Es Central?" />
                   <asp:HyperLinkField DataNavigateUrlFields="IdCadena, NifEmisora " DataNavigateUrlFormatString="Editar.aspx?IdCadena={0}&NifEmisora={1}" ControlStyle-CssClass="glyphicon glyphicon-edit" />
                   <asp:HyperLinkField DataNavigateUrlFields="IdCadena, NifEmisora " DataNavigateUrlFormatString="Eliminar.aspx?IdCadena={0}&NifEmisora={1}" ControlStyle-CssClass="glyphicon glyphicon-remove" />
            </Columns>
        </asp:GridView>
     
       <asp:ObjectDataSource ID="CadenaEmisoraODS" runat="server" SelectMethod="ObtenerTodas" TypeName="BaseDeDatos.Servicios.CadenaEmisoraServicio" SortParameterName="sortBy">
       </asp:ObjectDataSource>
     
</asp:Content>
