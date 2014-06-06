<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="BaseDeDatos.Vistas.Patrocinador.Crear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h2>Crear <small>Patrocinador</small></h2>
    <asp:ValidationSummary ID="vsCrearPatrocinador" runat="server" ForeColor="Red"/>
    <table>
        <tr>
            <td style="height:50px; width:100px" >
                <asp:Label ID="lblNif" runat="server" Text="Nif"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNif" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNif" runat="server" ErrorMessage="Debe ingresar un NIF para el patrocinador" ForeColor="Red" ControlToValidate="txtNif">*</asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td style="height:50px; width:100px">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server"  MaxLength="100" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Debe ingresar un Nombre para el patrocinador" ForeColor="Red" ControlToValidate="txtNombre">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="height:50px; width:100px">
                <asp:Label ID="lblDireccion" runat="server" Text="Direccion"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDireccion" runat="server"  MaxLength="50" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <div class="form-actions">
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-default" CausesValidation="false" OnClick="btnRegresar_Click" />
         <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="btnCrear_Click" />
    </div>

</asp:Content>
