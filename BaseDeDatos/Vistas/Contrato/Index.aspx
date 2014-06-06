<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BaseDeDatos.Vistas.Contrato.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <h2>Index <small>Contratos</small></h2>
   
    <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="btnCrear_Click"/><br /><br /><br />
        <asp:GridView ID="gvCadenas" runat="server" CssClass="table  table-bordered table-striped"  AutoGenerateColumns="False"  AllowSorting="True" DataSourceID="CadenasODS">
            <Columns>
                  <asp:BoundField DataField="NoContrato" HeaderText="NoContrato" SortExpression="NoContrato" />
                  <asp:BoundField DataField="Duracion" HeaderText="Duracion(en segundos)" SortExpression="Duracion" />
                  <asp:BoundField DataField="Patrocinador" HeaderText="Patrocinador" SortExpression="Patrocinador" />
                   <asp:HyperLinkField DataNavigateUrlFields="NoContrato" DataNavigateUrlFormatString="Editar.aspx?NoContrato={0}" ControlStyle-CssClass="glyphicon glyphicon-edit" />
                   <asp:HyperLinkField DataNavigateUrlFields="NoContrato" DataNavigateUrlFormatString="Eliminar.aspx?NoContrato={0}" ControlStyle-CssClass="glyphicon glyphicon-remove" />
            </Columns>
        </asp:GridView>
     <asp:ObjectDataSource ID="CadenasODS" runat="server" SelectMethod="ObtenerTodas" TypeName="BaseDeDatos.Servicios.ContratoServicio" SortParameterName="sortBy">
     </asp:ObjectDataSource>
</asp:Content>
