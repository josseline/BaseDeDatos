<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BaseDeDatos.Vistas.Programa.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Index <small>Programas</small></h2>
   
    <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="btnCrear_Click" /><br /><br /><br />
        <asp:GridView ID="gvProgramas" runat="server" CssClass="table  table-bordered table-striped"  AutoGenerateColumns="False" AllowSorting="True" DataSourceID="ProgramasODS">
            <Columns>
                <asp:BoundField DataField="IdPrograma" HeaderText="Id" SortExpression="IdPrograma" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="NIFPERSONA" HeaderText="Nif Representante" SortExpression="NIFPERSONA" />
                <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre Representante" SortExpression="NombreCompleto" />
                  <asp:HyperLinkField DataNavigateUrlFields="IdPrograma" DataNavigateUrlFormatString="Editar.aspx?Id={0}" ControlStyle-CssClass="glyphicon glyphicon-edit" />
                   <asp:HyperLinkField DataNavigateUrlFields="IdPrograma" DataNavigateUrlFormatString="Eliminar.aspx?Id={0}" ControlStyle-CssClass="glyphicon glyphicon-remove" />
            </Columns>
           
        </asp:GridView>
    <asp:ObjectDataSource ID="ProgramasODS" runat="server" SelectMethod="ObtenerTodas" TypeName="BaseDeDatos.Servicios.ProgramasServicio" SortParameterName="sortBy">
        
    </asp:ObjectDataSource>
</asp:Content>
