<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BaseDeDatos.Vistas.ProgramaFranja.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Index <small>Programa Franja</small></h2>
   

     <asp:ObjectDataSource ID="CadenasODS" runat="server" SelectMethod="ObtenerTodas" TypeName="BaseDeDatos.Servicios.PFServicio" SortParameterName="sortBy">
     </asp:ObjectDataSource>


   
    <asp:Button ID="Button1" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="btnCrear_Click"/><br /><br /><br />
        <asp:GridView ID="gvEmisoras" runat="server" CssClass="table  table-bordered table-striped"  AutoGenerateColumns="False"  AllowSorting="True" DataSourceID="CadenasODS">
            <Columns>
                  <asp:BoundField DataField="IdCorrelativo" HeaderText="Id" SortExpression="IdCorrelativo" />

                  <asp:BoundField DataField="NombrePrograma" HeaderText="Programa" />
                  <asp:BoundField DataField="FranjaHorarioDescripcion" HeaderText="Franja Horario" />

                   <asp:HyperLinkField DataNavigateUrlFields="IdCorrelativo" DataNavigateUrlFormatString="Editar.aspx?IdCorrelativo={0}" ControlStyle-CssClass="glyphicon glyphicon-edit" />
                   <asp:HyperLinkField DataNavigateUrlFields="IdCorrelativo" DataNavigateUrlFormatString="Eliminar.aspx?IdCorrelativo={0}" ControlStyle-CssClass="glyphicon glyphicon-remove" />
            </Columns>
        </asp:GridView>

</asp:Content>
