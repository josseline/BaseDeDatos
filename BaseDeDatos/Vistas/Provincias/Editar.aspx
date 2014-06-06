<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="BaseDeDatos.Vistas.Provincias.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h2>Editar <small>Provincias</small></h2>
    <asp:ValidationSummary ID="vsEditarProvincias" runat="server" ForeColor="Red"/>
    <asp:HiddenField ID="hdfIdProvincia" runat="server" />
    <table>
        <tr>
            <td style="height:50px; width:100px" >
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ErrorMessage="Debe ingresar una Descripcion" ForeColor="Red" ControlToValidate="txtDescripcion">*</asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td style="height:50px; width:100px" >
                <asp:Label ID="lblUbicacion" runat="server" Text="Ubicacion"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUbicacion" runat="server"  MaxLength="100" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
   <div class="form-actions">
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-default" CausesValidation="false" OnClick="btnRegresar_Click"/>
         <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click"  />
    </div>

</asp:Content>
