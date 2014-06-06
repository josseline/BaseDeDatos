<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="BaseDeDatos.Vistas.CadenaRadio.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h2>Editar <small>Cadena de Radio</small></h2>
    <asp:ValidationSummary ID="vsEditarProvincias" runat="server" ForeColor="Red"/>
    <asp:HiddenField ID="hdfIdCadena" runat="server" />
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
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-default" CausesValidation="false" OnClick="btnRegresar_Click"/>
         <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click"  />
    </div>

</asp:Content>
