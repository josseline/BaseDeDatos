<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="BaseDeDatos.Vistas.Personas.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h2>Editar <small>Persona</small></h2>
    <asp:ValidationSummary ID="vsEditarPersona" runat="server" ForeColor="Red"/>
    
     <table>
        <tr>
            <td style="height:50px; width:100px" >
                <asp:Label ID="lblNif" runat="server" Text="NIF"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNif" runat="server" MaxLength="50" CssClass="form-control" Enabled="true"></asp:TextBox>
                

            </td>
        </tr>
        <tr>
            <td style="height:50px; width:100px">
                <asp:Label ID="lblNombre" runat="server" Text="Nombres"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server"  MaxLength="200" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Debe ingresar un Nombre para el patrocinador" ForeColor="Red" ControlToValidate="txtNombre">*</asp:RequiredFieldValidator>
            </td>
        </tr>
          <tr>
            <td style="height:50px; width:100px">
                <asp:Label ID="lblApellidos" runat="server" Text="Apellidos"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtApellidos" runat="server"  MaxLength="200" CssClass="form-control"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td style="height:50px; width:100px">
                <asp:Label ID="lblDireccion" runat="server" Text="Direccion"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDireccion" runat="server"  MaxLength="100" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
   <div class="form-actions">
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-default" CausesValidation="false" OnClick="btnRegresar_Click"/>
         <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click"  />
    </div>

</asp:Content>
