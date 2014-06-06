<%@ Page Title="Crear Provincia" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="BaseDeDatos.Vistas.Provincias.Crear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Crear <small>Provincias</small></h2>
    <asp:ValidationSummary ID="vsCrearProvincias" runat="server" ForeColor="Red"/>
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
            <td style="height:50px; width:100px">
                <asp:Label ID="lblUbicacion" runat="server" Text="Ubicacion"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUbicacion" runat="server"  MaxLength="100" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <div class="form-actions">
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-default" CausesValidation="false" OnClick="btnRegresar_Click" />
         <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="btnCrear_Click" />
    </div>

</asp:Content>
