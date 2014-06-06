<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="BaseDeDatos.Vistas.BandaHertziana.Crear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h2>Crear <small>Banda Hertziana</small></h2>
    <asp:ValidationSummary ID="vsCrearBanda" runat="server" ForeColor="Red"/>
    <table>
        <tr>
            <td style="height:50px; width:100px" >
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="200" CssClass="form-control" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ErrorMessage="Debe ingresar una Descripcion" ForeColor="Red" ControlToValidate="txtDescripcion">*</asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td style="height:50px; width:100px">
                <asp:Label ID="lblDel" runat="server" Text="Del"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDel" runat="server"   CssClass="form-control" placeholder="En khertz..."></asp:TextBox>   
                  <asp:RegularExpressionValidator ID="revDel" runat="server" ErrorMessage="Del solo acepta numeros" ControlToValidate="txtDel" ForeColor="Red" ToolTip="Ingresar solo número" ValidationExpression="^\d+(\.\d\d)?$">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rfvDel" runat="server" ErrorMessage="Debe ingresar una cantidad de khertz Inicial" ForeColor="Red" ControlToValidate="txtDel">*</asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td style="height:50px; width:100px">
                <asp:Label ID="lblAl" runat="server" Text="Al"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAl" runat="server"   CssClass="form-control" placeholder="En khertz..."></asp:TextBox>  
                  <asp:RegularExpressionValidator ID="revAl" runat="server" ErrorMessage="Al solo acepta numeros" ControlToValidate="txtAl" ForeColor="Red" ToolTip="Ingresar solo número" ValidationExpression="^\d+(\.\d\d)?$">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rfv" runat="server" ErrorMessage="Debe ingresar una cantidad de khertz Final" ForeColor="Red" ControlToValidate="txtAl">*</asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <br />
    <div class="form-actions">
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-default" CausesValidation="false" OnClick="btnRegresar_Click"  />
         <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-success" OnClick="btnCrear_Click"  />
    </div>


</asp:Content>
