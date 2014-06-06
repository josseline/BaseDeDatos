<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="BaseDeDatos.Vistas.CadenaRadio.Crear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Crear <small>Cadena de Radio</small></h2>
    <asp:ValidationSummary ID="vsCrearCadena" runat="server" ForeColor="Red"/>
    <table>
        <tr>
            <td style="height:50px; width:100px" >
                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Debe ingresar un Nombre" ForeColor="Red" ControlToValidate="txtNombre">*</asp:RequiredFieldValidator>

            </td>
        </tr>
    </table>
    <br />
    <div class="form-actions">
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-default" CausesValidation="false" OnClick="btnRegresar_Click"  />
         <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="btnCrear_Click" />
    </div>

</asp:Content>
