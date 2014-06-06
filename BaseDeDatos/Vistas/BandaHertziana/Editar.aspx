<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="BaseDeDatos.Vistas.BandaHertziana.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <h2>Editar <small>Banda Hertziana</small></h2>
    <asp:ValidationSummary ID="vsEditarBanda" runat="server" ForeColor="Red"/>
    <asp:HiddenField ID="hdfIdBanda" runat="server" />
    <table>
        <tr>
            <td style="height:50px; width:100px" >
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="200" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ErrorMessage="Debe ingresar una Descripcion" ForeColor="Red" ControlToValidate="txtDescripcion">*</asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td style="height:50px; width:100px">
                <asp:Label ID="lblDel" runat="server" Text="Del"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDel" runat="server"   CssClass="form-control"></asp:TextBox>   
                  <asp:RegularExpressionValidator ID="rfvDel" runat="server" ErrorMessage="Del solo acepta numeros con 2 decimales" ControlToValidate="txtDel" ForeColor="Red" ToolTip="Ingresar solo número" ValidationExpression="^\d+(\.\d\d)?$">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe ingresar una cantidad de khertz Inicial" ForeColor="Red" ControlToValidate="txtDel">*</asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td style="height:50px; width:100px">
                <asp:Label ID="lblAl" runat="server" Text="Al"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAl" runat="server"   CssClass="form-control"></asp:TextBox>  
                  <asp:RegularExpressionValidator ID="rfvAl" runat="server" ErrorMessage="Al solo acepta numeros con 2 decimales" ControlToValidate="txtAl" ForeColor="Red" ToolTip="Ingresar solo número" ValidationExpression="^\d+(\.\d\d)?$">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rfv" runat="server" ErrorMessage="Debe ingresar una cantidad de khertz Final" ForeColor="Red" ControlToValidate="txtAl">*</asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <br />
    <div class="form-actions">
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-default" CausesValidation="false" OnClick="btnRegresar_Click"  />
         <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click"   />
    </div>


</asp:Content>
